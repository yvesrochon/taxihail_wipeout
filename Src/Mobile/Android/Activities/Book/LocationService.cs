using System;
using System.Threading;
using Android.App;
using Android.Content;
using TinyIoC;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Common.Diagnostic;
using Android.Locations;

namespace apcurium.MK.Booking.Mobile.Client.Activities.Book
{
    public class LocationService
    {
        private bool _isStarted = false;
        private LocationManager _locMgr;

        private LocationListener _gpsListener;
        private LocationListener _networkListener;

        private Android.Locations.Location _lastLocation;

        public LocationService()
        {
            _gpsListener = new LocationListener(this);
            _networkListener = new LocationListener(this);
        }


        public void Start()
        {
            if (_isStarted)
            {
                return;
            }
            _isStarted = true;
            _locMgr = Application.Context.GetSystemService(Context.LocationService) as LocationManager;

            if (LastLocation != null)
            {
                var lastDateTime = FromUnixTime(LastLocation.Time).ToLocalTime();
                Console.WriteLine(lastDateTime.ToShortTimeString());
                Console.WriteLine(lastDateTime.ToLongDateString());
                var timeDelta = DateTime.Now.Subtract(lastDateTime).TotalSeconds;

                if (timeDelta > 120)
                {
                    _lastLocation = null;
                }
            }

            _locMgr.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, _gpsListener);
            //_locMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, _networkListener);




        }
        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTime);
        }

        public long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var r = Convert.ToInt64((date - epoch).TotalMilliseconds);
            return r;
        }

        public Android.Locations.Location WaitForAccurateLocation(int timeout, float accuracy, out bool timeoutExpired)
        {
            var autoReset = new AutoResetEvent(false);
            var result = LastLocation;

            TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("Start WaitForAccurateLocation");

            _locMgr.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, _gpsListener);
            //_locMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, _networkListener);


            timeoutExpired = true;

            bool exit = false;
            var timeoutExpiredResult = true;
            var t = new Thread(() =>
                {

                    Thread.Sleep(2000);
                    while (!exit)
                    {
                        if (LastLocation != null)
                        {
                            TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("Current location : " + LastLocation.Provider + " pos Lat : " + LastLocation.Latitude.ToString() + "Pos Long : " + LastLocation.Longitude.ToString() + " + Accuracy : " + LastLocation.Accuracy.ToString());
                            result = LastLocation;
                            if (result.Accuracy <= accuracy)
                            {
                                TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("Good location found! : " + result.Provider.ToString());
                                timeoutExpiredResult = false;
                                autoReset.Set();
                            }
                        }


                        Thread.Sleep(200);
                    }

                });

            t.Start();
            autoReset.WaitOne(timeout);
            timeoutExpired = timeoutExpiredResult;

            if (timeoutExpired)
            {
                TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("Location search timed out");
            }

            TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("Done WaitForAccurateLocation");

            if (result == null)
            {
                UpdateWithLastLocation();
                result = LastLocation;
            }
            exit = true;
            if (t.IsAlive)
            {
                t.Abort();
            }

            return result;
        }

        private void UpdateWithLastLocation()
        {
            var locationGps = _locMgr.GetLastKnownLocation(LocationManager.GpsProvider);
            var locationNetwork = _locMgr.GetLastKnownLocation(LocationManager.NetworkProvider);


            if ((locationGps != null) || (locationNetwork != null))
            {
                if (locationGps == null)
                {
                    LastLocation = locationNetwork;
                }
                else if (locationNetwork == null)
                {
                    LastLocation = locationGps;
                }
                else if (IsBetterLocation(locationNetwork, locationGps))
                {
                    LastLocation = locationNetwork;
                }
                else
                {
                    LastLocation = locationGps;
                }

            }
            else
            {
                LastLocation = new Android.Locations.Location(LocationManager.PassiveProvider);

                var location = TinyIoCContainer.Current.Resolve<ICacheService>().Get<Android.Locations.Location>("LastKnowLocation");

                if ((location != null) && (location.Latitude != 0) && (location.Longitude != 0))
                {
                    LastLocation = location;
                    //                    LastLocation.Longitude = address.Longitude;
                    //                    LastLocation.Accuracy = float.MaxValue;
                }
                else
                {
                    LastLocation.Latitude = 45.34185;
                    LastLocation.Longitude = -75.92196;
                    LastLocation.Accuracy = float.MaxValue;
                }
            }
        }


        public Android.Locations.Location LastLocation
        {
            get { return _lastLocation; }
            set { _lastLocation = value; }
        }

        public void Stop()
        {
            _isStarted = false;
            _locMgr.RemoveUpdates(_networkListener);
            _locMgr.RemoveUpdates(_gpsListener);
        }


        public void LocationChanged(Android.Locations.Location location)
        {
            //TinyIoCContainer.Current.Resolve<ILogger>().LogMessage("Location changed : " + GetLocationText(location));

            //TinyIoCContainer.Current.Resolve<ICacheService>().Set("LastKnowLocation", new apcurium.MK.Common.Entity.Address { Longitude = location.Longitude, Latitude = location.Latitude });
            // this line make application frozen
            //TinyIoCContainer.Current.Resolve<ICacheService>().Set("LastKnowLocation", location );
            if (IsBetterLocation(location, LastLocation))
            {
                LastLocation = location;
            }
        }

        private string GetLocationText(Android.Locations.Location location)
        {
            return "Lat : " + location.Latitude.ToString() + " Long: " + location.Longitude.ToString() + " Acc : " +
                   location.Accuracy.ToString() + " Provider : " + location.Provider.ToString();
        }

        private static int TWO_MINUTES = 1000 * 60 * 2;

        protected bool IsBetterLocation(Android.Locations.Location location, Android.Locations.Location currentBestLocation)
        {
            if (currentBestLocation == null)
            {
                // A new location is always better than no location
                return true;
            }

            // Check whether the new location fix is newer or older
            long timeDelta = location.Time - currentBestLocation.Time;
            bool isSignificantlyNewer = timeDelta > TWO_MINUTES;
            bool isSignificantlyOlder = timeDelta < -TWO_MINUTES;
            bool isNewer = timeDelta > 0;

            // If it's been more than two minutes since the current location, use the new location
            // because the user has likely moved
            if (isSignificantlyNewer)
            {
                return true;
            }
            else if (isSignificantlyOlder) // If the new location is more than two minutes older, it must be worse
            {
                return false;
            }

            // Check whether the new location fix is more or less accurate
            int accuracyDelta = (int)(location.Accuracy - currentBestLocation.Accuracy);
            bool isLessAccurate = accuracyDelta > 0;
            bool isMoreAccurate = accuracyDelta < 0;
            bool isSignificantlyLessAccurate = accuracyDelta > 200;

            // Check if the old and new location are from the same provider
            bool isFromSameProvider = IsSameProvider(location.Provider, currentBestLocation.Provider);

            // Determine location quality using a combination of timeliness and accuracy
            if (isMoreAccurate)
            {
                return true;
            }
            else if (isNewer && !isLessAccurate)
            {
                return true;
            }
            else if (isNewer && !isSignificantlyLessAccurate && isFromSameProvider)
            {
                return true;
            }

            return false;
        }

        /** Checks whether two providers are the same */
        private bool IsSameProvider(string provider1, string provider2)
        {
            if (provider1 == null)
            {
                return provider2 == null;
            }
            return provider1.Equals(provider2);
        }


    }
}
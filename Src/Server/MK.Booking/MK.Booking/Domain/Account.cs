﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.EventSourcing;
using apcurium.MK.Booking.Events;
using apcurium.MK.Common;
using apcurium.MK.Common.Extensions;
namespace apcurium.MK.Booking.Domain
{
    public class Account : EventSourced
    {
        private readonly IList<Guid> _favoriteAddresses = new List<Guid>(); 
        protected Account(Guid id) : base(id)
        {
            base.Handles<AccountRegistered>(OnAccountRegistered);
            base.Handles<AccountUpdated>(OnAccountUpdated);
            base.Handles<AddressAdded>(OnAddressAdded);
            base.Handles<AddressRemoved>(OnAddressRemoved);
            base.Handles<AddressUpdated>(OnAddressUpdated);
            base.Handles<AccountPasswordResetted>(OnAccountPasswordResetted);
            base.Handles<BookingSettingsUpdated>(OnBookingSettingsUpdated);
        }

        public Account(Guid id, IEnumerable<IVersionedEvent> history)
            : this(id)
        {               
            this.LoadFrom(history);
        }

        public Account(Guid id, string name,string phone, string email, byte[] password, int ibsAccountId)
            : this(id)
        {
            if (Params.Get(name,phone,email).Any(p => p.IsNullOrEmpty())
                || ibsAccountId == 0 || (password == null) )
            {
                throw new InvalidOperationException("Missing required fields");
            }
            this.Update(new AccountRegistered
            {
                SourceId = id,
                Name = name,
                Email = email,
                Phone = phone,
                Password = password,
                IbsAcccountId = ibsAccountId,

            });
        }

        public Account(Guid id, string name, string phone, string email, int ibsAccountId, string facebookId = "", string twitterId = "")
            : this(id)
        {
            if (Params.Get(name, phone, email).Any(p => p.IsNullOrEmpty())
                || ibsAccountId == 0 )
            {
                throw new InvalidOperationException("Missing required fields");
            }
            this.Update(new AccountRegistered
            {
                SourceId = id,
                Name = name,
                Email = email,
                Phone = phone,
                IbsAcccountId = ibsAccountId,
                TwitterId = twitterId,
                FacebookId = facebookId
            });
        }        
        
        internal void Update( string name )
        {
            if (Params.Get(name).Any(p => p.IsNullOrEmpty()))
            {
                throw new InvalidOperationException("Missing required fields");
            }

            this.Update(new AccountUpdated
            {                 
                SourceId= Id,
                Name = name,                
            });        
        }

        internal void UpdatePassword(byte[] newPassword)
        {
            if (Params.Get(newPassword).Any(p => false))
            {
                throw new InvalidOperationException("Missing required fields");
            }

            this.Update(new AccountPasswordResetted()
            {
                SourceId = Id,
                Password = newPassword
            });
        }

        public void UpdateBookingSettings(BookingSettings settings)
        {
            this.Update(new BookingSettingsUpdated
            {
                SourceId = Id,
                Name = settings.Name,                
                ChargeTypeId = settings.ChargeTypeId,
                NumberOfTaxi = settings.NumberOfTaxi,
                Passengers = settings.Passengers,
                Phone = settings.Phone,
                ProviderId = settings.ProviderId,
                VehicleTypeId = settings.VehicleTypeId
            });  
        }

        public void AddAddress(Guid id, string friendlyName, string apartment, string fullAddress, string ringCode, double latitude, double longitude, bool isHistoric)
        {
            ValidateFavoriteAddress(friendlyName, fullAddress, latitude, longitude);

            this.Update(new AddressAdded
            {
                AddressId = id,
                FriendlyName = friendlyName,
                Apartment = apartment,
                FullAddress = fullAddress,
                RingCode = ringCode,
                Latitude = latitude,
                Longitude = longitude,
                IsHistoric = isHistoric
            });
        }

        public void UpdateAddress(Guid id, string friendlyName, string apartment, string fullAddress, string ringCode, double latitude, double longitude, bool isHistoric)
        {
            ValidateFavoriteAddress(friendlyName, fullAddress, latitude, longitude);

            this.Update(new AddressUpdated()
            {
                AddressId = id,
                FriendlyName = friendlyName,
                Apartment = apartment,
                FullAddress = fullAddress,
                RingCode = ringCode,
                Latitude = latitude,
                Longitude = longitude,
                IsHistoric = isHistoric
            });
        }

        public void RemoveFavoriteAddress(Guid addressId)
        {
            if(!_favoriteAddresses.Contains(addressId))
            {
                throw new InvalidOperationException("Address does not exist in account");
            }

            this.Update(new AddressRemoved
            {
                AddressId = addressId
            });
        }

        private void OnAccountRegistered(AccountRegistered @event)
        {

        }

        private void OnAccountUpdated(AccountUpdated @event)
        {

        }

        private void OnAddressAdded(AddressAdded @event)
        {
            _favoriteAddresses.Add(@event.AddressId);
        }

        private void OnAddressRemoved(AddressRemoved @event)
        {
            _favoriteAddresses.Remove(@event.AddressId);
        }

        private void OnAddressUpdated(AddressUpdated obj)
        {

        }

        private void OnAccountPasswordResetted(AccountPasswordResetted obj)
        {

        }
        
        private void OnBookingSettingsUpdated(BookingSettingsUpdated obj)
        {
        }


        private static void ValidateFavoriteAddress(string friendlyName, string fullAddress, double latitude, double longitude)
        {
            if (Params.Get(friendlyName, fullAddress).Any(p => p.IsNullOrEmpty()))
            {
                throw new InvalidOperationException("Missing required fields");
            }

            if (latitude < -90 || latitude > 90)
            {
                throw new ArgumentOutOfRangeException("latitude", "Invalid latitude");
            }

            if (longitude < -180 || latitude > 180)
            {
                throw new ArgumentOutOfRangeException("longitude", "Invalid longitude");
            }
        }

        
    }
}

// Geocoding service

(function () {

    TaxiHail.geocoder = {
        
        initialize: function (lat, lng) {
            this.latitude = lat;
            this.longitude = lng;
        },

        geocode: function (lat, lng) {

            return $.get(TaxiHail.parameters.apiRoot + '/geocode', { lat: lat, lng: lng }, function () { }, 'json')
                    .done(cleanupResult);
            
        },

        search: function(address) {

            var defaultLatitude = this.latitude,
                defaultLongitude = this.longitude;

            return TaxiHail.geolocation.getCurrentPosition()
                .pipe(function(coords) {
                    return $.get(TaxiHail.parameters.apiRoot + '/searchlocation',  {
                        name: address,
                        lat: coords.latitude || defaultlatitude,
                        lng: coords.longitude || defaultlongitude
                    }, function () { }, 'json').done(cleanupResult);
                });
        }
    };

    function cleanupResult(result) {
        if(result && result.length) {
            _.each(result, function(address){
                // BUGFIX: All addresses have the same empty Guid as id
                delete address.id;
            });
        }
    }
}());
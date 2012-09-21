﻿(function () {

    TaxiHail.BookView = TaxiHail.TemplatedView.extend({
        events: {
            'click [data-action=book]': 'book'
        },
        
        initialize: function () {
            _.bindAll(this, "renderEstimateResults");
            //this.model.on('change', this.render, this);

            this.model.on('change:pickupAddress', function(model, value) {
                this.actualizeEstimate();
            }, this);

            this.model.on('change:dropOffAddress', function(model, value) {
                this.actualizeEstimate();
            }, this);
            
        },

        render: function () {
            this.$el.html(this.renderTemplate(this.model.toJSON()));

            this.renderAddressControl('.pickup-address-container', new Backbone.Model())
                .on('selected', function(){
                    this.model.set({
                        pickupAddress: model.toJSON()
                    });
                }, this);
            this.renderAddressControl('.drop-off-address-container', new Backbone.Model())
                .on('selected', function(){
                    this.model.set({
                        dropOffAddress: model.toJSON()
                    });
                }, this);

            return this;
        },
        
        actualizeEstimate: function () {
            if (this.model.get('pickupAddress') && this.model.get('dropOffAddress')) {
                var pickup = this.model.get('pickupAddress');
                var dest = this.model.get('dropOffAddress');
                TaxiHail.directionInfo.getInfo(pickup['latitude'], pickup['longitude'], dest['latitude'], dest['longitude']).done(this.renderEstimateResults);
            }
           
        },
        
        renderEstimateResults: function (result) {

            this.model.set({
                'priceEstimate': result.formattedPrice,
                'distanceEstimate': result.formattedDistance
            });
            //TODO :
            //this.render();
        },

        renderAddressControl: function(selector, model) {

            var addressControlView = new TaxiHail.AddressControlView({
                model: model
            });

            this.$(selector).html(addressControlView.render().el);

            return addressControlView;
        },
        
        book: function (e) {
            e.preventDefault();
            TaxiHail.store.setItem("orderToBook", this.model.toJSON());
            TaxiHail.app.navigate('confirmationbook',{trigger:true});
        }
    });

}());
﻿(function () {
    var settings;
    var settingschanged = false;
    
    TaxiHail.BookingConfirmationView = TaxiHail.TemplatedView.extend({
        
        events: {
            'click [data-action=book]': 'book',
            'change :text': 'onPropertyChanged',
            
        },
        initialize: function () {   

            _.bindAll(this, "renderResults");
            
            var pickup = this.model.get('pickupAddress');
            var dest = this.model.get('dropOffAddress');
            if (pickup && dest) {
                TaxiHail.directionInfo.getInfo(pickup['latitude'], pickup['longitude'], dest['latitude'], dest['longitude']).done(this.renderResults);
            }
        },

        render: function (param) {

            this.$el.html(this.renderTemplate(this.model.toJSON()));
            this.renderItem(this.model);
            return this;
        },
        
        renderResults: function (result) {
            
            this.model.set({
                'priceEstimate': result.formattedPrice,
                'distanceEstimate': result.formattedDistance
            });
            this.render();
        },
        
        book: function (e) {
            this.$('#bookBt').button('loading');
            e.preventDefault();
            this.model.set('settings', settings);
            this.model.save({},{success : function (model) {
                TaxiHail.app.navigate('status/' + model.id, { trigger: true });
                },
                error: this.showErrors
            });
            
        },
        
        showErrors: function (model, result) {
            this.$('#bookBt').button('reset');
            
            if (result.responseText) {
                result = JSON.parse(result.responseText).responseStatus;
            }
            var $alert = $('<div class="alert alert-error" />');
            if (result.statusText) {
                $alert.append($('<div />').text(this.localize(result.statusText)));
            }
            _.each(result.errors, function (error) {
                $alert.append($('<div />').text(this.localize(error.errorCode)));
            }, this);
            this.$('.errors').html($alert);
        },
        
        renderItem: function (model) {

            var settingsView = new TaxiHail.SettingsEditView({
                model: settings = new TaxiHail.Settings(model.get('settings')) 
            });

            this.$('div#settingsContent').prepend(settingsView.render().el);
        },
        
        onPropertyChanged: function (e) {
            var $input = $(e.currentTarget);
            var pickup = this.model.get('pickupAddress');
            
            pickup[$input.attr("name")] = $input.val();
            settingschanged = true;
        },
        
    });

}());



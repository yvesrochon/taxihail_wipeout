﻿(function () {
    var currentView,
        renderView = function(view, model) {
            // Call remove on current view
            // in case it was overriden with custom logic
            if(currentView && _.isFunction(currentView.remove)) {
                currentView.remove();
            }

            if(_.isFunction(view)) {
                currentView = new view({
                    model: model
                }).render();
            } else {
                currentView = view;
                view.model = model || view.model;
                view.render();
            }

            $('#main').html(currentView.el);

            return currentView;

        },
        mapView;

    TaxiHail.App = Backbone.Router.extend({
        routes: {
            "": "grantadminaccess",   // #
            "managefavoritesdefault": "managefavoritesdefault"
        },

        initialize: function (options) {
            $('.menuadmin').html(new TaxiHail.AdminMenuView().render().el);
            /*TaxiHail.auth.account.fetch()
            {
                success: _.bind(function() {
                    $('.login-status-zone').html(new TaxiHail.LoginStatusView({
                        model: TaxiHail.auth.account
                    }).render().el);
                });
            };*/
            
        },

        admin: function() {


        },
        
        managefavoritesdefault : function () {
            renderView(TaxiHail.ManageDefaultAddressesView);
        },
        
        grantadminaccess : function () {
            renderView(TaxiHail.GrantAdminAccessView);
        }
    });

}());
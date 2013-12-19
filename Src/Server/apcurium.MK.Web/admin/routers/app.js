﻿(function () {
    var action = TaxiHail.Controller.action;

    TaxiHail.App = Backbone.Router.extend({
        routes: {
            /* Favorite addresses*/
            "": "manageDefaultAddresses",   // #
            'addresses/default/add': 'addDefaultAddress',
            'addresses/default/edit/:id': 'editDefaultAddress',

            /* popular addresses*/
            "addresses/popular": "managePopularAddresses",
            "addresses/popular/add": "addPopularAddress",
            "addresses/popular/edit/:id": "editPopularAddress",

            /* Admin right*/
            "security": "manageSecurity",
            "confirmemail": "confirmEmail",
            "disableemail": "disableEmail",
            "sendpushnotification": "sendPushNotification",
            
            /* settings */
            "settings" : "manageCompanySettings",

            /* paymentSettings */
            "paymentSettings": "managePaymentSettings",
            
            /* Tariffs */
            "tariffs": "manageTariffs", //#tariffs
            "tariffs/add/recurring": "addRecurringTariff", //#tariffs/add/recurring
            "tariffs/add/day": "addDayTariff", //#tariffs/add/day
            "tariffs/edit/:id": "editTariff", //#tariffs/edit/{GUID}

            /* Rules */
            "rules": "manageRules", //#rules
            "rules/add/disable/default": "addDefaultDisableRule", //#rules/add/recurring
            "rules/add/disable/recurring": "addRecurringDisableRule", //#rules/add/recurring
            "rules/add/disable/day": "addDayDisableRule", //#rules/add/day
            "rules/add/warning/default": "addDefaultWarningRule", //#rules/add/recurring
            "rules/add/warning/recurring": "addRecurringWarningRule", //#rules/add/recurring
            "rules/add/warning/day": "addDayWarningRule", //#rules/add/day
            "rules/edit/:id": "editRule", //#rules/edit/{GUID}

            /* IBS exclusions */
            "exclusions": "manageIBSExclusions",

            /*Export*/
            "exportaccounts": "exportaccounts",
            "exportorders": "exportorders"
        },

        initialize: function (options) {
            $('.menu-zone').html(new TaxiHail.AdminMenuView().render().el);
            
            //default lat and long are defined in the default.aspx
            TaxiHail.geocoder.initialize(TaxiHail.parameters.defaultLatitude, TaxiHail.parameters.defaultLongitude);
        },
        
        manageCompanySettings: function () {
            action(TaxiHail.CompanySettingsController, 'index');
        },

        managePaymentSettings: function () {
            action(TaxiHail.PaymentSettingsController, 'index');
        },
        
        manageDefaultAddresses: function () {
            action(TaxiHail.DefaultAddressesController, 'index');
        },

        addDefaultAddress: function () {
            action(TaxiHail.DefaultAddressesController, 'add');
        },

        editDefaultAddress: function(id) {
            action(TaxiHail.DefaultAddressesController, 'edit', id);
        },
        
        managePopularAddresses : function () {
            action(TaxiHail.PopularAddressesController, 'index');
        },

        addPopularAddress : function () {
            action(TaxiHail.PopularAddressesController, 'add');
        },
        
        editPopularAddress : function (id) {
            action(TaxiHail.PopularAddressesController, 'edit', id);
        },

        manageSecurity: function () {
            action(TaxiHail.SecurityController, 'index');
        },
        
        confirmEmail: function () {
            action(TaxiHail.SecurityController, 'confirmemail');
        },
        
        disableEmail: function () {
            action(TaxiHail.SecurityController, 'disableemail');
        },

        sendPushNotification: function () {
            action(TaxiHail.SecurityController, 'sendpushnotification');
        },

        manageTariffs: function() {
            action(TaxiHail.TariffsController, 'index');
        },

        addRecurringTariff: function() {
            action(TaxiHail.TariffsController, 'addRecurring');
        },

        addDayTariff: function() {
            action(TaxiHail.TariffsController, 'addDay');
        },

        editTariff: function(id) {
            
            action(TaxiHail.TariffsController, 'edit', id);
        },

        manageRules: function () {
            action(TaxiHail.RulesController, 'index');
        },

        addDefaultDisableRule: function () {
            action(TaxiHail.RulesController, 'addDefaultDisable');
        },

        addRecurringDisableRule: function () {
            action(TaxiHail.RulesController, 'addRecurringDisable');
        },

        addDayDisableRule: function () {
            action(TaxiHail.RulesController, 'addDayDisable');
        },
        
        addDefaultWarningRule: function () {
            action(TaxiHail.RulesController, 'addDefaultWarning');
        },

        addRecurringWarningRule: function () {
            action(TaxiHail.RulesController, 'addRecurringWarning');
        },

        addDayWarningRule: function () {
            action(TaxiHail.RulesController, 'addDayWarning');
        },

        editRule: function (id) {

            action(TaxiHail.RulesController, 'edit', id);
        },

        manageIBSExclusions: function () {
            
            action(TaxiHail.ExclusionsController, 'index');
        },

        exportaccounts: function () {
           
        },
        exportorders: function () {
            
        }
    });

}());
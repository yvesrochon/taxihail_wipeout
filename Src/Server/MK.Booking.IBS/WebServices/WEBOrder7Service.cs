using apcurium.MK.Booking.IBS.WebServices;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="IWEBOrder_7binding", Namespace="http://tempuri.org/")]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TException))]
public partial class WebOrder7Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback GetOrderStatusOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrderOperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrderOperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrderWrapperOperationCompleted;
    
    private System.Threading.SendOrPostCallback CancelBookOrderOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetHeartBeatOperationCompleted;
    
    private System.Threading.SendOrPostCallback DeleteBookOrderOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetFareTollsDistanceOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetVehicleLocationOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetDriverLocationOperationCompleted;
    
    private System.Threading.SendOrPostCallback SendDriverMsgOperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveExtrPaymentOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrder_2OperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrder_2OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrder_3OperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrder_3OperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrderWithCarOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetOrderHistoryOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrderByConfirmationNoOperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrder_4OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrder_4OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetVehicleLocationWithTaxiNoOperationCompleted;
    
    private System.Threading.SendOrPostCallback AddressCorrelationOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetOrderHistory_4OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrderByConfirmationNo_4OperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrder_5OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrder_5OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetOrderHistory_5OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrderByConfirmationNo_5OperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrder_6OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrder_6OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetOrderHistory_6OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrderByConfirmationNo_6OperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveRunOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetRunOperationCompleted;
    
    private System.Threading.SendOrPostCallback CancelSROrderOperationCompleted;
    
    private System.Threading.SendOrPostCallback CancelRunOperationCompleted;
    
    private System.Threading.SendOrPostCallback SaveBookOrder_7OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrder_7OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetOrderHistory_7OperationCompleted;
    
    private System.Threading.SendOrPostCallback GetBookOrderByConfirmationNo_7OperationCompleted;
    
    /// <remarks/>
    public WebOrder7Service() {
        this.Url = "http://72.38.252.190:6928/XDS_IASPI.DLL/soap/IWEBOrder_7";
    }
    
    /// <remarks/>
    public event GetOrderStatusCompletedEventHandler GetOrderStatusCompleted;
    
    /// <remarks/>
    public event GetBookOrderCompletedEventHandler GetBookOrderCompleted;
    
    /// <remarks/>
    public event SaveBookOrderCompletedEventHandler SaveBookOrderCompleted;
    
    /// <remarks/>
    public event SaveBookOrderWrapperCompletedEventHandler SaveBookOrderWrapperCompleted;
    
    /// <remarks/>
    public event CancelBookOrderCompletedEventHandler CancelBookOrderCompleted;
    
    /// <remarks/>
    public event GetHeartBeatCompletedEventHandler GetHeartBeatCompleted;
    
    /// <remarks/>
    public event DeleteBookOrderCompletedEventHandler DeleteBookOrderCompleted;
    
    /// <remarks/>
    public event GetFareTollsDistanceCompletedEventHandler GetFareTollsDistanceCompleted;
    
    /// <remarks/>
    public event GetVehicleLocationCompletedEventHandler GetVehicleLocationCompleted;
    
    /// <remarks/>
    public event GetDriverLocationCompletedEventHandler GetDriverLocationCompleted;
    
    /// <remarks/>
    public event SendDriverMsgCompletedEventHandler SendDriverMsgCompleted;
    
    /// <remarks/>
    public event SaveExtrPaymentCompletedEventHandler SaveExtrPaymentCompleted;
    
    /// <remarks/>
    public event GetBookOrder_2CompletedEventHandler GetBookOrder_2Completed;
    
    /// <remarks/>
    public event SaveBookOrder_2CompletedEventHandler SaveBookOrder_2Completed;
    
    /// <remarks/>
    public event GetBookOrder_3CompletedEventHandler GetBookOrder_3Completed;
    
    /// <remarks/>
    public event SaveBookOrder_3CompletedEventHandler SaveBookOrder_3Completed;
    
    /// <remarks/>
    public event SaveBookOrderWithCarCompletedEventHandler SaveBookOrderWithCarCompleted;
    
    /// <remarks/>
    public event GetOrderHistoryCompletedEventHandler GetOrderHistoryCompleted;
    
    /// <remarks/>
    public event GetBookOrderByConfirmationNoCompletedEventHandler GetBookOrderByConfirmationNoCompleted;
    
    /// <remarks/>
    public event SaveBookOrder_4CompletedEventHandler SaveBookOrder_4Completed;
    
    /// <remarks/>
    public event GetBookOrder_4CompletedEventHandler GetBookOrder_4Completed;
    
    /// <remarks/>
    public event GetVehicleLocationWithTaxiNoCompletedEventHandler GetVehicleLocationWithTaxiNoCompleted;
    
    /// <remarks/>
    public event AddressCorrelationCompletedEventHandler AddressCorrelationCompleted;
    
    /// <remarks/>
    public event GetOrderHistory_4CompletedEventHandler GetOrderHistory_4Completed;
    
    /// <remarks/>
    public event GetBookOrderByConfirmationNo_4CompletedEventHandler GetBookOrderByConfirmationNo_4Completed;
    
    /// <remarks/>
    public event SaveBookOrder_5CompletedEventHandler SaveBookOrder_5Completed;
    
    /// <remarks/>
    public event GetBookOrder_5CompletedEventHandler GetBookOrder_5Completed;
    
    /// <remarks/>
    public event GetOrderHistory_5CompletedEventHandler GetOrderHistory_5Completed;
    
    /// <remarks/>
    public event GetBookOrderByConfirmationNo_5CompletedEventHandler GetBookOrderByConfirmationNo_5Completed;
    
    /// <remarks/>
    public event SaveBookOrder_6CompletedEventHandler SaveBookOrder_6Completed;
    
    /// <remarks/>
    public event GetBookOrder_6CompletedEventHandler GetBookOrder_6Completed;
    
    /// <remarks/>
    public event GetOrderHistory_6CompletedEventHandler GetOrderHistory_6Completed;
    
    /// <remarks/>
    public event GetBookOrderByConfirmationNo_6CompletedEventHandler GetBookOrderByConfirmationNo_6Completed;
    
    /// <remarks/>
    public event SaveRunCompletedEventHandler SaveRunCompleted;
    
    /// <remarks/>
    public event GetRunCompletedEventHandler GetRunCompleted;
    
    /// <remarks/>
    public event CancelSROrderCompletedEventHandler CancelSROrderCompleted;
    
    /// <remarks/>
    public event CancelRunCompletedEventHandler CancelRunCompleted;
    
    /// <remarks/>
    public event SaveBookOrder_7CompletedEventHandler SaveBookOrder_7Completed;
    
    /// <remarks/>
    public event GetBookOrder_7CompletedEventHandler GetBookOrder_7Completed;
    
    /// <remarks/>
    public event GetOrderHistory_7CompletedEventHandler GetOrderHistory_7Completed;
    
    /// <remarks/>
    public event GetBookOrderByConfirmationNo_7CompletedEventHandler GetBookOrderByConfirmationNo_7Completed;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetOrderStatus", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TWEBOrderStatusValue GetOrderStatus(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetOrderStatus", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TWEBOrderStatusValue)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetOrderStatus(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetOrderStatus", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TWEBOrderStatusValue EndGetOrderStatus(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TWEBOrderStatusValue)(results[0]));
    }
    
    /// <remarks/>
    public void GetOrderStatusAsync(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetOrderStatusAsync(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetOrderStatusAsync(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetOrderStatusOperationCompleted == null)) {
            this.GetOrderStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderStatusOperationCompleted);
        }
        this.InvokeAsync("GetOrderStatus", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetOrderStatusOperationCompleted, userState);
    }
    
    private void OnGetOrderStatusOperationCompleted(object arg) {
        if ((this.GetOrderStatusCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetOrderStatusCompleted(this, new GetOrderStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder GetBookOrder(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder", new object[] {
                                                                        Login,
                                                                        Password,
                                                                        OrderID,
                                                                        ContactPhone,
                                                                        CCNumber,
                                                                        AccountID});
        return ((TBookOrder)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder", new object[] {
                                                                 Login,
                                                                 Password,
                                                                 OrderID,
                                                                 ContactPhone,
                                                                 CCNumber,
                                                                 AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder EndGetBookOrder(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrderAsync(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrderAsync(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrderAsync(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrderOperationCompleted == null)) {
            this.GetBookOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrderOperationCompleted);
        }
        this.InvokeAsync("GetBookOrder", new object[] {
                                                          Login,
                                                          Password,
                                                          OrderID,
                                                          ContactPhone,
                                                          CCNumber,
                                                          AccountID}, this.GetBookOrderOperationCompleted, userState);
    }
    
    private void OnGetBookOrderOperationCompleted(object arg) {
        if ((this.GetBookOrderCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrderCompleted(this, new GetBookOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder(string Login, string Password, TBookOrder BookOrder) {
        object[] results = this.Invoke("SaveBookOrder", new object[] {
                                                                         Login,
                                                                         Password,
                                                                         BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder(string Login, string Password, TBookOrder BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrderAsync(string Login, string Password, TBookOrder BookOrder) {
        this.SaveBookOrderAsync(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrderAsync(string Login, string Password, TBookOrder BookOrder, object userState) {
        if ((this.SaveBookOrderOperationCompleted == null)) {
            this.SaveBookOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrderOperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder", new object[] {
                                                           Login,
                                                           Password,
                                                           BookOrder}, this.SaveBookOrderOperationCompleted, userState);
    }
    
    private void OnSaveBookOrderOperationCompleted(object arg) {
        if ((this.SaveBookOrderCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrderCompleted(this, new SaveBookOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrderWrapper", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrderWrapper(
        string Login, 
        string Password, 
        int ServiceProviderID, 
        int ConfirmationID, 
        int AccountID, 
        string Customer, 
        string Phone, 
        int PickupYear, 
        int PickupMonth, 
        int PickupDay, 
        int PickupHour, 
        int PickupMinute, 
        string PickupStreetPlace, 
        string PickupAptBaz, 
        string PickupPostal, 
        int PickupCityID, 
        int PickupRegionID, 
        int PickupCountryID, 
        int PickupAddressID, 
        double PickupLatitude, 
        double PickupLongitude, 
        string DropoffStreetPlace, 
        string DropoffAptBaz, 
        string DropoffPostal, 
        int DropoffCityID, 
        int DropoffRegionID, 
        int DropoffCountryID, 
        int DropoffAddressID, 
        double DropoffLatitude, 
        double DropoffLongitude, 
        int Passengers, 
        string VehicleTypeName, 
        int VehicleTypeID, 
        string Note, 
        string ContactPhone, 
        string CCNumber, 
        string CCExpMonth, 
        string CCExpYear, 
        int CCTransID, 
        TWEBOrderStatusValue OrderStatus, 
        int OrderID, 
        double Fare, 
        double Tolls, 
        double EstDistance, 
        string CCHolder, 
        string CCStartMonth, 
        string CCStartYear, 
        string CCSecurityCode, 
        string CCIssueNumber, 
        string CCTransDate, 
        TCCTransResult CCTransResult, 
        string CCRespondText, 
        string CCAuth) {
        object[] results = this.Invoke("SaveBookOrderWrapper", new object[] {
                                                                                Login,
                                                                                Password,
                                                                                ServiceProviderID,
                                                                                ConfirmationID,
                                                                                AccountID,
                                                                                Customer,
                                                                                Phone,
                                                                                PickupYear,
                                                                                PickupMonth,
                                                                                PickupDay,
                                                                                PickupHour,
                                                                                PickupMinute,
                                                                                PickupStreetPlace,
                                                                                PickupAptBaz,
                                                                                PickupPostal,
                                                                                PickupCityID,
                                                                                PickupRegionID,
                                                                                PickupCountryID,
                                                                                PickupAddressID,
                                                                                PickupLatitude,
                                                                                PickupLongitude,
                                                                                DropoffStreetPlace,
                                                                                DropoffAptBaz,
                                                                                DropoffPostal,
                                                                                DropoffCityID,
                                                                                DropoffRegionID,
                                                                                DropoffCountryID,
                                                                                DropoffAddressID,
                                                                                DropoffLatitude,
                                                                                DropoffLongitude,
                                                                                Passengers,
                                                                                VehicleTypeName,
                                                                                VehicleTypeID,
                                                                                Note,
                                                                                ContactPhone,
                                                                                CCNumber,
                                                                                CCExpMonth,
                                                                                CCExpYear,
                                                                                CCTransID,
                                                                                OrderStatus,
                                                                                OrderID,
                                                                                Fare,
                                                                                Tolls,
                                                                                EstDistance,
                                                                                CCHolder,
                                                                                CCStartMonth,
                                                                                CCStartYear,
                                                                                CCSecurityCode,
                                                                                CCIssueNumber,
                                                                                CCTransDate,
                                                                                CCTransResult,
                                                                                CCRespondText,
                                                                                CCAuth});
        return ((int)(results[0]));
        }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrderWrapper(
        string Login, 
        string Password, 
        int ServiceProviderID, 
        int ConfirmationID, 
        int AccountID, 
        string Customer, 
        string Phone, 
        int PickupYear, 
        int PickupMonth, 
        int PickupDay, 
        int PickupHour, 
        int PickupMinute, 
        string PickupStreetPlace, 
        string PickupAptBaz, 
        string PickupPostal, 
        int PickupCityID, 
        int PickupRegionID, 
        int PickupCountryID, 
        int PickupAddressID, 
        double PickupLatitude, 
        double PickupLongitude, 
        string DropoffStreetPlace, 
        string DropoffAptBaz, 
        string DropoffPostal, 
        int DropoffCityID, 
        int DropoffRegionID, 
        int DropoffCountryID, 
        int DropoffAddressID, 
        double DropoffLatitude, 
        double DropoffLongitude, 
        int Passengers, 
        string VehicleTypeName, 
        int VehicleTypeID, 
        string Note, 
        string ContactPhone, 
        string CCNumber, 
        string CCExpMonth, 
        string CCExpYear, 
        int CCTransID, 
        TWEBOrderStatusValue OrderStatus, 
        int OrderID, 
        double Fare, 
        double Tolls, 
        double EstDistance, 
        string CCHolder, 
        string CCStartMonth, 
        string CCStartYear, 
        string CCSecurityCode, 
        string CCIssueNumber, 
        string CCTransDate, 
        TCCTransResult CCTransResult, 
        string CCRespondText, 
        string CCAuth, 
        System.AsyncCallback callback, 
        object asyncState) {
        return this.BeginInvoke("SaveBookOrderWrapper", new object[] {
                                                                         Login,
                                                                         Password,
                                                                         ServiceProviderID,
                                                                         ConfirmationID,
                                                                         AccountID,
                                                                         Customer,
                                                                         Phone,
                                                                         PickupYear,
                                                                         PickupMonth,
                                                                         PickupDay,
                                                                         PickupHour,
                                                                         PickupMinute,
                                                                         PickupStreetPlace,
                                                                         PickupAptBaz,
                                                                         PickupPostal,
                                                                         PickupCityID,
                                                                         PickupRegionID,
                                                                         PickupCountryID,
                                                                         PickupAddressID,
                                                                         PickupLatitude,
                                                                         PickupLongitude,
                                                                         DropoffStreetPlace,
                                                                         DropoffAptBaz,
                                                                         DropoffPostal,
                                                                         DropoffCityID,
                                                                         DropoffRegionID,
                                                                         DropoffCountryID,
                                                                         DropoffAddressID,
                                                                         DropoffLatitude,
                                                                         DropoffLongitude,
                                                                         Passengers,
                                                                         VehicleTypeName,
                                                                         VehicleTypeID,
                                                                         Note,
                                                                         ContactPhone,
                                                                         CCNumber,
                                                                         CCExpMonth,
                                                                         CCExpYear,
                                                                         CCTransID,
                                                                         OrderStatus,
                                                                         OrderID,
                                                                         Fare,
                                                                         Tolls,
                                                                         EstDistance,
                                                                         CCHolder,
                                                                         CCStartMonth,
                                                                         CCStartYear,
                                                                         CCSecurityCode,
                                                                         CCIssueNumber,
                                                                         CCTransDate,
                                                                         CCTransResult,
                                                                         CCRespondText,
                                                                         CCAuth}, callback, asyncState);
        }
    
    /// <remarks/>
    public int EndSaveBookOrderWrapper(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrderWrapperAsync(
        string Login, 
        string Password, 
        int ServiceProviderID, 
        int ConfirmationID, 
        int AccountID, 
        string Customer, 
        string Phone, 
        int PickupYear, 
        int PickupMonth, 
        int PickupDay, 
        int PickupHour, 
        int PickupMinute, 
        string PickupStreetPlace, 
        string PickupAptBaz, 
        string PickupPostal, 
        int PickupCityID, 
        int PickupRegionID, 
        int PickupCountryID, 
        int PickupAddressID, 
        double PickupLatitude, 
        double PickupLongitude, 
        string DropoffStreetPlace, 
        string DropoffAptBaz, 
        string DropoffPostal, 
        int DropoffCityID, 
        int DropoffRegionID, 
        int DropoffCountryID, 
        int DropoffAddressID, 
        double DropoffLatitude, 
        double DropoffLongitude, 
        int Passengers, 
        string VehicleTypeName, 
        int VehicleTypeID, 
        string Note, 
        string ContactPhone, 
        string CCNumber, 
        string CCExpMonth, 
        string CCExpYear, 
        int CCTransID, 
        TWEBOrderStatusValue OrderStatus, 
        int OrderID, 
        double Fare, 
        double Tolls, 
        double EstDistance, 
        string CCHolder, 
        string CCStartMonth, 
        string CCStartYear, 
        string CCSecurityCode, 
        string CCIssueNumber, 
        string CCTransDate, 
        TCCTransResult CCTransResult, 
        string CCRespondText, 
        string CCAuth) {
        this.SaveBookOrderWrapperAsync(Login, Password, ServiceProviderID, ConfirmationID, AccountID, Customer, Phone, PickupYear, PickupMonth, PickupDay, PickupHour, PickupMinute, PickupStreetPlace, PickupAptBaz, PickupPostal, PickupCityID, PickupRegionID, PickupCountryID, PickupAddressID, PickupLatitude, PickupLongitude, DropoffStreetPlace, DropoffAptBaz, DropoffPostal, DropoffCityID, DropoffRegionID, DropoffCountryID, DropoffAddressID, DropoffLatitude, DropoffLongitude, Passengers, VehicleTypeName, VehicleTypeID, Note, ContactPhone, CCNumber, CCExpMonth, CCExpYear, CCTransID, OrderStatus, OrderID, Fare, Tolls, EstDistance, CCHolder, CCStartMonth, CCStartYear, CCSecurityCode, CCIssueNumber, CCTransDate, CCTransResult, CCRespondText, CCAuth, null);
        }
    
    /// <remarks/>
    public void SaveBookOrderWrapperAsync(
        string Login, 
        string Password, 
        int ServiceProviderID, 
        int ConfirmationID, 
        int AccountID, 
        string Customer, 
        string Phone, 
        int PickupYear, 
        int PickupMonth, 
        int PickupDay, 
        int PickupHour, 
        int PickupMinute, 
        string PickupStreetPlace, 
        string PickupAptBaz, 
        string PickupPostal, 
        int PickupCityID, 
        int PickupRegionID, 
        int PickupCountryID, 
        int PickupAddressID, 
        double PickupLatitude, 
        double PickupLongitude, 
        string DropoffStreetPlace, 
        string DropoffAptBaz, 
        string DropoffPostal, 
        int DropoffCityID, 
        int DropoffRegionID, 
        int DropoffCountryID, 
        int DropoffAddressID, 
        double DropoffLatitude, 
        double DropoffLongitude, 
        int Passengers, 
        string VehicleTypeName, 
        int VehicleTypeID, 
        string Note, 
        string ContactPhone, 
        string CCNumber, 
        string CCExpMonth, 
        string CCExpYear, 
        int CCTransID, 
        TWEBOrderStatusValue OrderStatus, 
        int OrderID, 
        double Fare, 
        double Tolls, 
        double EstDistance, 
        string CCHolder, 
        string CCStartMonth, 
        string CCStartYear, 
        string CCSecurityCode, 
        string CCIssueNumber, 
        string CCTransDate, 
        TCCTransResult CCTransResult, 
        string CCRespondText, 
        string CCAuth, 
        object userState) {
        if ((this.SaveBookOrderWrapperOperationCompleted == null)) {
            this.SaveBookOrderWrapperOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrderWrapperOperationCompleted);
        }
        this.InvokeAsync("SaveBookOrderWrapper", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  ServiceProviderID,
                                                                  ConfirmationID,
                                                                  AccountID,
                                                                  Customer,
                                                                  Phone,
                                                                  PickupYear,
                                                                  PickupMonth,
                                                                  PickupDay,
                                                                  PickupHour,
                                                                  PickupMinute,
                                                                  PickupStreetPlace,
                                                                  PickupAptBaz,
                                                                  PickupPostal,
                                                                  PickupCityID,
                                                                  PickupRegionID,
                                                                  PickupCountryID,
                                                                  PickupAddressID,
                                                                  PickupLatitude,
                                                                  PickupLongitude,
                                                                  DropoffStreetPlace,
                                                                  DropoffAptBaz,
                                                                  DropoffPostal,
                                                                  DropoffCityID,
                                                                  DropoffRegionID,
                                                                  DropoffCountryID,
                                                                  DropoffAddressID,
                                                                  DropoffLatitude,
                                                                  DropoffLongitude,
                                                                  Passengers,
                                                                  VehicleTypeName,
                                                                  VehicleTypeID,
                                                                  Note,
                                                                  ContactPhone,
                                                                  CCNumber,
                                                                  CCExpMonth,
                                                                  CCExpYear,
                                                                  CCTransID,
                                                                  OrderStatus,
                                                                  OrderID,
                                                                  Fare,
                                                                  Tolls,
                                                                  EstDistance,
                                                                  CCHolder,
                                                                  CCStartMonth,
                                                                  CCStartYear,
                                                                  CCSecurityCode,
                                                                  CCIssueNumber,
                                                                  CCTransDate,
                                                                  CCTransResult,
                                                                  CCRespondText,
                                                                  CCAuth}, this.SaveBookOrderWrapperOperationCompleted, userState);
        }
    
    private void OnSaveBookOrderWrapperOperationCompleted(object arg) {
        if ((this.SaveBookOrderWrapperCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrderWrapperCompleted(this, new SaveBookOrderWrapperCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#CancelBookOrder", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int CancelBookOrder(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("CancelBookOrder", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           OrderID,
                                                                           ContactPhone,
                                                                           CCNumber,
                                                                           AccountID});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginCancelBookOrder(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("CancelBookOrder", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    OrderID,
                                                                    ContactPhone,
                                                                    CCNumber,
                                                                    AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndCancelBookOrder(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void CancelBookOrderAsync(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.CancelBookOrderAsync(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void CancelBookOrderAsync(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.CancelBookOrderOperationCompleted == null)) {
            this.CancelBookOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelBookOrderOperationCompleted);
        }
        this.InvokeAsync("CancelBookOrder", new object[] {
                                                             Login,
                                                             Password,
                                                             OrderID,
                                                             ContactPhone,
                                                             CCNumber,
                                                             AccountID}, this.CancelBookOrderOperationCompleted, userState);
    }
    
    private void OnCancelBookOrderOperationCompleted(object arg) {
        if ((this.CancelBookOrderCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.CancelBookOrderCompleted(this, new CancelBookOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetHeartBeat", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TWEBTimeStamp GetHeartBeat(string Login, string Password) {
        object[] results = this.Invoke("GetHeartBeat", new object[] {
                                                                        Login,
                                                                        Password});
        return ((TWEBTimeStamp)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetHeartBeat(string Login, string Password, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetHeartBeat", new object[] {
                                                                 Login,
                                                                 Password}, callback, asyncState);
    }
    
    /// <remarks/>
    public TWEBTimeStamp EndGetHeartBeat(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TWEBTimeStamp)(results[0]));
    }
    
    /// <remarks/>
    public void GetHeartBeatAsync(string Login, string Password) {
        this.GetHeartBeatAsync(Login, Password, null);
    }
    
    /// <remarks/>
    public void GetHeartBeatAsync(string Login, string Password, object userState) {
        if ((this.GetHeartBeatOperationCompleted == null)) {
            this.GetHeartBeatOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetHeartBeatOperationCompleted);
        }
        this.InvokeAsync("GetHeartBeat", new object[] {
                                                          Login,
                                                          Password}, this.GetHeartBeatOperationCompleted, userState);
    }
    
    private void OnGetHeartBeatOperationCompleted(object arg) {
        if ((this.GetHeartBeatCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetHeartBeatCompleted(this, new GetHeartBeatCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#DeleteBookOrder", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int DeleteBookOrder(string Login, string Password, int OrderID) {
        object[] results = this.Invoke("DeleteBookOrder", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           OrderID});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginDeleteBookOrder(string Login, string Password, int OrderID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("DeleteBookOrder", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    OrderID}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndDeleteBookOrder(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void DeleteBookOrderAsync(string Login, string Password, int OrderID) {
        this.DeleteBookOrderAsync(Login, Password, OrderID, null);
    }
    
    /// <remarks/>
    public void DeleteBookOrderAsync(string Login, string Password, int OrderID, object userState) {
        if ((this.DeleteBookOrderOperationCompleted == null)) {
            this.DeleteBookOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteBookOrderOperationCompleted);
        }
        this.InvokeAsync("DeleteBookOrder", new object[] {
                                                             Login,
                                                             Password,
                                                             OrderID}, this.DeleteBookOrderOperationCompleted, userState);
    }
    
    private void OnDeleteBookOrderOperationCompleted(object arg) {
        if ((this.DeleteBookOrderCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.DeleteBookOrderCompleted(this, new DeleteBookOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetFareTollsDistance", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int GetFareTollsDistance(string Login, string Password, int OrderID, ref double Fare, ref double Tolls, ref double Distance) {
        object[] results = this.Invoke("GetFareTollsDistance", new object[] {
                                                                                Login,
                                                                                Password,
                                                                                OrderID,
                                                                                Fare,
                                                                                Tolls,
                                                                                Distance});
        Fare = ((double)(results[1]));
        Tolls = ((double)(results[2]));
        Distance = ((double)(results[3]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetFareTollsDistance(string Login, string Password, int OrderID, double Fare, double Tolls, double Distance, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetFareTollsDistance", new object[] {
                                                                         Login,
                                                                         Password,
                                                                         OrderID,
                                                                         Fare,
                                                                         Tolls,
                                                                         Distance}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndGetFareTollsDistance(System.IAsyncResult asyncResult, out double Fare, out double Tolls, out double Distance) {
        object[] results = this.EndInvoke(asyncResult);
        Fare = ((double)(results[1]));
        Tolls = ((double)(results[2]));
        Distance = ((double)(results[3]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void GetFareTollsDistanceAsync(string Login, string Password, int OrderID, double Fare, double Tolls, double Distance) {
        this.GetFareTollsDistanceAsync(Login, Password, OrderID, Fare, Tolls, Distance, null);
    }
    
    /// <remarks/>
    public void GetFareTollsDistanceAsync(string Login, string Password, int OrderID, double Fare, double Tolls, double Distance, object userState) {
        if ((this.GetFareTollsDistanceOperationCompleted == null)) {
            this.GetFareTollsDistanceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFareTollsDistanceOperationCompleted);
        }
        this.InvokeAsync("GetFareTollsDistance", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  OrderID,
                                                                  Fare,
                                                                  Tolls,
                                                                  Distance}, this.GetFareTollsDistanceOperationCompleted, userState);
    }
    
    private void OnGetFareTollsDistanceOperationCompleted(object arg) {
        if ((this.GetFareTollsDistanceCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetFareTollsDistanceCompleted(this, new GetFareTollsDistanceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetVehicleLocation", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int GetVehicleLocation(string Login, string Password, int OrderID, ref double Lon, ref double Lat) {
        object[] results = this.Invoke("GetVehicleLocation", new object[] {
                                                                              Login,
                                                                              Password,
                                                                              OrderID,
                                                                              Lon,
                                                                              Lat});
        Lon = ((double)(results[1]));
        Lat = ((double)(results[2]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetVehicleLocation(string Login, string Password, int OrderID, double Lon, double Lat, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetVehicleLocation", new object[] {
                                                                       Login,
                                                                       Password,
                                                                       OrderID,
                                                                       Lon,
                                                                       Lat}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndGetVehicleLocation(System.IAsyncResult asyncResult, out double Lon, out double Lat) {
        object[] results = this.EndInvoke(asyncResult);
        Lon = ((double)(results[1]));
        Lat = ((double)(results[2]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void GetVehicleLocationAsync(string Login, string Password, int OrderID, double Lon, double Lat) {
        this.GetVehicleLocationAsync(Login, Password, OrderID, Lon, Lat, null);
    }
    
    /// <remarks/>
    public void GetVehicleLocationAsync(string Login, string Password, int OrderID, double Lon, double Lat, object userState) {
        if ((this.GetVehicleLocationOperationCompleted == null)) {
            this.GetVehicleLocationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetVehicleLocationOperationCompleted);
        }
        this.InvokeAsync("GetVehicleLocation", new object[] {
                                                                Login,
                                                                Password,
                                                                OrderID,
                                                                Lon,
                                                                Lat}, this.GetVehicleLocationOperationCompleted, userState);
    }
    
    private void OnGetVehicleLocationOperationCompleted(object arg) {
        if ((this.GetVehicleLocationCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetVehicleLocationCompleted(this, new GetVehicleLocationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetDriverLocation", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int GetDriverLocation(string Login, string Password, string DriverID, ref double Lon, ref double Lat) {
        object[] results = this.Invoke("GetDriverLocation", new object[] {
                                                                             Login,
                                                                             Password,
                                                                             DriverID,
                                                                             Lon,
                                                                             Lat});
        Lon = ((double)(results[1]));
        Lat = ((double)(results[2]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetDriverLocation(string Login, string Password, string DriverID, double Lon, double Lat, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetDriverLocation", new object[] {
                                                                      Login,
                                                                      Password,
                                                                      DriverID,
                                                                      Lon,
                                                                      Lat}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndGetDriverLocation(System.IAsyncResult asyncResult, out double Lon, out double Lat) {
        object[] results = this.EndInvoke(asyncResult);
        Lon = ((double)(results[1]));
        Lat = ((double)(results[2]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void GetDriverLocationAsync(string Login, string Password, string DriverID, double Lon, double Lat) {
        this.GetDriverLocationAsync(Login, Password, DriverID, Lon, Lat, null);
    }
    
    /// <remarks/>
    public void GetDriverLocationAsync(string Login, string Password, string DriverID, double Lon, double Lat, object userState) {
        if ((this.GetDriverLocationOperationCompleted == null)) {
            this.GetDriverLocationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDriverLocationOperationCompleted);
        }
        this.InvokeAsync("GetDriverLocation", new object[] {
                                                               Login,
                                                               Password,
                                                               DriverID,
                                                               Lon,
                                                               Lat}, this.GetDriverLocationOperationCompleted, userState);
    }
    
    private void OnGetDriverLocationOperationCompleted(object arg) {
        if ((this.GetDriverLocationCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetDriverLocationCompleted(this, new GetDriverLocationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SendDriverMsg", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SendDriverMsg(string Login, string Password, string CarID, string Msg) {
        object[] results = this.Invoke("SendDriverMsg", new object[] {
                                                                         Login,
                                                                         Password,
                                                                         CarID,
                                                                         Msg});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSendDriverMsg(string Login, string Password, string CarID, string Msg, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SendDriverMsg", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  CarID,
                                                                  Msg}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSendDriverMsg(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SendDriverMsgAsync(string Login, string Password, string CarID, string Msg) {
        this.SendDriverMsgAsync(Login, Password, CarID, Msg, null);
    }
    
    /// <remarks/>
    public void SendDriverMsgAsync(string Login, string Password, string CarID, string Msg, object userState) {
        if ((this.SendDriverMsgOperationCompleted == null)) {
            this.SendDriverMsgOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendDriverMsgOperationCompleted);
        }
        this.InvokeAsync("SendDriverMsg", new object[] {
                                                           Login,
                                                           Password,
                                                           CarID,
                                                           Msg}, this.SendDriverMsgOperationCompleted, userState);
    }
    
    private void OnSendDriverMsgOperationCompleted(object arg) {
        if ((this.SendDriverMsgCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SendDriverMsgCompleted(this, new SendDriverMsgCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveExtrPayment", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveExtrPayment(string Login, string Password, int RideID, double Amount, string AuthNum) {
        object[] results = this.Invoke("SaveExtrPayment", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           RideID,
                                                                           Amount,
                                                                           AuthNum});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveExtrPayment(string Login, string Password, int RideID, double Amount, string AuthNum, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveExtrPayment", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    RideID,
                                                                    Amount,
                                                                    AuthNum}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveExtrPayment(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveExtrPaymentAsync(string Login, string Password, int RideID, double Amount, string AuthNum) {
        this.SaveExtrPaymentAsync(Login, Password, RideID, Amount, AuthNum, null);
    }
    
    /// <remarks/>
    public void SaveExtrPaymentAsync(string Login, string Password, int RideID, double Amount, string AuthNum, object userState) {
        if ((this.SaveExtrPaymentOperationCompleted == null)) {
            this.SaveExtrPaymentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveExtrPaymentOperationCompleted);
        }
        this.InvokeAsync("SaveExtrPayment", new object[] {
                                                             Login,
                                                             Password,
                                                             RideID,
                                                             Amount,
                                                             AuthNum}, this.SaveExtrPaymentOperationCompleted, userState);
    }
    
    private void OnSaveExtrPaymentOperationCompleted(object arg) {
        if ((this.SaveExtrPaymentCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveExtrPaymentCompleted(this, new SaveExtrPaymentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder_2", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder_2 GetBookOrder_2(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder_2", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TBookOrder_2)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder_2(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder_2", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder_2 EndGetBookOrder_2(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder_2)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrder_2Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrder_2Async(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrder_2Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrder_2OperationCompleted == null)) {
            this.GetBookOrder_2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrder_2OperationCompleted);
        }
        this.InvokeAsync("GetBookOrder_2", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetBookOrder_2OperationCompleted, userState);
    }
    
    private void OnGetBookOrder_2OperationCompleted(object arg) {
        if ((this.GetBookOrder_2Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrder_2Completed(this, new GetBookOrder_2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder_2", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder_2(string Login, string Password, TBookOrder_2 BookOrder) {
        object[] results = this.Invoke("SaveBookOrder_2", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder_2(string Login, string Password, TBookOrder_2 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder_2", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder_2(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrder_2Async(string Login, string Password, TBookOrder_2 BookOrder) {
        this.SaveBookOrder_2Async(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrder_2Async(string Login, string Password, TBookOrder_2 BookOrder, object userState) {
        if ((this.SaveBookOrder_2OperationCompleted == null)) {
            this.SaveBookOrder_2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrder_2OperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder_2", new object[] {
                                                             Login,
                                                             Password,
                                                             BookOrder}, this.SaveBookOrder_2OperationCompleted, userState);
    }
    
    private void OnSaveBookOrder_2OperationCompleted(object arg) {
        if ((this.SaveBookOrder_2Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrder_2Completed(this, new SaveBookOrder_2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder_3", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder_3 GetBookOrder_3(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder_3", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TBookOrder_3)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder_3(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder_3", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder_3 EndGetBookOrder_3(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder_3)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrder_3Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrder_3Async(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrder_3Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrder_3OperationCompleted == null)) {
            this.GetBookOrder_3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrder_3OperationCompleted);
        }
        this.InvokeAsync("GetBookOrder_3", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetBookOrder_3OperationCompleted, userState);
    }
    
    private void OnGetBookOrder_3OperationCompleted(object arg) {
        if ((this.GetBookOrder_3Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrder_3Completed(this, new GetBookOrder_3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder_3", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder_3(string Login, string Password, TBookOrder_3 BookOrder) {
        object[] results = this.Invoke("SaveBookOrder_3", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder_3(string Login, string Password, TBookOrder_3 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder_3", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder_3(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrder_3Async(string Login, string Password, TBookOrder_3 BookOrder) {
        this.SaveBookOrder_3Async(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrder_3Async(string Login, string Password, TBookOrder_3 BookOrder, object userState) {
        if ((this.SaveBookOrder_3OperationCompleted == null)) {
            this.SaveBookOrder_3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrder_3OperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder_3", new object[] {
                                                             Login,
                                                             Password,
                                                             BookOrder}, this.SaveBookOrder_3OperationCompleted, userState);
    }
    
    private void OnSaveBookOrder_3OperationCompleted(object arg) {
        if ((this.SaveBookOrder_3Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrder_3Completed(this, new SaveBookOrder_3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrderWithCar", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrderWithCar(string Login, string Password, int CarNumber, TBookOrder_3 BookOrder) {
        object[] results = this.Invoke("SaveBookOrderWithCar", new object[] {
                                                                                Login,
                                                                                Password,
                                                                                CarNumber,
                                                                                BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrderWithCar(string Login, string Password, int CarNumber, TBookOrder_3 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrderWithCar", new object[] {
                                                                         Login,
                                                                         Password,
                                                                         CarNumber,
                                                                         BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrderWithCar(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrderWithCarAsync(string Login, string Password, int CarNumber, TBookOrder_3 BookOrder) {
        this.SaveBookOrderWithCarAsync(Login, Password, CarNumber, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrderWithCarAsync(string Login, string Password, int CarNumber, TBookOrder_3 BookOrder, object userState) {
        if ((this.SaveBookOrderWithCarOperationCompleted == null)) {
            this.SaveBookOrderWithCarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrderWithCarOperationCompleted);
        }
        this.InvokeAsync("SaveBookOrderWithCar", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  CarNumber,
                                                                  BookOrder}, this.SaveBookOrderWithCarOperationCompleted, userState);
    }
    
    private void OnSaveBookOrderWithCarOperationCompleted(object arg) {
        if ((this.SaveBookOrderWithCarCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrderWithCarCompleted(this, new SaveBookOrderWithCarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetOrderHistory", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_3 GetOrderHistory(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        object[] results = this.Invoke("GetOrderHistory", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           AccountID,
                                                                           FrDate,
                                                                           ToDate,
                                                                           OrderStatus});
        return ((TBookOrderList_3)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetOrderHistory(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetOrderHistory", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    AccountID,
                                                                    FrDate,
                                                                    ToDate,
                                                                    OrderStatus}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_3 EndGetOrderHistory(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_3)(results[0]));
    }
    
    /// <remarks/>
    public void GetOrderHistoryAsync(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        this.GetOrderHistoryAsync(Login, Password, AccountID, FrDate, ToDate, OrderStatus, null);
    }
    
    /// <remarks/>
    public void GetOrderHistoryAsync(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, object userState) {
        if ((this.GetOrderHistoryOperationCompleted == null)) {
            this.GetOrderHistoryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderHistoryOperationCompleted);
        }
        this.InvokeAsync("GetOrderHistory", new object[] {
                                                             Login,
                                                             Password,
                                                             AccountID,
                                                             FrDate,
                                                             ToDate,
                                                             OrderStatus}, this.GetOrderHistoryOperationCompleted, userState);
    }
    
    private void OnGetOrderHistoryOperationCompleted(object arg) {
        if ((this.GetOrderHistoryCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetOrderHistoryCompleted(this, new GetOrderHistoryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrderByConfirmationNo", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_3 GetBookOrderByConfirmationNo(string Login, string Password, int ConfirmationNo, int AccountID) {
        object[] results = this.Invoke("GetBookOrderByConfirmationNo", new object[] {
                                                                                        Login,
                                                                                        Password,
                                                                                        ConfirmationNo,
                                                                                        AccountID});
        return ((TBookOrderList_3)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrderByConfirmationNo(string Login, string Password, int ConfirmationNo, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrderByConfirmationNo", new object[] {
                                                                                 Login,
                                                                                 Password,
                                                                                 ConfirmationNo,
                                                                                 AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_3 EndGetBookOrderByConfirmationNo(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_3)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNoAsync(string Login, string Password, int ConfirmationNo, int AccountID) {
        this.GetBookOrderByConfirmationNoAsync(Login, Password, ConfirmationNo, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNoAsync(string Login, string Password, int ConfirmationNo, int AccountID, object userState) {
        if ((this.GetBookOrderByConfirmationNoOperationCompleted == null)) {
            this.GetBookOrderByConfirmationNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrderByConfirmationNoOperationCompleted);
        }
        this.InvokeAsync("GetBookOrderByConfirmationNo", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          ConfirmationNo,
                                                                          AccountID}, this.GetBookOrderByConfirmationNoOperationCompleted, userState);
    }
    
    private void OnGetBookOrderByConfirmationNoOperationCompleted(object arg) {
        if ((this.GetBookOrderByConfirmationNoCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrderByConfirmationNoCompleted(this, new GetBookOrderByConfirmationNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder_4", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder_4(string Login, string Password, TBookOrder_4 BookOrder) {
        object[] results = this.Invoke("SaveBookOrder_4", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder_4(string Login, string Password, TBookOrder_4 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder_4", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder_4(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrder_4Async(string Login, string Password, TBookOrder_4 BookOrder) {
        this.SaveBookOrder_4Async(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrder_4Async(string Login, string Password, TBookOrder_4 BookOrder, object userState) {
        if ((this.SaveBookOrder_4OperationCompleted == null)) {
            this.SaveBookOrder_4OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrder_4OperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder_4", new object[] {
                                                             Login,
                                                             Password,
                                                             BookOrder}, this.SaveBookOrder_4OperationCompleted, userState);
    }
    
    private void OnSaveBookOrder_4OperationCompleted(object arg) {
        if ((this.SaveBookOrder_4Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrder_4Completed(this, new SaveBookOrder_4CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder_4", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder_4 GetBookOrder_4(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder_4", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TBookOrder_4)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder_4(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder_4", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder_4 EndGetBookOrder_4(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder_4)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrder_4Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrder_4Async(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrder_4Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrder_4OperationCompleted == null)) {
            this.GetBookOrder_4OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrder_4OperationCompleted);
        }
        this.InvokeAsync("GetBookOrder_4", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetBookOrder_4OperationCompleted, userState);
    }
    
    private void OnGetBookOrder_4OperationCompleted(object arg) {
        if ((this.GetBookOrder_4Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrder_4Completed(this, new GetBookOrder_4CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetVehicleLocationWithTaxiNo", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int GetVehicleLocationWithTaxiNo(string Login, string Password, int OrderID, ref double Lon, ref double Lat, ref TWEBTimeStamp LastGPSUpdate, ref string TaxiNo) {
        object[] results = this.Invoke("GetVehicleLocationWithTaxiNo", new object[] {
                                                                                        Login,
                                                                                        Password,
                                                                                        OrderID,
                                                                                        Lon,
                                                                                        Lat,
                                                                                        LastGPSUpdate,
                                                                                        TaxiNo});
        Lon = ((double)(results[1]));
        Lat = ((double)(results[2]));
        LastGPSUpdate = ((TWEBTimeStamp)(results[3]));
        TaxiNo = ((string)(results[4]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetVehicleLocationWithTaxiNo(string Login, string Password, int OrderID, double Lon, double Lat, TWEBTimeStamp LastGPSUpdate, string TaxiNo, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetVehicleLocationWithTaxiNo", new object[] {
                                                                                 Login,
                                                                                 Password,
                                                                                 OrderID,
                                                                                 Lon,
                                                                                 Lat,
                                                                                 LastGPSUpdate,
                                                                                 TaxiNo}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndGetVehicleLocationWithTaxiNo(System.IAsyncResult asyncResult, out double Lon, out double Lat, out TWEBTimeStamp LastGPSUpdate, out string TaxiNo) {
        object[] results = this.EndInvoke(asyncResult);
        Lon = ((double)(results[1]));
        Lat = ((double)(results[2]));
        LastGPSUpdate = ((TWEBTimeStamp)(results[3]));
        TaxiNo = ((string)(results[4]));
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void GetVehicleLocationWithTaxiNoAsync(string Login, string Password, int OrderID, double Lon, double Lat, TWEBTimeStamp LastGPSUpdate, string TaxiNo) {
        this.GetVehicleLocationWithTaxiNoAsync(Login, Password, OrderID, Lon, Lat, LastGPSUpdate, TaxiNo, null);
    }
    
    /// <remarks/>
    public void GetVehicleLocationWithTaxiNoAsync(string Login, string Password, int OrderID, double Lon, double Lat, TWEBTimeStamp LastGPSUpdate, string TaxiNo, object userState) {
        if ((this.GetVehicleLocationWithTaxiNoOperationCompleted == null)) {
            this.GetVehicleLocationWithTaxiNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetVehicleLocationWithTaxiNoOperationCompleted);
        }
        this.InvokeAsync("GetVehicleLocationWithTaxiNo", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          Lon,
                                                                          Lat,
                                                                          LastGPSUpdate,
                                                                          TaxiNo}, this.GetVehicleLocationWithTaxiNoOperationCompleted, userState);
    }
    
    private void OnGetVehicleLocationWithTaxiNoOperationCompleted(object arg) {
        if ((this.GetVehicleLocationWithTaxiNoCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetVehicleLocationWithTaxiNoCompleted(this, new GetVehicleLocationWithTaxiNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#AddressCorrelation", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TWEBFavotiteAddress[] AddressCorrelation(string Login, string Password, double Lon, double Lat) {
        object[] results = this.Invoke("AddressCorrelation", new object[] {
                                                                              Login,
                                                                              Password,
                                                                              Lon,
                                                                              Lat});
        return ((TWEBFavotiteAddress[])(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginAddressCorrelation(string Login, string Password, double Lon, double Lat, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("AddressCorrelation", new object[] {
                                                                       Login,
                                                                       Password,
                                                                       Lon,
                                                                       Lat}, callback, asyncState);
    }
    
    /// <remarks/>
    public TWEBFavotiteAddress[] EndAddressCorrelation(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TWEBFavotiteAddress[])(results[0]));
    }
    
    /// <remarks/>
    public void AddressCorrelationAsync(string Login, string Password, double Lon, double Lat) {
        this.AddressCorrelationAsync(Login, Password, Lon, Lat, null);
    }
    
    /// <remarks/>
    public void AddressCorrelationAsync(string Login, string Password, double Lon, double Lat, object userState) {
        if ((this.AddressCorrelationOperationCompleted == null)) {
            this.AddressCorrelationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddressCorrelationOperationCompleted);
        }
        this.InvokeAsync("AddressCorrelation", new object[] {
                                                                Login,
                                                                Password,
                                                                Lon,
                                                                Lat}, this.AddressCorrelationOperationCompleted, userState);
    }
    
    private void OnAddressCorrelationOperationCompleted(object arg) {
        if ((this.AddressCorrelationCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.AddressCorrelationCompleted(this, new AddressCorrelationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetOrderHistory_4", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_4 GetOrderHistory_4(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        object[] results = this.Invoke("GetOrderHistory_4", new object[] {
                                                                             Login,
                                                                             Password,
                                                                             AccountID,
                                                                             FrDate,
                                                                             ToDate,
                                                                             OrderStatus});
        return ((TBookOrderList_4)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetOrderHistory_4(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetOrderHistory_4", new object[] {
                                                                      Login,
                                                                      Password,
                                                                      AccountID,
                                                                      FrDate,
                                                                      ToDate,
                                                                      OrderStatus}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_4 EndGetOrderHistory_4(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_4)(results[0]));
    }
    
    /// <remarks/>
    public void GetOrderHistory_4Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        this.GetOrderHistory_4Async(Login, Password, AccountID, FrDate, ToDate, OrderStatus, null);
    }
    
    /// <remarks/>
    public void GetOrderHistory_4Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, object userState) {
        if ((this.GetOrderHistory_4OperationCompleted == null)) {
            this.GetOrderHistory_4OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderHistory_4OperationCompleted);
        }
        this.InvokeAsync("GetOrderHistory_4", new object[] {
                                                               Login,
                                                               Password,
                                                               AccountID,
                                                               FrDate,
                                                               ToDate,
                                                               OrderStatus}, this.GetOrderHistory_4OperationCompleted, userState);
    }
    
    private void OnGetOrderHistory_4OperationCompleted(object arg) {
        if ((this.GetOrderHistory_4Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetOrderHistory_4Completed(this, new GetOrderHistory_4CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrderByConfirmationNo_4", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_4 GetBookOrderByConfirmationNo_4(string Login, string Password, int ConfirmationNo, int AccountID) {
        object[] results = this.Invoke("GetBookOrderByConfirmationNo_4", new object[] {
                                                                                          Login,
                                                                                          Password,
                                                                                          ConfirmationNo,
                                                                                          AccountID});
        return ((TBookOrderList_4)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrderByConfirmationNo_4(string Login, string Password, int ConfirmationNo, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrderByConfirmationNo_4", new object[] {
                                                                                   Login,
                                                                                   Password,
                                                                                   ConfirmationNo,
                                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_4 EndGetBookOrderByConfirmationNo_4(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_4)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_4Async(string Login, string Password, int ConfirmationNo, int AccountID) {
        this.GetBookOrderByConfirmationNo_4Async(Login, Password, ConfirmationNo, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_4Async(string Login, string Password, int ConfirmationNo, int AccountID, object userState) {
        if ((this.GetBookOrderByConfirmationNo_4OperationCompleted == null)) {
            this.GetBookOrderByConfirmationNo_4OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrderByConfirmationNo_4OperationCompleted);
        }
        this.InvokeAsync("GetBookOrderByConfirmationNo_4", new object[] {
                                                                            Login,
                                                                            Password,
                                                                            ConfirmationNo,
                                                                            AccountID}, this.GetBookOrderByConfirmationNo_4OperationCompleted, userState);
    }
    
    private void OnGetBookOrderByConfirmationNo_4OperationCompleted(object arg) {
        if ((this.GetBookOrderByConfirmationNo_4Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrderByConfirmationNo_4Completed(this, new GetBookOrderByConfirmationNo_4CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder_5", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder_5(string Login, string Password, TBookOrder_5 BookOrder) {
        object[] results = this.Invoke("SaveBookOrder_5", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder_5(string Login, string Password, TBookOrder_5 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder_5", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder_5(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrder_5Async(string Login, string Password, TBookOrder_5 BookOrder) {
        this.SaveBookOrder_5Async(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrder_5Async(string Login, string Password, TBookOrder_5 BookOrder, object userState) {
        if ((this.SaveBookOrder_5OperationCompleted == null)) {
            this.SaveBookOrder_5OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrder_5OperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder_5", new object[] {
                                                             Login,
                                                             Password,
                                                             BookOrder}, this.SaveBookOrder_5OperationCompleted, userState);
    }
    
    private void OnSaveBookOrder_5OperationCompleted(object arg) {
        if ((this.SaveBookOrder_5Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrder_5Completed(this, new SaveBookOrder_5CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder_5", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder_5 GetBookOrder_5(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder_5", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TBookOrder_5)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder_5(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder_5", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder_5 EndGetBookOrder_5(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder_5)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrder_5Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrder_5Async(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrder_5Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrder_5OperationCompleted == null)) {
            this.GetBookOrder_5OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrder_5OperationCompleted);
        }
        this.InvokeAsync("GetBookOrder_5", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetBookOrder_5OperationCompleted, userState);
    }
    
    private void OnGetBookOrder_5OperationCompleted(object arg) {
        if ((this.GetBookOrder_5Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrder_5Completed(this, new GetBookOrder_5CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetOrderHistory_5", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_5 GetOrderHistory_5(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        object[] results = this.Invoke("GetOrderHistory_5", new object[] {
                                                                             Login,
                                                                             Password,
                                                                             AccountID,
                                                                             FrDate,
                                                                             ToDate,
                                                                             OrderStatus});
        return ((TBookOrderList_5)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetOrderHistory_5(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetOrderHistory_5", new object[] {
                                                                      Login,
                                                                      Password,
                                                                      AccountID,
                                                                      FrDate,
                                                                      ToDate,
                                                                      OrderStatus}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_5 EndGetOrderHistory_5(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_5)(results[0]));
    }
    
    /// <remarks/>
    public void GetOrderHistory_5Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        this.GetOrderHistory_5Async(Login, Password, AccountID, FrDate, ToDate, OrderStatus, null);
    }
    
    /// <remarks/>
    public void GetOrderHistory_5Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, object userState) {
        if ((this.GetOrderHistory_5OperationCompleted == null)) {
            this.GetOrderHistory_5OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderHistory_5OperationCompleted);
        }
        this.InvokeAsync("GetOrderHistory_5", new object[] {
                                                               Login,
                                                               Password,
                                                               AccountID,
                                                               FrDate,
                                                               ToDate,
                                                               OrderStatus}, this.GetOrderHistory_5OperationCompleted, userState);
    }
    
    private void OnGetOrderHistory_5OperationCompleted(object arg) {
        if ((this.GetOrderHistory_5Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetOrderHistory_5Completed(this, new GetOrderHistory_5CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrderByConfirmationNo_5", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_5 GetBookOrderByConfirmationNo_5(string Login, string Password, int ConfirmationNo, int AccountID) {
        object[] results = this.Invoke("GetBookOrderByConfirmationNo_5", new object[] {
                                                                                          Login,
                                                                                          Password,
                                                                                          ConfirmationNo,
                                                                                          AccountID});
        return ((TBookOrderList_5)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrderByConfirmationNo_5(string Login, string Password, int ConfirmationNo, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrderByConfirmationNo_5", new object[] {
                                                                                   Login,
                                                                                   Password,
                                                                                   ConfirmationNo,
                                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_5 EndGetBookOrderByConfirmationNo_5(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_5)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_5Async(string Login, string Password, int ConfirmationNo, int AccountID) {
        this.GetBookOrderByConfirmationNo_5Async(Login, Password, ConfirmationNo, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_5Async(string Login, string Password, int ConfirmationNo, int AccountID, object userState) {
        if ((this.GetBookOrderByConfirmationNo_5OperationCompleted == null)) {
            this.GetBookOrderByConfirmationNo_5OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrderByConfirmationNo_5OperationCompleted);
        }
        this.InvokeAsync("GetBookOrderByConfirmationNo_5", new object[] {
                                                                            Login,
                                                                            Password,
                                                                            ConfirmationNo,
                                                                            AccountID}, this.GetBookOrderByConfirmationNo_5OperationCompleted, userState);
    }
    
    private void OnGetBookOrderByConfirmationNo_5OperationCompleted(object arg) {
        if ((this.GetBookOrderByConfirmationNo_5Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrderByConfirmationNo_5Completed(this, new GetBookOrderByConfirmationNo_5CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder_6", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder_6(string Login, string Password, TBookOrder_6 BookOrder) {
        object[] results = this.Invoke("SaveBookOrder_6", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder_6(string Login, string Password, TBookOrder_6 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder_6", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder_6(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrder_6Async(string Login, string Password, TBookOrder_6 BookOrder) {
        this.SaveBookOrder_6Async(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrder_6Async(string Login, string Password, TBookOrder_6 BookOrder, object userState) {
        if ((this.SaveBookOrder_6OperationCompleted == null)) {
            this.SaveBookOrder_6OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrder_6OperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder_6", new object[] {
                                                             Login,
                                                             Password,
                                                             BookOrder}, this.SaveBookOrder_6OperationCompleted, userState);
    }
    
    private void OnSaveBookOrder_6OperationCompleted(object arg) {
        if ((this.SaveBookOrder_6Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrder_6Completed(this, new SaveBookOrder_6CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder_6", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder_6 GetBookOrder_6(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder_6", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TBookOrder_6)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder_6(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder_6", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder_6 EndGetBookOrder_6(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder_6)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrder_6Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrder_6Async(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrder_6Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrder_6OperationCompleted == null)) {
            this.GetBookOrder_6OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrder_6OperationCompleted);
        }
        this.InvokeAsync("GetBookOrder_6", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetBookOrder_6OperationCompleted, userState);
    }
    
    private void OnGetBookOrder_6OperationCompleted(object arg) {
        if ((this.GetBookOrder_6Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrder_6Completed(this, new GetBookOrder_6CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetOrderHistory_6", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_6 GetOrderHistory_6(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        object[] results = this.Invoke("GetOrderHistory_6", new object[] {
                                                                             Login,
                                                                             Password,
                                                                             AccountID,
                                                                             FrDate,
                                                                             ToDate,
                                                                             OrderStatus});
        return ((TBookOrderList_6)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetOrderHistory_6(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetOrderHistory_6", new object[] {
                                                                      Login,
                                                                      Password,
                                                                      AccountID,
                                                                      FrDate,
                                                                      ToDate,
                                                                      OrderStatus}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_6 EndGetOrderHistory_6(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_6)(results[0]));
    }
    
    /// <remarks/>
    public void GetOrderHistory_6Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        this.GetOrderHistory_6Async(Login, Password, AccountID, FrDate, ToDate, OrderStatus, null);
    }
    
    /// <remarks/>
    public void GetOrderHistory_6Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, object userState) {
        if ((this.GetOrderHistory_6OperationCompleted == null)) {
            this.GetOrderHistory_6OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderHistory_6OperationCompleted);
        }
        this.InvokeAsync("GetOrderHistory_6", new object[] {
                                                               Login,
                                                               Password,
                                                               AccountID,
                                                               FrDate,
                                                               ToDate,
                                                               OrderStatus}, this.GetOrderHistory_6OperationCompleted, userState);
    }
    
    private void OnGetOrderHistory_6OperationCompleted(object arg) {
        if ((this.GetOrderHistory_6Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetOrderHistory_6Completed(this, new GetOrderHistory_6CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrderByConfirmationNo_6", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_6 GetBookOrderByConfirmationNo_6(string Login, string Password, int ConfirmationNo, int AccountID) {
        object[] results = this.Invoke("GetBookOrderByConfirmationNo_6", new object[] {
                                                                                          Login,
                                                                                          Password,
                                                                                          ConfirmationNo,
                                                                                          AccountID});
        return ((TBookOrderList_6)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrderByConfirmationNo_6(string Login, string Password, int ConfirmationNo, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrderByConfirmationNo_6", new object[] {
                                                                                   Login,
                                                                                   Password,
                                                                                   ConfirmationNo,
                                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_6 EndGetBookOrderByConfirmationNo_6(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_6)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_6Async(string Login, string Password, int ConfirmationNo, int AccountID) {
        this.GetBookOrderByConfirmationNo_6Async(Login, Password, ConfirmationNo, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_6Async(string Login, string Password, int ConfirmationNo, int AccountID, object userState) {
        if ((this.GetBookOrderByConfirmationNo_6OperationCompleted == null)) {
            this.GetBookOrderByConfirmationNo_6OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrderByConfirmationNo_6OperationCompleted);
        }
        this.InvokeAsync("GetBookOrderByConfirmationNo_6", new object[] {
                                                                            Login,
                                                                            Password,
                                                                            ConfirmationNo,
                                                                            AccountID}, this.GetBookOrderByConfirmationNo_6OperationCompleted, userState);
    }
    
    private void OnGetBookOrderByConfirmationNo_6OperationCompleted(object arg) {
        if ((this.GetBookOrderByConfirmationNo_6Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrderByConfirmationNo_6Completed(this, new GetBookOrderByConfirmationNo_6CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveRun", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveRun(string Login, string Password, TRun Run) {
        object[] results = this.Invoke("SaveRun", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   Run});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveRun(string Login, string Password, TRun Run, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveRun", new object[] {
                                                            Login,
                                                            Password,
                                                            Run}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveRun(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveRunAsync(string Login, string Password, TRun Run) {
        this.SaveRunAsync(Login, Password, Run, null);
    }
    
    /// <remarks/>
    public void SaveRunAsync(string Login, string Password, TRun Run, object userState) {
        if ((this.SaveRunOperationCompleted == null)) {
            this.SaveRunOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveRunOperationCompleted);
        }
        this.InvokeAsync("SaveRun", new object[] {
                                                     Login,
                                                     Password,
                                                     Run}, this.SaveRunOperationCompleted, userState);
    }
    
    private void OnSaveRunOperationCompleted(object arg) {
        if ((this.SaveRunCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveRunCompleted(this, new SaveRunCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetRun", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TRun GetRun(string Login, string Password, int RunID) {
        object[] results = this.Invoke("GetRun", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  RunID});
        return ((TRun)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetRun(string Login, string Password, int RunID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetRun", new object[] {
                                                           Login,
                                                           Password,
                                                           RunID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TRun EndGetRun(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TRun)(results[0]));
    }
    
    /// <remarks/>
    public void GetRunAsync(string Login, string Password, int RunID) {
        this.GetRunAsync(Login, Password, RunID, null);
    }
    
    /// <remarks/>
    public void GetRunAsync(string Login, string Password, int RunID, object userState) {
        if ((this.GetRunOperationCompleted == null)) {
            this.GetRunOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRunOperationCompleted);
        }
        this.InvokeAsync("GetRun", new object[] {
                                                    Login,
                                                    Password,
                                                    RunID}, this.GetRunOperationCompleted, userState);
    }
    
    private void OnGetRunOperationCompleted(object arg) {
        if ((this.GetRunCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetRunCompleted(this, new GetRunCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#CancelSROrder", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int CancelSROrder(string Login, string Password, int OrderID) {
        object[] results = this.Invoke("CancelSROrder", new object[] {
                                                                         Login,
                                                                         Password,
                                                                         OrderID});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginCancelSROrder(string Login, string Password, int OrderID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("CancelSROrder", new object[] {
                                                                  Login,
                                                                  Password,
                                                                  OrderID}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndCancelSROrder(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void CancelSROrderAsync(string Login, string Password, int OrderID) {
        this.CancelSROrderAsync(Login, Password, OrderID, null);
    }
    
    /// <remarks/>
    public void CancelSROrderAsync(string Login, string Password, int OrderID, object userState) {
        if ((this.CancelSROrderOperationCompleted == null)) {
            this.CancelSROrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelSROrderOperationCompleted);
        }
        this.InvokeAsync("CancelSROrder", new object[] {
                                                           Login,
                                                           Password,
                                                           OrderID}, this.CancelSROrderOperationCompleted, userState);
    }
    
    private void OnCancelSROrderOperationCompleted(object arg) {
        if ((this.CancelSROrderCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.CancelSROrderCompleted(this, new CancelSROrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#CancelRun", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int CancelRun(string Login, string Password, int RunID) {
        object[] results = this.Invoke("CancelRun", new object[] {
                                                                     Login,
                                                                     Password,
                                                                     RunID});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginCancelRun(string Login, string Password, int RunID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("CancelRun", new object[] {
                                                              Login,
                                                              Password,
                                                              RunID}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndCancelRun(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void CancelRunAsync(string Login, string Password, int RunID) {
        this.CancelRunAsync(Login, Password, RunID, null);
    }
    
    /// <remarks/>
    public void CancelRunAsync(string Login, string Password, int RunID, object userState) {
        if ((this.CancelRunOperationCompleted == null)) {
            this.CancelRunOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelRunOperationCompleted);
        }
        this.InvokeAsync("CancelRun", new object[] {
                                                       Login,
                                                       Password,
                                                       RunID}, this.CancelRunOperationCompleted, userState);
    }
    
    private void OnCancelRunOperationCompleted(object arg) {
        if ((this.CancelRunCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.CancelRunCompleted(this, new CancelRunCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#SaveBookOrder_7", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public int SaveBookOrder_7(string Login, string Password, TBookOrder_7 BookOrder) {
        object[] results = this.Invoke("SaveBookOrder_7", new object[] {
                                                                           Login,
                                                                           Password,
                                                                           BookOrder});
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSaveBookOrder_7(string Login, string Password, TBookOrder_7 BookOrder, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("SaveBookOrder_7", new object[] {
                                                                    Login,
                                                                    Password,
                                                                    BookOrder}, callback, asyncState);
    }
    
    /// <remarks/>
    public int EndSaveBookOrder_7(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((int)(results[0]));
    }
    
    /// <remarks/>
    public void SaveBookOrder_7Async(string Login, string Password, TBookOrder_7 BookOrder) {
        this.SaveBookOrder_7Async(Login, Password, BookOrder, null);
    }
    
    /// <remarks/>
    public void SaveBookOrder_7Async(string Login, string Password, TBookOrder_7 BookOrder, object userState) {
        if ((this.SaveBookOrder_7OperationCompleted == null)) {
            this.SaveBookOrder_7OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveBookOrder_7OperationCompleted);
        }
        this.InvokeAsync("SaveBookOrder_7", new object[] {
                                                             Login,
                                                             Password,
                                                             BookOrder}, this.SaveBookOrder_7OperationCompleted, userState);
    }
    
    private void OnSaveBookOrder_7OperationCompleted(object arg) {
        if ((this.SaveBookOrder_7Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SaveBookOrder_7Completed(this, new SaveBookOrder_7CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrder_7", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrder_7 GetBookOrder_7(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        object[] results = this.Invoke("GetBookOrder_7", new object[] {
                                                                          Login,
                                                                          Password,
                                                                          OrderID,
                                                                          ContactPhone,
                                                                          CCNumber,
                                                                          AccountID});
        return ((TBookOrder_7)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrder_7(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrder_7", new object[] {
                                                                   Login,
                                                                   Password,
                                                                   OrderID,
                                                                   ContactPhone,
                                                                   CCNumber,
                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrder_7 EndGetBookOrder_7(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrder_7)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrder_7Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID) {
        this.GetBookOrder_7Async(Login, Password, OrderID, ContactPhone, CCNumber, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrder_7Async(string Login, string Password, int OrderID, string ContactPhone, string CCNumber, int AccountID, object userState) {
        if ((this.GetBookOrder_7OperationCompleted == null)) {
            this.GetBookOrder_7OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrder_7OperationCompleted);
        }
        this.InvokeAsync("GetBookOrder_7", new object[] {
                                                            Login,
                                                            Password,
                                                            OrderID,
                                                            ContactPhone,
                                                            CCNumber,
                                                            AccountID}, this.GetBookOrder_7OperationCompleted, userState);
    }
    
    private void OnGetBookOrder_7OperationCompleted(object arg) {
        if ((this.GetBookOrder_7Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrder_7Completed(this, new GetBookOrder_7CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetOrderHistory_7", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_7 GetOrderHistory_7(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        object[] results = this.Invoke("GetOrderHistory_7", new object[] {
                                                                             Login,
                                                                             Password,
                                                                             AccountID,
                                                                             FrDate,
                                                                             ToDate,
                                                                             OrderStatus});
        return ((TBookOrderList_7)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetOrderHistory_7(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetOrderHistory_7", new object[] {
                                                                      Login,
                                                                      Password,
                                                                      AccountID,
                                                                      FrDate,
                                                                      ToDate,
                                                                      OrderStatus}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_7 EndGetOrderHistory_7(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_7)(results[0]));
    }
    
    /// <remarks/>
    public void GetOrderHistory_7Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus) {
        this.GetOrderHistory_7Async(Login, Password, AccountID, FrDate, ToDate, OrderStatus, null);
    }
    
    /// <remarks/>
    public void GetOrderHistory_7Async(string Login, string Password, int AccountID, TWEBTimeStamp FrDate, TWEBTimeStamp ToDate, int OrderStatus, object userState) {
        if ((this.GetOrderHistory_7OperationCompleted == null)) {
            this.GetOrderHistory_7OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOrderHistory_7OperationCompleted);
        }
        this.InvokeAsync("GetOrderHistory_7", new object[] {
                                                               Login,
                                                               Password,
                                                               AccountID,
                                                               FrDate,
                                                               ToDate,
                                                               OrderStatus}, this.GetOrderHistory_7OperationCompleted, userState);
    }
    
    private void OnGetOrderHistory_7OperationCompleted(object arg) {
        if ((this.GetOrderHistory_7Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetOrderHistory_7Completed(this, new GetOrderHistory_7CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:WEBOrder_7Intf-IWEBOrder_7#GetBookOrderByConfirmationNo_7", RequestNamespace="urn:WEBOrder_7Intf-IWEBOrder_7", ResponseNamespace="urn:WEBOrder_7Intf-IWEBOrder_7")]
    [return: System.Xml.Serialization.SoapElementAttribute("return")]
    public TBookOrderList_7 GetBookOrderByConfirmationNo_7(string Login, string Password, int ConfirmationNo, int AccountID) {
        object[] results = this.Invoke("GetBookOrderByConfirmationNo_7", new object[] {
                                                                                          Login,
                                                                                          Password,
                                                                                          ConfirmationNo,
                                                                                          AccountID});
        return ((TBookOrderList_7)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetBookOrderByConfirmationNo_7(string Login, string Password, int ConfirmationNo, int AccountID, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetBookOrderByConfirmationNo_7", new object[] {
                                                                                   Login,
                                                                                   Password,
                                                                                   ConfirmationNo,
                                                                                   AccountID}, callback, asyncState);
    }
    
    /// <remarks/>
    public TBookOrderList_7 EndGetBookOrderByConfirmationNo_7(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((TBookOrderList_7)(results[0]));
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_7Async(string Login, string Password, int ConfirmationNo, int AccountID) {
        this.GetBookOrderByConfirmationNo_7Async(Login, Password, ConfirmationNo, AccountID, null);
    }
    
    /// <remarks/>
    public void GetBookOrderByConfirmationNo_7Async(string Login, string Password, int ConfirmationNo, int AccountID, object userState) {
        if ((this.GetBookOrderByConfirmationNo_7OperationCompleted == null)) {
            this.GetBookOrderByConfirmationNo_7OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOrderByConfirmationNo_7OperationCompleted);
        }
        this.InvokeAsync("GetBookOrderByConfirmationNo_7", new object[] {
                                                                            Login,
                                                                            Password,
                                                                            ConfirmationNo,
                                                                            AccountID}, this.GetBookOrderByConfirmationNo_7OperationCompleted, userState);
    }
    
    private void OnGetBookOrderByConfirmationNo_7OperationCompleted(object arg) {
        if ((this.GetBookOrderByConfirmationNo_7Completed != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetBookOrderByConfirmationNo_7Completed(this, new GetBookOrderByConfirmationNo_7CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeWEB")]
public enum TWEBOrderStatusValue
{

    /// <remarks/>
    wosNone,

    /// <remarks/>
    wosAddrValidQry,

    /// <remarks/>
    wosAddrValidating,

    /// <remarks/>
    wosAddrValidatingTimeout,

    /// <remarks/>
    wosAddrNotValid,

    /// <remarks/>
    wosAddrValid,

    /// <remarks/>
    wosSCHED,

    /// <remarks/>
    wosCANCELLED,

    /// <remarks/>
    wosPost,

    /// <remarks/>
    wosMove,

    /// <remarks/>
    wosMoved,

    /// <remarks/>
    wosDONE,

    /// <remarks/>
    wosWAITING,

    /// <remarks/>
    wosASSIGNED,

    /// <remarks/>
    wosARRIVED,

    /// <remarks/>
    wosLOADED,

    /// <remarks/>
    wosNOSHOW,

    /// <remarks/>
    wosAddrPostalValidQry,

    /// <remarks/>
    wosCANCELLED_DONE,

    /// <remarks/>
    wosCCPreauthQry,

    /// <remarks/>
    wosCCSaleQry,

    /// <remarks/>
    wosCCProcessing,

    /// <remarks/>
    wosCCProcDone,

    /// <remarks/>
    wosPriceQry,

    /// <remarks/>
    wosPriceCalculating,

    /// <remarks/>
    wosPriceDone,

    /// <remarks/>
    wosReportQry,

    /// <remarks/>
    wosReportProcessing,

    /// <remarks/>
    wosReportDone,

    /// <remarks/>
    wosCCEncryptCCInfo,

    /// <remarks/>
    wosCCEncryptCCInfoDone,
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TRun))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_2))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_3))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_4))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_5))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_6))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_7))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder
{

    private int serviceProviderIDField;

    private int confirmationIDField;

    private int accountIDField;

    private string customerField;

    private string phoneField;

    private TWEBTimeStamp pickupDateField;

    private TWEBTimeStamp pickupTimeField;

    private TWEBAddress pickupAddressField;

    private TWEBAddress dropoffAddressField;

    private int passengersField;

    private string vehicleTypeNameField;

    private int vehicleTypeIDField;

    private string noteField;

    private string contactPhoneField;

    private double fareField;

    private double tollsField;

    private double estDistanceField;

    private string cCNumberField;

    private string cCExpMonthField;

    private string cCExpYearField;

    private int cCTransIDField;

    private string cCHolderField;

    private string cCStartMonthField;

    private string cCStartYearField;

    private string cCSecurityCodeField;

    private string cCIssueNumberField;

    private string cCTransDateField;

    private TCCTransResult cCTransResultField;

    private string cCRespondTextField;

    private string cCAuthField;

    private TWEBOrderStatusValue orderStatusField;

    private int orderIDField;

    private TWEBTimeStamp orderDateField;

    /// <remarks/>
    public int ServiceProviderID
    {
        get
        {
            return this.serviceProviderIDField;
        }
        set
        {
            this.serviceProviderIDField = value;
        }
    }

    /// <remarks/>
    public int ConfirmationID
    {
        get
        {
            return this.confirmationIDField;
        }
        set
        {
            this.confirmationIDField = value;
        }
    }

    /// <remarks/>
    public int AccountID
    {
        get
        {
            return this.accountIDField;
        }
        set
        {
            this.accountIDField = value;
        }
    }

    /// <remarks/>
    public string Customer
    {
        get
        {
            return this.customerField;
        }
        set
        {
            this.customerField = value;
        }
    }

    /// <remarks/>
    public string Phone
    {
        get
        {
            return this.phoneField;
        }
        set
        {
            this.phoneField = value;
        }
    }

    /// <remarks/>
    public TWEBTimeStamp PickupDate
    {
        get
        {
            return this.pickupDateField;
        }
        set
        {
            this.pickupDateField = value;
        }
    }

    /// <remarks/>
    public TWEBTimeStamp PickupTime
    {
        get
        {
            return this.pickupTimeField;
        }
        set
        {
            this.pickupTimeField = value;
        }
    }

    /// <remarks/>
    public TWEBAddress PickupAddress
    {
        get
        {
            return this.pickupAddressField;
        }
        set
        {
            this.pickupAddressField = value;
        }
    }

    /// <remarks/>
    public TWEBAddress DropoffAddress
    {
        get
        {
            return this.dropoffAddressField;
        }
        set
        {
            this.dropoffAddressField = value;
        }
    }

    /// <remarks/>
    public int Passengers
    {
        get
        {
            return this.passengersField;
        }
        set
        {
            this.passengersField = value;
        }
    }

    /// <remarks/>
    public string VehicleTypeName
    {
        get
        {
            return this.vehicleTypeNameField;
        }
        set
        {
            this.vehicleTypeNameField = value;
        }
    }

    /// <remarks/>
    public int VehicleTypeID
    {
        get
        {
            return this.vehicleTypeIDField;
        }
        set
        {
            this.vehicleTypeIDField = value;
        }
    }

    /// <remarks/>
    public string Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    /// <remarks/>
    public string ContactPhone
    {
        get
        {
            return this.contactPhoneField;
        }
        set
        {
            this.contactPhoneField = value;
        }
    }

    /// <remarks/>
    public double Fare
    {
        get
        {
            return this.fareField;
        }
        set
        {
            this.fareField = value;
        }
    }

    /// <remarks/>
    public double Tolls
    {
        get
        {
            return this.tollsField;
        }
        set
        {
            this.tollsField = value;
        }
    }

    /// <remarks/>
    public double EstDistance
    {
        get
        {
            return this.estDistanceField;
        }
        set
        {
            this.estDistanceField = value;
        }
    }

    /// <remarks/>
    public string CCNumber
    {
        get
        {
            return this.cCNumberField;
        }
        set
        {
            this.cCNumberField = value;
        }
    }

    /// <remarks/>
    public string CCExpMonth
    {
        get
        {
            return this.cCExpMonthField;
        }
        set
        {
            this.cCExpMonthField = value;
        }
    }

    /// <remarks/>
    public string CCExpYear
    {
        get
        {
            return this.cCExpYearField;
        }
        set
        {
            this.cCExpYearField = value;
        }
    }

    /// <remarks/>
    public int CCTransID
    {
        get
        {
            return this.cCTransIDField;
        }
        set
        {
            this.cCTransIDField = value;
        }
    }

    /// <remarks/>
    public string CCHolder
    {
        get
        {
            return this.cCHolderField;
        }
        set
        {
            this.cCHolderField = value;
        }
    }

    /// <remarks/>
    public string CCStartMonth
    {
        get
        {
            return this.cCStartMonthField;
        }
        set
        {
            this.cCStartMonthField = value;
        }
    }

    /// <remarks/>
    public string CCStartYear
    {
        get
        {
            return this.cCStartYearField;
        }
        set
        {
            this.cCStartYearField = value;
        }
    }

    /// <remarks/>
    public string CCSecurityCode
    {
        get
        {
            return this.cCSecurityCodeField;
        }
        set
        {
            this.cCSecurityCodeField = value;
        }
    }

    /// <remarks/>
    public string CCIssueNumber
    {
        get
        {
            return this.cCIssueNumberField;
        }
        set
        {
            this.cCIssueNumberField = value;
        }
    }

    /// <remarks/>
    public string CCTransDate
    {
        get
        {
            return this.cCTransDateField;
        }
        set
        {
            this.cCTransDateField = value;
        }
    }

    /// <remarks/>
    public TCCTransResult CCTransResult
    {
        get
        {
            return this.cCTransResultField;
        }
        set
        {
            this.cCTransResultField = value;
        }
    }

    /// <remarks/>
    public string CCRespondText
    {
        get
        {
            return this.cCRespondTextField;
        }
        set
        {
            this.cCRespondTextField = value;
        }
    }

    /// <remarks/>
    public string CCAuth
    {
        get
        {
            return this.cCAuthField;
        }
        set
        {
            this.cCAuthField = value;
        }
    }

    /// <remarks/>
    public TWEBOrderStatusValue OrderStatus
    {
        get
        {
            return this.orderStatusField;
        }
        set
        {
            this.orderStatusField = value;
        }
    }

    /// <remarks/>
    public int OrderID
    {
        get
        {
            return this.orderIDField;
        }
        set
        {
            this.orderIDField = value;
        }
    }

    /// <remarks/>
    public TWEBTimeStamp OrderDate
    {
        get
        {
            return this.orderDateField;
        }
        set
        {
            this.orderDateField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TWEBTimeStamp
{

    private int yearField;

    private int monthField;

    private int dayField;

    private int hourField;

    private int minuteField;

    private int secondField;

    private int fractionsField;

    /// <remarks/>
    public int Year
    {
        get
        {
            return this.yearField;
        }
        set
        {
            this.yearField = value;
        }
    }

    /// <remarks/>
    public int Month
    {
        get
        {
            return this.monthField;
        }
        set
        {
            this.monthField = value;
        }
    }

    /// <remarks/>
    public int Day
    {
        get
        {
            return this.dayField;
        }
        set
        {
            this.dayField = value;
        }
    }

    /// <remarks/>
    public int Hour
    {
        get
        {
            return this.hourField;
        }
        set
        {
            this.hourField = value;
        }
    }

    /// <remarks/>
    public int Minute
    {
        get
        {
            return this.minuteField;
        }
        set
        {
            this.minuteField = value;
        }
    }

    /// <remarks/>
    public int Second
    {
        get
        {
            return this.secondField;
        }
        set
        {
            this.secondField = value;
        }
    }

    /// <remarks/>
    public int Fractions
    {
        get
        {
            return this.fractionsField;
        }
        set
        {
            this.fractionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrderList_7
{

    private int orderCountField;

    private TBookOrder_7[] orderListField;

    /// <remarks/>
    public int OrderCount
    {
        get
        {
            return this.orderCountField;
        }
        set
        {
            this.orderCountField = value;
        }
    }

    /// <remarks/>
    public TBookOrder_7[] OrderList
    {
        get
        {
            return this.orderListField;
        }
        set
        {
            this.orderListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder_7 : TBookOrder_6
{

    private double tipsField;

    /// <remarks/>
    public double Tips
    {
        get
        {
            return this.tipsField;
        }
        set
        {
            this.tipsField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_7))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder_6 : TBookOrder_5
{

    private int priorityField;

    /// <remarks/>
    public int Priority
    {
        get
        {
            return this.priorityField;
        }
        set
        {
            this.priorityField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_6))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_7))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder_5 : TBookOrder_4
{

    private int chargeTypeIDField;

    private TException[] rideExceptionsField;

    private string cabNoField;

    private string callNumberField;

    private bool dispByAutoField;

    private string frCityField;

    private string frRegionField;

    private string toCityField;

    private string toRegionField;

    /// <remarks/>
    public int ChargeTypeID
    {
        get
        {
            return this.chargeTypeIDField;
        }
        set
        {
            this.chargeTypeIDField = value;
        }
    }

    /// <remarks/>
    public TException[] RideExceptions
    {
        get
        {
            return this.rideExceptionsField;
        }
        set
        {
            this.rideExceptionsField = value;
        }
    }

    /// <remarks/>
    public string CabNo
    {
        get
        {
            return this.cabNoField;
        }
        set
        {
            this.cabNoField = value;
        }
    }

    /// <remarks/>
    public string CallNumber
    {
        get
        {
            return this.callNumberField;
        }
        set
        {
            this.callNumberField = value;
        }
    }

    /// <remarks/>
    public bool DispByAuto
    {
        get
        {
            return this.dispByAutoField;
        }
        set
        {
            this.dispByAutoField = value;
        }
    }

    /// <remarks/>
    public string FrCity
    {
        get
        {
            return this.frCityField;
        }
        set
        {
            this.frCityField = value;
        }
    }

    /// <remarks/>
    public string FrRegion
    {
        get
        {
            return this.frRegionField;
        }
        set
        {
            this.frRegionField = value;
        }
    }

    /// <remarks/>
    public string ToCity
    {
        get
        {
            return this.toCityField;
        }
        set
        {
            this.toCityField = value;
        }
    }

    /// <remarks/>
    public string ToRegion
    {
        get
        {
            return this.toRegionField;
        }
        set
        {
            this.toRegionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TException
{

    private int exIDField;

    private string exNameField;

    private int exValueField;

    /// <remarks/>
    public int ExID
    {
        get
        {
            return this.exIDField;
        }
        set
        {
            this.exIDField = value;
        }
    }

    /// <remarks/>
    public string ExName
    {
        get
        {
            return this.exNameField;
        }
        set
        {
            this.exNameField = value;
        }
    }

    /// <remarks/>
    public int ExValue
    {
        get
        {
            return this.exValueField;
        }
        set
        {
            this.exValueField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_5))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_6))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_7))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder_4 : TBookOrder_3
{

    private string ccTypeField;

    private string ccFirstField;

    private string ccLastField;

    private string ccCityField;

    private string ccStateField;

    /// <remarks/>
    public string ccType
    {
        get
        {
            return this.ccTypeField;
        }
        set
        {
            this.ccTypeField = value;
        }
    }

    /// <remarks/>
    public string ccFirst
    {
        get
        {
            return this.ccFirstField;
        }
        set
        {
            this.ccFirstField = value;
        }
    }

    /// <remarks/>
    public string ccLast
    {
        get
        {
            return this.ccLastField;
        }
        set
        {
            this.ccLastField = value;
        }
    }

    /// <remarks/>
    public string ccCity
    {
        get
        {
            return this.ccCityField;
        }
        set
        {
            this.ccCityField = value;
        }
    }

    /// <remarks/>
    public string ccState
    {
        get
        {
            return this.ccStateField;
        }
        set
        {
            this.ccStateField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_4))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_5))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_6))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_7))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder_3 : TBookOrder_2
{

    private TWEBAddress[] rideStopsField;

    private bool txtBackField;

    private bool emailBackField;

    private bool callBackField;

    private string prompt1Field;

    private string prompt2Field;

    private string prompt3Field;

    private string prompt4Field;

    private string prompt5Field;

    private string prompt6Field;

    private string prompt7Field;

    private string prompt8Field;

    private string field1Field;

    private string field2Field;

    private string field3Field;

    private string field4Field;

    private string field5Field;

    private string field6Field;

    private string field7Field;

    private string field8Field;

    private string txtBackAddField;

    private string emailBackAddField;

    private string callBackNoField;

    private string cCAddressField;

    private string cCPostCodeField;

    private int rideIDField;

    /// <remarks/>
    public TWEBAddress[] RideStops
    {
        get
        {
            return this.rideStopsField;
        }
        set
        {
            this.rideStopsField = value;
        }
    }

    /// <remarks/>
    public bool TxtBack
    {
        get
        {
            return this.txtBackField;
        }
        set
        {
            this.txtBackField = value;
        }
    }

    /// <remarks/>
    public bool EmailBack
    {
        get
        {
            return this.emailBackField;
        }
        set
        {
            this.emailBackField = value;
        }
    }

    /// <remarks/>
    public bool CallBack
    {
        get
        {
            return this.callBackField;
        }
        set
        {
            this.callBackField = value;
        }
    }

    /// <remarks/>
    public string Prompt1
    {
        get
        {
            return this.prompt1Field;
        }
        set
        {
            this.prompt1Field = value;
        }
    }

    /// <remarks/>
    public string Prompt2
    {
        get
        {
            return this.prompt2Field;
        }
        set
        {
            this.prompt2Field = value;
        }
    }

    /// <remarks/>
    public string Prompt3
    {
        get
        {
            return this.prompt3Field;
        }
        set
        {
            this.prompt3Field = value;
        }
    }

    /// <remarks/>
    public string Prompt4
    {
        get
        {
            return this.prompt4Field;
        }
        set
        {
            this.prompt4Field = value;
        }
    }

    /// <remarks/>
    public string Prompt5
    {
        get
        {
            return this.prompt5Field;
        }
        set
        {
            this.prompt5Field = value;
        }
    }

    /// <remarks/>
    public string Prompt6
    {
        get
        {
            return this.prompt6Field;
        }
        set
        {
            this.prompt6Field = value;
        }
    }

    /// <remarks/>
    public string Prompt7
    {
        get
        {
            return this.prompt7Field;
        }
        set
        {
            this.prompt7Field = value;
        }
    }

    /// <remarks/>
    public string Prompt8
    {
        get
        {
            return this.prompt8Field;
        }
        set
        {
            this.prompt8Field = value;
        }
    }

    /// <remarks/>
    public string Field1
    {
        get
        {
            return this.field1Field;
        }
        set
        {
            this.field1Field = value;
        }
    }

    /// <remarks/>
    public string Field2
    {
        get
        {
            return this.field2Field;
        }
        set
        {
            this.field2Field = value;
        }
    }

    /// <remarks/>
    public string Field3
    {
        get
        {
            return this.field3Field;
        }
        set
        {
            this.field3Field = value;
        }
    }

    /// <remarks/>
    public string Field4
    {
        get
        {
            return this.field4Field;
        }
        set
        {
            this.field4Field = value;
        }
    }

    /// <remarks/>
    public string Field5
    {
        get
        {
            return this.field5Field;
        }
        set
        {
            this.field5Field = value;
        }
    }

    /// <remarks/>
    public string Field6
    {
        get
        {
            return this.field6Field;
        }
        set
        {
            this.field6Field = value;
        }
    }

    /// <remarks/>
    public string Field7
    {
        get
        {
            return this.field7Field;
        }
        set
        {
            this.field7Field = value;
        }
    }

    /// <remarks/>
    public string Field8
    {
        get
        {
            return this.field8Field;
        }
        set
        {
            this.field8Field = value;
        }
    }

    /// <remarks/>
    public string TxtBackAdd
    {
        get
        {
            return this.txtBackAddField;
        }
        set
        {
            this.txtBackAddField = value;
        }
    }

    /// <remarks/>
    public string EmailBackAdd
    {
        get
        {
            return this.emailBackAddField;
        }
        set
        {
            this.emailBackAddField = value;
        }
    }

    /// <remarks/>
    public string CallBackNo
    {
        get
        {
            return this.callBackNoField;
        }
        set
        {
            this.callBackNoField = value;
        }
    }

    /// <remarks/>
    public string CCAddress
    {
        get
        {
            return this.cCAddressField;
        }
        set
        {
            this.cCAddressField = value;
        }
    }

    /// <remarks/>
    public string CCPostCode
    {
        get
        {
            return this.cCPostCodeField;
        }
        set
        {
            this.cCPostCodeField = value;
        }
    }

    /// <remarks/>
    public int RideID
    {
        get
        {
            return this.rideIDField;
        }
        set
        {
            this.rideIDField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TWEBFavotiteAddress))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TWEBAddress
{

    private string streetPlaceField;

    private string aptBazField;

    private string postalField;

    private int cityIDField;

    private int regionIDField;

    private int countryIDField;

    private double longitudeField;

    private double latitudeField;

    private int addressIDField;

    private TWEBTimeStamp stopTimeField;

    private int stopOrderField;

    private int runOrderField;

    private int stopPassField;

    /// <remarks/>
    public string StreetPlace
    {
        get
        {
            return this.streetPlaceField;
        }
        set
        {
            this.streetPlaceField = value;
        }
    }

    /// <remarks/>
    public string AptBaz
    {
        get
        {
            return this.aptBazField;
        }
        set
        {
            this.aptBazField = value;
        }
    }

    /// <remarks/>
    public string Postal
    {
        get
        {
            return this.postalField;
        }
        set
        {
            this.postalField = value;
        }
    }

    /// <remarks/>
    public int CityID
    {
        get
        {
            return this.cityIDField;
        }
        set
        {
            this.cityIDField = value;
        }
    }

    /// <remarks/>
    public int RegionID
    {
        get
        {
            return this.regionIDField;
        }
        set
        {
            this.regionIDField = value;
        }
    }

    /// <remarks/>
    public int CountryID
    {
        get
        {
            return this.countryIDField;
        }
        set
        {
            this.countryIDField = value;
        }
    }

    /// <remarks/>
    public double Longitude
    {
        get
        {
            return this.longitudeField;
        }
        set
        {
            this.longitudeField = value;
        }
    }

    /// <remarks/>
    public double Latitude
    {
        get
        {
            return this.latitudeField;
        }
        set
        {
            this.latitudeField = value;
        }
    }

    /// <remarks/>
    public int AddressID
    {
        get
        {
            return this.addressIDField;
        }
        set
        {
            this.addressIDField = value;
        }
    }

    /// <remarks/>
    public TWEBTimeStamp StopTime
    {
        get
        {
            return this.stopTimeField;
        }
        set
        {
            this.stopTimeField = value;
        }
    }

    /// <remarks/>
    public int StopOrder
    {
        get
        {
            return this.stopOrderField;
        }
        set
        {
            this.stopOrderField = value;
        }
    }

    /// <remarks/>
    public int RunOrder
    {
        get
        {
            return this.runOrderField;
        }
        set
        {
            this.runOrderField = value;
        }
    }

    /// <remarks/>
    public int StopPass
    {
        get
        {
            return this.stopPassField;
        }
        set
        {
            this.stopPassField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TWEBFavotiteAddress : TWEBAddress
{

    private string addressAliasField;

    /// <remarks/>
    public string AddressAlias
    {
        get
        {
            return this.addressAliasField;
        }
        set
        {
            this.addressAliasField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_3))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_4))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_5))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_6))]
[System.Xml.Serialization.SoapIncludeAttribute(typeof(TBookOrder_7))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrder_2 : TBookOrder
{

    private string orderedByField;

    private string majorIntersectField;

    private int cancelNumField;

    private string airlineField;

    private string flightField;

    private TWEBTimeStamp arrivalField;

    private string airportCodeField;

    private string crewAuthorizField;

    private string permanentRemField;

    /// <remarks/>
    public string OrderedBy
    {
        get
        {
            return this.orderedByField;
        }
        set
        {
            this.orderedByField = value;
        }
    }

    /// <remarks/>
    public string MajorIntersect
    {
        get
        {
            return this.majorIntersectField;
        }
        set
        {
            this.majorIntersectField = value;
        }
    }

    /// <remarks/>
    public int CancelNum
    {
        get
        {
            return this.cancelNumField;
        }
        set
        {
            this.cancelNumField = value;
        }
    }

    /// <remarks/>
    public string Airline
    {
        get
        {
            return this.airlineField;
        }
        set
        {
            this.airlineField = value;
        }
    }

    /// <remarks/>
    public string Flight
    {
        get
        {
            return this.flightField;
        }
        set
        {
            this.flightField = value;
        }
    }

    /// <remarks/>
    public TWEBTimeStamp Arrival
    {
        get
        {
            return this.arrivalField;
        }
        set
        {
            this.arrivalField = value;
        }
    }

    /// <remarks/>
    public string AirportCode
    {
        get
        {
            return this.airportCodeField;
        }
        set
        {
            this.airportCodeField = value;
        }
    }

    /// <remarks/>
    public string CrewAuthoriz
    {
        get
        {
            return this.crewAuthorizField;
        }
        set
        {
            this.crewAuthorizField = value;
        }
    }

    /// <remarks/>
    public string PermanentRem
    {
        get
        {
            return this.permanentRemField;
        }
        set
        {
            this.permanentRemField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrderList_6
{

    private int orderCountField;

    private TBookOrder_6[] orderListField;

    /// <remarks/>
    public int OrderCount
    {
        get
        {
            return this.orderCountField;
        }
        set
        {
            this.orderCountField = value;
        }
    }

    /// <remarks/>
    public TBookOrder_6[] OrderList
    {
        get
        {
            return this.orderListField;
        }
        set
        {
            this.orderListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrderList_5
{

    private int orderCountField;

    private TBookOrder_5[] orderListField;

    /// <remarks/>
    public int OrderCount
    {
        get
        {
            return this.orderCountField;
        }
        set
        {
            this.orderCountField = value;
        }
    }

    /// <remarks/>
    public TBookOrder_5[] OrderList
    {
        get
        {
            return this.orderListField;
        }
        set
        {
            this.orderListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrderList_4
{

    private int orderCountField;

    private TBookOrder_4[] orderListField;

    /// <remarks/>
    public int OrderCount
    {
        get
        {
            return this.orderCountField;
        }
        set
        {
            this.orderCountField = value;
        }
    }

    /// <remarks/>
    public TBookOrder_4[] OrderList
    {
        get
        {
            return this.orderListField;
        }
        set
        {
            this.orderListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TBookOrderList_3
{

    private int orderCountField;

    private TBookOrder_3[] orderListField;

    /// <remarks/>
    public int OrderCount
    {
        get
        {
            return this.orderCountField;
        }
        set
        {
            this.orderCountField = value;
        }
    }

    /// <remarks/>
    public TBookOrder_3[] OrderList
    {
        get
        {
            return this.orderListField;
        }
        set
        {
            this.orderListField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeWEB")]
public enum TCCTransResult
{

    /// <remarks/>
    ctrNone,

    /// <remarks/>
    ctrDeclined,

    /// <remarks/>
    ctrApproved,

    /// <remarks/>
    ctrTimeout,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace = "urn:TypeOrder")]
public partial class TRun : TBookOrder
{

    private string runNumField;

    private TBookOrder_6[] runRidesField;

    /// <remarks/>
    public string RunNum
    {
        get
        {
            return this.runNumField;
        }
        set
        {
            this.runNumField = value;
        }
    }

    /// <remarks/>
    public TBookOrder_6[] RunRides
    {
        get
        {
            return this.runRidesField;
        }
        set
        {
            this.runRidesField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetOrderStatusCompletedEventHandler(object sender, GetOrderStatusCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetOrderStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetOrderStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TWEBOrderStatusValue Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TWEBOrderStatusValue)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrderCompletedEventHandler(object sender, GetBookOrderCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrderCompletedEventHandler(object sender, SaveBookOrderCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrderWrapperCompletedEventHandler(object sender, SaveBookOrderWrapperCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrderWrapperCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrderWrapperCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void CancelBookOrderCompletedEventHandler(object sender, CancelBookOrderCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CancelBookOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal CancelBookOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetHeartBeatCompletedEventHandler(object sender, GetHeartBeatCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetHeartBeatCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetHeartBeatCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TWEBTimeStamp Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TWEBTimeStamp)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void DeleteBookOrderCompletedEventHandler(object sender, DeleteBookOrderCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DeleteBookOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal DeleteBookOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetFareTollsDistanceCompletedEventHandler(object sender, GetFareTollsDistanceCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetFareTollsDistanceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetFareTollsDistanceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }

    /// <remarks/>
    public double Fare
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[1]));
        }
    }

    /// <remarks/>
    public double Tolls
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[2]));
        }
    }

    /// <remarks/>
    public double Distance
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[3]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetVehicleLocationCompletedEventHandler(object sender, GetVehicleLocationCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetVehicleLocationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetVehicleLocationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }

    /// <remarks/>
    public double Lon
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[1]));
        }
    }

    /// <remarks/>
    public double Lat
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[2]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetDriverLocationCompletedEventHandler(object sender, GetDriverLocationCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetDriverLocationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetDriverLocationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }

    /// <remarks/>
    public double Lon
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[1]));
        }
    }

    /// <remarks/>
    public double Lat
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[2]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SendDriverMsgCompletedEventHandler(object sender, SendDriverMsgCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SendDriverMsgCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SendDriverMsgCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveExtrPaymentCompletedEventHandler(object sender, SaveExtrPaymentCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveExtrPaymentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveExtrPaymentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrder_2CompletedEventHandler(object sender, GetBookOrder_2CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrder_2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrder_2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder_2 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder_2)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrder_2CompletedEventHandler(object sender, SaveBookOrder_2CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrder_2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrder_2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrder_3CompletedEventHandler(object sender, GetBookOrder_3CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrder_3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrder_3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder_3 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder_3)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrder_3CompletedEventHandler(object sender, SaveBookOrder_3CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrder_3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrder_3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrderWithCarCompletedEventHandler(object sender, SaveBookOrderWithCarCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrderWithCarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrderWithCarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetOrderHistoryCompletedEventHandler(object sender, GetOrderHistoryCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetOrderHistoryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetOrderHistoryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_3 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_3)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrderByConfirmationNoCompletedEventHandler(object sender, GetBookOrderByConfirmationNoCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrderByConfirmationNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrderByConfirmationNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_3 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_3)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrder_4CompletedEventHandler(object sender, SaveBookOrder_4CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrder_4CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrder_4CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrder_4CompletedEventHandler(object sender, GetBookOrder_4CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrder_4CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrder_4CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder_4 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder_4)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetVehicleLocationWithTaxiNoCompletedEventHandler(object sender, GetVehicleLocationWithTaxiNoCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetVehicleLocationWithTaxiNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetVehicleLocationWithTaxiNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }

    /// <remarks/>
    public double Lon
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[1]));
        }
    }

    /// <remarks/>
    public double Lat
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((double)(this.results[2]));
        }
    }

    /// <remarks/>
    public TWEBTimeStamp LastGPSUpdate
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TWEBTimeStamp)(this.results[3]));
        }
    }

    /// <remarks/>
    public string TaxiNo
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[4]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void AddressCorrelationCompletedEventHandler(object sender, AddressCorrelationCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AddressCorrelationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal AddressCorrelationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TWEBFavotiteAddress[] Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TWEBFavotiteAddress[])(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetOrderHistory_4CompletedEventHandler(object sender, GetOrderHistory_4CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetOrderHistory_4CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetOrderHistory_4CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_4 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_4)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrderByConfirmationNo_4CompletedEventHandler(object sender, GetBookOrderByConfirmationNo_4CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrderByConfirmationNo_4CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrderByConfirmationNo_4CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_4 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_4)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrder_5CompletedEventHandler(object sender, SaveBookOrder_5CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrder_5CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrder_5CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrder_5CompletedEventHandler(object sender, GetBookOrder_5CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrder_5CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrder_5CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder_5 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder_5)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetOrderHistory_5CompletedEventHandler(object sender, GetOrderHistory_5CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetOrderHistory_5CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetOrderHistory_5CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_5 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_5)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrderByConfirmationNo_5CompletedEventHandler(object sender, GetBookOrderByConfirmationNo_5CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrderByConfirmationNo_5CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrderByConfirmationNo_5CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_5 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_5)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrder_6CompletedEventHandler(object sender, SaveBookOrder_6CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrder_6CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrder_6CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrder_6CompletedEventHandler(object sender, GetBookOrder_6CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrder_6CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrder_6CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder_6 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder_6)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetOrderHistory_6CompletedEventHandler(object sender, GetOrderHistory_6CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetOrderHistory_6CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetOrderHistory_6CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_6 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_6)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrderByConfirmationNo_6CompletedEventHandler(object sender, GetBookOrderByConfirmationNo_6CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrderByConfirmationNo_6CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrderByConfirmationNo_6CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_6 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_6)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveRunCompletedEventHandler(object sender, SaveRunCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveRunCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveRunCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetRunCompletedEventHandler(object sender, GetRunCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetRunCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetRunCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TRun Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TRun)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void CancelSROrderCompletedEventHandler(object sender, CancelSROrderCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CancelSROrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal CancelSROrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void CancelRunCompletedEventHandler(object sender, CancelRunCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CancelRunCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal CancelRunCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void SaveBookOrder_7CompletedEventHandler(object sender, SaveBookOrder_7CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SaveBookOrder_7CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal SaveBookOrder_7CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public int Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((int)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrder_7CompletedEventHandler(object sender, GetBookOrder_7CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrder_7CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrder_7CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrder_7 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrder_7)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetOrderHistory_7CompletedEventHandler(object sender, GetOrderHistory_7CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetOrderHistory_7CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetOrderHistory_7CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_7 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_7)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetBookOrderByConfirmationNo_7CompletedEventHandler(object sender, GetBookOrderByConfirmationNo_7CompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetBookOrderByConfirmationNo_7CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
{

    private object[] results;

    internal GetBookOrderByConfirmationNo_7CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
        base(exception, cancelled, userState)
    {
        this.results = results;
    }

    /// <remarks/>
    public TBookOrderList_7 Result
    {
        get
        {
            this.RaiseExceptionIfNecessary();
            return ((TBookOrderList_7)(this.results[0]));
        }
    }
}
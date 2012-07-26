﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace apcurium.MK.Booking.Api.Contract.Requests
{
    [RestService("/accounts/Register", "POST")]
    public class RegisterAccount : BaseDTO
    {
        public Guid AccountId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }        

        public string Password { get; set; }

        public string Phone { get; set; }

        public string FacebookId { get; set; }

        public string TwitterId { get; set; }

        public string Language { get; set; }
        
    }
}

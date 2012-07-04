﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Messaging.Handling;
using apcurium.MK.Booking.Events;
using apcurium.MK.Booking.Database;
using apcurium.MK.Booking.ReadModel;
using Infrastructure.Messaging;
using apcurium.MK.Booking.IBS;

namespace apcurium.MK.Booking.EventHandlers
{
    public class AccountDetailsGenerator : IEventHandler<AccountRegistered>, IEventHandler<AccountUpdated>
    {
        private readonly Func<BookingDbContext> _contextFactory;

        private IWebServiceClient _webServiceClient;

        public AccountDetailsGenerator(Func<BookingDbContext> contextFactory, IWebServiceClient webServiceClient)
        {
            _contextFactory = contextFactory;
            _webServiceClient = webServiceClient;
        }

        public void Handle(AccountRegistered @event)
        {
            using (var context = _contextFactory.Invoke())
            {
                var ibsAccountId = _webServiceClient.CreateAccount(@event.SourceId, @event.Email, @event.FirstName, @event.LastName, @event.Phone);
                context.Save(new AccountDetail
                {
                    FirstName = @event.FirstName,
                    LastName = @event.LastName,
                    Email = @event.Email,
                    Password = @event.Password,
                    Phone = @event.Phone,
                    Id = @event.SourceId,
                    IBSAccountid = ibsAccountId
                });

            }



        }

        public void Handle(AccountUpdated @event)
        {
            using (var context = _contextFactory.Invoke())
            {
                var account = context.Find<AccountDetail>(@event.SourceId);
                account.FirstName = @event.FirstName;
                account.LastName = @event.LastName;

                context.Save(account);
            }
        }
    }
}

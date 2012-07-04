﻿using System;

using Infrastructure.Messaging;

namespace apcurium.MK.Booking.Commands
{
    public class AddFavoriteAddress : ICommand
    {
        public AddFavoriteAddress()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string FriendlyName { get; set; }
        public string FullAddress { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Apartment { get; set; }
        public string RingCode { get; set; }

    }
}

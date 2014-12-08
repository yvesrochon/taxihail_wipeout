﻿using System;
using Infrastructure.Messaging;

namespace apcurium.MK.Booking.Commands
{
    public class ActivatePromotion : ICommand
    {
        public ActivatePromotion()
        {
            Id = Guid.NewGuid();
        }

        public Guid PromoId { get; set; }

        public Guid Id { get; private set; }
    }
}
﻿using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Common.Http;
using apcurium.MK.Common.Http.Response;

namespace apcurium.MK.Booking.Api.Contract.Requests
{
    [RouteDescription("/promotions/", "GET")]
    public class ActivePromotions : IReturn<ActivePromotion[]>
    {
    }
}
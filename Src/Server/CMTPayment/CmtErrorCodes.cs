﻿
namespace CMTPayment
{
    public static class CmtErrorCodes
    {
        // TripInfo Codes
        public const int TripNotFound = 441;

        public const int UnableToPair = 103;

		public const int CreditCardDeclinedOnPreauthorization = 104;

		public const int UnablePreauthorizeCreditCard = 110;

        public const int TripUnpaired = 111;

        public const int TripEndedNoPairing = 112;

        public const int PairingTimedOut = 113; 

        public const int CardDeclined = 114;

        public const int PaymentProcessingError = 115;
        // TripInfo Codes
    }
}
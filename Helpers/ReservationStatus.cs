using System.ComponentModel;

namespace TestWebApi.Helpers
{
    public enum ReservationStatus : byte
    {
        Free = 0,

        Reserved = 1
    }

    public static class ReservationStatusHelper
    {
        public static string GetStatusString(ReservationStatus status)
        {
            switch (status)
            {
                case ReservationStatus.Free:
                    return "Free";
                case ReservationStatus.Reserved:
                    return "Reserved";
            }

            return "No status";
        }
    }
}
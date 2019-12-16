using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Payments;

namespace ProjectWindowsVliegtuig.Util
{
    public static class PriceStringUtilities
    {
        private static readonly CultureInfo EURCulture = new CultureInfo("nl-BE");

        public static readonly string Currency = "EUR";

        /// <summary>
        /// Correctly formats a price as a string.
        /// </summary>
        public static string CreatePriceString(decimal cost)
        {
            return String.Format(EURCulture, "{0:C}", cost);
        }

        public static string CreatePriceString(PaymentCurrencyAmount cost)
        {
            decimal value = FromInvariantString(cost.Value);
            return String.Format(EURCulture, "{0:C}", value);
        }

        public static string ToInvariantString(decimal cost)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:F2}", cost);
        }

        public static decimal FromInvariantString(string value)
        {
            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}

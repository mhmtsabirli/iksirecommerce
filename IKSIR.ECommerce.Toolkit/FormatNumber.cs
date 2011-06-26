using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;

namespace IKSIR.ECommerce.Toolkit
{
    public class NumberManipulation
    {
        /// <summary>
        /// Gets a formatted number string and changes its formatting according to the desired culture.
        /// This works only for plain numbers, not numbers with currency symbol etc...
        /// </summary>
        /// <param name="numberString">The current number as string</param>
        /// <param name="inCulture">The received culture representing the number</param>
        /// <param name="outCulture">The desired culture to represent the number</param>
        /// <returns>New string representing the number with the outGoingCulture</returns>
        public static String ChangeNumberFormatByCulture(string numberString, CultureInfo inCulture, CultureInfo outCulture)
        {
            Double number = Double.Parse(
                numberString,
                NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint,
                inCulture.NumberFormat
                );
            string tempNumber = number < 1 ? "0" + number.ToString("#,##.00") : number.ToString("#,##.00");
            string formattedNumber = String.Format(outCulture.NumberFormat, "{0}", tempNumber);

            return formattedNumber;
        }

        /// <summary>
        /// Gets a formatted number string and changes its formatting according to the server's current culture.
        /// This works only for plain numbers, not numbers with currency symbol etc...
        /// </summary>
        /// <param name="numberString">The current number as string</param>
        /// <param name="inCulture">The received culture representing the number</param>
        /// <returns>New string representing the number with the outGoingCulture</returns>
        public static String ChangeNumberFormatByCulture(string numberString, CultureInfo inCulture)
        {
            CultureInfo outCulture = Thread.CurrentThread.CurrentCulture;
            return ChangeNumberFormatByCulture(numberString, inCulture, outCulture);
        }
    }
}

using System;
using Myob.Fma.Payslip.IncomeProcessing.Interfaces;

namespace Myob.Fma.Payslip.DateProcessing
{
    public class PayPeriod : IPayPeriod
    {   public DateTime Start { get; private set; }
        public DateTime End { get; private set; }


        public static PayPeriod Generate(string startDate, string endDate)
        {
            if (string.IsNullOrWhiteSpace(startDate) || string.IsNullOrWhiteSpace(endDate))
                throw new Exception("Date must not be left blank");

            var startDateAsDateTime = ConvertStringToDateTimeFormat(startDate);
            var endDateAsDateTime = ConvertStringToDateTimeFormat(endDate);
            
            if (endDateAsDateTime <= startDateAsDateTime)
                throw new Exception("End date must be larger than start date");
            
            return new PayPeriod{Start = startDateAsDateTime, End = endDateAsDateTime};
        }

        private static DateTime ConvertStringToDateTimeFormat(string date)
        {
            try
            {
                return DateTime.Parse(date);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Date is in an invalid format, try entering something like '1 March' {e}");
                throw;
            }
        }
    }
}
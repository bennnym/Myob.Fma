using System;

namespace Myob.Fma.Payslip.UserInputs
{
    public static class StandardMessage
    {
        public static string CaptureData(string field)
        {
            Console.WriteLine($"Please input your {field}:");
            return Console.ReadLine();
        }
    }
}
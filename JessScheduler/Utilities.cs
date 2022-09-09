using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JessScheduler
{
    public class Utilities
    {
        public static string FormatPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                return String.Format("{0:###-###-####}", Int64.Parse(phoneNumber));
            }
            else
                return phoneNumber;
        }

        public static string UnformatPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Replace("-", "");
        }
    }
}

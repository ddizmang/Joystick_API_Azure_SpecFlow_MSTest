using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick_API_Azure_SpecFlow_MSTest.Domain.Operations
{
    public static class EnvironmentOperations
    {
        public static string GetEnvironmentName()
        {
            var value = "";
            try
            {

                value = Environment.GetEnvironmentVariable("ENVIRONMENT");

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Environment Helper : GetEnvironmentName");
                Debug.WriteLine($"Error Message : {e.Message}");
                Debug.WriteLine($"Error Stack : {e.StackTrace}");
            }

            return value;
        }
    }
}

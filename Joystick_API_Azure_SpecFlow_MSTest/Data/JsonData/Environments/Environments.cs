using Joystick_API_Azure_SpecFlow_MSTest.Domain.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick_API_Azure_SpecFlow_MSTest.Data.JsonData.Environments
{
    public class Environments
    {
        public string Environment { get; set; }
        public string URL { get; set; }
        public string RabbitHostName { get; set; }
        public string RabbitUserName { get; set; }
        public string RabbitPassword { get; set; }
        public List<Environments> GetEnvironmentDetails()
        {
            List<Environments> allEnvironments = null;

            //TODO: Switch JSONPath to Resources class
            //allEnvironments = JsonHelper
            //    .GetObjectData<AppEnvironment>(Resources.JSonDataFileLocation + "Environment.json").Environments;
            allEnvironments =
                JsonOperations.GetObjectData<AppEnvironment>(".\\Data\\JsonData\\Environments\\Environment.json").Environments;
            return allEnvironments;
        }
        public class AppEnvironment
        {
            public List<Environments> Environments { get; set; }
        }
    }
}

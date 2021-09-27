using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick_API_Azure_SpecFlow_MSTest.Domain.Operations
{
    public static class JsonOperations
    {
        public static T GetObjectData<T>(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}

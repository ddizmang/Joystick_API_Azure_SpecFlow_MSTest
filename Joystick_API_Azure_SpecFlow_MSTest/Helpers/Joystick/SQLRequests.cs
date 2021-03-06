using Joystick_API_Azure_SpecFlow_MSTest.Domain.Models.Joystick;
using Joystick_API_Azure_SpecFlow_MSTest.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick_API_Azure_SpecFlow_MSTest.Helpers.Joystick
{
    public static class SQLRequests
    {
        public static APIResponse SqlServerRequest(string scenarioTitle, string sqlConnection, string sqlQuery)
        {
            APIResponse apiResponse = new APIResponse();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = sqlConnection;
                    conn.Open();
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        apiResponse.RequestDurationMilliseconds = stopWatch.ElapsedMilliseconds.ToString();
                        stopWatch.Stop();
                        sdr.Read();
                        apiResponse.TestName = scenarioTitle;
                        apiResponse.Environment = TestRun_Resources.AppEnv.ToString();
                        apiResponse.RequestType = "SqlServerRequest-JSON";
                        apiResponse.RequestBody = sqlQuery;
                        apiResponse.ResponseCode = "Success";
                        apiResponse.ResponseBody = sdr.GetValue(0).ToString().Replace("\"", "'");
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return apiResponse;
        }
    }
}

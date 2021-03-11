using BankConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BankConsoleApp.HelperClassData
{
   public class BankAPIHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44320/");
            return client;
        }


        public AllEmployeeDetails GetAllEmployeeBankDetails()
        {
            var webClient = new WebClient();

            var json = webClient.DownloadString(@"C:\Users\Limbot Express\source\repos\BankAPI\BankWEB\wwwroot\json\employee.config.json");


            var allEmployeeBankDetails = JsonConvert.DeserializeObject<AllEmployeeDetails>(json);

            return allEmployeeBankDetails;

        }
    }
}

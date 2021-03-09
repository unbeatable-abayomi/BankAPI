using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankWEB.Models;
using BankWEB.HelperClassData;
using System.Net.Http;
using Newtonsoft.Json;

namespace BankWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BankAPIHelper bankAPIHelper = new BankAPIHelper();
        List<CorrectBankDetails> correctBankDetails = new List<CorrectBankDetails>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeBankDetails> bankDetails = new List<EmployeeBankDetails>();
            HttpClient client = bankAPIHelper.Initial();

            var helperDataClass = new BankAPIHelper();

            var details = helperDataClass.GetAllEmployeeBankDetails();

            foreach (var d in details.employee)
            {
                //string bankName = d.bankName;
                HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);
                    await Task.Run(() => {
                        foreach (var x in bankDetails)
                        {
                            if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                            {
                                CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
                                {
                                    AccountNumber = x.AccountNumber,
                                    BankName = x.BankName,
                                    AccountName = x.AccountName
                                };



                                correctBankDetails.Add(correctBankDetails1);

                            }
                        }
                    });

                }


            }
            var allValidZenithBank = correctBankDetails.ToList();
            // HttpResponseMessage res = await client.GetAsync("api/employee/{}");
            //if (res.IsSuccessStatusCode)
            //{
            //    var results = res.Content.ReadAsStringAsync().Result;
            //    bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

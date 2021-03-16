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
using System.Threading;

namespace BankWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BankAPIHelper bankAPIHelper = new BankAPIHelper();
        List<CorrectBankDetails> correctBankDetails = new List<CorrectBankDetails>();
        Random random = new Random();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //this is working
        //public async Task<IActionResult> Index()
        //{

        //    //Thread workerThread = new Thread(new ThreadStart(Get));


        //    List<EmployeeBankDetails> bankDetails = new List<EmployeeBankDetails>();
        //    HttpClient client = bankAPIHelper.Initial();
        //    Stopwatch sw;
        //    var helperDataClass = new BankAPIHelper();

        //    var details = helperDataClass.GetAllEmployeeBankDetails();
        //    sw = Stopwatch.StartNew();

        //    foreach (var d in details.employee.Skip(15))
        //    {

        //        await Task.Run(async() => {
        //          //var number = random.Next(2000, 10000);
        //           //await Task.Delay(number);
        //            HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
        //        if (res.IsSuccessStatusCode)
        //        {
        //            var results = res.Content.ReadAsStringAsync().Result;
        //            bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

        //                foreach (var x in bankDetails)
        //                {
        //                    if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
        //                    {
        //                        CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
        //                        {
        //                            AccountNumber = x.AccountNumber,
        //                            BankName = x.BankName,
        //                            AccountName = x.AccountName,
        //                            IsValidAccount = true
        //                        };



        //                        correctBankDetails.Add(correctBankDetails1);

        //                    }
        //                }


        //        }
        //            });

        //        };
        //    var time = sw.ElapsedMilliseconds;
        //    var allValidBankDetails = correctBankDetails.ToList();

        //    return View(allValidBankDetails);
        //}

        //this is working


        public async Task<IActionResult> Index()
        {

           // Thread workerThread = new Thread(() => GetBank());


            List<EmployeeBankDetails> bankDetails = new List<EmployeeBankDetails>();
            HttpClient client = bankAPIHelper.Initial();
            Stopwatch sw;
            var helperDataClass = new BankAPIHelper();

            var details = helperDataClass.GetAllEmployeeBankDetails();
            sw = Stopwatch.StartNew();
            var timeNow = DateTime.Now;
            

            await Task.Run(async () => {
           
                    
                foreach (var d in details.employee)
                    {
                    
                    HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
                    if (res.IsSuccessStatusCode)
                    {
                        var results = res.Content.ReadAsStringAsync().Result;
                        bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

                        Thread workerThread = new Thread(() => GetBank(bankDetails,d));
                      
                        if (bankDetails.Any(x => x.AccountNumber == d.accountNumber && x.BankName == d.bankName))
                        {
                            CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
                            {
                                AccountNumber = d.accountNumber,
                                BankName = d.bankName,
                                AccountName = d.name,
                                IsValidAccount = true
                            };


                            
                                correctBankDetails.Add(correctBankDetails1);
                        
                        }
                     


                    }
                };
            });
            //await Task.Run(async () => {
            //   // var number = random.Next(2000, 10000);

            //    foreach (var d in details.employee.Skip(18))
            //    {
            //       // await Task.Delay(number);
            //        HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
            //        if (res.IsSuccessStatusCode)
            //        {
            //            var results = res.Content.ReadAsStringAsync().Result;
            //            bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

            //            foreach (var x in bankDetails)
            //            {
            //                if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
            //                {
            //                    CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
            //                    {
            //                        AccountNumber = x.AccountNumber,
            //                        BankName = x.BankName,
            //                        AccountName = x.AccountName,
            //                        IsValidAccount = true
            //                    };



            //                    correctBankDetails.Add(correctBankDetails1);

            //                }
            //            }


            //        }
            //    };
            //});

            var timeReal = DateTime.Now;
            var time = sw.ElapsedMilliseconds;
            ViewBag.TimeUsed = time;
            ViewBag.TimeUsed2 = timeNow;
            ViewBag.TimeUsed3 = timeReal;
           
            var allValidBankDetails = correctBankDetails.ToList();
            var timeReal2 = allValidBankDetails.Count();
            ViewBag.TimeUsed4 = timeReal2;
            return View(allValidBankDetails);
        }


        public void GetBank(List<EmployeeBankDetails> employeeBankDetails , EmployeeDetails d)
        {
            foreach (var x in employeeBankDetails.Where(x => x.AccountNumber == d.accountNumber && x.BankName == d.bankName))
            {
                //if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                //{
                CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
                {
                    AccountNumber = x.AccountNumber,
                    BankName = x.BankName,
                    AccountName = x.AccountName,
                    IsValidAccount = true
                };



                correctBankDetails.Add(correctBankDetails1);

                Debug.WriteLine(correctBankDetails1);

                Debug.WriteLine("kkkkkkkkkkkkkkkkkkkk");

                //}
            }
            
        }


        //public async void Get()
        //{
        //    List<EmployeeBankDetails> bankDetails = new List<EmployeeBankDetails>();
        //    HttpClient client = bankAPIHelper.Initial();
        //    Stopwatch sw;
        //    var helperDataClass = new BankAPIHelper();
        //    var details = helperDataClass.GetAllEmployeeBankDetails();
            
        //   await Task.Run(async () => {
        //        foreach (var d in details.employee.Skip(15))
        //        {

        //            var number = random.Next(2000, 10000);
        //            await Task.Delay(number);
        //            HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var results = res.Content.ReadAsStringAsync().Result;
        //                bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

        //                foreach (var x in bankDetails)
        //                {
        //                    if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
        //                    {
        //                        CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
        //                        {
        //                            AccountNumber = x.AccountNumber,
        //                            BankName = x.BankName,
        //                            AccountName = x.AccountName,
        //                            IsValidAccount = true
        //                        };



        //                        correctBankDetails.Add(correctBankDetails1);

        //                    }
        //                }


        //            }
        //        };
        //   });

        //    await Task.Run(async () => {
        //        foreach (var d in details.employee.Skip(15))
        //        {

        //            var number = random.Next(2000, 10000);
        //            await Task.Delay(number);
        //            HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
        //            if (res.IsSuccessStatusCode)
        //            {
        //                var results = res.Content.ReadAsStringAsync().Result;
        //                bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

        //                foreach (var x in bankDetails)
        //                {
        //                    if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
        //                    {
        //                        CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
        //                        {
        //                            AccountNumber = x.AccountNumber,
        //                            BankName = x.BankName,
        //                            AccountName = x.AccountName,
        //                            IsValidAccount = true
        //                        };



        //                        correctBankDetails.Add(correctBankDetails1);

        //                    }
        //                }


        //            }
        //        };
        //    });


        //}
        public async Task<ActionResult<IEnumerable<CorrectBankDetails>>> GetFirstt()
        {
            List<EmployeeBankDetails> bankDetails = new List<EmployeeBankDetails>();
            HttpClient client = bankAPIHelper.Initial();
            Stopwatch sw;
            var helperDataClass = new BankAPIHelper();

            var details = helperDataClass.GetAllEmployeeBankDetails();
            sw = Stopwatch.StartNew();
            //bool i = true;
            foreach (var d in details.employee.Take(15))
            {

                await Task.Run(async () => {
                    var number = random.Next(2000, 10000);
                    await Task.Delay(number);
                    HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
                    if (res.IsSuccessStatusCode)
                    {
                        var results = res.Content.ReadAsStringAsync().Result;
                        bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

                        foreach (var x in bankDetails)
                        {
                            if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                            {
                                CorrectBankDetails correctBankDetails1 = new CorrectBankDetails()
                                {
                                    AccountNumber = x.AccountNumber,
                                    BankName = x.BankName,
                                    AccountName = x.AccountName,
                                    IsValidAccount = true
                                };



                                correctBankDetails.Add(correctBankDetails1);

                            }
                        }


                    }
                });

            };
            var time = sw.ElapsedMilliseconds;
            var allValidBankDetails = correctBankDetails.ToList();
            return allValidBankDetails;
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

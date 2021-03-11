using BankConsoleApp.HelperClassData;
using BankConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BankAPIHelper bankAPIHelper = new BankAPIHelper();
            List<EmployeeBankDetails> bankDetails = new List<EmployeeBankDetails>();
            HttpClient client = bankAPIHelper.Initial();
            Stopwatch sw;
            var helperDataClass = new BankAPIHelper();
            Random random = new Random();
            var details = helperDataClass.GetAllEmployeeBankDetails();
            sw = Stopwatch.StartNew();



        await Task.Run(async () =>  {
                 var number = random.Next(2000, 10000);
            
                foreach (var d in details.employee)
                {
                   var ti = Task.Delay(number);
                    HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
                    if (res.IsSuccessStatusCode)
                    {
                        var results = res.Content.ReadAsStringAsync().Result;
                        bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

                        foreach (var x in bankDetails)
                        {
                            if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                            {
                                Console.WriteLine($"{ x.AccountNumber}, {x.BankName} ,{x.AccountName}");
                                break;
                

                            }
                        }


                    }

                await ti;
                Console.WriteLine($"{ti.IsCompleted}");
                };
            
            });
            
            //await Task.Run(async () => {
            //     var number = random.Next(2000, 10000);

            //    foreach (var d in details.employee.Skip(20))
            //    {
            //         await Task.Delay(number);
            //        HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
            //        if (res.IsSuccessStatusCode)
            //        {
            //            var results = res.Content.ReadAsStringAsync().Result;
            //            bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

            //            foreach (var x in bankDetails)
            //            {
            //                if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
            //                {
            //                    Console.WriteLine($"{ x.AccountNumber}, {x.BankName} ,{x.AccountName}");
            //                    break;
           

            //                }
            //            }


            //        }
            //    };
            //});


            var time = sw.ElapsedMilliseconds;
           
            Console.WriteLine($"Hello World! {time}");
        }
    }
}

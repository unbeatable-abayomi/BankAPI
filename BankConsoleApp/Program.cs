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
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            // Begin timing.
            stopwatch.Start();


            await Task.Run(async () =>  {
                //A random delay in milliseconds ranges from 2 to 10 seconds .Considering effect of network latency on the speed of processing.
                var number = random.Next(2000, 10000);

                foreach (var d in details.employee)
                {
                    //A random delay in milliseconds ranges from 2 to 10 seconds .Considering effect of network latency on the speed of processing.
                    var ti = Task.Delay(number);//This line of code activates the delay.
                    HttpResponseMessage res = await client.GetAsync($"api/banks/{d.bankName}");
                    if (res.IsSuccessStatusCode)
                    {
                        var results = res.Content.ReadAsStringAsync().Result;
                        bankDetails = JsonConvert.DeserializeObject<List<EmployeeBankDetails>>(results);

                        foreach (var x in bankDetails)
                        {
                            if (d.accountNumber == x.AccountNumber && d.bankName == x.BankName)
                            {
                                Console.WriteLine($" Bank Name: {x.BankName}  Account Number : {x.AccountNumber}, Name : {x.AccountName}");
                                break;
                

                            }
                        }


                    }

               // await ti;
               //Console.WriteLine($"{ti.IsCompleted}");
                };
            
            });

            //Below we could also take the First 500 in a task/loop and the second 500 by skipping the first 500, to take the second 500 making 1000 records 


            //await Task.Run(async () =>
            //{
            //    var number = random.Next(2000, 10000);

            //    foreach (var d in details.employee.Take(500))
            //    {
            //        await Task.Delay(number);
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
            //await Task.Run(async () =>
            //{
            //    var number = random.Next(2000, 10000);

            //    foreach (var d in details.employee.Skip(500))
            //    {
            //        await Task.Delay(number);
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

            // Stop timing.
            stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.WriteLine("Time elapsed in Milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            //var time = sw.ElapsedMilliseconds;
           
            //Console.WriteLine($"Time Taken To Process In Milliseconds => {time}");
        }

       
    }
}

using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Latency
{
    static class Extensions
    {
        public static IApplicationBuilder UseSimulatedLatency(
     this IApplicationBuilder app,
     TimeSpan min,
     TimeSpan max
 )
        {
            return app.UseMiddleware(
                typeof(SimulatedLatencyMiddleware),
                min,
                max
            );
        }
    }

   
}

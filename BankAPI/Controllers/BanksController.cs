using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm"
        };

        private readonly ILogger<BanksController> _logger;
        private readonly BankAppDBContext _context;
        public BanksController(ILogger<BanksController> logger, BankAppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("ACCESSBANK")]
        public async Task<ActionResult<IEnumerable<AccessBankCustomer>>> GetAcessCustomers()
        {

            return await _context.accessBankCustomers.ToListAsync();
           
        }

        [HttpGet("ACCESSBANK/{id}")]
        public async Task<ActionResult<AccessBankCustomer>> GetOneAccessCustomer(int id)
        {
            var accessCustomer = await _context.accessBankCustomers.FindAsync(id);

            if (accessCustomer == null)
            {
                return NotFound();
            }

            return accessCustomer;
        }

        [HttpPost("ACCESSBANK")]
        public async Task<ActionResult<AccessBankCustomer>> PostAccess(AccessBankCustomer accessBankCustomer)
        {
            _context.accessBankCustomers.Add(accessBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneAccessCustomer", new { id = accessBankCustomer.Id }, accessBankCustomer);
        }


        [HttpGet("ECOBANK")]
        public async Task<ActionResult<IEnumerable<EcoBankCustomer>>> GetEcoBankCustomers()
        {

            return await _context.ecoBankCustomers.ToListAsync();

        }

        [HttpGet("ECOBANK/{id}")]
        public async Task<ActionResult<EcoBankCustomer>> GetOneEcoBankCustomer(int id)
        {
            var ecoBankCustomer = await _context.ecoBankCustomers.FindAsync(id);

            if (ecoBankCustomer == null)
            {
                return NotFound();
            }

            return ecoBankCustomer;
        }

        [HttpPost("ECOBANK")]
        public async Task<ActionResult<EcoBankCustomer>> PostEcoBank(EcoBankCustomer ecoBankCustomer)
        {
            _context.ecoBankCustomers.Add(ecoBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneEcoBankCustomer", new { id = ecoBankCustomer.Id }, ecoBankCustomer);
        }



        [HttpGet("FIDELITYBANK")]
        public async Task<ActionResult<IEnumerable<FidelityBankCustomer>>> GetFidelityBankCustomers()
        {

            return await _context.fidelityBankCustomers.ToListAsync();

        }

        [HttpGet("FIDELITYBANK/{id}")]
        public async Task<ActionResult<FidelityBankCustomer>> GetOneFidelityCustomer(int id)
        {
            var fidelityBankCustomer = await _context.fidelityBankCustomers.FindAsync(id);

            if (fidelityBankCustomer == null)
            {
                return NotFound();
            }

            return fidelityBankCustomer;
        }

        [HttpPost("FIDELITYBANK")]
        public async Task<ActionResult<FidelityBankCustomer>> PostFidelityBank(FidelityBankCustomer fidelityBankCustomer)
        {
            _context.fidelityBankCustomers.Add(fidelityBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneFidelityCustomer", new { id = fidelityBankCustomer.Id }, fidelityBankCustomer);
        }



        [HttpGet("FIRSTBANK")]
        public async Task<ActionResult<IEnumerable<FirstBankCustomer>>> GetFirstBankCustomers()
        {

            return await _context.firstBankCustomers.ToListAsync();

        }

        [HttpGet("FIRSTBANK/{id}")]
        public async Task<ActionResult<FirstBankCustomer>> GetOneFirstBankCustomer(int id)
        {
            var firstBankCustomer = await _context.firstBankCustomers.FindAsync(id);

            if (firstBankCustomer == null)
            {
                return NotFound();
            }

            return firstBankCustomer;
        }

        [HttpPost("FIRSTBANK")]
        public async Task<ActionResult<FirstBankCustomer>> PostFirstBank(FirstBankCustomer firstBankCustomer)
        {
            _context.firstBankCustomers.Add(firstBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneFirstBankCustomer", new { id = firstBankCustomer.Id }, firstBankCustomer);
        }


        [HttpGet("GTBANK")]
        public async Task<ActionResult<IEnumerable<GTBankCustomer>>> GetGTBankCustomers()
        {

            return await _context.gTBankCustomers.ToListAsync();

        }

        [HttpGet("GTBANK/{id}")]
        public async Task<ActionResult<GTBankCustomer>> GetOneGTBankCustomer(int id)
        {
            var gtBankCustomer = await _context.gTBankCustomers.FindAsync(id);

            if (gtBankCustomer == null)
            {
                return NotFound();
            }

            return gtBankCustomer;
        }

        [HttpPost("GTBANK")]
        public async Task<ActionResult<GTBankCustomer>> PostGTBank(GTBankCustomer gTBankCustomer)
        {
            _context.gTBankCustomers.Add(gTBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneGTBankCustomer", new { id = gTBankCustomer.Id }, gTBankCustomer);
        }



        [HttpGet("POLARISBANK")]
        public async Task<ActionResult<IEnumerable<PolarisBankCustomer>>> GetPolarisBankCustomers()
        {

            return await _context.polarisBankCustomers.ToListAsync();

        }

        [HttpGet("POLARISBANK/{id}")]
        public async Task<ActionResult<PolarisBankCustomer>> GetOnePolarisBankCustomer(int id)
        {
            var polarisBankCustomer = await _context.polarisBankCustomers.FindAsync(id);

            if (polarisBankCustomer == null)
            {
                return NotFound();
            }

            return polarisBankCustomer;
        }

        [HttpPost("POLARISBANK")]
        public async Task<ActionResult<PolarisBankCustomer>> PostPolarisBank(PolarisBankCustomer polarisBankCustomer)
        {
            _context.polarisBankCustomers.Add(polarisBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnePolarisBankCustomer", new { id = polarisBankCustomer.Id }, polarisBankCustomer);
        }

        [HttpGet("UBABANK")]
        public async Task<ActionResult<IEnumerable<UbaBankCustomer>>> GetUbaBankCustomers()
        {

            return await _context.ubaBankCustomers.ToListAsync();

        }

        [HttpGet("UBABANK/{id}")]
        public async Task<ActionResult<UbaBankCustomer>> GetOneUbaBankCustomer(int id)
        {
            var ubaBankCustomer = await _context.ubaBankCustomers.FindAsync(id);

            if (ubaBankCustomer == null)
            {
                return NotFound();
            }

            return ubaBankCustomer;
        }

        [HttpPost("UBABANK")]
        public async Task<ActionResult<UbaBankCustomer>> PostUbaBank(UbaBankCustomer ubaBankCustomer)
        {
            _context.ubaBankCustomers.Add(ubaBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneUbaBankCustomer", new { id = ubaBankCustomer.Id }, ubaBankCustomer);
        }



        [HttpGet("WEMABANK")]
        public async Task<ActionResult<IEnumerable<WemaBankCustomer>>> GetWemaBankCustomers()
        {

            return await _context.wemaBankCustomers.ToListAsync();

        }

        [HttpGet("WEMABANK/{id}")]
        public async Task<ActionResult<WemaBankCustomer>> GetOneWemaBankCustomer(int id)
        {
            var wemaBankCustomer = await _context.wemaBankCustomers.FindAsync(id);

            if (wemaBankCustomer == null)
            {
                return NotFound();
            }

            return wemaBankCustomer;
        }

        [HttpPost("WEMABANK")]
        public async Task<ActionResult<WemaBankCustomer>> PostWemaBank(WemaBankCustomer wemaBankCustomer)
        {
            _context.wemaBankCustomers.Add(wemaBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneWemaBankCustomer", new { id = wemaBankCustomer.Id }, wemaBankCustomer);
        }



        [HttpGet("ZENITHBANK")]
        public async Task<ActionResult<IEnumerable<ZenithBankCustomer>>> GetZenithBankCustomers()
        {

            return await _context.zenithBankCustomers.ToListAsync();

        }

        [HttpGet("ZENITHBANK/{id}")]
        public async Task<ActionResult<ZenithBankCustomer>> GetOneZenithBankCustomer(int id)
        {
            var zenithBankCustomer = await _context.zenithBankCustomers.FindAsync(id);

            if (zenithBankCustomer == null)
            {
                return NotFound();
            }

            return zenithBankCustomer;
        }

        [HttpPost("ZENITHBANK")]
        public async Task<ActionResult<ZenithBankCustomer>> PostZenithBank(ZenithBankCustomer zenithBankCustomer)
        {
            _context.zenithBankCustomers.Add(zenithBankCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneZenithBankCustomer", new { id = zenithBankCustomer.Id }, zenithBankCustomer);
        }
    }
}

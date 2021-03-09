using BankAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI
{
    public class BankAppDBContext  : DbContext
    {

        public BankAppDBContext(DbContextOptions<BankAppDBContext> options) : base(options)
        {

        }

        public DbSet<AccessBankCustomer> accessBankCustomers { get; set; }
        public DbSet<EcoBankCustomer> ecoBankCustomers { get; set; }
        public DbSet<FidelityBankCustomer> fidelityBankCustomers { get; set; }
        public DbSet<FirstBankCustomer> firstBankCustomers { get; set; }
        public DbSet<GTBankCustomer> gTBankCustomers { get; set; }
        public DbSet<PolarisBankCustomer> polarisBankCustomers { get; set; }
        public DbSet<UbaBankCustomer> ubaBankCustomers { get; set; }
        public DbSet<WemaBankCustomer> wemaBankCustomers { get; set; }

        public DbSet<ZenithBankCustomer> zenithBankCustomers { get; set; }
        public DbSet<UnionBankCustomer> unionBankCustomers { get; set; }
        public DbSet<SterlingBankCustomer> sterlingBankCustomers { get; set; }
    }
}

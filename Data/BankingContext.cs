using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingApp_PK.Models;

    public class BankingContext : DbContext
    {
        public BankingContext (DbContextOptions<BankingContext> options)
            : base(options)
        {
        }

        public DbSet<BankingApp_PK.Models.Account> Account { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
    }

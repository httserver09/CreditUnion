using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace union.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Account> accounts { get; set; }

        public DbSet<Client> clients { get; set; }
        public DbSet<Models.Transaction> transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    id = 1,
                    accountType = "Savings",
                    activatedDate = new DateTime(2018, 03,15),
                    clientId = 1,
                    baseAmount = 55000.00
                },
                new Account
                {
                    id = 2,
                    accountType = "Savings",
                    activatedDate = new DateTime(2019, 04, 12),
                    clientId = 2,
                    baseAmount = 145788.99
                }
                );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    id = 1,
                    firstname = "John",
                    lastname = "Doe",
                    address = "123 Yemen str Florida",
                    email = "j@j.com",
                    dateOfBirth = new DateTime(1990, 07, 21),
                    gender = "Male",
                    maritalStatus = "Single",
                    phone = "1234567889"
                },
                new Client
                {
                    id = 2,
                    firstname = "Kris",
                    lastname = "Olaku",
                    address = "123 NY road New York",
                    email = "k@k.com",
                    dateOfBirth = new DateTime(1987, 03, 13),
                    gender = "Male",
                    maritalStatus = "Single",
                    phone = "1234567889"
                }
                );

            modelBuilder.Entity<Models.Transaction>().HasData(
                new Models.Transaction
                {
                    id = 1,
                    accountId = 1,
                    accountCredited = "1234567",
                    amount = 7600.89,
                    description = "Annual House Maintenance",
                    bankName = "Chase bank",
                    transactionDate = new DateTime(2021, 01, 12),
                    transactionStatus = "Successfully"
                });
        }

    }
}

using System;
using Web2.Models;

namespace Web2.Repository.Context
{
    public class BzaleContextSeedData
    {
        private BzaleContext _context;

        public BzaleContextSeedData(BzaleContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            //Initialize dummy companies
            _context.Companies.Add(new Company() { Name = "Company1" });
            //Initialize dummy ..

            _context.SaveChanges();
        }
    }
}
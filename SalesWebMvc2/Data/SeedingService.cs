using System;
using System.Linq;
using SalesWebMvc2.Models;
using SalesWebMvc2.Models.Enuns;

namespace SalesWebMvc2.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void seed()
        {
            if( _context.Department.Any() ||
                _context.SalesRecord.Any() ||
                _context.Seller.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Furniture");
            Department d4 = new Department(4, "Credit");

            Seller s1 = new Seller(1, "Silvio Cressoni", "cressoni.silvio@gmail.com", new DateTime(1986, 06, 26), 1000.0, d1);
            Seller s2 = new Seller(2, "Juliana Cressoni", "jscressoni@gmail.com", new DateTime(1990, 08, 19), 1500.0, d2);
            Seller s3 = new Seller(3, "Jimmy Cressoni", "jimmy_cressoni@gmail.com", new DateTime(2018, 03, 15), 1300.0, d3);
            Seller s4 = new Seller(4, "Chloe Cressoni", "cressoni.chloe@gmail.com", new DateTime(2016, 12, 01), 1800.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 1100.0, SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 25), 1500.0, SalesStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 25), 2000.0, SalesStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 25), 5000.0, SalesStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SalesRecord.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();
        }
    }
}

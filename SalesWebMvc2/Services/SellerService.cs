using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc2.Models;
using SalesWebMvc2.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace SalesWebMvc2.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        //public void Insert(Seller obj)
        public async Task InsertAsync(Seller obj) 
        {
            // this command just save in memory
            _context.Add(obj);

            // this one at truth saving on Database and needs to be included Async and await
            await _context.SaveChangesAsync();
        }

        //public Seller FindByIdAsync(int id)
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Seller obj)
        {
            // searching if there is some existing register

            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

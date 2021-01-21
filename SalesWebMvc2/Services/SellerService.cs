﻿using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc2.Models;

namespace SalesWebMvc2.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}

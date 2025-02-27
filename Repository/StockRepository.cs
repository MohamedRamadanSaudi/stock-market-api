using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stock_market_api.Data;
using stock_market_api.Interfaces;
using stock_market_api.models;

namespace stock_market_api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Stock>> GetStocksAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}
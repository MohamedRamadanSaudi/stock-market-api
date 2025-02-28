using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stock_market_api.models;

namespace stock_market_api.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<Stock?> AddStockToPortfolio(Portfolio portfolio);
        Task<Stock?> DeleteStockFromPortfolio(AppUser user, string symbol);
    }
}
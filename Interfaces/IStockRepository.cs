using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stock_market_api.models;

namespace stock_market_api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocksAsync();
    }
}
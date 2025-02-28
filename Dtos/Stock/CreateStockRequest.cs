using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stock_market_api.Dtos.Stock
{
    public class CreateStockRequest
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol must be at most 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Company Name must be at most 10 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100, ErrorMessage = "Last Div must be between 0.001 and 100")]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Industry must be at most 10 characters")]
        public string Industry { get; set; } = string.Empty;
        [Range(1, 5000000000, ErrorMessage = "Market Cap must be between 1 and 5000000000")]
        public long MarketCap { get; set; }
    }
}
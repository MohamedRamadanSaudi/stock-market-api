using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_market_api.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = string.Empty;
        public int? StockId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stock_market_api.Dtos.Comment;
using stock_market_api.models;

namespace stock_market_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsAsync();
        Task<Comment?> GetCommentByIdAsync(int id); // Nullable
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment?> UpdateCommentAsync(int id, UpdateCommentDto comment); // Nullable
        // Task<Comment?> DeleteCommentAsync(int id);
    }
}
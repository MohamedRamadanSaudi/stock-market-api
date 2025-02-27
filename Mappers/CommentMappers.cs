using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stock_market_api.Dtos.Comment;
using stock_market_api.models;

namespace stock_market_api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                Created = comment.Created,
                StockId = comment.StockId
            };
        }
    }
}
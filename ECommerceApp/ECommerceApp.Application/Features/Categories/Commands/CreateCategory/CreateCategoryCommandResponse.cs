﻿using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {
            
        }

        public CreateCategoryDto Category { get; set; }
    }
}

﻿using MediatR;

namespace ECommerceApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; }
    }
}

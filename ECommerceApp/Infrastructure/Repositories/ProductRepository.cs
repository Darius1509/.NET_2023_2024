﻿using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;

namespace Infrastructure.Repositories
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceAppContext context) : base(context)
        {
        }
    }
}

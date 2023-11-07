using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Contracts
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<DeleteOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}

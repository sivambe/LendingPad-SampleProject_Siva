using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IDeleteOrderService
    {
        bool Delete(Guid id);
        void DeleteAll();
    }
}

using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IDeleteProductService
    {
        bool Delete(Guid id);
        void DeleteAll();
    }
}

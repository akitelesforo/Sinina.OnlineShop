using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sinina.OnlineShop.Infrastructure.Core.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

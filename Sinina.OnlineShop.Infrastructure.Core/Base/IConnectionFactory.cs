using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinina.OnlineShop.Infrastructure.Core.Base
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}

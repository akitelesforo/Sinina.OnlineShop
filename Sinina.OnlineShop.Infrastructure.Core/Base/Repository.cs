using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinina.OnlineShop.Infrastructure.Core.Base
{
    public abstract class Repository<TEntity> where TEntity : new()
    {
        AdoNetContext _context;

        public Repository(AdoNetContext context)
        {
            _context = context;
        }

        protected AdoNetContext Context { get; set; }

        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }
                return items;
            }
        }

        protected abstract void Map(IDataRecord record, TEntity entity);
    }
}

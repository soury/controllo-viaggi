using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Core.Sevice
{
    public class TipiDocumentiRepository : IRepository<TipiDocumenti, int>
    {
        private DBContext context;
        public TipiDocumentiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<TipiDocumenti> All()
        {
            return this.context.TipiDocumenti;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.TipiDocumenti.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public TipiDocumenti FindById(int id)
        {
            return this.context.TipiDocumenti.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(TipiDocumenti item)
        {
            TipiDocumenti TipiDocumenti = this.context.TipiDocumenti.Where(v => v.Id == item.Id).FirstOrDefault();
            if(TipiDocumenti == null)
            {
                this.context.TipiDocumenti.Add(item);
            } else
            {
                this.context.TipiDocumenti.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

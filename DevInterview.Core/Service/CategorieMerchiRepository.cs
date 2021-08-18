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
    public class CategorieMerchiRepository : IRepository<CategorieMerchi, int>
    {
        private DBContext context;
        public CategorieMerchiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<CategorieMerchi> All()
        {
            return this.context.CategorieMerchi;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.CategorieMerchi.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public CategorieMerchi FindById(int id)
        {
            return this.context.CategorieMerchi.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(CategorieMerchi item)
        {
            CategorieMerchi CategorieMerchi = this.context.CategorieMerchi.Where(v => v.Id == item.Id).FirstOrDefault();
            if(CategorieMerchi == null)
            {
                this.context.CategorieMerchi.Add(item);
            } else
            {
                this.context.CategorieMerchi.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

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
    public class PuntiControlliRepository : IRepository<PuntiControlli, int>
    {
        private DBContext context;
        public PuntiControlliRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<PuntiControlli> All()
        {
            return this.context.PuntiControlli;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.PuntiControlli.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public PuntiControlli FindById(int id)
        {
            return this.context.PuntiControlli.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(PuntiControlli item)
        {
            PuntiControlli PuntiControlli = this.context.PuntiControlli.Where(v => v.Id == item.Id).FirstOrDefault();
            if(PuntiControlli == null)
            {
                this.context.PuntiControlli.Add(item);
            } else
            {
                this.context.PuntiControlli.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

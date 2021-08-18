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
    public class RevisioniControlliRepository : IRepository<RevisioniControlli, int>
    {
        private DBContext context;
        public RevisioniControlliRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<RevisioniControlli> All()
        {
            return this.context.RevisioniControlli;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.RevisioniControlli.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public RevisioniControlli FindById(int id)
        {
            return this.context.RevisioniControlli.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(RevisioniControlli item)
        {
            RevisioniControlli RevisioniControlli = this.context.RevisioniControlli.Where(v => v.Id == item.Id).FirstOrDefault();
            if(RevisioniControlli == null)
            {
                this.context.RevisioniControlli.Add(item);
            } else
            {
                this.context.RevisioniControlli.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

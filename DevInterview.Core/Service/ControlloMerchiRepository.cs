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
    public class ControlloMerchiRepository : IRepository<ControlloMerchi, int>
    {
        private DBContext context;
        public ControlloMerchiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<ControlloMerchi> All()
        {
            return this.context.ControlloMerchi;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.ControlloMerchi.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public ControlloMerchi FindById(int id)
        {
            return this.context.ControlloMerchi.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(ControlloMerchi item)
        {
            ControlloMerchi ControlloMerchi = this.context.ControlloMerchi.Where(v => v.Id == item.Id).FirstOrDefault();
            if(ControlloMerchi == null)
            {
                this.context.ControlloMerchi.Add(item);
            } else
            {
                this.context.ControlloMerchi.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

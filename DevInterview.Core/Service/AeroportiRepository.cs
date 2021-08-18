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
    public class AeroportiRepository : IRepository<Aeroporti, int>
    {
        private DBContext context;
        public AeroportiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Aeroporti> All()
        {
            return this.context.Aeroporti;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Aeroporti.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Aeroporti FindById(int id)
        {
            return this.context.Aeroporti.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Aeroporti item)
        {
            Aeroporti Aeroporti = this.context.Aeroporti.Where(v => v.Id == item.Id).FirstOrDefault();
            if(Aeroporti == null)
            {
                this.context.Aeroporti.Add(item);
            } else
            {
                this.context.Aeroporti.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

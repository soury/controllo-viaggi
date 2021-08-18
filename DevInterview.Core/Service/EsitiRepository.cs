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
    public class EsitiRepository : IRepository<Esiti, int>
    {
        private DBContext context;
        public EsitiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Esiti> All()
        {
            return this.context.Esiti;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Esiti.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Esiti FindById(int id)
        {
            return this.context.Esiti.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Esiti item)
        {
            Esiti Esiti = this.context.Esiti.Where(v => v.Id == item.Id).FirstOrDefault();
            if(Esiti == null)
            {
                this.context.Esiti.Add(item);
            } else
            {
                this.context.Esiti.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

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
    public class PasseggeriRepository : IRepository<Passeggeri, int>
    {
        private DBContext context;
        public PasseggeriRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Passeggeri> All()
        {
            return this.context.Passeggeri;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Passeggeri.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Passeggeri FindById(int id)
        {
            return this.context.Passeggeri.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Passeggeri item)
        {
            Passeggeri Passeggeri = this.context.Passeggeri.Where(v => v.Id == item.Id).FirstOrDefault();
            if(Passeggeri == null)
            {
                this.context.Passeggeri.Add(item);
            } else
            {
                this.context.Passeggeri.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

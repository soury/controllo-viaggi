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
    public class ViaggioRepository : IRepository<Viaggi, int>
    {
        private DBContext context;
        public ViaggioRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Viaggi> All()
        {
            return this.context.Viaggi;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Viaggi.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Viaggi FindById(int id)
        {
            return this.context.Viaggi.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Viaggi item)
        {
            Viaggi Viaggi = this.context.Viaggi.Where(v => v.Id == item.Id).FirstOrDefault();
            if(Viaggi == null)
            {
                this.context.Viaggi.Add(item);
            } else
            {
                this.context.Viaggi.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

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
    public class StatiRepository : IRepository<Stati, int>
    {
        private DBContext context;
        public StatiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Stati> All()
        {
            return this.context.Stati;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Stati.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Stati FindById(int id)
        {
            return this.context.Stati.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Stati item)
        {
            Stati Stati = this.context.Stati.Where(v => v.Id == item.Id).FirstOrDefault();
            if(Stati == null)
            {
                this.context.Stati.Add(item);
            } else
            {
                this.context.Stati.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

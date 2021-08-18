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
    public class UtentiRepository : IRepository<Utenti, int>
    {
        private DBContext context;
        public UtentiRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<Utenti> All()
        {
            return this.context.Utenti;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.Utenti.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public Utenti FindById(int id)
        {
            return this.context.Utenti.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(Utenti item)
        {
            Utenti Utenti = this.context.Utenti.Where(v => v.Id == item.Id).FirstOrDefault();
            if(Utenti == null)
            {
                this.context.Utenti.Add(item);
            } else
            {
                this.context.Utenti.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

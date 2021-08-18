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
    public class MotivazioniRevisioneRepository : IRepository<MotivazioniRevisione, int>
    {
        private DBContext context;
        public MotivazioniRevisioneRepository(DBContext context)
        {
            this.context = context;
        }
        public IEnumerable<MotivazioniRevisione> All()
        {
            return this.context.MotivazioniRevisioni;
        }

        public bool Delete(int id)
        {
            this.context.Remove(this.context.MotivazioniRevisioni.Where(v => v.Id == id).FirstOrDefault());
            return this.context.SaveChanges() > 0;
        }

        public MotivazioniRevisione FindById(int id)
        {
            return this.context.MotivazioniRevisioni.Where(v => v.Id == id).FirstOrDefault();
        }

        public bool Save(MotivazioniRevisione item)
        {
            MotivazioniRevisione MotivazioniRevisione = this.context.MotivazioniRevisioni.Where(v => v.Id == item.Id).FirstOrDefault();
            if(MotivazioniRevisione == null)
            {
                this.context.MotivazioniRevisioni.Add(item);
            } else
            {
                this.context.MotivazioniRevisioni.Update(item);
            }
            return this.context.SaveChanges() > 0;
        }
    }
}

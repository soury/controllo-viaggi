using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class ControlloMerchi : IStoreable<int>, IComparable<int>
    {
        public int Id { get; set; }
        public int IdViaggio { get; set; }
        public int IdCategoria { get; set; }
        public int IdEsito { get; set; }
        public double Quantita { get; set; }
        public string Descrizione { get; set; }

        public virtual CategorieMerchi IdCategoriaNavigation { get; set; }
        public virtual Esiti IdEsitoNavigation { get; set; }
        public virtual Viaggi IdViaggioNavigation { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

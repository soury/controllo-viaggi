using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class PuntiControlli : IStoreable<int>, IComparable<int>
    {
        public PuntiControlli()
        {
            Viaggi = new HashSet<Viaggi>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<Viaggi> Viaggi { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Stati : IStoreable<int>, IComparable<int>
    {
        public Stati()
        {
            Aeroporti = new HashSet<Aeroporti>();
            Passeggeri = new HashSet<Passeggeri>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SiglaNumerica { get; set; }
        public string SiglaIso31661Alpha3 { get; set; }
        public string LaIso31661Alpha2 { get; set; }

        public virtual ICollection<Aeroporti> Aeroporti { get; set; }
        public virtual ICollection<Passeggeri> Passeggeri { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

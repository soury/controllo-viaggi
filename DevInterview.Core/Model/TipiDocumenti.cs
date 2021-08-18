using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class TipiDocumenti : IStoreable<int>, IComparable<int>
    {
        public TipiDocumenti()
        {
            Passeggeri = new HashSet<Passeggeri>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Passeggeri> Passeggeri { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

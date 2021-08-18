using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Esiti : IStoreable<int>, IComparable<int>
    {
        public Esiti()
        {
            ControlloMerchi = new HashSet<ControlloMerchi>();
        }

        public int Id { get; set; }
        public string Esito { get; set; }

        public virtual ICollection<ControlloMerchi> ControlloMerchi { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

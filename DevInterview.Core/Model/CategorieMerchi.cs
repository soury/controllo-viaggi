using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class CategorieMerchi : IStoreable<int>, IComparable<int>
    {
        public CategorieMerchi()
        {
            ControlloMerchi = new HashSet<ControlloMerchi>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ControlloMerchi> ControlloMerchi { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

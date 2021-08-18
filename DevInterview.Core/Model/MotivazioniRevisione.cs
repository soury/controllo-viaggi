using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class MotivazioniRevisione : IStoreable<int>, IComparable<int>
    {
        public MotivazioniRevisione()
        {
            RevisioniControlli = new HashSet<RevisioniControlli>();
        }

        public int Id { get; set; }
        public string Motivazione { get; set; }

        public virtual ICollection<RevisioniControlli> RevisioniControlli { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

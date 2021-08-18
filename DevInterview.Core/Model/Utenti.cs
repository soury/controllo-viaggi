using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Utenti : IStoreable<int>, IComparable<int>
    {
        public Utenti()
        {
            RevisioniControlli = new HashSet<RevisioniControlli>();
            Viaggi = new HashSet<Viaggi>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<RevisioniControlli> RevisioniControlli { get; set; }
        public virtual ICollection<Viaggi> Viaggi { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

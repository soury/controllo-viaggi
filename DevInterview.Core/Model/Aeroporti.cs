using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Aeroporti : IStoreable<int>, IComparable<int>
    {
        public Aeroporti()
        {
            ViaggiIdADestinazioneNavigations = new HashSet<Viaggi>();
            ViaggiIdAProvenienzaNavigations = new HashSet<Viaggi>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public int IdNazione { get; set; }

        public virtual Stati IdNazioneNavigation { get; set; }
        public virtual ICollection<Viaggi> ViaggiIdADestinazioneNavigations { get; set; }
        public virtual ICollection<Viaggi> ViaggiIdAProvenienzaNavigations { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

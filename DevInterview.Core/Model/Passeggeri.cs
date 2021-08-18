using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Passeggeri : IStoreable<int>, IComparable<int>
    {
        public Passeggeri()
        {
            Viaggi = new HashSet<Viaggi>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int IdNazione { get; set; }

        public virtual Stati IdNazioneNavigation { get; set; }
        public virtual TipiDocumenti IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Viaggi> Viaggi { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class Viaggi : IStoreable<int>, IComparable<int>
    {
        public Viaggi()
        {
            ControlloMerchi = new HashSet<ControlloMerchi>();
            RevisioniControlli = new HashSet<RevisioniControlli>();
        }

        public int Id { get; set; }
        public int IdUtente { get; set; }
        public int IdPuntoControllo { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public double DazioDoganale { get; set; }
        public int IdPasseggero { get; set; }
        public int IdAProvenienza { get; set; }
        public int IdADestinazione { get; set; }
        public string Motivazione { get; set; }

        public virtual Aeroporti IdADestinazioneNavigation { get; set; }
        public virtual Aeroporti IdAProvenienzaNavigation { get; set; }
        public virtual Passeggeri IdPasseggeroNavigation { get; set; }
        public virtual PuntiControlli IdPuntoControlloNavigation { get; set; }
        public virtual Utenti IdUtenteNavigation { get; set; }
        public virtual ICollection<ControlloMerchi> ControlloMerchi { get; set; }
        public virtual ICollection<RevisioniControlli> RevisioniControlli { get; set; }

        public int CompareTo(int id)
        {
            return Id.CompareTo(id);
        }
    }
}

using DevInterview.Providers.Common.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace DevInterview.Core.Model
{
    public partial class RevisioniControlli : IStoreable<int>, IComparable<int>
    {
        public int Id { get; set; }
        public int? IdUtente { get; set; }
        public int IdControllo { get; set; }
        public int IdMotivazione { get; set; }
        public string Note { get; set; }

        public virtual Viaggi IdControlloNavigation { get; set; }
        public virtual MotivazioniRevisione IdMotivazioneNavigation { get; set; }
        public virtual Utenti IdUtenteNavigation { get; set; }

        public int CompareTo(int other)
        {
            return Id.CompareTo(other);
        }
    }
}

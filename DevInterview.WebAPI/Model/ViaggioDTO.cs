using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Model
{
    public class ViaggioDTO
    {
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

    }
}

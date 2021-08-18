import { Component, OnInit } from '@angular/core';

import {
  AeroportiService,
  ViaggiService,
  ControlloMerchiService,
  PasseggeriService,
  PuntiControlliService,
  UtentiService,
  TipiDocumentiService,
  StatiService,
  CategorieMerchiService,
  EsitiService
} from './_services/index';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'DevInterview Frontend';

  constructor(
    private _controlli: ControlloMerchiService,
    private _viaggi: ViaggiService,
    private _passeggeri: PasseggeriService,
    private _aeroporti: AeroportiService,
    private _punti_controllo: PuntiControlliService,
    private _utente: UtentiService,
    private _tipi_documenti: TipiDocumentiService,
    private _stati: StatiService,
    private _categorie_merchi: CategorieMerchiService,
    private _esiti: EsitiService,

  ) { }
  controlli:any = [];

  ngOnInit() {
    this._controlli.getAll().subscribe(response => {
      this.controlli = response.$values.map((controllo:any) => {
        this._categorie_merchi.getById(controllo.idCategoria).subscribe(cm => controllo.categoria = cm);
        this._esiti.getById(controllo.idEsito).subscribe(e => controllo.esito = e);
        this._viaggi.getById(controllo.idViaggio).subscribe(r => {
          controllo.viaggio = r;
          this._passeggeri.getById(r.idPasseggero).subscribe(p => {
            controllo.passeggero = p;
            this._tipi_documenti.getById(p.idTipoDocumento).subscribe(t => controllo.passeggero.tipoDocumento = t);
            this._stati.getById(p.idNazione).subscribe(n => controllo.passeggero.nazionalita = n);
          });
          this._aeroporti.getById(r.idAProvenienza).subscribe(pr => {
            controllo.provenienza = pr;
            this._stati.getById(pr.idNazione).subscribe(n => controllo.provenienza.nazione = n);
          });
          this._aeroporti.getById(r.idADestinazione).subscribe(ds => {
            controllo.destinazione = ds;
            this._stati.getById(ds.idNazione).subscribe(n => controllo.provenienza.nazione = n);
          });
          this._punti_controllo.getById(r.idPuntoControllo).subscribe(pc => controllo.punto_controllo = pc);
          this._utente.getById(r.idUtente).subscribe(ad => controllo.addetto = ad);
        });
        return controllo;
      })
      console.log(this.controlli);
    })
  }
}

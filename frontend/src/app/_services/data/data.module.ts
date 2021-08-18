import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { AeroportiService } from "./aeroporti.service";
import { ViaggiService } from "./viaggi.service";
import { PasseggeriService } from "./passeggeri.service";
import { ControlloMerchiService } from "./controllo-merchi.service";
import { PuntiControlliService } from "./punti-controlli.service";
import { UtentiService } from "./utenti.service";
import { EsitiService } from "./esiti.service";
import { CategorieMerchiService } from "./categorie-merchi.service";
import { MotivazioniRevisioneService } from "./motivazioni-revisione.service";
import { TipiDocumentiService } from "./tipi-documenti.service";
import { StatiService } from "./stati.service";
import { HttpModule } from "../http/http.module";

@NgModule({
  imports: [
    HttpModule
  ],
  providers: [
    AeroportiService,
    ViaggiService,
    ControlloMerchiService,
    PasseggeriService,
    PuntiControlliService,
    UtentiService,
    EsitiService,
    CategorieMerchiService,
    MotivazioniRevisioneService,
    TipiDocumentiService,
    StatiService,
    BrowserModule
  ]
})
export class DataModule {}

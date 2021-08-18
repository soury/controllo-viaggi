import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';

import { ApiClass } from './api.class';
import { Observable } from 'rxjs';

@Injectable()
export class CategorieMerchiService extends ApiClass {
  constructor(private http: HttpService) {
    super(http, 'categorie-merchi');
  }
}

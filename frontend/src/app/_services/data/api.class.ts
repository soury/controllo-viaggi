import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpService } from '../index';


export abstract class ApiClass {

  readonly API_URL = environment.apiUrl;

  constructor(private _http: HttpService, public apiMethod: string) {

  }

  /**
   * Returns multiple items
   * @param resultsPerPage Optional, numbers of results to return per call, if null returns all the results
   * @param params Optional, params accepted by the endpoint of the call
   */
  getAll(resultsPerPage: number = 0, params: {[key:string]: any}={}) {
    return <Observable<any>>this._http/*.auth()*/.get(this.API_URL + '/' + this.apiMethod /*+ '/' + resultsPerPage + this.parseParams(params)*/);
  }


  /**
   * Returns a single item
   * @param id Id of the item to fetch
   */
  getById(id: number) {
    return <Observable<any>>this._http/*.auth()*/.get(this.API_URL + '/' + this.apiMethod + '/' + id);
  }

  /**
   * Creates a new item
   * @param data The new data to insert
   */
  create(data: any) {
    return <Observable<any>>this._http/*.auth()*/.post(this.API_URL + '/' + this.apiMethod, data);
  }

  /**
   * Updates the item based on the id
   * @param id The id of the item to modify
   * @param data The updated data
   */
  update(id: number, data:any) {
    return <Observable<any>>this._http/*.auth()*/.patch(this.API_URL + '/' + this.apiMethod + '/' + id, data);
  }

  /**
   * Deletes an item
   * @param id The id of the item to be deleted
   */
  delete(id: number) {
    return <Observable<any>>this._http/*.auth()*/.delete(this.API_URL + '/' + this.apiMethod + '/' + id);
  }

  /**
   * Determines if the item must be created or updated based on the id
   * @param id Optional, if present the method will call the update function else the create
   * @param item The data to save
   */
  save(id: number, item: any) {
    if (typeof +id == "number" && !isNaN(+id)) {
      return this.update(id, item);
    } else {
      return this.create(item);
    }
  }

  private parseParamsCore(obj: any){
    let arr = [];
    for (let key in obj){
      arr.push(encodeURIComponent(key)+'='+encodeURIComponent(obj[key]));
    }
    return arr;
  }

  protected parseParams(obj: any){
    let paramsArr = this.parseParamsCore(obj)
    return paramsArr.length ? '?'+paramsArr.join('&') : '';
  }
}

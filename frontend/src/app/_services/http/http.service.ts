import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class HttpService extends HttpClient {

	constructor(
    private httpHandler: HttpHandler,
    private _router: Router,
  ) {
		super(httpHandler);
	}

	addInterceptor(interceptor: HttpInterceptor): HttpService {
		const handler: HttpHandler = new HttpInterceptorHandler(this.httpHandler, interceptor);
		return new HttpService(handler, this._router);
	}

	noCache(): HttpService {
		return this.addInterceptor({
			intercept(req, next) {
				req = req.clone({
					setHeaders: { 'Pragma': 'no-cache' },
				});
				return next.handle(req);
			}
		});
  }

  /*auth(): HttpService {
    let self = this;
    return self.addInterceptor({
			intercept(req, next) {

        // Controllo se il token è presente
        const authReq = req.clone({headers: req.headers.set('Content-Language','it')});
        return next.handle(authReq).do(event => {
          if (event instanceof HttpResponse) self.handleMessage(event.body.extra && event.body.extra.message, event.body.return ? 'info' : 'error')
        }, (err) => {
          // Se si verifica un errore di autenticazione faccio il redirect al login
          if (err instanceof HttpErrorResponse) {
            if (err.status == 401) {
              //location.href='/login';
              return self._router.navigateByUrl('/login');
            }
            // Se si verifica un errore con messaggio lo visualizzo
            if (typeof err.error == 'string'){
              console.error("Si è verificato un errore, se l'errore persiste contattare il supporto");
            } else {
              self.handleMessage(err.error.extra && err.error.extra.message || err.error.error)
            }
          }
        });
      }
    })
  }*/

  private handleMessage(message: any, method='error'){
    if (message){
      let msg = '';
      if (typeof message == 'string'){
        msg = message;
      } else {
        for (let key in message){
          for (let error of message[key]){
            msg+= error+'<br>';
          }
        }
      }
      //console[method](msg,'',{enableHtml:true});
    }
  }
}

class HttpInterceptorHandler implements HttpHandler {
	constructor(private next: HttpHandler, private interceptor: HttpInterceptor) {}

	handle(req: HttpRequest<any>): Observable<HttpEvent<any>> {
		return this.interceptor.intercept(req, this.next);
	}
}

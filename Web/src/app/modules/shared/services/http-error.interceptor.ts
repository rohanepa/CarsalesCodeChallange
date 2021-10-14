import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError, timer } from 'rxjs';
import { catchError, concatMap, delayWhen, retryWhen } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor() { }

  public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retryWhen((error) => this.handleRetry(error)),
      catchError((httpErrorResponse: HttpErrorResponse) => {
        return throwError(httpErrorResponse);
      }),
    );
  }

  public handleRetry(source: Observable<HttpErrorResponse>): Observable<HttpErrorResponse> {
    return source.pipe(
      delayWhen(() => timer(500)),
      concatMap((error, index) => {
        if (index === 1 || error.status === 0) {
          return throwError(error);
        }
        return throwError(error);
      }));
  }

}

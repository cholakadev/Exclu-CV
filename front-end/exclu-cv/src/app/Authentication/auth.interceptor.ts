import { Router } from '@angular/router';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  // constructor(
  //     private router: Router
  // ) {

  // }

  // intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //     if (localStorage.getItem('token') != null) {
  //         const clonedReq = req.clone({
  //             headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
  //         });
  //         return next.handle(clonedReq).pipe(
  //             tap(
  //                 succ => { },
  //                 err => {
  //                     if (err.status == 401) {
  //                         localStorage.removeItem('token');
  //                         this.router.navigateByUrl('/user/login');
  //                     }
  //                 }
  //             )
  //         )
  //     }
  //     else
  //         return next.handle(req.clone());
  // }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    var requestToken = this.getCookieValue('XSRF-REQUEST-TOKEN');
    return next.handle(
      req.clone({
        headers: req.headers.set('X-XSRF-TOKEN', requestToken),
      })
    );
  }

  private getCookieValue(cookieName: string) {
    const allCookies = decodeURIComponent(document.cookie).split('; ');
    for (let i = 0; i < allCookies.length; i++) {
      const cookie = allCookies[i];
      if (cookie.startsWith(cookieName + '=')) {
        return cookie.substring(cookieName.length + 1);
      }
    }
    return '';
  }
}

// TODO: handle 401 error and refresh token
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Injectable()
export class UnauthorizeInterceptor implements HttpInterceptor {
    constructor(private router: Router, private authService: AuthService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if (error.status === 401) {
                    console.log("Unauthorized!!");
                    debugger;
                    // Handle unauthorized error
                    this.authService.clearToken();

                    if (this.authService.getToken()) {
                        // call authService.refreshToken() and retry the request
                        return this.authService.refreshToken().pipe(
                            switchMap(() => {
                                return next.handle(req);
                            })
                        );
                    }
                }

                // redirect to login page or show a message
                // this.router.navigate(['/auth/login']);
                return throwError(() => error);
            })
        );
    }
}
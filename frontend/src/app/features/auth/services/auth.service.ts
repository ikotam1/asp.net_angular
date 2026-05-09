import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { User } from '../../../shared/models/User';
import { LoginRequest, SignupRequest, LoginResponse, SignupResponse } from '../../../shared/models/Request';
import { ApiService } from '../../../core/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenKey = 'auth_token';
  private userKey = 'auth_user';
  private serviceUrl = 'auth/'; // Base URL for auth endpoints
  
  // private currentUserSubject = new BehaviorSubject<User | null>(this.getUserFromStorage());
  // public currentUser$ = this.currentUserSubject.asObservable();

  constructor(private apiService: ApiService) {
    // this.checkExistingToken();
  }

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.apiService.post<LoginResponse>(`${this.serviceUrl}login`, credentials)
      .pipe(
        tap(response => {
          // // Store token and user
          localStorage.setItem(this.tokenKey, response.token);
          // localStorage.setItem(thcccis.userKey, JSON.stringify(response.user));
          // this.currentUserSubject.next(response.user);
        }),
        catchError(error => {
          console.error('Login error:', error);
          throw error;
        })
      );
  }

  signup(credentials: SignupRequest): Observable<SignupResponse> {
    return this.apiService.post<SignupResponse>(`${this.serviceUrl}register`, credentials)
      .pipe(
        tap(response => {
          console.log("signup response", response);
            
        //   // Store token and user
        //   localStorage.setItem(this.tokenKey, response.token);
        //   localStorage.setItem(this.userKey, JSON.stringify(response.user));
        //   this.currentUserSubject.next(response.user);
        }),
        catchError(error => {
          console.error('Signup error:', error);
          throw error;
        })
      );
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.userKey);
    // this.currentUserSubject.next(null);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  // getCurrentUser(): User | null {
  //   return this.currentUserSubject.getValue();
  // }

  // getCurrentUser$(): Observable<User | null> {
  //   return this.currentUser$;
  // }

  // private getUserFromStorage(): User | null {
  //   const user = localStorage.getItem(this.userKey);
  //   return user ? JSON.parse(user) : null;
  // }

  // private checkExistingToken(): void {
  //   if (this.getToken()) {
  //     const user = this.getUserFromStorage();
  //     if (user) {
  //       this.currentUserSubject.next(user);
  //     }
  //   }
  // }
}

import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { LoginRequest, SignupRequest, LoginResponse, SignupResponse } from '../../../shared/models/Request';
import { ApiService } from '../../../core/services/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private serviceUrl = 'auth/'; // Base URL for auth endpoints
  private userServiceUrl = 'user/'; // Base URL for user-related endpoints

  constructor(private apiService: ApiService) {
  }

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.apiService.post<LoginResponse>(`${this.serviceUrl}login`, credentials)
      .pipe();
  }

  signup(credentials: SignupRequest): Observable<SignupResponse> {
    return this.apiService.post<SignupResponse>(`${this.serviceUrl}register`, credentials)
      .pipe();
  }

  logout(): void {
  }

  isAuthenticated(): Observable<boolean> {
    // Implement logic to check if the user is authenticated
    return this.apiService.get(
      `${this.userServiceUrl}me`,
    ).pipe(
      map((response) => {
        debugger;
        console.log(response);
        return true;
      }),
      catchError(() => of(false))
    );
  }
}

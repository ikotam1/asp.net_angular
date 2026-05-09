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
  private token = '';

  private setToken(token: string) {
    this.token = token;
  }

  getToken(): string {
    return this.token;
  }

  constructor(private apiService: ApiService) {
  }

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.apiService.post<LoginResponse>(`${this.serviceUrl}login`, credentials)
      .pipe(
        map((response) => {
          this.setToken(response.accessToken);
          return response;
        })
      );
  }

  signup(credentials: SignupRequest): Observable<SignupResponse> {
    return this.apiService.post<SignupResponse>(`${this.serviceUrl}register`, credentials)
      .pipe();
  }

  logout(): void {
  }

  refreshToken(): Observable<LoginResponse> {
    return this.apiService.post<LoginResponse>(
      `${this.serviceUrl}refresh-token`,
      {},
      {
        withCredentials: true,
      }
    ).pipe(
        map((response) => {
          this.setToken(response.accessToken);
          return response;
        })
      );
  }

  isAuthenticated(): Observable<boolean> {
    // Implement logic to check if the user is authenticated
    return this.apiService.get(
      `${this.userServiceUrl}me`,
    ).pipe(
      map(() => true),
      catchError(() => of(false))
    );
  }
}

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
  private token : string | null = null;

  private setToken(token: string) {
    this.token = token;
  }

  getToken(): string | null {
    return this.token;
  }

  clearToken(): void {
    this.token = null;
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
    return this.getToken() ? of(true) : of(false);
  }
}

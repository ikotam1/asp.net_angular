# Angular Frontend Code Structure and Rules

This document outlines the normalized Angular frontend structure and coding rules for the project.

## Project Structure

```
src/
├── app/
│   ├── core/
│   │   ├── services/
│   │   │   ├── api.service.ts         # Generic HTTP API service
│   │   │   └── auth.service.ts        # Authentication service
│   │   ├── interceptors/
│   │   │   └── auth.interceptor.ts    # HTTP interceptor for auth tokens
│   │   └── guards/
│   │       └── auth.guard.ts          # Route protection guard
│   ├── shared/
│   │   ├── models/
│   │   │   ├── User.ts                # User interface
│   │   │   ├── Post.ts                # Post interface
│   │   │   ├── Feature.ts             # Feature interface
│   │   │   ├── Navigation.ts          # Navigation interface
│   │   │   └── models.ts              # Model exports
│   │   ├── components/
│   │   │   └── page-layout/           # Shared layout component
│   │   └── pipes/                     # Custom pipes
│   ├── features/                      # Feature modules
│   ├── pages/
│   │   ├── login-page/
│   │   ├── start-page/
│   │   ├── explore-page/
│   │   ├── posts-page/
│   │   └── about-page/
│   ├── app.component.ts               # Root component
│   ├── app.config.ts                  # Application configuration
│   └── app.routes.ts                  # Route definitions
├── environments/
│   ├── environment.ts                 # Development environment config
│   └── environment.prod.ts            # Production environment config
```

## Coding Rules

### 1. File Naming Conventions
- Components: `component-name.component.ts`
- Services: `service-name.service.ts`
- Guards: `guard-name.guard.ts`
- Interceptors: `interceptor-name.interceptor.ts`
- Models: `ModelName.ts`

### 2. Folder Organization
- **Core**: Singleton services, interceptors, guards
- **Shared**: Reusable components, models, pipes
- **Features**: Feature-specific modules and components
- **Pages**: Route-specific page components

### 3. Environment Configuration
- Use `environment.ts` for development
- Use `environment.prod.ts` for production
- Backend URL: `https://localhost:7230/`

### 4. HTTP Communication
- Use `ApiService` for generic HTTP requests
- Use `AuthService` for authentication operations (login, logout, token management)
- Authentication tokens are automatically added via `AuthInterceptor`
- Use `AuthGuard` to protect authenticated routes
- `AuthService` manages JWT tokens in localStorage and maintains current user state

### 5. Type Safety
- Define interfaces in `shared/models/`
- Use TypeScript strict mode
- Avoid `any` types where possible

### 6. Component Architecture
- Use standalone components
- Import only necessary modules
- Follow single responsibility principle

### 7. State Management
- Use services for shared state
- Consider signals for local component state (Angular 17+)

## Development Guidelines

1. Always run `npm run build` before committing to ensure no compilation errors
2. Use the provided `ApiService` for all HTTP requests
3. Implement proper error handling in services
4. Follow Angular style guide for naming and structure
5. Use lazy loading for feature modules when appropriate

## Core Services

### AuthService
The `AuthService` is responsible for handling all authentication-related operations:
- **login(credentials)**: Authenticates user with email and password, stores JWT token and user info
- **logout()**: Clears stored credentials and resets user state
- **getToken()**: Returns the stored JWT token
- **isLoggedIn()**: Checks if user is currently authenticated
- **getCurrentUser()**: Returns the current user object
- **getCurrentUser$()**: Returns Observable of current user for reactive subscriptions

Usage in components:
```typescript
constructor(private authService: AuthService) {}

onLogin(credentials: LoginRequest) {
  this.authService.login(credentials).subscribe({
    next: (response) => {
      // Handle successful login
    },
    error: (error) => {
      // Handle login error
    }
  });
}
```

## Backend Integration

- Backend URL: `https://localhost:7230/`
- All API calls should go through the `ApiService`
- Authentication is handled via JWT tokens in localStorage
- CORS and other backend configurations should be handled on the server side

### API Endpoints
- **POST /login**: Accepts email and password, returns JWT token and user object
  ```json
  {
    "token": "jwt_token_string",
    "user": { "id": 1, "username": "user", "email": "user@example.com" }
  }
  ```
# openAuth

```TypeScript
  interface OpenAuth {
    type: 'Register' | 'Login',
    loginInfo?: {
      username: string
    }
  }

  interface LoginRequest {
    username: string,
    password: string
  }

  interface LoginResponse {
    success: boolean,
    error?: string
  }

  interface RegisterRequest {
    username: string,
    email: string,
    password: string
  }

  interface RegisterResponse {
    success: boolean,
    error?: string
  }
```

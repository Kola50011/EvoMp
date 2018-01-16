# openAuth

```TypeScript
  interface AuthOpen {
    type: 'Register' | 'Login',
    username?: string
  }

  interface AuthRequest {
    type: 'Login' | 'Register',
    username: string,
    password: string
  }

  interface AuthResponse {
    type: 'Login' | 'Register',
    success: boolean,
    error?: string
  }
```

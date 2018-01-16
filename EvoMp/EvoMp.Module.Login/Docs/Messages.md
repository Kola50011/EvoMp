# openAuth

```TypeScript
  interface AuthOpen {
    type: 'Login' | 'Register',
    username?: string
  }

  interface AuthRequest {
    type: 'Login' | 'Register',
    username: string,
    password: string,
    email?: string,
  }

  interface AuthResponse {
    type: 'Login' | 'Register',
    success: boolean,
    error: Array<string>
  }
```

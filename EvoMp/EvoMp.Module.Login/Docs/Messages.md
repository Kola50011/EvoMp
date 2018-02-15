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
    success: boolean,
    error: Array<string>
  }
```

# Sending messages:

Messages are sent in JSON format (args[0])

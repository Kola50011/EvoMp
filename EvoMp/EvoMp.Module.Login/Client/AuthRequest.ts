export interface AuthRequest {
  type: "Login" | "Register"
  username: string
  password: string
  email?: string
}

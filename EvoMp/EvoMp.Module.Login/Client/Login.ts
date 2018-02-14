/// <reference path='../../../typings/index.d.ts' />

import AuthRequest from './AuthRequest'
import AuthResponse from './AuthResponse'
import Cef from '../../EvoMp.Module.Cef/Client/Cef'
import EventHandler from '../../EvoMp.Module.EventHandler/Client/EventHandler'

function sendAuthRequest(args: any[]): void {
  const request: AuthRequest = {
    type: 'Login',
    username: args[0].username,
    password: args[0].password
  }

  API.triggerServerEvent('AuthRequest', JSON.stringify(request))
}

export default async function openLogin(username: string): Promise<void> {
  const loginWindow = new Cef('Login', 'dist/Login.html', {})
  loginWindow.addEventListener('LoginAttempt', sendAuthRequest)
  await loginWindow.load()

  const authResponseListener = EventHandler.subscribe('AuthResponse', (args: string) => {
    const response: AuthResponse = JSON.parse(args)

    if (response.success) {
      loginWindow.destroy()
      authResponseListener.unsubscribe()
    } else {
      loginWindow.eval('loginInvalid("ERROR")')
    }
  })
}

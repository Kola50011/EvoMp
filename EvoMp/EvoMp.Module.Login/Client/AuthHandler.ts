/// <reference path='../../../typings/index.d.ts' />

import Cef from '../../EvoMp.Module.Cef/Client/Cef'
import EventHandler from '../../EvoMp.Module.EventHandler/Client/EventHandler'

let resourceStartHandler = API.onResourceStart.connect(initAuthentication)

interface AuthOpen {
  type: 'Login' | 'Register'
  username?: string
}

interface AuthRequest {
  type: 'Login' | 'Register'
  username: string
  password: string
  email?: string
}

interface AuthResponse {
  success: boolean
  error: Array<string>
}

function sendAuthRequest (request: AuthRequest): void {
  API.triggerServerEvent('AuthRequest', JSON.stringify(request))
}

async function onOpenLogin(username: string): Promise<void> {
  let loginWindow = new Cef('Login', 'dist/Login.html', {})
  await loginWindow.load()

  loginWindow.addEventListener('LoginAttempt', (args: any[]) => {
    sendAuthRequest({
      type: 'Login',
      username: args[0].username,
      password: args[0].password
    })
  })

  let onAuthResponseListener = EventHandler.subscribe('AuthResponse', (args: string) => {
    const response: AuthResponse = JSON.parse(args)

    if (response.success) {
      loginWindow.destroy()
      API.showCursor(false);
      onAuthResponseListener.unsubscribe()
    } else {
      API.sendChatMessage('Login invalid!')
      loginWindow.eval('loginInvalid("ERROR")')
    }
  })
}

async function onOpenRegister(): Promise<void> {
  // TODO

  return
}

async function initAuthentication() {
  resourceStartHandler.disconnect()

  let onOpenListener = EventHandler.subscribe('AuthOpen', (args: any) => {
    const arg = args as AuthOpen

    if (arg.type === 'Register') {
      onOpenRegister().catch(() => {
        API.sendChatMessage('Error on Register')
      })
    } else {
      onOpenLogin(arg.username || 'ERROR').catch(() => {
        API.sendChatMessage('Error on Register')
      })
    }

    onOpenListener.unsubscribe()
  })

  const cefWindow: Cef = new Cef('Login', 'dist/Login.html', {})
  await cefWindow.load()
  API.showCursor(true);
  API.triggerServerEvent('ready')
}

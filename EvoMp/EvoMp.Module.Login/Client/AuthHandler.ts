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

async function onOpenLogin(username: string): Promise<void> {
  let loginWindow = new Cef('Login', 'dist/Login.html', {})

  await loginWindow.load()

  loginWindow.addEventListener('LoginAttempt', (args: any[]) => {
    API.sendChatMessage('Login')
    API.sendChatMessage(JSON.stringify(args))
  })

  let onAuthResponseListener = EventHandler.subscribe('AuthRequest', (args: any) => {
    const arg = args as AuthResponse

    if (arg.success) {
      loginWindow.destroy()
      onAuthResponseListener.unsubscribe()
    }
  })
}

async function onOpenRegister(): Promise<void> {
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
  API.triggerServerEvent('ready')
}

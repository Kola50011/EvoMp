/// <reference path='../../../typings/index.d.ts' />

// import Cef from '../../EvoMp.Module.Cef/Client/Cef'
import EventHandler from '../../EvoMp.Module.EventHandler/Client/EventHandler'
import openLogin from './Login'
import openRegister from './Register'
import AuthOpen from './AuthOpen'

const resourceStartHandler = API.onResourceStart.connect(initAuthentication)

async function initAuthentication() {
  resourceStartHandler.disconnect()

  const onOpenListener = EventHandler.subscribe('AuthOpen', (args: any) => {
    const arg = args as AuthOpen

    switch (arg.type) {
      case 'Register':
        openRegister().catch(() => {
          API.sendChatMessage('Exception: onOpenRegister')
        })

        break
      case 'Login':
        openLogin(arg.username || 'ERROR').catch(() => {
          API.sendChatMessage('Exception: onOpenLogin')
        })

        break
      default:
        // TODO: Add better error handling.
        API.sendChatMessage('Wrong packet received in Auth!')

        break
    }

    onOpenListener.unsubscribe()
  })

  // const cefWindow: Cef = new Cef('Login', 'dist/Login.html', {})
  // await cefWindow.load()
  // API.showCursor(true)
  API.triggerServerEvent('ready')
}

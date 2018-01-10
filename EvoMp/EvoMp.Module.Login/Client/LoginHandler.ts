/// <reference path='../../../typings/index.d.ts' />

import {Cef} from '../../EvoMp.Module.Cef/Client/Cef'

let resourceStartHandler = API.onResourceStart.connect(() => {
  API.triggerServerEvent('ready')
  API.sendChatMessage('Initialised!')
  const cefWindow: Cef = new Cef('Login', 'dist/Login.html', {chat: false, hud: false, cursor: true})
  cefWindow.load()
  resourceStartHandler.disconnect()
})

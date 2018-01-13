/// <reference path='../../../typings/index.d.ts' />

import {Cef} from '../../EvoMp.Module.Cef/Client/Cef'

async function test() {
  resourceStartHandler.disconnect()
  API.triggerServerEvent('ready')
  API.sendChatMessage('Initialised!')
  const cefWindow: Cef = new Cef('Login', 'dist/Login.html', {})
  await cefWindow.load()
  API.sendChatMessage('Loaded Login')
}

let resourceStartHandler = API.onResourceStart.connect(test)

/// <reference path='../../../typings/index.d.ts' />

import {Cef} from '../../EvoMp.Module.Cef/Client/Cef'

API.onResourceStart.connect(() => {
  API.sendChatMessage('Initialised!')
  const cefWindow: Cef = new Cef('Login', 'dist/Login.html', {chat: false, hud: false, cursor: true})
  cefWindow.load()
})

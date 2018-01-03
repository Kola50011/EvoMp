/// <reference path='../../../typings/index.d.ts' />

import {Cef} from './Cef'

export class Debugger {
  private static instance: Debugger
  private cef: Cef = new Cef('Debugger', './dist/Debugger.Web/Debugger.html')

  private constructor() {
    this.cef.setHeadless(false)
    this.cef.setChatVisible(true)
    this.cef.setCursorVisible(false)
    this.cef.load()
    API.waitUntilCefBrowserLoaded(this.cef.browser)
    API.sleep(1000)
  }

  public static getInstance(): Debugger {
    if (!Debugger.instance) {
      Debugger.instance = new Debugger()
    }
    return Debugger.instance
  }

  public log(caller: string, obj?: Object): void {
    obj
      ? this.cef.call('log', `[${caller}]`, JSON.stringify(obj))
      : this.cef.call('log', `[${caller}]`, '{}')
  }

  public error(caller: string, obj?: Object): void {
    obj
      ? this.cef.call('error', `[${caller}]`, JSON.stringify(obj))
      : this.cef.call('error', `[${caller}]`, '{}')
  }

  public warn(caller: string, obj?: Object): void {
    obj
      ? this.cef.call('warn', `[${caller}]`, JSON.stringify(obj))
      : this.cef.call('warn', `[${caller}]`, '{}')
  }
}

API.onResourceStart.connect(() => {
  Debugger.getInstance().log('Debugger', {msg: 'Initialised'})
})

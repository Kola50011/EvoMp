/// <reference path='../../../typings/index.d.ts' />

import { Cef } from './Cef'
import { ServerEventHandlerSingleton } from './ServerEventHandlerSingleton'

/**
 * Notifications, pretty self explainatory
 * @author Sascha <sascha@localhost.systems>
 */
export class Notification {
  private static cef: Cef
  private static cefReady: boolean = false

  constructor (icon: string, message: string, color: string) {
    if (Notification.cefReady) Notification.cef.call('notify', icon, message, color)
  }

  public static async init (): Promise<void> {
    Notification.cef = new Cef('Notification', './dist/Notification.Web/Notification.html')
    Notification.cef.setHeadless(false)
    Notification.cef.setChatVisible(true)
    Notification.cef.setCursorVisible(false)
    await this.cef.load()
    Notification.cefReady = true
  }
}

API.onResourceStart.connect(() => {
  Notification.init()
  .then(() => {
    // tslint:disable-next-line:no-unused-variable
    let notification: Notification = new Notification('ion-bug', 'Notifications initialised', 'red')
  })
})

ServerEventHandlerSingleton.getInstance().on('notify', args => {
  // tslint:disable-next-line:no-unused-variable
  let notification: Notification = new Notification(args[0], args[1], args[2])
})

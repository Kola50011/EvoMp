/// <reference path='../../../typings/index.d.ts' />
import EventListener from './EventListener'

export default class ServerEventHandler {
  private static listeners: {[eventName: string]: EventListener[]} = {}

  public static subscribe(eventName: string, callback: (args: any) => void): EventListener {
    const listener = new EventListener(eventName, callback)

    if (!this.listeners[eventName]) this.listeners[eventName] = []

    this.listeners[eventName].push(listener)

    return listener
  }

  public static detach(listener: EventListener): void {
    if (!this.listeners[listener.eventName]) return

    this.listeners[listener.eventName] = this.listeners[listener.eventName].filter((elem) => elem === listener)

    if (this.listeners[listener.eventName].length === 0) delete this.listeners[listener.eventName]
  }
}

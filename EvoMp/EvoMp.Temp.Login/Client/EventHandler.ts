import {Debugger} from './Debugger'
import {EventListener} from './EventListener'

export class EventHandler {
  private listeners: {[name: string]: EventListener[]} = {}

  public on(eventName: string, cb: (args: any[]) => void): void {
    let listener: EventListener = new EventListener(eventName, cb)
    this.add(listener)
  }

  public add(listener: EventListener): void {
    if (!this.listeners[listener.getName()]) {
      this.listeners[listener.getName()] = new Array<EventListener>()
    }

    this.listeners[listener.getName()].push(listener)
  }

  public remove(listener: EventListener): void {
    this.listeners[listener.getName()].filter((l: EventListener) => {
      return l !== listener
    })
  }

  public trigger(eventName: string, args: any[]): void {
    if (this.listeners[eventName]) {
      Debugger.getInstance().log('Event: ' + eventName, {
        params: args,
        handler: this
      })
      this.listeners[eventName].forEach((listener: EventListener) => {
        listener.run(args)
      })
    } else {
      Debugger.getInstance().warn('Event unhandlet: ' + eventName, {
        params: args,
        handler: this
      })
    }
  }
}

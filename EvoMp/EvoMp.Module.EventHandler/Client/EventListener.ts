/// <reference path='../../../typings/index.d.ts' />
import ServerEventHandler from './EventHandler'

export default class EventListener {
  public eventName: string
  private callback: (args: any) => void

  constructor(eventName: string, callback: (args: any) => void) {
    this.eventName = eventName
    this.callback = callback
  }

  public unsubscribe(): void {
    ServerEventHandler.detach(this)
  }

  public trigger(args: any): void {
    this.callback(args)
  }
}

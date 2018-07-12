/// <reference path='../../../typings/index.d.ts' />
import EventHandler from "./EventHandler"

export default class EventListener {
  eventName: string
  private callback: (args: any) => void

  constructor(eventName: string, callback: (args: any) => void) {
    this.eventName = eventName
    this.callback = callback
  }

  unsubscribe(): void {
    EventHandler.detach(this)
  }

  trigger(args: any): void {
    this.callback(args)
  }
}

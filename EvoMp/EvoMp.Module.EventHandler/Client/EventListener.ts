/// <reference path='../../../typings/index.d.ts' />
import ServerEventHandler from "./EventHandler"

export default class EventListener {
  eventName: string;
  private callback: (args: any) => void;

  constructor(eventName: string, callback: (args: any) => void) {
    this.eventName = eventName;
    this.callback = callback;
  }

  unsubscribe(): void {
    ServerEventHandler.detach(this);
  }

  trigger(args: any): void {
    this.callback(args);
  }
}

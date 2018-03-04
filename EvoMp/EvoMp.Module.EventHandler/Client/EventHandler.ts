/// <reference path='../../../typings/index.d.ts' />
import EventListener from "./EventListener"

export default class ServerEventHandler {
  private static listeners: { [eventName: string]: EventListener[] } = {};

  /**
   * Listen for server events.
   */
  static startListen() {
    API.onServerEventTrigger.connect((eventName, argumentss) => {
      if (this.listeners[eventName]) {
        for (let i = 0; i < this.listeners[eventName].length; i++) {
          this.listeners[eventName][i].trigger(argumentss);
        }
      }
    });
  }

  static subscribe(eventName: string, callback: (args: any) => void): EventListener {
    const listener = new EventListener(eventName, callback);

    if (!this.listeners[eventName]) this.listeners[eventName] = [];

    this.listeners[eventName].push(listener);

    return listener;
  }

  static debug(message: string): void {
    API.triggerServerEvent("Debug", message);
  }

  static detach(listener: EventListener): void {
    if (!this.listeners[listener.eventName]) return;

    this.listeners[listener.eventName] = this.listeners[listener.eventName].filter((elem) => elem === listener);

    if (this.listeners[listener.eventName].length === 0) delete this.listeners[listener.eventName];
  }
}

API.onResourceStart.connect(() => { ServerEventHandler.startListen() });

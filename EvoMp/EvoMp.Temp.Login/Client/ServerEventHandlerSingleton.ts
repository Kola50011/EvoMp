/// <reference path='../../../typings/index.d.ts' />

import {EventHandler} from './EventHandler'

export class ServerEventHandlerSingleton extends EventHandler {
  private static instance: ServerEventHandlerSingleton

  private constructor() {
    super()
  }

  public static getInstance(): ServerEventHandlerSingleton {
    if (!ServerEventHandlerSingleton.instance) {
      ServerEventHandlerSingleton.instance = new ServerEventHandlerSingleton()
    }
    return ServerEventHandlerSingleton.instance
  }
}

API.onServerEventTrigger.connect(
  (eventName: string, args: System.Array<any>) => {
    let convArgs: any[] = toArray(args) // System.Array is a pain in the butt - convert it right away!

    ServerEventHandlerSingleton.getInstance().trigger(eventName, convArgs)
  }
)

function toArray(args: System.Array<any>): any[] {
  let ret: any[] = []
  for (let i: number = 0; i < args.Length; i++) {
    ret.push(args[i])
  }

  return ret
}

let resourceStartHandler = API.onResourceStart.connect(() => {
  API.triggerServerEvent('ready')
  resourceStartHandler.disconnect()
})

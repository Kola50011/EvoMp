/// <reference path='../../../typings/index.d.ts' />

import { EventHandler } from './EventHandler'

/**
 * @desc Singleton that handles all events incoming from the web.
 * @author Sascha <sascha@localhost.systems>
 */
export class CefEventHandlerSingleton extends EventHandler {
  private static instance: CefEventHandlerSingleton

  private constructor () {
    super()
  }

  public static getInstance (): CefEventHandlerSingleton {
    if (!CefEventHandlerSingleton.instance) {
      CefEventHandlerSingleton.instance = new CefEventHandlerSingleton()
    }
    return CefEventHandlerSingleton.instance
  }
}

// Hack for GT-MP - this makes everything callable outside of webpock, so in  the gloabal context
API.onResourceStart.connect(() => {
  resource.CefEventHandlerSingleton = CefEventHandlerSingleton.getInstance()
})

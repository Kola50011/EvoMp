/// <reference path='../../../typings/index.d.ts' />
import Cef from "./Cef"

/**
 * Collects events from all the CEFs and forwards them.
 * @author Sascha <sascha(at)localhost.systems>
 */
export class CefEventCollector {
  private static cefs: {[identifier: string]: Cef} = {}

  public static trigger(cefName: string, event: string, obj: any) {
    if (!this.cefs[cefName]) return

    if (obj) {
      this.cefs[cefName].trigger(event, JSON.parse(obj))
    } else {
      this.cefs[cefName].trigger(event)
    }
  }

  public static register(cef: Cef): void {
    this.cefs[cef.identifier] = cef
  }

  public static unregister(cef: Cef): void {
    delete this.cefs[cef.identifier]
  }
}

// So we can uniquely identify the CEC from each CEF.

let resourceStartHandler = API.onResourceStart.connect(() => {
  resourceStartHandler.disconnect()

  resource.CEC = CefEventCollector
})

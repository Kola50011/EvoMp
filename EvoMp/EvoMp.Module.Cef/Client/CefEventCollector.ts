/// <reference path='../../../typings/index.d.ts' />
import {Cef} from './Cef'

/**
 * Collects events from all the CEFs and forwards them.
 * @author Sascha <sascha(at)localhost.systems>
 */
export class CefEventCollector {
  private static cefs: {[identifier: string]: Cef} = {}

  public static trigger(cefName: string, event: string, args: any[]) {
    if (!this.cefs[cefName]) return

    this.cefs[cefName].trigger(event, args)
  }

  public static register(cef: Cef): void {
    this.cefs[cef.identifier] = cef
  }

  public static unregister(cef: Cef): void {
    delete this.cefs[cef.identifier]
  }
}

// So we can uniquely identify the CEC from each CEF.
resource.CEC = new CefEventCollector()

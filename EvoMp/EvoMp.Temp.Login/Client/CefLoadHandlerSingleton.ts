/// <reference path='../../../typings/index.d.ts' />
/// <reference path='./Cef.ts' />

/**
 * A centralised location to collect and notify all currently loading cefs windows.
 * @author Sascha <sascha@localhost.systems>
 */
export class CefLoadHandlerSingleton {
  private static instance: CefLoadHandlerSingleton
  private loadingCallbacks: { [name: string]: () => void } = {}

  private constructor () {}

  /**
   * This just returns the CefLoadHandlerSingleton instance, because singleton.
   */
  public static getInstance (): CefLoadHandlerSingleton {
    if (!CefLoadHandlerSingleton.instance) CefLoadHandlerSingleton.instance = new CefLoadHandlerSingleton()
    return CefLoadHandlerSingleton.instance
  }

  /**
   * Called from the Browser to signalised, that he's done loading.
   * @param {string} name The Name of the Browser window, should be unique.
   */
  public doneLoading (name: string): void {
    this.loadingCallbacks[name]()
  }

  /**
   * Returns a Promise, that is resolved as soon as the CEF finished loading.
   * @param {string} name Browser Name, this better be unique or complications will happen.
   */
  public finishedLoading (name: string): Promise<void> {
    return new Promise<void>((resolve: () => void) => {
      this.loadingCallbacks[name] = resolve
    })
  }
}

// Hack for GT-MP - this makes everything callable outside of webpock, so in  the gloabal context
API.onResourceStart.connect(() => {
  resource.CefLoadHandlerSingleton = CefLoadHandlerSingleton.getInstance()
})

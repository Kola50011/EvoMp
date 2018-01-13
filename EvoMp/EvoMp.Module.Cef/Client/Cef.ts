/// <reference path='../../../typings/index.d.ts' />
import {CefEventCollector} from './CefEventCollector'

interface CefOptions {
  readonly external: boolean
  readonly headless: boolean
}

interface CefOptionsArgument {
  readonly external?: boolean
  readonly headless?: boolean
}

/**
 * Wrapper around the Chromium Embedded Framework, for GT-MP
 * @author Sascha <sascha(at)localhost.systems>
 */
export class Cef {
  public readonly identifier: string
  private readonly browser: GTANetwork.GUI.Browser
  private readonly path: string
  private readonly options: CefOptions
  private open: boolean
  private events: {[name: string]: (args: any[]) => void} = {}
  private loadingResolve: () => void

  constructor(identifier: string, path: string, options: CefOptionsArgument) {
    this.identifier = identifier
    this.path = path
    this.options = {
      external: options.external ? options.external : false,
      headless: options.headless ? options.headless : false
    }

    const res = API.getScreenResolution()
    this.browser = API.createCefBrowser(res.Width, res.Height, !this.options.external)

    CefEventCollector.register(this)
    this.addEventListener('doneLoading', this.loadingResolve)
  }

  destroy(): void {
    CefEventCollector.unregister(this)
    API.destroyCefBrowser(this.browser)
  }

  async load(): Promise<void> {
    API.setCefBrowserHeadless(this.browser, this.options.headless)

    API.setCefBrowserPosition(this.browser, 0, 0)
    API.waitUntilCefBrowserInit(this.browser)
    API.loadPageCefBrowser(this.browser, this.path)
    API.waitUntilCefBrowserLoaded(this.browser)

    this.open = true

    return new Promise<void>(resolve => {
      this.loadingResolve = resolve
    })
  }

  public eval(str: string): void {
    this.browser.eval(str)
  }

  public addEventListener(event: string, func: (args: any[]) => void): void {
    this.events[event] = func
  }

  public removeEventListener(event: string): void {
    delete this.events[event]
  }

  public trigger(event: string, args: any[]): void {
    if (!this.events[event]) return

    this.events[event](args)
  }
}

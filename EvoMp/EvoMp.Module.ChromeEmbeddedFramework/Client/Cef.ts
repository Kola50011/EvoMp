/// <reference path='../../../typings/index.d.ts' />
import {CefEventCollector} from "./CefEventCollector"
import { ICefOptions } from "./ICefOptions"
import { ICefOptionsArgument } from "./ICefOptionsArgument"

/**
 * Wrapper around the Chromium Embedded Framework, for GT-MP
 * @author Sascha <sascha(at)localhost.systems>
 */
export default class Cef {
  readonly identifier: string
  private readonly browser: GrandTheftMultiplayer.Client.GUI.CEF.Browser
  private readonly path: string
  private readonly options: ICefOptions
  private events: { [name: string]: (args: any[]) => void } = {}
  private loadingResolve: () => void

  constructor(identifier: string, path: string, options: ICefOptionsArgument) {
    this.identifier = identifier
    this.path = path
    this.options = {
      external: options.external ? options.external : false,
      headless: options.headless ? options.headless : false,
      fps: options.fps ? options.fps : 30
    }

    const res = API.getScreenResolution()
    this.browser = API.createCefBrowser(res.Width, res.Height, !this.options.external)
    API.setCefBrowserHeadless(this.browser, this.options.headless)
    API.setCefBrowserPosition(this.browser, 0, 0)

    CefEventCollector.register(this)
    // This is a default value / initialiser, otherwise the compiler screams.
    this.loadingResolve = () => {
      // TODO: Add proper error handling!
      API.sendChatMessage("Loaded before assignment, CEF!")
    }
    this.addEventListener("doneLoading", this.loadingResolve)
  }

  destroy(): void {
    CefEventCollector.unregister(this)
    API.destroyCefBrowser(this.browser)
  }

  async load(): Promise<void> {
    return new Promise<void>((resolve) => {
      API.waitUntilCefBrowserLoaded(this.browser)
      API.loadPageCefBrowser(this.browser, this.path)
      this.loadingResolve = resolve
    })
  }

  eval(str: string): void {
    this.browser.eval(`window.exports.${str}`)
  }

  call(func: string, ...args: any[]) {
    this.browser.call(`window.exports.${func}`, ...args)
  }

  addEventListener(event: string, func: (args: any[]) => void): void {
    this.events[event] = func
  }

  removeEventListener(event: string): void {
    delete this.events[event]
  }

  trigger(event: string, args: any[]): void {
    if (!this.events[event]) return

    this.events[event](args)
  }
}

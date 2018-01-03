/// <reference path='../../../typings/index.d.ts' />

import {CefEventHandlerSingleton} from './CefEventHandlerSingleton'
import {CefLoadHandlerSingleton} from './CefLoadHandlerSingleton'
import {EventListener} from './EventListener'

/**
 * Wrapper around the Chromium Embedded Framework, for GT-MP
 * @author Sascha <sascha@localhost.systems>
 */
export class Cef {
  public browser: GTANetwork.GUI.Browser
  private cursor: boolean = false
  private open: boolean = false
  private external: boolean = false
  private headless: boolean = false
  private name: string
  private path: string
  private cefEventHandler: CefEventHandlerSingleton = CefEventHandlerSingleton.getInstance()
  private chat: boolean = false
  private hud: boolean = true

  constructor(name: string, path: string) {
    this.name = name
    this.path = path

    const resolution: Size = API.getScreenResolution()
    this.browser = API.createCefBrowser(
      resolution.Width,
      resolution.Height,
      !this.external
    )
    API.setCefBrowserPosition(this.browser, 0, 0)
    API.waitUntilCefBrowserInit(this.browser)
  }

  /**
   * Openes the webpage.
   * @param {string} path You can still change the site to load until the last minute.
   */
  public async load(path?: string): Promise<void> {
    if (path) this.path = path
    if (this.open) return

    API.loadPageCefBrowser(this.browser, this.path)

    await CefLoadHandlerSingleton.getInstance().finishedLoading(this.name)

    if (!this.chat) {
      API.setCanOpenChat(false)
    }
    if (!this.hud) {
      API.setHudVisible(false)
    }
    if (this.cursor) {
      API.showCursor(true)
    }
    this.setOpen(true)
  }

  /**
   * Closes the whole website.
   */
  public destroy(): void {
    API.destroyCefBrowser(this.browser)

    if (!this.chat) {
      API.setCanOpenChat(true)
    }
    if (!this.hud) {
      API.setHudVisible(true)
    }
    if (this.cursor) {
      API.showCursor(false)
    }

    this.setOpen(false)
  }

  /**
   * Evaluates the string inside the web context. Basically runs the string like you'd type it inside the Chrome Dev Tools Console
   * @param {string} evalString The String to evaluate
   */
  public eval(evalString: string): void {
    this.browser.eval(evalString)
  }

  /**
   * Executes the function inside the browser context
   * @param {string} method  Method to call
   * @param {any[]}  ...args the arguments
   */
  public call(method: string, ...args: any[]): void {
    this.browser.call(method, ...args)
  }

  /**
   * Attaches a new event to the global Cef Event Handler
   * @param  {string} eventName The name of the event
   * @param  {any[]}  cb        Callback
   */
  public on(eventName: string, cb: (args: any[]) => void): void {
    this.cefEventHandler.on(`${this.name}.${eventName}`, cb)
  }

  /**
   * Attaches a listener to the global Cef Event Handler
   * @param  {EventListener} listener The name of the listener
   */
  public add(listener: EventListener): void {
    this.cefEventHandler.add(listener)
  }

  /**
   * Removes a listener to the global Cef Event Handler
   * @param  {EventListener} listener The name of the listener
   */
  public remove(listener: EventListener): void {
    this.cefEventHandler.remove(listener)
  }

  public setExternal(newValue: boolean): void {
    this.external = newValue
  }
  public setHeadless(newValue: boolean): void {
    this.headless = newValue
    API.setCefBrowserHeadless(this.browser, this.headless)
  }
  public setCursorVisible(newValue: boolean): void {
    this.cursor = newValue
  }
  public setChatVisible(newValue: boolean): void {
    this.chat = newValue
  }
  public setHudVisible(newValue: boolean): void {
    this.hud = newValue
  }

  private setOpen(newValue: boolean): void {
    this.open = newValue
  }
}

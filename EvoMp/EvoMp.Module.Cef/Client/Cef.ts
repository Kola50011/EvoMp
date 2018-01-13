/// <reference path='../../../typings/index.d.ts' />

interface CefOptions {
  cursor: boolean
  external: boolean
  headless: boolean
  chat: boolean
  hud: boolean
}

interface CefOptionsArgument {
  cursor?: boolean
  external?: boolean
  headless?: boolean
  chat?: boolean
  hud?: boolean
}

/**
 * Wrapper around the Chromium Embedded Framework, for GT-MP
 * @author Sascha <sascha(at)localhost.systems>
 */
export class Cef {
  private browser: GTANetwork.GUI.Browser
  private identifier: string
  private path: string
  private options: CefOptions
  private open: boolean

  constructor(identifier: string, path: string, options: CefOptionsArgument) {
    this.identifier = identifier
    this.path = path
    this.options = {
      cursor: options.cursor ? options.cursor : true,
      external: options.external ? options.external : false,
      headless: options.headless ? options.headless : false,
      chat: options.chat ? options.chat : true,
      hud: options.hud ? options.hud : true
    }
  }

  async load(): Promise<void> {
    const res = API.getScreenResolution()
    this.browser = API.createCefBrowser(res.Width, res.Height, !this.options.external)

    API.showCursor(this.options.cursor)
    API.setHudVisible(this.options.hud)
    API.setChatVisible(this.options.chat)
    API.setCefBrowserHeadless(this.browser, this.options.headless)

    API.setCefBrowserPosition(this.browser, 0, 0)
    API.waitUntilCefBrowserInit(this.browser)
    API.loadPageCefBrowser(this.browser, this.path)
    API.waitUntilCefBrowserLoaded(this.browser)
    this.open = true
  }

  public eval(str: string): void {
    this.browser.eval(str)
  }
}

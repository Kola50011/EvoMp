/// <reference path='../../../typings/index.d.ts' />

import {Cef} from './Cef'
import {Debugger} from './Debugger'
import {EventListener} from './EventListener'
import {ServerEventHandlerSingleton} from './ServerEventHandlerSingleton'

interface LoginResponse {
  Successfull: boolean
  Messages: String[]
}

/**
 * Respons to Login Authentification Requests from the Server.
 * @author Sascha <sascha@localhost.systems>
 * TODO Add Try Catch around Json.Parse
 */
export class LoginHandler {
  private cef: Cef
  private loginRequestListener: EventListener
  private loginResponseListener: EventListener

  constructor() {
    this.cef = new Cef('Login', './dist/Login.Web/Login.html')
    this.cef.setHudVisible(false)
    this.cef.setChatVisible(false)
    this.cef.setCursorVisible(true)

    this.loginRequestListener = new EventListener(
      'loginRequest',
      this.handleRequest
    )
    this.cef.add(this.loginRequestListener)

    this.loginResponseListener = new EventListener(
      'loginResponse',
      (args: any[]) => this.handleResponse(args)
    )
    ServerEventHandlerSingleton.getInstance().add(this.loginResponseListener)
  }

  /**
   * open the Login Window.
   * @param username {string} Well, the username...
   */
  public async open(username: string): Promise<void> {
    await this.cef.load()
  }

  /**
   * Properly delete all references in all listeners etc.
   */
  public delete() {
    this.cef.remove(this.loginRequestListener)
    this.cef.destroy()

    delete this.cef
    delete this.loginRequestListener
  }

  /**
   * Handles incoming LoginRequest.
   * @param args {any[]}
   */
  private handleRequest(args: any[]): void {
    API.triggerServerEvent('loginRequest', JSON.stringify(args))
  }

  /**
   * Handles incoming loginResponse.
   * @param args {LoginResponse}
   */
  private handleResponse(args: any[]): void {
    try {
      let response: LoginResponse = JSON.parse(args[0])
      if (response.Successfull) {
        this.delete()
      } else {
        this.cef.call('invalid', response)
      }
    } catch (error) {
      Debugger.getInstance().error(error)
    }
  }
}

let openLoginListener = new EventListener('openLogin', (args) => {
  try {
    let username: string = JSON.parse(args[0]).username

    let loginHandler = new LoginHandler()
    loginHandler.open(username)
  } catch (error) {
    Debugger.getInstance().error(error)
  }
})

ServerEventHandlerSingleton.getInstance().add(openLoginListener)

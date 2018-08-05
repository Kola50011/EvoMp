/// <reference path='../../../typings/index.d.ts' />

import Cef from "../../EvoMp.Module.ChromeEmbeddedFramework/Client/Cef"
import EventHandler from "../../EvoMp.Module.EventHandler/Client/EventHandler"
import * as AuthRequest from "./AuthRequest";
import * as AuthResponse from "./AuthResponse";

function sendAuthRequest(args: any): void {
  const request: AuthRequest.AuthRequest = {
    type: "Login",
    username: args.username,
    password: args.password
  }

  API.triggerServerEvent("AuthRequest", JSON.stringify(request))
}

export default async function openLogin(username: string): Promise<void> {
  const loginWindow = new Cef("Login", "dist/EvoMp.Module.Login/Web/Login.html", { headless: false }) // Debug
  loginWindow.addEventListener("LoginAttempt", sendAuthRequest)
  loginWindow.trigger("LoginUsername", API.getPlayerName(API.getLocalPlayer()));
  //loginWindow.
  await loginWindow.load()

  API.showCursor(true)
  const authResponseListener = EventHandler.subscribe("AuthResponse",
    (args: string) => {
      const response: AuthResponse.AuthResponse = JSON.parse(args)
      if (response.success) {
        loginWindow.destroy()
        authResponseListener.unsubscribe()
      } else {
        loginWindow.eval('loginInvalid("ERROR")')
      }
    })
}

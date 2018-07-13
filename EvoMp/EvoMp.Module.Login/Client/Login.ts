/// <reference path='../../../typings/index.d.ts' />

import Cef from "../../EvoMp.Module.ChromeEmbeddedFramework/Client/Cef"
import EventHandler from "../../EvoMp.Module.EventHandler/Client/EventHandler"
import * as AuthRequest from "./AuthRequest";
import * as AuthResponse from "./AuthResponse";

function sendAuthRequest(args: any[]): void {
  const request: AuthRequest.AuthRequest = {
    type: "Login",
    username: args[0].username,
    password: args[0].password
  }

  API.triggerServerEvent("AuthRequest", JSON.stringify(request))
}

export default async function openLogin(username: string): Promise<void> {
  API.sendChatMessage("1")
  const loginWindow = new Cef("Login", "dist/Login.html", { headless: false }) // Debug
  API.sendChatMessage("2")
  loginWindow.addEventListener("LoginAttempt", sendAuthRequest)
  API.sendChatMessage("3")
  await loginWindow.load()
  API.sendChatMessage("4")

  API.showCursor(true)
  API.sendChatMessage("5")
  const authResponseListener = EventHandler.subscribe("AuthResponse",
    (args: string) => {
      API.sendChatMessage("6")
      const response: AuthResponse.AuthResponse = JSON.parse(args)
      API.sendChatMessage("7")
      if (response.success) {
        API.sendChatMessage("8.1")
        loginWindow.destroy()
        API.sendChatMessage("9")
        authResponseListener.unsubscribe()
        API.sendChatMessage("10")
      } else {
        loginWindow.eval('loginInvalid("ERROR")')
        API.sendChatMessage("8.2")
      }
    })
}

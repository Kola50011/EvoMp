/// <reference path='../../../typings/index.d.ts' />

import EventHandler from "../../EvoMp.Module.EventHandler/Client/EventHandler"
import openLogin from "./Login"
import openRegister from "./Register"

import {AuthOpen} from "./AuthOpen"

const resourceStartHandler = API.onResourceStart.connect(initAuthentication)

async function initAuthentication() {
  resourceStartHandler.disconnect()

  const onOpenListener = EventHandler.subscribe("AuthOpen",
    (args: any) => {

      const arg = JSON.parse(args[0]) as AuthOpen

      switch (arg.Type) {
        case "Register":
          openRegister().catch(() => {
            API.sendChatMessage("Exception: onOpenRegister")
          })

          break
        case "Login":
          openLogin(arg.Username || "ERROR").catch((e) => {
            API.sendChatMessage(JSON.stringify(e)); // Debug
            API.sendChatMessage("Exception: onOpenLogin")
          })

          break
        default:
          // TODO: Add better error handling.
          API.sendChatMessage(`Wrong packet received in Auth! ${JSON.stringify(arg)}`)

          break
      }

      onOpenListener.unsubscribe()
    })

  API.triggerServerEvent("ready")
}

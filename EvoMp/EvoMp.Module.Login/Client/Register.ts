/// <reference path='../../../typings/index.d.ts' />

import Cef from "../../EvoMp.Module.Cef/Client/Cef"
import EventHandler from "../../EvoMp.Module.EventHandler/Client/EventHandler"

function sendRegisterRequest(args: any[]) {
  const request: AuthRequest = {
    type: "Register",
    username: args[0].username,
    email: args[0].email,
    password: args[0].password
  };

  API.triggerServerEvent("AuthRequest", JSON.stringify(request));
}

export default async function openRegister(): Promise<void> {
  const browser = new Cef("Register", "dist/Register.html", {});
  browser.addEventListener("onRegister", sendRegisterRequest);

  const listener = EventHandler.subscribe("AuthResponse",
    (args) => {
      const response: AuthResponse = JSON.parse(args[0]);

      if (response.success) {
        listener.unsubscribe();
        browser.destroy();
      } else {
        // TODO: Added proper fu**ing error handling.

        API.sendChatMessage("Immer han i die pech :(");
      }
    });

  await browser.load();
}

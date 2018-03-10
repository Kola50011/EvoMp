import EventHandler from "../../EvoMp.Module.ChromeEmbeddedFramework/Web/EventHandler.ts"

async function initialiseIcons() {
  const UIkit = await import("../../EvoMp.Module.UiKit/Web/uikit.min.js")
  const Icons = await import("../../EvoMp.Module.UiKit/Web/uikit-icons.min.js")

  UIkit.use(Icons)
}

document.addEventListener("DOMContentLoaded",
  () => {
    EventHandler.setName("Login")
    EventHandler.doneLoading()
    initialiseIcons()

    const loginForm = document.getElementById("login-form")
    loginForm.addEventListener("submit",
      event => {
        event.preventDefault()

        const username = event.target.elements.username.value
        const password = event.target.elements.password.value

        EventHandler.trigger("LoginAttempt", { username, password })
      })
  })

import eventHandler from "../../EvoMp.Module.ChromeEmbeddedFramework/Web/EventHandler.js"

async function initalizeIcons() {
  const uIkit = await import("../../EvoMp.Module.UiKit/Web/uikit.min.js")
  const icons = await import("../../EvoMp.Module.UiKit/Web/uikit-icons.min.js")

  uIkit.use(icons)
}


document.addEventListener("DOMContentLoaded",
  () => {
    initalizeIcons()

    // Set login name
    document.addEventListener("LoginUsername", (username) => {
      document.getElementById("username").value = username
    })

    document.getElementById("login-form").addEventListener("submit",
      event => {
        event.preventDefault()

        const username = event.target.elements.username.value
        const password = event.target.elements.password.value

        debugger

        eventHandler.trigger("LoginAttempt", { username, password })
      })
  })


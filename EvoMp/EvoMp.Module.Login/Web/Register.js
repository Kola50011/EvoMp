import eventHandler from "../../EvoMp.Module.ChromeEmbeddedFramework/Web/EventHandler.js"

async function initalizeIcons() {
  const uIkit = await import("../../EvoMp.Module.UiKit/Web/uikit.min.js")
  const icons = await import("../../EvoMp.Module.UiKit/Web/uikit-icons.min.js")

  uIkit.use(icons)
}

document.addEventListener("DOMContentLoaded",
  () => {
    initalizeIcons()

    const registerForm = document.getElementById("register-form")
    registerForm.addEventListener("submit",
      event => {
        event.preventDefault()

        const username = event.target.elements.username.value
        const password = event.target.elements.password.value

        eventHandler.trigger("register", { username, password })
      })
  })

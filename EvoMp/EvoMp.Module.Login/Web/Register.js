import EventHandler from '../../EvoMp.Module.Cef/Web/EventHandler.ts'

async function initialiseIcons () {
  const UIkit = await import('../../EvoMp.Module.UIKit/Web/uikit.min.js')
  const Icons = await import('../../EvoMp.Module.UIKit/Web/uikit-icons.min.js')

  UIkit.use(Icons)
}

document.addEventListener('DOMContentLoaded', () => {
  EventHandler.setName('Register')
  EventHandler.doneLoading()
  initialiseIcons()

  const registerForm = document.getElementById('register-form')
  registerForm.addEventListener('submit', event => {
    event.preventDefault()

    const username = event.target.elements.username.value
    const password = event.target.elements.password.value

    EventHandler.trigger('register', { username, password })
  })
})

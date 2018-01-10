async function doStuff () {
  const UIkit = await import('../../EvoMp.Modules.UIKit/Web/uikit.min.js')
  const Icons = await import('../../EvoMp.Modules.UIKit/Web/uikit-icons.min.js')

  UIkit.use(Icons)

  try {
    resourceEval(`API.sendChatMessage("Login open!")`)
  } catch (error) {
    console.warn('resourceEval not supported!')
  }
}

document.addEventListener('DOMContentLoaded', () => {
  doStuff()
})

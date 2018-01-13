import EventHandler from '../../EvoMp.Module.Cef/Web/EventHandler.ts'

async function doStuff () {
  const UIkit = await import('../../EvoMp.Module.UIKit/Web/uikit.min.js')
  const Icons = await import('../../EvoMp.Module.UIKit/Web/uikit-icons.min.js')

  UIkit.use(Icons)
}

document.addEventListener('DOMContentLoaded', () => {
  EventHandler.setName('Login')
  EventHandler.doneLoading()
  doStuff()
})

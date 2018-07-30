export default class EventHandler {

  static doneLoading() {
    this.trigger("DoneLoading")
  }

  static trigger(eventName, obj) {
    console.log(`[Event dispatched]: ${eventName}`, obj)

    if (this.getResourceCallSupport()) {
      resourceCall("resource.CEC.trigger", 'Login', eventName, JSON.stringify(obj))
    }
  }

  static getResourceCallSupport() {
    try {
      return resourceCall !== null
    } catch (e) {
      console.warn('ResourceCall is not supported!')

      return false
    }
  }
}

document.addEventListener("DOMContentLoaded",
  () => {
    EventHandler.doneLoading()
  })

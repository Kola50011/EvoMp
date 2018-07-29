export default class eventHandler {

  static doneLoading() {
    this.trigger("DoneLoading")
  }

  static trigger(eventName, ...args) {
    console.debug(`[Event dispatched]: ${eventName}`, args)

    if (typeof supportsResourceCall === "undefined") {
      supportsResourceCall = this.getResourceCallSupport()
    }

    if (this.supportsResourceCall) {
      resourceCall("resource.CEF.trigger", this.eventName, args)
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

var supportsResourceCall

document.addEventListener("DOMContentLoaded",
  () => {
    eventHandler.doneLoading()

  })

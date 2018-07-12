class EventHandler {
  static name

  static supportsResourceCall = null

  static setName(identifier) {
    this.name = name
  }

  static doneLoading() {
    this.trigger("doneLoading")
  }

  static trigger(eventName, ...args) {
    if (this.supportsResourceCall === null) {
      this.supportsResourceCall = this.getResourceCallSupport()
    }

    if (this.supportsResourceCall) {
      resourceCall("resource.CEC.trigger", this.eventName, args)
    }

    console.debug(`[Event dispatched]: ${eventName}`, args)
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

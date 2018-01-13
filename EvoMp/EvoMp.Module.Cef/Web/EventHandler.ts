/// <reference path='../../../typings/index.d.ts' />

export default class EventHandler {
  private static identifier: string
  private static supportsResourceCall: boolean = null

  public static setName(identifier: string): void {
    this.identifier = identifier
  }

  public static doneLoading (): void {
    this.trigger('doneLoading')
  }

  public static trigger (eventName: string, ...args: any[]) {
    if (this.supportsResourceCall === null) {
      this.supportsResourceCall = this.getResourceCallSupport()
    }

    if (this.supportsResourceCall) {
      resourceCall('resource.CEC.trigger', this.identifier, args)
    }

    console.debug('[Event dispatched]: ' + eventName, args)
  }

  private static getResourceCallSupport (): boolean {
    try {
      return resourceCall === null
    } catch {
      console.warn('ResourceCall is not supported!')
      return false
    }
  }
}

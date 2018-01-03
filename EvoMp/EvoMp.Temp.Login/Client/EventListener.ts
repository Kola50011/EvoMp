export class EventListener {
  private name: string
  private callback: (args: any[]) => void

  constructor (name: string, callback: (args: any[]) => void) {
    this.name = name
    this.callback = callback
  }

  public run (args: any[]): void {
    this.callback(args)
  }

  public getName (): string { return this.name }
  public getCallback (): (args: any[]) => void { return this.callback }
}

import Cef from "../../EvoMp.Module.Cef/Client/Cef"
import Notification from "./Notification"

export class Notifications {
  private static cef: Cef

  public static async send(notification: Notification): Promise<void> {
    if (!this.cef) {
      await this.init();
    }

    this.cef.call('notify', notification)
  }

  private static async init() {
    this.cef = new Cef('Notifications', 'Notifications.html', {})
    await this.cef.load();
  }
}

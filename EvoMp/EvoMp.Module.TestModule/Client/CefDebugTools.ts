/// <reference path='../../../typings/index.d.ts' />
API.onKeyDown.connect(
  (sender, key) => {
    if (key.KeyCode === Keys.M) {
      let newState: boolean = !API.isCursorShown()
      API.showCursor(newState)
      API.sendNotification(`Cursor: ~b~${API.isCursorShown()}, ${newState}`)
    }
  }
);

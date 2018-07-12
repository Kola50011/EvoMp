/// <reference path='../../../typings/index.d.ts' />
API.onKeyDown.connect(function (sender, key) {
    if (key.KeyCode === Keys.M) {
        var newState = !API.isCursorShown();
        API.showCursor(newState);
        API.sendNotification("Cursor: ~b~" + API.isCursorShown() + ", " + newState);
    }
});
//# sourceMappingURL=CefDebugTools.js.map
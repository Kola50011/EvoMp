"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/**
 * Collects events from all the CEFs and forwards them.
 * @author Sascha <sascha(at)localhost.systems>
 */
var CefEventCollector = /** @class */ (function () {
    function CefEventCollector() {
    }
    CefEventCollector.trigger = function (cefName, event, args) {
        if (!this.cefs[cefName])
            return;
        this.cefs[cefName].trigger(event, args);
    };
    CefEventCollector.register = function (cef) {
        this.cefs[cef.identifier] = cef;
    };
    CefEventCollector.unregister = function (cef) {
        delete this.cefs[cef.identifier];
    };
    CefEventCollector.cefs = {};
    return CefEventCollector;
}());
exports.CefEventCollector = CefEventCollector;
// So we can uniquely identify the CEC from each CEF.
var resourceStartHandler = API.onResourceStart.connect(function () {
    resourceStartHandler.disconnect();
    resource.CEC = new CefEventCollector();
});
//# sourceMappingURL=CefEventCollector.js.map
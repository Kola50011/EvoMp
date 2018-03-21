"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path='../../../typings/index.d.ts' />
var EventHandler_1 = require("../../EvoMp.Module.EventHandler/Client/EventHandler");
var resourceStartHandler = API.onResourceStart.connect(registerEvents);
API.onUpdate.connect(onUpdate);
var playbackWaypoints = [];
function registerEvents() {
    // Save recived Waypoints to local list
    EventHandler_1.default.subscribe("BotHandler.BotPlaybackWaypoints", function (args) {
        var vehicle = args[0], velocitys = args[1], rotations = args[2];
        playbackWaypoints.push({
            vehicle: vehicle,
            velocitys: velocitys,
            rotations: rotations,
            active: false
        });
        // Send recived event to Server, to count playback users
        API.triggerServerEvent("BotHandler.RecivedWaypoints", vehicle);
    });
    // Save recived Waypoints to local list
    EventHandler_1.default.subscribe("BotHandler.StartPlayback", function (args) {
        var vehicle = args[0];
        for (var i = 0; i < playbackWaypoints.length; i++) {
            if (playbackWaypoints[i].vehicle === vehicle) {
                playbackWaypoints[i].active = true;
            }
        }
    });
    resourceStartHandler.disconnect();
}
function onUpdate() {
    playbackWaypoints.forEach(function (value, index, array) {
        // Not active -> return
        if (!value.active) {
            return;
        }
        // No more waypoints -> remove & return
        if (value.velocitys.length === 0) {
            API.triggerServerEvent("BotHandler.PlaybackDone", value.vehicle);
            playbackWaypoints.splice(index, 1);
            return;
        }
        // Apply first waypoints
        API.setEntityRotation(value.vehicle, value.rotations[0]);
        API.setEntityVelocity(value.vehicle, value.velocitys[0]);
        // remove first waypoints
        value.rotations.shift();
        value.velocitys.shift();
    });
}
//# sourceMappingURL=BotHandler.js.map
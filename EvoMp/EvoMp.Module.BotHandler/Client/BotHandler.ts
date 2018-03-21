/// <reference path='../../../typings/index.d.ts' />
import EventHandler from "../../EvoMp.Module.EventHandler/Client/EventHandler"
import {IPlaybackBot} from "./Models/IPlaybackBot";
const resourceStartHandler = API.onResourceStart.connect(registerEvents)
API.onUpdate.connect(onUpdate)

let playbackWaypoints: IPlaybackBot[] = []

function registerEvents() {

  // Save recived Waypoints to local list
  EventHandler.subscribe("BotHandler.BotPlaybackWaypoints",
    (args: any) => {
      const [vehicle, velocitys, rotations] = args
        playbackWaypoints.push({
          vehicle,
          velocitys,
          rotations,
          active: false
        })
      // Send recived event to Server, to count playback users
      API.triggerServerEvent("BotHandler.RecivedWaypoints", vehicle)
    })

  // Save recived Waypoints to local list
  EventHandler.subscribe("BotHandler.StartPlayback",
    (args: any) => {
      const [vehicle] = args

      for (let i = 0; i < playbackWaypoints.length; i++) {
        if (playbackWaypoints[i].vehicle === vehicle) {
          playbackWaypoints[i].active = true
        }
      }
    })

  resourceStartHandler.disconnect()
}

function onUpdate(): void{
  playbackWaypoints.forEach((value: IPlaybackBot, index: number, array: IPlaybackBot[]) => {

    // Not active -> return
    if (!value.active) {
      return
    }

    // No more waypoints -> remove & return
    if (value.velocitys.length === 0) {
      API.triggerServerEvent("BotHandler.PlaybackDone", value.vehicle)
      playbackWaypoints.splice(index, 1)
      return
    }

    // Apply first waypoints
    API.setEntityRotation(value.vehicle, value.rotations[0])
    API.setEntityVelocity(value.vehicle, value.velocitys[0])

    // remove first waypoints
    value.rotations.shift()
    value.velocitys.shift()
  })

}


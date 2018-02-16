/// <reference path='../../../typings/index.d.ts' />
import EventHandler from '../../EvoMp.Module.EventHandler/Client/EventHandler'

export default function initSetFunctions() {
  EventHandler.subscribe('ClientWrapper.Set.setSetting', (args: any) => { API.setSetting(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setGameplayCameraActive',
    (args: any) => { API.setGameplayCameraActive() })
  EventHandler.subscribe('ClientWrapper.Set.setCanOpenChat', (args: any) => { API.setCanOpenChat(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setDisplayWastedShard',
    (args: any) => { API.setDisplayWastedShard(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setUiColor', (args: any) => { API.setUiColor(args[0], args[1], args[2]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityInvincible',
    (args: any) => { API.setEntityInvincible(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleLivery',
    (args: any) => { API.setVehicleLivery(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleLocked',
    (args: any) => { API.setVehicleLocked(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleDoorState',
    (args: any) => { API.setVehicleDoorState(args[0], args[1], args[2]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleExtra',
    (args: any) => { API.setVehicleExtra(args[0], args[1], args[2]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleNumberPlate',
    (args: any) => { API.setVehicleNumberPlate(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleEngineStatus',
    (args: any) => { API.setVehicleEngineStatus(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleSpecialLightStatus',
    (args: any) => { API.setVehicleSpecialLightStatus(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityCollissionless',
    (args: any) => { API.setEntityCollissionless(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleMod',
    (args: any) => { API.setVehicleMod(args[0], args[1], args[2]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleBulletproofTyres',
    (args: any) => { API.setVehicleBulletproofTyres(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleNumberPlateStyle',
    (args: any) => { API.setVehicleNumberPlateStyle(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehiclePearlescentColor',
    (args: any) => { API.setVehiclePearlescentColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleWheelColor',
    (args: any) => { API.setVehicleWheelColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleWheelType',
    (args: any) => { API.setVehicleWheelType(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleModColor1',
    (args: any) => { API.setVehicleModColor1(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleModColor2',
    (args: any) => { API.setVehicleModColor2(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleTyreSmokeColor',
    (args: any) => { API.setVehicleTyreSmokeColor(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleWindowTint',
    (args: any) => { API.setVehicleWindowTint(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleEnginePowerMultiplier',
    (args: any) => { API.setVehicleEnginePowerMultiplier(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleEngineTorqueMultiplier',
    (args: any) => { API.setVehicleEngineTorqueMultiplier(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleNeonState',
    (args: any) => { API.setVehicleNeonState(args[0], args[1], args[2]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleNeonColor',
    (args: any) => { API.setVehicleNeonColor(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleDashboardColor',
    (args: any) => { API.setVehicleDashboardColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleTrimColor',
    (args: any) => { API.setVehicleTrimColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerNametag',
    (args: any) => { API.setPlayerNametag(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerNametagVisible',
    (args: any) => { API.setPlayerNametagVisible(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerNametagColor',
    (args: any) => { API.setPlayerNametagColor(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerSkin', (args: any) => { API.setPlayerSkin(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerDefaultClothes',
    (args: any) => { API.setPlayerDefaultClothes() })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerTeam', (args: any) => { API.setPlayerTeam(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehiclePrimaryColor',
    (args: any) => { API.setVehiclePrimaryColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleSecondaryColor',
    (args: any) => { API.setVehicleSecondaryColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleCustomPrimaryColor',
    (args: any) => { API.setVehicleCustomPrimaryColor(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setVehicleCustomSecondaryColor',
    (args: any) => { API.setVehicleCustomSecondaryColor(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerClothes',
    (args: any) => { API.setPlayerClothes(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerAccessory',
    (args: any) => { API.setPlayerAccessory(args[0], args[1], args[2], args[3]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityPositionFrozen',
    (args: any) => { API.setEntityPositionFrozen(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityVelocity',
    (args: any) => { API.setEntityVelocity(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerWeaponTint',
    (args: any) => { API.setPlayerWeaponTint(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityPosition',
    (args: any) => { API.setEntityPosition(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityRotation',
    (args: any) => { API.setEntityRotation(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerIntoVehicle',
    (args: any) => { API.setPlayerIntoVehicle(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerHealth', (args: any) => { API.setPlayerHealth(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setTextLabelText',
    (args: any) => { API.setTextLabelText(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setTextLabelColor',
    (args: any) => { API.setTextLabelColor(args[0], args[1], args[2], args[3], args[4]) })
  EventHandler.subscribe('ClientWrapper.Set.setTextLabelSeethrough',
    (args: any) => { API.setTextLabelSeethrough(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerInvincible', (args: any) => { API.setPlayerInvincible(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerWantedLevel',
    (args: any) => { API.setPlayerWantedLevel(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setPlayerArmor', (args: any) => { API.setPlayerArmor(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipPosition',
    (args: any) => { API.setBlipPosition(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setWaypoint', (args: any) => { API.setWaypoint(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipColor', (args: any) => { API.setBlipColor(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipSprite', (args: any) => { API.setBlipSprite(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipName', (args: any) => { API.setBlipName(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipTransparency',
    (args: any) => { API.setBlipTransparency(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipShortRange',
    (args: any) => { API.setBlipShortRange(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipScale', (args: any) => { API.setBlipScale(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setBlipScale', (args: any) => { API.setBlipScale(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setChatVisible', (args: any) => { API.setChatVisible(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setHudVisible', (args: any) => { API.setHudVisible(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setMarkerType', (args: any) => { API.setMarkerType(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setMarkerColor',
    (args: any) => { API.setMarkerColor(args[0], args[1], args[2], args[3], args[4]) })
  EventHandler.subscribe('ClientWrapper.Set.setMarkerScale', (args: any) => { API.setMarkerScale(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setMarkerDirection',
    (args: any) => { API.setMarkerDirection(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setAudioTime', (args: any) => { API.setAudioTime(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setGameVolume', (args: any) => { API.setGameVolume(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityTransparency',
    (args: any) => { API.setEntityTransparency(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setEntityDimension',
    (args: any) => { API.setEntityDimension(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setWeather', (args: any) => { API.setWeather(args[0]) })
  EventHandler.subscribe('ClientWrapper.Set.setTime', (args: any) => { API.setTime(args[0], args[1]) })
}

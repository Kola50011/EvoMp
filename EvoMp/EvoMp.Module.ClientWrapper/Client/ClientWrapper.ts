/// <reference path='../../../typings/index.d.ts' />
import EventHandler from '../../EvoMp.Module.EventHandler/Client/EventHandler'
const resourceStartHandler = API.onResourceStart.connect(registerEvents)

// Regex for replace params from typing with args[X]
// (?!\([^(]+)(([\w :.\?]|\[\])+)(?=\)}|,)


function registerEvents() {
  initSetFunctions()
  initGetFunctions()
  API.sendChatMessage('Testing')
  resourceStartHandler.disconnect()
};

function initGetFunctions() {
  EventHandler.subscribe('ClientWrapper.Get.getDiscordPresenceActivity', (args: any) => {
    API.triggerServerEvent(args[0], API.getDiscordPresenceActivity())
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleAntiRollBarBiasFront', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleAntiRollBarBiasFront(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleAntiRollBarForce', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleAntiRollBarForce(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleBrakeForce', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleBrakeForce(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleCamberStiffness', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleCamberStiffness(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleCenterOfMassOffset', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleCenterOfMassOffset(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleClutchChangeRateScaleDownShift', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleClutchChangeRateScaleDownShift(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleClutchChangeRateScaleUpShift', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleClutchChangeRateScaleUpShift(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleCollisionDamageMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleCollisionDamageMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDeformationDamageMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDeformationDamageMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDriveInertia', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDriveInertia(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleEngineDamageMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleEngineDamageMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleHandBrakeForce', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleHandBrakeForce(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleInertiaMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleInertiaMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleInitialDriveForce', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleInitialDriveForce(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleInitialDriveGears', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleInitialDriveGears(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMass', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMass(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMonetaryValue', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMonetaryValue(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehiclePercentSubmerged', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehiclePercentSubmerged(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleRollCenterHeightFront', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleRollCenterHeightFront(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleRollCenterHeightRear', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleRollCenterHeightRear(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSeatOffsetDistanceX', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSeatOffsetDistanceX(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSeatOffsetDistanceY', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSeatOffsetDistanceY(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSeatOffsetDistanceZ', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSeatOffsetDistanceZ(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSteeringLock', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSteeringLock(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionBiasFront', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionBiasFront(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionCompressionDamping', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionCompressionDamping(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionForce', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionForce(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionLowerLimit', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionLowerLimit(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionRaise', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionRaise(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionReboundDamping', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionReboundDamping(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSuspensionUpperLimit', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSuspensionUpperLimit(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTractionBiasFront', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTractionBiasFront(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTractionCurveMax', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTractionCurveMax(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTractionCurveMin', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTractionCurveMin(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTractionLossMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTractionLossMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTractionSpringDeltaMax', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTractionSpringDeltaMax(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDriveBiasFront', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDriveBiasFront(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleBrakeBiasFront', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleBrakeBiasFront(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleInitialDragCoefficiency', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleInitialDragCoefficiency(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleInitialDriveMaxFlatVelocity', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleInitialDriveMaxFlatVelocity(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getCharFromKey', (args: any) => {
    API.triggerServerEvent(args[0], API.getCharFromKey(args[1], args[2], args[3], args[4]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getClosestProp', (args: any) => {
    API.triggerServerEvent(args[0], API.getClosestProp(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNearbyProps', (args: any) => {
    API.triggerServerEvent(args[0], API.getNearbyProps(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getWorldProps', (args: any) => {
    API.triggerServerEvent(args[0], API.getWorldProps(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllLoadedAsiNames', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllLoadedAsiNames())
  })
  EventHandler.subscribe('ClientWrapper.Get.getLoadedAsiHash', (args: any) => {
    API.triggerServerEvent(args[0], API.getLoadedAsiHash(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllActiveModDlcPacksNames', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllActiveModDlcPacksNames())
  })
  EventHandler.subscribe('ClientWrapper.Get.getModDlcPackHash', (args: any) => {
    API.triggerServerEvent(args[0], API.getModDlcPackHash(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllModdedFileNames', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllModdedFileNames())
  })
  EventHandler.subscribe('ClientWrapper.Get.getModdedFileHash', (args: any) => {
    API.triggerServerEvent(args[0], API.getModdedFileHash(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllCustomScriptsNames', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllCustomScriptsNames())
  })
  EventHandler.subscribe('ClientWrapper.Get.getCustomScriptHash', (args: any) => {
    API.triggerServerEvent(args[0], API.getCustomScriptHash(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAnimCurrentTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getAnimCurrentTime(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAnimTotalTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getAnimTotalTime(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAnimTotalTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getAnimTotalTime(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getGameFramerate', (args: any) => {
    API.triggerServerEvent(args[0], API.getGameFramerate())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGameText', (args: any) => {
    API.triggerServerEvent(args[0], API.getGameText(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getGameTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getGameTime())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGlobalTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getGlobalTime())
  })
  EventHandler.subscribe('ClientWrapper.Get.getHashKey', (args: any) => {
    API.triggerServerEvent(args[0], API.getHashKey(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAlternativeMainMenuKeyDisabled', (args: any) => {
    API.triggerServerEvent(args[0], API.getAlternativeMainMenuKeyDisabled())
  })
  EventHandler.subscribe('ClientWrapper.Get.getCultureISOLanguageName', (args: any) => {
    API.triggerServerEvent(args[0], API.getCultureISOLanguageName())
  })
  EventHandler.subscribe('ClientWrapper.Get.getMusicVolume', (args: any) => {
    API.triggerServerEvent(args[0], API.getMusicVolume())
  })
  EventHandler.subscribe('ClientWrapper.Get.getMusicTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getMusicTime())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAudioTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getAudioTime())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGameplayCamPos', (args: any) => {
    API.triggerServerEvent(args[0], API.getGameplayCamPos())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGameplayCamRot', (args: any) => {
    API.triggerServerEvent(args[0], API.getGameplayCamRot())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGameplayCamDir', (args: any) => {
    API.triggerServerEvent(args[0], API.getGameplayCamDir())
  })
  EventHandler.subscribe('ClientWrapper.Get.getBytesSentPerSecond', (args: any) => {
    API.triggerServerEvent(args[0], API.getBytesSentPerSecond())
  })
  EventHandler.subscribe('ClientWrapper.Get.getBytesReceivedPerSecond', (args: any) => {
    API.triggerServerEvent(args[0], API.getBytesReceivedPerSecond())
  })
  EventHandler.subscribe('ClientWrapper.Get.getControlNormal', (args: any) => {
    API.triggerServerEvent(args[0], API.getControlNormal(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getDisabledControlNormal', (args: any) => {
    API.triggerServerEvent(args[0], API.getDisabledControlNormal(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getFontWidth', (args: any) => {
    API.triggerServerEvent(args[0], API.getFontWidth(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityQuaternion', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityQuaternion(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityRotation', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityRotation(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityLeftPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityLeftPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityRightPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityRightPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityFrontPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityFrontPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityRearPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityRearPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityAbovePosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityAbovePosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBelowPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBelowPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityForwardVector', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityForwardVector(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityRightVector', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityRightVector(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityUpVector', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityUpVector(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityVelocity', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityVelocity(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityTransparency', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityTransparency(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityType', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityType(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityDimension', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityDimension(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityModel', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityModel(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityInvincible', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityInvincible(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBoneCount', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBoneCount(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBoneIndexByName', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBoneIndexByName(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBoneWorldPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBoneWorldPosition(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBoneWorldPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBoneWorldPosition(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBoneRelativePosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBoneRelativePosition(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityBoneRelativePosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityBoneRelativePosition(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityHasCollided', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityHasCollided(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntityCollisionless', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntityCollisionless(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getEntitySyncedData', (args: any) => {
    API.triggerServerEvent(args[0], API.getEntitySyncedData(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllEntitySyncedData', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllEntitySyncedData(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getWorldSyncedData', (args: any) => {
    API.triggerServerEvent(args[0], API.getWorldSyncedData(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllWorldSyncedData', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllWorldSyncedData())
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipPosition(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipSprite', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipSprite(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipName', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipTransparency', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipTransparency(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipShortRange', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipShortRange(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipScale', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipScale(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipRouteVisible', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipRouteVisible(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipRouteColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipRouteColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipFlashing', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipFlashing(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBlipScaleToMapZoom', (args: any) => {
    API.triggerServerEvent(args[0], API.getBlipScaleToMapZoom(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getMarkerType', (args: any) => {
    API.triggerServerEvent(args[0], API.getMarkerType(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getMarkerColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getMarkerColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getMarkerScale', (args: any) => {
    API.triggerServerEvent(args[0], API.getMarkerScale(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getMarkerDirection', (args: any) => {
    API.triggerServerEvent(args[0], API.getMarkerDirection(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getMarkerBobUpAndDown', (args: any) => {
    API.triggerServerEvent(args[0], API.getMarkerBobUpAndDown(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getBoneName', (args: any) => {
    API.triggerServerEvent(args[0], API.getBoneName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPedCanRagdoll', (args: any) => {
    API.triggerServerEvent(args[0], API.getPedCanRagdoll())
  })
  EventHandler.subscribe('ClientWrapper.Get.getMaxHealth', (args: any) => {
    API.triggerServerEvent(args[0], API.getMaxHealth())
  })
  EventHandler.subscribe('ClientWrapper.Get.getPedHeadShotTextureString', (args: any) => {
    API.triggerServerEvent(args[0], API.getPedHeadShotTextureString(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getTextLabelColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getTextLabelColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getTextLabelSeethrough', (args: any) => {
    API.triggerServerEvent(args[0], API.getTextLabelSeethrough(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getClosestVehicle', (args: any) => {
    API.triggerServerEvent(args[0], API.getClosestVehicle(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNearbyVehicles', (args: any) => {
    API.triggerServerEvent(args[0], API.getNearbyVehicles(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleLivery', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleLivery(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDeluxoTransformation', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDeluxoTransformation(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSubmarineTransformed', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSubmarineTransformed(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleOppressorTransformation', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleOppressorTransformation(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getCurrentVehicleRadioStationId', (args: any) => {
    API.triggerServerEvent(args[0], API.getCurrentVehicleRadioStationId())
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleRadioEnabled', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleRadioEnabled())
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleRadioRetuning', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleRadioRetuning())
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleLocked', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleLocked(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTrailer', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTrailer(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTruck', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTruck(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTraileredBy', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTraileredBy(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSirenState', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSirenState(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleModSlotName', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleModSlotName(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleModTextLabel', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleModTextLabel(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleLiveryName', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleLiveryName(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDoorState', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDoorState(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleExtra', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleExtra(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleNumberPlate', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleNumberPlate(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleEngineStatus', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleEngineStatus(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSpecialLightStatus', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSpecialLightStatus(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleNumModCount', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleNumModCount(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMod', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMod(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleEngineTemperature', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleEngineTemperature(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTurbo', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTurbo(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleClutch', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleClutch(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleThrottle', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleThrottle(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleThrottlePower', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleThrottlePower(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleBrakePower', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleBrakePower(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleOilLevel', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleOilLevel(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleFuelLevel', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleFuelLevel(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDirtLevel', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDirtLevel(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleBulletproofTyres', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleBulletproofTyres(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleNumberPlateStyle', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleNumberPlateStyle(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehiclePearlescentColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehiclePearlescentColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleWheelColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleWheelColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleWheelType', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleWheelType(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleWindowTint', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleWindowTint(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleEnginePowerMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleEnginePowerMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleEngineTorqueMultiplier', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleEngineTorqueMultiplier(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleNeonState', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleNeonState(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleNeonColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleNeonColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDashboardColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDashboardColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleTrimColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleTrimColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleDisplayName', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleDisplayName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMaxSpeed', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMaxSpeed(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMaxBraking', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMaxBraking(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMaxTraction', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMaxTraction(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMaxAcceleration', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMaxAcceleration(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleMaxOccupants', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleMaxOccupants(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleClass', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleClass(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleCustomPrimaryColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleCustomPrimaryColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleCustomSecondaryColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleCustomSecondaryColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehiclePrimaryColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehiclePrimaryColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleSecondaryColor', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleSecondaryColor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleHealth', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleHealth(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehiclePetrolTankHealth', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehiclePetrolTankHealth(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleRPM', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleRPM(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleHighGear', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleHighGear(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleCurrentGear', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleCurrentGear(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleModelName', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleModelName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getCanOpenChat', (args: any) => {
    API.triggerServerEvent(args[0], API.getCanOpenChat())
  })
  EventHandler.subscribe('ClientWrapper.Get.getChatVisible', (args: any) => {
    API.triggerServerEvent(args[0], API.getChatVisible())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAlternativeVersionLabelPositionActive', (args: any) => {
    API.triggerServerEvent(args[0], API.getAlternativeVersionLabelPositionActive())
  })
  EventHandler.subscribe('ClientWrapper.Get.getShowWastedScreenOnDeath', (args: any) => {
    API.triggerServerEvent(args[0], API.getShowWastedScreenOnDeath())
  })
  EventHandler.subscribe('ClientWrapper.Get.getVehicleEnteringKeysDisabled', (args: any) => {
    API.triggerServerEvent(args[0], API.getVehicleEnteringKeysDisabled())
  })
  EventHandler.subscribe('ClientWrapper.Get.getScreenResolutionMantainRatio', (args: any) => {
    API.triggerServerEvent(args[0], API.getScreenResolutionMantainRatio())
  })
  EventHandler.subscribe('ClientWrapper.Get.getScreenResolutionMaintainRatio', (args: any) => {
    API.triggerServerEvent(args[0], API.getScreenResolutionMaintainRatio())
  })
  EventHandler.subscribe('ClientWrapper.Get.getScreenResolution', (args: any) => {
    API.triggerServerEvent(args[0], API.getScreenResolution())
  })
  EventHandler.subscribe('ClientWrapper.Get.getWaypointPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getWaypointPosition())
  })
  EventHandler.subscribe('ClientWrapper.Get.getHudVisible', (args: any) => {
    API.triggerServerEvent(args[0], API.getHudVisible())
  })
  EventHandler.subscribe('ClientWrapper.Get.getUserInput', (args: any) => {
    API.triggerServerEvent(args[0], API.getUserInput(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNamedRenderTargetRenderID', (args: any) => {
    API.triggerServerEvent(args[0], API.getNamedRenderTargetRenderID(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getUniqueHardwareId', (args: any) => {
    API.triggerServerEvent(args[0], API.getUniqueHardwareId())
  })
  EventHandler.subscribe('ClientWrapper.Get.getSocialClubName', (args: any) => {
    API.triggerServerEvent(args[0], API.getSocialClubName())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGamePlayer', (args: any) => {
    API.triggerServerEvent(args[0], API.getGamePlayer())
  })
  EventHandler.subscribe('ClientWrapper.Get.getLocalPlayer', (args: any) => {
    API.triggerServerEvent(args[0], API.getLocalPlayer())
  })
  EventHandler.subscribe('ClientWrapper.Get.getLocalPlayerInvincible', (args: any) => {
    API.triggerServerEvent(args[0], API.getLocalPlayerInvincible())
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerNametagVisible', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerNametagVisible(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerHealthbarVisible', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerHealthbarVisible(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerArmorbarVisible', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerArmorbarVisible(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getLocalPlayerAimingAtEntity', (args: any) => {
    API.triggerServerEvent(args[0], API.getLocalPlayerAimingAtEntity())
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerAimingPoint', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerAimingPoint(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerTeam', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerTeam(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerWantedLevel', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerWantedLevel())
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerInvincible', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerInvincible())
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerArmor', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerArmor(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerByName', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerByName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerName', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerVehicleSeatIndex', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerVehicleSeatIndex(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerVehicleSeat', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerVehicleSeat(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerSeatbelt', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerSeatbelt(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerHealth', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerHealth(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerAimCoords', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerAimCoords(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerPing', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerPing(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerVehicle', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerVehicle(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerHeadOverlayValue', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerHeadOverlayValue(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getFirstParentIdForPedType', (args: any) => {
    API.triggerServerEvent(args[0], API.getFirstParentIdForPedType(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNumHeadOverlayValues', (args: any) => {
    API.triggerServerEvent(args[0], API.getNumHeadOverlayValues(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNumHairColors', (args: any) => {
    API.triggerServerEvent(args[0], API.getNumHairColors())
  })
  EventHandler.subscribe('ClientWrapper.Get.getNumMakeupColors', (args: any) => {
    API.triggerServerEvent(args[0], API.getNumMakeupColors())
  })
  EventHandler.subscribe('ClientWrapper.Get.getTattooZone', (args: any) => {
    API.triggerServerEvent(args[0], API.getTattooZone(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getTattooZone', (args: any) => {
    API.triggerServerEvent(args[0], API.getTattooZone(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerWeaponTint', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerWeaponTint(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getWeaponAmmo', (args: any) => {
    API.triggerServerEvent(args[0], API.getWeaponAmmo(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getAmmoInClip', (args: any) => {
    API.triggerServerEvent(args[0], API.getAmmoInClip())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllWeaponComponents', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllWeaponComponents(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getPlayerCurrentWeapon', (args: any) => {
    API.triggerServerEvent(args[0], API.getPlayerCurrentWeapon())
  })
  EventHandler.subscribe('ClientWrapper.Get.getWeaponName', (args: any) => {
    API.triggerServerEvent(args[0], API.getWeaponName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getCursorPosition', (args: any) => {
    API.triggerServerEvent(args[0], API.getCursorPosition())
  })
  EventHandler.subscribe('ClientWrapper.Get.getCursorPositionMantainRatio', (args: any) => {
    API.triggerServerEvent(args[0], API.getCursorPositionMantainRatio())
  })
  EventHandler.subscribe('ClientWrapper.Get.getCursorPositionMaintainRatio', (args: any) => {
    API.triggerServerEvent(args[0], API.getCursorPositionMaintainRatio())
  })
  EventHandler.subscribe('ClientWrapper.Get.getSetting', (args: any) => {
    API.triggerServerEvent(args[0], API.getSetting(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedPlayers', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedPlayers())
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedVehicles', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedVehicles())
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedObjects', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedObjects())
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedPickups', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedPickups())
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedPeds', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedPeds())
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedMarkers', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedMarkers())
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreamedTextLabels', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreamedTextLabels())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllPlayers', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllPlayers())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllVehicles', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllVehicles())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllObjects', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllObjects())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllPickups', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllPickups())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllPeds', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllPeds())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllMarkers', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllMarkers())
  })
  EventHandler.subscribe('ClientWrapper.Get.getAllTextLabels', (args: any) => {
    API.triggerServerEvent(args[0], API.getAllTextLabels())
  })
  EventHandler.subscribe('ClientWrapper.Get.getWeather', (args: any) => {
    API.triggerServerEvent(args[0], API.getWeather())
  })
  EventHandler.subscribe('ClientWrapper.Get.getNextWeather', (args: any) => {
    API.triggerServerEvent(args[0], API.getNextWeather())
  })
  EventHandler.subscribe('ClientWrapper.Get.getWeatherTransitionType', (args: any) => {
    API.triggerServerEvent(args[0], API.getWeatherTransitionType())
  })
  EventHandler.subscribe('ClientWrapper.Get.getTime', (args: any) => {
    API.triggerServerEvent(args[0], API.getTime())
  })
  EventHandler.subscribe('ClientWrapper.Get.getOffsetInWorldCoords', (args: any) => {
    API.triggerServerEvent(args[0], API.getOffsetInWorldCoords(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getSafeCoordForPed', (args: any) => {
    API.triggerServerEvent(args[0], API.getSafeCoordForPed(args[1], args[2], args[3]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNextPositionOnStreet', (args: any) => {
    API.triggerServerEvent(args[0], API.getNextPositionOnStreet(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getNextPositionOnSidewalk', (args: any) => {
    API.triggerServerEvent(args[0], API.getNextPositionOnSidewalk(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getOffsetFromWorldCoords', (args: any) => {
    API.triggerServerEvent(args[0], API.getOffsetFromWorldCoords(args[1], args[2]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getStreetName', (args: any) => {
    API.triggerServerEvent(args[0], API.getStreetName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getZoneName', (args: any) => {
    API.triggerServerEvent(args[0], API.getZoneName(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getZoneNameLabel', (args: any) => {
    API.triggerServerEvent(args[0], API.getZoneNameLabel(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getGroundHeight', (args: any) => {
    API.triggerServerEvent(args[0], API.getGroundHeight(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getInteriorAtPos', (args: any) => {
    API.triggerServerEvent(args[0], API.getInteriorAtPos(args[1]))
  })
  EventHandler.subscribe('ClientWrapper.Get.getCityBlackout', (args: any) => {
    API.triggerServerEvent(args[0], API.getCityBlackout())
  })
  EventHandler.subscribe('ClientWrapper.Get.getWorldLimits', (args: any) => {
    API.triggerServerEvent(args[0], API.getWorldLimits())
  })
  EventHandler.subscribe('ClientWrapper.Get.getGravityLevel', (args: any) => {
    API.triggerServerEvent(args[0], API.getGravityLevel())
  })
  EventHandler.subscribe('ClientWrapper.Get.getCloudHatOpacity', (args: any) => {
    API.triggerServerEvent(args[0], API.getCloudHatOpacity())
  })
  EventHandler.subscribe('ClientWrapper.Get.getCurrentResourceName', (args: any) => {
    API.triggerServerEvent(args[0], API.getCurrentResourceName())
  })
}

function initSetFunctions() {
  EventHandler.subscribe('ClientWrapper.Set.setSetting', (args: any) => { API.setSetting(args[0], args[1]) })
  EventHandler.subscribe('ClientWrapper.Set.setGameplayCameraActive',
    (args: any) => { API.setGameplayCameraActive() })
  EventHandler.subscribe('ClientWrapper.Set.setCanOpenChat', (args: any) => { API.setCanOpenChat(args[0]) })

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
  EventHandler.subscribe('ClientWrapper.Set.setEntityCollisionless',
    (args: any) => { API.setEntityCollisionless(args[0], args[1]) })
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

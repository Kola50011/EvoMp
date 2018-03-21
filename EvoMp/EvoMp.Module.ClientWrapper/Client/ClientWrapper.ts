/// <reference path='../../../typings/index.d.ts' />
import EventHandler from "../../EvoMp.Module.EventHandler/Client/EventHandler"
const resourceStartHandler = API.onResourceStart.connect(registerEvents)

// Regex for replace params from typing with args[X]
// (?!\([^(]+)(([\w :.\?]|\[\])+)(?=\)}|,|(\) \}))

function registerEvents() {
  initSetFunctions()
  initGetFunctions()
  resourceStartHandler.disconnect()
};

function initGetFunctions() {
  EventHandler.subscribe("ClientWrapper.Get.getDiscordPresenceActivity",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getDiscordPresenceActivity())
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleAntiRollBarBiasFront",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleAntiRollBarBiasFront(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleAntiRollBarForce",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleAntiRollBarForce(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleBrakeForce",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleBrakeForce(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleCamberStiffness",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleCamberStiffness(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleCenterOfMassOffset",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleCenterOfMassOffset(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleClutchChangeRateScaleDownShift",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleClutchChangeRateScaleDownShift(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleClutchChangeRateScaleUpShift",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleClutchChangeRateScaleUpShift(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleCollisionDamageMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleCollisionDamageMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDeformationDamageMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDeformationDamageMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDriveInertia",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDriveInertia(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleEngineDamageMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleEngineDamageMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleHandBrakeForce",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleHandBrakeForce(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleInertiaMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleInertiaMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleInitialDriveForce",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleInitialDriveForce(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleInitialDriveGears",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleInitialDriveGears(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMass",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMass(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMonetaryValue",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMonetaryValue(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehiclePercentSubmerged",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehiclePercentSubmerged(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleRollCenterHeightFront",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleRollCenterHeightFront(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleRollCenterHeightRear",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleRollCenterHeightRear(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSeatOffsetDistanceX",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSeatOffsetDistanceX(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSeatOffsetDistanceY",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSeatOffsetDistanceY(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSeatOffsetDistanceZ",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSeatOffsetDistanceZ(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSteeringLock",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSteeringLock(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionBiasFront",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionBiasFront(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionCompressionDamping",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionCompressionDamping(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionForce",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionForce(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionLowerLimit",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionLowerLimit(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionRaise",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionRaise(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionReboundDamping",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionReboundDamping(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSuspensionUpperLimit",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSuspensionUpperLimit(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTractionBiasFront",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTractionBiasFront(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTractionCurveMax",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTractionCurveMax(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTractionCurveMin",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTractionCurveMin(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTractionLossMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTractionLossMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTractionSpringDeltaMax",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTractionSpringDeltaMax(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDriveBiasFront",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDriveBiasFront(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleBrakeBiasFront",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleBrakeBiasFront(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleInitialDragCoefficiency",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleInitialDragCoefficiency(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleInitialDriveMaxFlatVelocity",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleInitialDriveMaxFlatVelocity(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getCharFromKey",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCharFromKey(args[1], args[2], args[3], args[4]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getClosestProp",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getClosestProp(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNearbyProps",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNearbyProps(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getWorldProps",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWorldProps(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllLoadedAsiNames",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllLoadedAsiNames())
    })
  EventHandler.subscribe("ClientWrapper.Get.getLoadedAsiHash",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getLoadedAsiHash(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllActiveModDlcPacksNames",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllActiveModDlcPacksNames())
    })
  EventHandler.subscribe("ClientWrapper.Get.getModDlcPackHash",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getModDlcPackHash(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllModdedFileNames",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllModdedFileNames())
    })
  EventHandler.subscribe("ClientWrapper.Get.getModdedFileHash",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getModdedFileHash(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllCustomScriptsNames",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllCustomScriptsNames())
    })
  EventHandler.subscribe("ClientWrapper.Get.getCustomScriptHash",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCustomScriptHash(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAnimCurrentTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAnimCurrentTime(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAnimTotalTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAnimTotalTime(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAnimTotalTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAnimTotalTime(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getGameFramerate",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGameFramerate())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGameText",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGameText(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getGameTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGameTime())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGlobalTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGlobalTime())
    })
  EventHandler.subscribe("ClientWrapper.Get.getHashKey",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getHashKey(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAlternativeMainMenuKeyDisabled",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAlternativeMainMenuKeyDisabled())
    })
  EventHandler.subscribe("ClientWrapper.Get.getCultureISOLanguageName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCultureISOLanguageName())
    })
  EventHandler.subscribe("ClientWrapper.Get.getMusicVolume",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMusicVolume())
    })
  EventHandler.subscribe("ClientWrapper.Get.getMusicTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMusicTime())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAudioTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAudioTime())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGameplayCamPos",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGameplayCamPos())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGameplayCamRot",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGameplayCamRot())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGameplayCamDir",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGameplayCamDir())
    })
  EventHandler.subscribe("ClientWrapper.Get.getBytesSentPerSecond",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBytesSentPerSecond())
    })
  EventHandler.subscribe("ClientWrapper.Get.getBytesReceivedPerSecond",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBytesReceivedPerSecond())
    })
  EventHandler.subscribe("ClientWrapper.Get.getControlNormal",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getControlNormal(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getDisabledControlNormal",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getDisabledControlNormal(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getFontWidth",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getFontWidth(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityQuaternion",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityQuaternion(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityRotation",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityRotation(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityLeftPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityLeftPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityRightPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityRightPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityFrontPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityFrontPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityRearPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityRearPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityAbovePosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityAbovePosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBelowPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBelowPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityForwardVector",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityForwardVector(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityRightVector",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityRightVector(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityUpVector",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityUpVector(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityVelocity",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityVelocity(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityTransparency",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityTransparency(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityType",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityType(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityDimension",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityDimension(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityModel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityModel(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityInvincible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityInvincible(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBoneCount",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBoneCount(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBoneIndexByName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBoneIndexByName(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBoneWorldPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBoneWorldPosition(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBoneWorldPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBoneWorldPosition(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBoneRelativePosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBoneRelativePosition(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityBoneRelativePosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityBoneRelativePosition(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityHasCollided",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityHasCollided(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntityCollisionless",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntityCollisionless(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getEntitySyncedData",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getEntitySyncedData(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllEntitySyncedData",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllEntitySyncedData(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getWorldSyncedData",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWorldSyncedData(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllWorldSyncedData",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllWorldSyncedData())
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipPosition(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipSprite",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipSprite(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipTransparency",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipTransparency(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipShortRange",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipShortRange(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipScale",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipScale(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipRouteVisible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipRouteVisible(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipRouteColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipRouteColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipFlashing",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipFlashing(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBlipScaleToMapZoom",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBlipScaleToMapZoom(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getMarkerType",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMarkerType(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getMarkerColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMarkerColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getMarkerScale",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMarkerScale(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getMarkerDirection",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMarkerDirection(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getMarkerBobUpAndDown",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMarkerBobUpAndDown(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getBoneName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getBoneName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPedCanRagdoll",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPedCanRagdoll())
    })
  EventHandler.subscribe("ClientWrapper.Get.getMaxHealth",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getMaxHealth())
    })
  EventHandler.subscribe("ClientWrapper.Get.getPedHeadShotTextureString",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPedHeadShotTextureString(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getTextLabelColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getTextLabelColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getTextLabelSeethrough",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getTextLabelSeethrough(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getClosestVehicle",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getClosestVehicle(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNearbyVehicles",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNearbyVehicles(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleLivery",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleLivery(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDeluxoTransformation",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDeluxoTransformation(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSubmarineTransformed",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSubmarineTransformed(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleOppressorTransformation",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleOppressorTransformation(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getCurrentVehicleRadioStationId",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCurrentVehicleRadioStationId())
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleRadioEnabled",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleRadioEnabled())
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleRadioRetuning",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleRadioRetuning())
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleLocked",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleLocked(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTrailer",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTrailer(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTruck",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTruck(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTraileredBy",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTraileredBy(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSirenState",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSirenState(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleModSlotName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleModSlotName(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleModTextLabel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleModTextLabel(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleLiveryName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleLiveryName(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDoorState",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDoorState(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleExtra",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleExtra(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleNumberPlate",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleNumberPlate(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleEngineStatus",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleEngineStatus(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSpecialLightStatus",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSpecialLightStatus(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleNumModCount",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleNumModCount(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMod",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMod(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleEngineTemperature",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleEngineTemperature(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTurbo",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTurbo(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleClutch",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleClutch(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleThrottle",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleThrottle(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleThrottlePower",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleThrottlePower(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleBrakePower",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleBrakePower(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleOilLevel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleOilLevel(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleFuelLevel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleFuelLevel(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDirtLevel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDirtLevel(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleBulletproofTyres",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleBulletproofTyres(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleNumberPlateStyle",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleNumberPlateStyle(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehiclePearlescentColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehiclePearlescentColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleWheelColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleWheelColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleWheelType",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleWheelType(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleWindowTint",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleWindowTint(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleEnginePowerMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleEnginePowerMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleEngineTorqueMultiplier",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleEngineTorqueMultiplier(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleNeonState",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleNeonState(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleNeonColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleNeonColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDashboardColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDashboardColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleTrimColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleTrimColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleDisplayName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleDisplayName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMaxSpeed",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMaxSpeed(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMaxBraking",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMaxBraking(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMaxTraction",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMaxTraction(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMaxAcceleration",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMaxAcceleration(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleMaxOccupants",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleMaxOccupants(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleClass",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleClass(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleCustomPrimaryColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleCustomPrimaryColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleCustomSecondaryColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleCustomSecondaryColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehiclePrimaryColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehiclePrimaryColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleSecondaryColor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleSecondaryColor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleHealth",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleHealth(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehiclePetrolTankHealth",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehiclePetrolTankHealth(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleRPM",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleRPM(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleHighGear",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleHighGear(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleCurrentGear",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleCurrentGear(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleModelName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleModelName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getCanOpenChat",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCanOpenChat())
    })
  EventHandler.subscribe("ClientWrapper.Get.getChatVisible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getChatVisible())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAlternativeVersionLabelPositionActive",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAlternativeVersionLabelPositionActive())
    })
  EventHandler.subscribe("ClientWrapper.Get.getShowWastedScreenOnDeath",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getShowWastedScreenOnDeath())
    })
  EventHandler.subscribe("ClientWrapper.Get.getVehicleEnteringKeysDisabled",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getVehicleEnteringKeysDisabled())
    })
  EventHandler.subscribe("ClientWrapper.Get.getScreenResolutionMantainRatio",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getScreenResolutionMantainRatio())
    })
  EventHandler.subscribe("ClientWrapper.Get.getScreenResolutionMaintainRatio",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getScreenResolutionMaintainRatio())
    })
  EventHandler.subscribe("ClientWrapper.Get.getScreenResolution",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getScreenResolution())
    })
  EventHandler.subscribe("ClientWrapper.Get.getWaypointPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWaypointPosition())
    })
  EventHandler.subscribe("ClientWrapper.Get.getHudVisible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getHudVisible())
    })
  EventHandler.subscribe("ClientWrapper.Get.getUserInput",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getUserInput(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNamedRenderTargetRenderID",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNamedRenderTargetRenderID(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getUniqueHardwareId",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getUniqueHardwareId())
    })
  EventHandler.subscribe("ClientWrapper.Get.getSocialClubName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getSocialClubName())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGamePlayer",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGamePlayer())
    })
  EventHandler.subscribe("ClientWrapper.Get.getLocalPlayer",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getLocalPlayer())
    })
  EventHandler.subscribe("ClientWrapper.Get.getLocalPlayerInvincible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getLocalPlayerInvincible())
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerNametagVisible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerNametagVisible(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerHealthbarVisible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerHealthbarVisible(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerArmorbarVisible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerArmorbarVisible(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getLocalPlayerAimingAtEntity",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getLocalPlayerAimingAtEntity())
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerAimingPoint",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerAimingPoint(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerTeam",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerTeam(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerWantedLevel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerWantedLevel())
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerInvincible",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerInvincible())
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerArmor",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerArmor(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerByName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerByName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerVehicleSeatIndex",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerVehicleSeatIndex(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerVehicleSeat",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerVehicleSeat(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerSeatbelt",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerSeatbelt(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerHealth",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerHealth(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerAimCoords",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerAimCoords(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerPing",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerPing(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerVehicle",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerVehicle(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerHeadOverlayValue",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerHeadOverlayValue(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getFirstParentIdForPedType",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getFirstParentIdForPedType(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNumHeadOverlayValues",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNumHeadOverlayValues(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNumHairColors",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNumHairColors())
    })
  EventHandler.subscribe("ClientWrapper.Get.getNumMakeupColors",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNumMakeupColors())
    })
  EventHandler.subscribe("ClientWrapper.Get.getTattooZone",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getTattooZone(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getTattooZone",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getTattooZone(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerWeaponTint",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerWeaponTint(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getWeaponAmmo",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWeaponAmmo(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getAmmoInClip",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAmmoInClip())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllWeaponComponents",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllWeaponComponents(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getPlayerCurrentWeapon",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getPlayerCurrentWeapon())
    })
  EventHandler.subscribe("ClientWrapper.Get.getWeaponName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWeaponName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getCursorPosition",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCursorPosition())
    })
  EventHandler.subscribe("ClientWrapper.Get.getCursorPositionMantainRatio",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCursorPositionMantainRatio())
    })
  EventHandler.subscribe("ClientWrapper.Get.getCursorPositionMaintainRatio",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCursorPositionMaintainRatio())
    })
  EventHandler.subscribe("ClientWrapper.Get.getSetting",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getSetting(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedPlayers",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedPlayers())
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedVehicles",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedVehicles())
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedObjects",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedObjects())
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedPickups",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedPickups())
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedPeds",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedPeds())
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedMarkers",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedMarkers())
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreamedTextLabels",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreamedTextLabels())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllPlayers",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllPlayers())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllVehicles",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllVehicles())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllObjects",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllObjects())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllPickups",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllPickups())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllPeds",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllPeds())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllMarkers",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllMarkers())
    })
  EventHandler.subscribe("ClientWrapper.Get.getAllTextLabels",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getAllTextLabels())
    })
  EventHandler.subscribe("ClientWrapper.Get.getWeather",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWeather())
    })
  EventHandler.subscribe("ClientWrapper.Get.getNextWeather",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNextWeather())
    })
  EventHandler.subscribe("ClientWrapper.Get.getWeatherTransitionType",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWeatherTransitionType())
    })
  EventHandler.subscribe("ClientWrapper.Get.getTime",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getTime())
    })
  EventHandler.subscribe("ClientWrapper.Get.getOffsetInWorldCoords",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getOffsetInWorldCoords(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getSafeCoordForPed",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getSafeCoordForPed(args[1], args[2], args[3]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNextPositionOnStreet",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNextPositionOnStreet(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getNextPositionOnSidewalk",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getNextPositionOnSidewalk(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getOffsetFromWorldCoords",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getOffsetFromWorldCoords(args[1], args[2]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getStreetName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getStreetName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getZoneName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getZoneName(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getZoneNameLabel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getZoneNameLabel(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getGroundHeight",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGroundHeight(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getInteriorAtPos",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getInteriorAtPos(args[1]))
    })
  EventHandler.subscribe("ClientWrapper.Get.getCityBlackout",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCityBlackout())
    })
  EventHandler.subscribe("ClientWrapper.Get.getWorldLimits",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getWorldLimits())
    })
  EventHandler.subscribe("ClientWrapper.Get.getGravityLevel",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getGravityLevel())
    })
  EventHandler.subscribe("ClientWrapper.Get.getCloudHatOpacity",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCloudHatOpacity())
    })
  EventHandler.subscribe("ClientWrapper.Get.getCurrentResourceName",
    (args: any) => {
      API.triggerServerEvent(args[0], API.getCurrentResourceName())
    })
}

function initSetFunctions() {
  EventHandler.subscribe("ClientWrapper.Set.setDiscordPresenceActivity",
    (args: any) => {
      API.setDiscordPresenceActivity(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetVehicleHandlingData",
    (args: any) => {
      API.resetVehicleHandlingData(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleAntiRollBarBiasFront",
    (args: any) => {
      API.setVehicleAntiRollBarBiasFront(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleAntiRollBarForce",
    (args: any) => {
      API.setVehicleAntiRollBarForce(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleBrakeForce",
    (args: any) => {
      API.setVehicleBrakeForce(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleCamberStiffness",
    (args: any) => {
      API.setVehicleCamberStiffness(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleCenterOfMassOffset",
    (args: any) => {
      API.setVehicleCenterOfMassOffset(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleClutchChangeRateScaleDownShift",
    (args: any) => {
      API.setVehicleClutchChangeRateScaleDownShift(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleClutchChangeRateScaleUpShift",
    (args: any) => {
      API.setVehicleClutchChangeRateScaleUpShift(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleCollisionDamageMultiplier",
    (args: any) => {
      API.setVehicleCollisionDamageMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDeformationDamageMultiplier",
    (args: any) => {
      API.setVehicleDeformationDamageMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDriveInertia",
    (args: any) => {
      API.setVehicleDriveInertia(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleEngineDamageMultiplier",
    (args: any) => {
      API.setVehicleEngineDamageMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleHandBrakeForce",
    (args: any) => {
      API.setVehicleHandBrakeForce(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleInertiaMultiplier",
    (args: any) => {
      API.setVehicleInertiaMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleInitialDriveForce",
    (args: any) => {
      API.setVehicleInitialDriveForce(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleInitialDriveGears",
    (args: any) => {
      API.setVehicleInitialDriveGears(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleMass",
    (args: any) => {
      API.setVehicleMass(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleMonetaryValue",
    (args: any) => {
      API.setVehicleMonetaryValue(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehiclePercentSubmerged",
    (args: any) => {
      API.setVehiclePercentSubmerged(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleRollCenterHeightFront",
    (args: any) => {
      API.setVehicleRollCenterHeightFront(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleRollCenterHeightRear",
    (args: any) => {
      API.setVehicleRollCenterHeightRear(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSeatOffsetDistanceX",
    (args: any) => {
      API.setVehicleSeatOffsetDistanceX(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSeatOffsetDistanceY",
    (args: any) => {
      API.setVehicleSeatOffsetDistanceY(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSeatOffsetDistanceZ",
    (args: any) => {
      API.setVehicleSeatOffsetDistanceZ(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSteeringLock",
    (args: any) => {
      API.setVehicleSteeringLock(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionBiasFront",
    (args: any) => {
      API.setVehicleSuspensionBiasFront(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionCompressionDamping",
    (args: any) => {
      API.setVehicleSuspensionCompressionDamping(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionForce",
    (args: any) => {
      API.setVehicleSuspensionForce(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionLowerLimit",
    (args: any) => {
      API.setVehicleSuspensionLowerLimit(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionRaise",
    (args: any) => {
      API.setVehicleSuspensionRaise(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionReboundDamping",
    (args: any) => {
      API.setVehicleSuspensionReboundDamping(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSuspensionUpperLimit",
    (args: any) => {
      API.setVehicleSuspensionUpperLimit(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTractionBiasFront",
    (args: any) => {
      API.setVehicleTractionBiasFront(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTractionCurveMax",
    (args: any) => {
      API.setVehicleTractionCurveMax(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTractionCurveMin",
    (args: any) => {
      API.setVehicleTractionCurveMin(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTractionLossMultiplier",
    (args: any) => {
      API.setVehicleTractionLossMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTractionSpringDeltaMax",
    (args: any) => {
      API.setVehicleTractionSpringDeltaMax(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDriveBiasFront",
    (args: any) => {
      API.setVehicleDriveBiasFront(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleBrakeBiasFront",
    (args: any) => {
      API.setVehicleBrakeBiasFront(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleInitialDragCoefficiency",
    (args: any) => {
      API.setVehicleInitialDragCoefficiency(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleInitialDriveMaxFlatVelocity",
    (args: any) => {
      API.setVehicleInitialDriveMaxFlatVelocity(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setAnimCurrentTime",
    (args: any) => {
      API.setAnimCurrentTime(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setAnimSpeed",
    (args: any) => {
      API.setAnimSpeed(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableAlternativeMainMenuKey",
    (args: any) => {
      API.disableAlternativeMainMenuKey(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.verifyIntegrityOfCache",
    (args: any) => {
      API.verifyIntegrityOfCache()
    })
  EventHandler.subscribe("ClientWrapper.Set.preloadAnimationDictionary",
    (args: any) => {
      API.preloadAnimationDictionary(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.requestStreamedTextureDict",
    (args: any) => {
      API.requestStreamedTextureDict(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.disposeStreamedTextureDict",
    (args: any) => {
      API.disposeStreamedTextureDict(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.requestAdditionalText",
    (args: any) => {
      API.requestAdditionalText(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearAdditionalText",
    (args: any) => {
      API.clearAdditionalText(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.startMusic",
    (args: any) => {
      API.startMusic(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopMusic",
    (args: any) => {
      API.stopMusic()
    })
  EventHandler.subscribe("ClientWrapper.Set.setMusicVolume",
    (args: any) => {
      API.setMusicVolume(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMusicTime",
    (args: any) => {
      API.setMusicTime(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setAudioTime",
    (args: any) => {
      API.setAudioTime(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.preloadAudio",
    (args: any) => {
      API.preloadAudio(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setGameVolume",
    (args: any) => {
      API.setGameVolume(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setAudioVolume",
    (args: any) => {
      API.setAudioVolume(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.playSoundFrontEnd",
    (args: any) => {
      API.playSoundFrontEnd(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.startAudioScene",
    (args: any) => {
      API.startAudioScene(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopAudioScene",
    (args: any) => {
      API.stopAudioScene(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopAllAudioScenes",
    (args: any) => {
      API.stopAllAudioScenes()
    })
  EventHandler.subscribe("ClientWrapper.Set.prepareMusicEvent",
    (args: any) => {
      API.prepareMusicEvent(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.triggerMusicEvent",
    (args: any) => {
      API.triggerMusicEvent(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.cancelMusicEvent",
    (args: any) => {
      API.cancelMusicEvent(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setStaticEmitterEnabled",
    (args: any) => {
      API.setStaticEmitterEnabled(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.releaseNamedScriptAudioBank",
    (args: any) => {
      API.releaseNamedScriptAudioBank(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.playSoundFromCoord",
    (args: any) => {
      API.playSoundFromCoord(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.playSoundFromCoord",
    (args: any) => {
      API.playSoundFromCoord(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.playSoundFromEntity",
    (args: any) => {
      API.playSoundFromEntity(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setGameplayCameraActive",
    (args: any) => {
      API.setGameplayCameraActive()
    })
  EventHandler.subscribe("ClientWrapper.Set.setGameplayCameraShake",
    (args: any) => {
      API.setGameplayCameraShake(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopGameplayCameraShake",
    (args: any) => {
      API.stopGameplayCameraShake()
    })
  EventHandler.subscribe("ClientWrapper.Set.setCameraBehindPlayer",
    (args: any) => {
      API.setCameraBehindPlayer()
    })
  EventHandler.subscribe("ClientWrapper.Set.setCefDrawState",
    (args: any) => {
      API.setCefDrawState(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableControlThisFrame",
    (args: any) => {
      API.disableControlThisFrame(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.enableControlThisFrame",
    (args: any) => {
      API.enableControlThisFrame(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableAllControlsThisFrame",
    (args: any) => {
      API.disableAllControlsThisFrame()
    })
  EventHandler.subscribe("ClientWrapper.Set.disableAllControls",
    (args: any) => {
      API.disableAllControls(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setControlNormal",
    (args: any) => {
      API.setControlNormal(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawLine",
    (args: any) => {
      API.drawLine(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawGameTexture",
    (args: any) => {
      API.drawGameTexture(args[0],
        args[1],
        args[2],
        args[3],
        args[4],
        args[5],
        args[6],
        args[7],
        args[8],
        args[9],
        args[10])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawRectangle",
    (args: any) => {
      API.drawRectangle(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawText",
    (args: any) => {
      API.drawText(args[0],
        args[1],
        args[2],
        args[3],
        args[4],
        args[5],
        args[6],
        args[7],
        args[8],
        args[9],
        args[10],
        args[11],
        args[12])
    })
  EventHandler.subscribe("ClientWrapper.Set.dxDrawTexture",
    (args: any) => {
      API.dxDrawTexture(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.createParticleEffectOnPosition",
    (args: any) => {
      API.createParticleEffectOnPosition(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.createParticleEffectOnEntity",
    (args: any) => {
      API.createParticleEffectOnEntity(args[0], args[1], args[2], args[3], args[4], args[5], args[6])
    })
  EventHandler.subscribe("ClientWrapper.Set.createExplosion",
    (args: any) => {
      API.createExplosion(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.createOwnedExplosion",
    (args: any) => {
      API.createOwnedExplosion(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawLight",
    (args: any) => {
      API.drawLight(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawLight",
    (args: any) => {
      API.drawLight(args[0], args[1], args[2], args[3], args[4], args[5], args[6])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawMarker",
    (args: any) => {
      API.drawMarker(args[0],
        args[1],
        args[2],
        args[3],
        args[4],
        args[5],
        args[6],
        args[7],
        args[8],
        args[9],
        args[10],
        args[11])
    })
  EventHandler.subscribe("ClientWrapper.Set.deleteEntity",
    (args: any) => {
      API.deleteEntity(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityPosition",
    (args: any) => {
      API.setEntityPosition(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityRotation",
    (args: any) => {
      API.setEntityRotation(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityQuaternion",
    (args: any) => {
      API.setEntityQuaternion(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityVelocity",
    (args: any) => {
      API.setEntityVelocity(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityTransparency",
    (args: any) => {
      API.setEntityTransparency(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityDimension",
    (args: any) => {
      API.setEntityDimension(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityInvincible",
    (args: any) => {
      API.setEntityInvincible(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityCollisionless",
    (args: any) => {
      API.setEntityCollisionless(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setEntityPositionFrozen",
    (args: any) => {
      API.setEntityPositionFrozen(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.attachEntity",
    (args: any) => {
      API.attachEntity(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.attachEntityToEntity",
    (args: any) => {
      API.attachEntityToEntity(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.detachEntity",
    (args: any) => {
      API.detachEntity(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetEntitySyncedData",
    (args: any) => {
      API.resetEntitySyncedData(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetWorldSyncedData",
    (args: any) => {
      API.resetWorldSyncedData(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipPosition",
    (args: any) => {
      API.setBlipPosition(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipColor",
    (args: any) => {
      API.setBlipColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipSprite",
    (args: any) => {
      API.setBlipSprite(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipName",
    (args: any) => {
      API.setBlipName(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipTransparency",
    (args: any) => {
      API.setBlipTransparency(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipShortRange",
    (args: any) => {
      API.setBlipShortRange(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.showBlipRoute",
    (args: any) => {
      API.showBlipRoute(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipScale",
    (args: any) => {
      API.setBlipScale(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipRouteVisible",
    (args: any) => {
      API.setBlipRouteVisible(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipRouteColor",
    (args: any) => {
      API.setBlipRouteColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipFlashing",
    (args: any) => {
      API.setBlipFlashing(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setBlipScaleToMapZoom",
    (args: any) => {
      API.setBlipScaleToMapZoom(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.hideBlipOnMap",
    (args: any) => {
      API.hideBlipOnMap(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.showBlipOnMap",
    (args: any) => {
      API.showBlipOnMap(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMarkerType",
    (args: any) => {
      API.setMarkerType(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMarkerColor",
    (args: any) => {
      API.setMarkerColor(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMarkerScale",
    (args: any) => {
      API.setMarkerScale(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMarkerDirection",
    (args: any) => {
      API.setMarkerDirection(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMarkerBobUpAndDown",
    (args: any) => {
      API.setMarkerBobUpAndDown(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setMaxHealth",
    (args: any) => {
      API.setMaxHealth(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPedCanRagdoll",
    (args: any) => {
      API.setPedCanRagdoll(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.playAmbientSpeech",
    (args: any) => {
      API.playAmbientSpeech(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.playAmbientSpeech",
    (args: any) => {
      API.playAmbientSpeech(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPedToRagdoll",
    (args: any) => {
      API.setPedToRagdoll(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.cancelPedRagdoll",
    (args: any) => {
      API.cancelPedRagdoll()
    })
  EventHandler.subscribe("ClientWrapper.Set.unregisterPedHeadShot",
    (args: any) => {
      API.unregisterPedHeadShot(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTextLabelText",
    (args: any) => {
      API.setTextLabelText(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTextLabelColor",
    (args: any) => {
      API.setTextLabelColor(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTextLabelSeethrough",
    (args: any) => {
      API.setTextLabelSeethrough(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleLivery",
    (args: any) => {
      API.setVehicleLivery(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDeluxoTransformation",
    (args: any) => {
      API.setVehicleDeluxoTransformation(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSubmarineTransformed",
    (args: any) => {
      API.setVehicleSubmarineTransformed(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleOppressorTransformation",
    (args: any) => {
      API.setVehicleOppressorTransformation(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleLocked",
    (args: any) => {
      API.setVehicleLocked(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleRadioEnabled",
    (args: any) => {
      API.setVehicleRadioEnabled(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleRadioStation",
    (args: any) => {
      API.setVehicleRadioStation(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.freezeVehicleRadioStation",
    (args: any) => {
      API.freezeVehicleRadioStation(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.unfreezeVehicleRadioStation",
    (args: any) => {
      API.unfreezeVehicleRadioStation(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleRadioAutoUnfreeze",
    (args: any) => {
      API.setVehicleRadioAutoUnfreeze(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleRadioLoud",
    (args: any) => {
      API.setVehicleRadioLoud(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDisablePetrolTankDamage",
    (args: any) => {
      API.setVehicleDisablePetrolTankDamage(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDisablePetrolTankFires",
    (args: any) => {
      API.setVehicleDisablePetrolTankFires(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.popVehicleTyre",
    (args: any) => {
      API.popVehicleTyre(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDoorState",
    (args: any) => {
      API.setVehicleDoorState(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.breakVehicleDoor",
    (args: any) => {
      API.breakVehicleDoor(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.breakVehicleWindow",
    (args: any) => {
      API.breakVehicleWindow(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.breakVehicleHeadlight",
    (args: any) => {
      API.breakVehicleHeadlight(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleExtra",
    (args: any) => {
      API.setVehicleExtra(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleNumberPlate",
    (args: any) => {
      API.setVehicleNumberPlate(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleEngineStatus",
    (args: any) => {
      API.setVehicleEngineStatus(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSpecialLightStatus",
    (args: any) => {
      API.setVehicleSpecialLightStatus(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleMod",
    (args: any) => {
      API.setVehicleMod(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleOilLevel",
    (args: any) => {
      API.setVehicleOilLevel(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleFuelLevel",
    (args: any) => {
      API.setVehicleFuelLevel(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDirtLevel",
    (args: any) => {
      API.setVehicleDirtLevel(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.removeVehicleMod",
    (args: any) => {
      API.removeVehicleMod(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleLightsMode",
    (args: any) => {
      API.setVehicleLightsMode(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleBulletproofTyres",
    (args: any) => {
      API.setVehicleBulletproofTyres(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleNumberPlateStyle",
    (args: any) => {
      API.setVehicleNumberPlateStyle(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehiclePearlescentColor",
    (args: any) => {
      API.setVehiclePearlescentColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleWheelColor",
    (args: any) => {
      API.setVehicleWheelColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleWheelType",
    (args: any) => {
      API.setVehicleWheelType(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleModColor1",
    (args: any) => {
      API.setVehicleModColor1(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleModColor2",
    (args: any) => {
      API.setVehicleModColor2(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTyreSmokeColor",
    (args: any) => {
      API.setVehicleTyreSmokeColor(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleWindowTint",
    (args: any) => {
      API.setVehicleWindowTint(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.toggleVehicleGrip",
    (args: any) => {
      API.toggleVehicleGrip(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleEnginePowerMultiplier",
    (args: any) => {
      API.setVehicleEnginePowerMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleEngineTorqueMultiplier",
    (args: any) => {
      API.setVehicleEngineTorqueMultiplier(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleNeonState",
    (args: any) => {
      API.setVehicleNeonState(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleNeonColor",
    (args: any) => {
      API.setVehicleNeonColor(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleDashboardColor",
    (args: any) => {
      API.setVehicleDashboardColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleTrimColor",
    (args: any) => {
      API.setVehicleTrimColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehiclePrimaryColor",
    (args: any) => {
      API.setVehiclePrimaryColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleSecondaryColor",
    (args: any) => {
      API.setVehicleSecondaryColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleCustomPrimaryColor",
    (args: any) => {
      API.setVehicleCustomPrimaryColor(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setVehicleCustomSecondaryColor",
    (args: any) => {
      API.setVehicleCustomSecondaryColor(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.explodeVehicle",
    (args: any) => {
      API.explodeVehicle(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setCanOpenChat",
    (args: any) => {
      API.setCanOpenChat(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setChatVisible",
    (args: any) => {
      API.setChatVisible(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.toggleAlternativeVersionLabelPosition",
    (args: any) => {
      API.toggleAlternativeVersionLabelPosition(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setShowWastedScreenOnDeath",
    (args: any) => {
      API.setShowWastedScreenOnDeath(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableVehicleEnteringKeys",
    (args: any) => {
      API.disableVehicleEnteringKeys(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setUiColor",
    (args: any) => {
      API.setUiColor(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.sendChatMessage",
    (args: any) => {
      API.sendChatMessage(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.sendChatMessage",
    (args: any) => {
      API.sendChatMessage(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.sendNotification",
    (args: any) => {
      API.sendNotification(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.sendColoredNotification",
    (args: any) => {
      API.sendColoredNotification(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.sendColoredPictureNotification",
    (args: any) => {
      API.sendColoredPictureNotification(args[0],
        args[1],
        args[2],
        args[3],
        args[4],
        args[5],
        args[6],
        args[7],
        args[8],
        args[9],
        args[10],
        args[11])
    })
  EventHandler.subscribe("ClientWrapper.Set.sendPictureNotification",
    (args: any) => {
      API.sendPictureNotification(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.displaySubtitle",
    (args: any) => {
      API.displaySubtitle(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.displaySubtitle",
    (args: any) => {
      API.displaySubtitle(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.displayHelpTextThisFrame",
    (args: any) => {
      API.displayHelpTextThisFrame(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.displayHelpText",
    (args: any) => {
      API.displayHelpText(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.showShard",
    (args: any) => {
      API.showShard(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.showColorShard",
    (args: any) => {
      API.showColorShard(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.showWeaponPurchasedShard",
    (args: any) => {
      API.showWeaponPurchasedShard(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setWaypoint",
    (args: any) => {
      API.setWaypoint(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.removeWaypoint",
    (args: any) => {
      API.removeWaypoint()
    })
  EventHandler.subscribe("ClientWrapper.Set.setHudVisible",
    (args: any) => {
      API.setHudVisible(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.closeAllMenus",
    (args: any) => {
      API.closeAllMenus()
    })
  EventHandler.subscribe("ClientWrapper.Set.registerNamedRenderTarget",
    (args: any) => {
      API.registerNamedRenderTarget(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.linkNamedRenderTarget",
    (args: any) => {
      API.linkNamedRenderTarget(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTextRenderID",
    (args: any) => {
      API.setTextRenderID(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.releaseNamedRenderTarget",
    (args: any) => {
      API.releaseNamedRenderTarget(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.drawScaleformMovie",
    (args: any) => {
      API.drawScaleformMovie(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8])
    })
  EventHandler.subscribe("ClientWrapper.Set.playScreenEffect",
    (args: any) => {
      API.playScreenEffect(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopScreenEffect",
    (args: any) => {
      API.stopScreenEffect(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopAllScreenEffects",
    (args: any) => {
      API.stopAllScreenEffects()
    })
  EventHandler.subscribe("ClientWrapper.Set.loadModel",
    (args: any) => {
      API.loadModel(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.callNative",
    (args: any) => {
      API.callNative(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.disconnect",
    (args: any) => {
      API.disconnect(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.forceSendAimData",
    (args: any) => {
      API.forceSendAimData(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableFingerPointing",
    (args: any) => {
      API.disableFingerPointing(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setFingerPointing",
    (args: any) => {
      API.setFingerPointing(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setFlashlightEnabled",
    (args: any) => {
      API.setFlashlightEnabled(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableFlashlightToggling",
    (args: any) => {
      API.disableFlashlightToggling(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.detonatePlayerStickies",
    (args: any) => {
      API.detonatePlayerStickies()
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametag",
    (args: any) => {
      API.setPlayerNametag(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerNametag",
    (args: any) => {
      API.resetPlayerNametag(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagVisible",
    (args: any) => {
      API.setPlayerNametagVisible(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHealthbarVisible",
    (args: any) => {
      API.setPlayerHealthbarVisible(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerArmorbarVisible",
    (args: any) => {
      API.setPlayerArmorbarVisible(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagColor",
    (args: any) => {
      API.setPlayerNametagColor(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerNametagColor",
    (args: any) => {
      API.resetPlayerNametagColor(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerSkin",
    (args: any) => {
      API.setPlayerSkin(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerDefaultClothes",
    (args: any) => {
      API.setPlayerDefaultClothes()
    })
  EventHandler.subscribe("ClientWrapper.Set.applyLocalPlayerRevivePatches",
    (args: any) => {
      API.applyLocalPlayerRevivePatches()
    })
  EventHandler.subscribe("ClientWrapper.Set.reviveLocalPlayer",
    (args: any) => {
      API.reviveLocalPlayer()
    })
  EventHandler.subscribe("ClientWrapper.Set.resetLocalPlayerRevivePatches",
    (args: any) => {
      API.resetLocalPlayerRevivePatches()
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerTeam",
    (args: any) => {
      API.setPlayerTeam(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.playPlayerScenario",
    (args: any) => {
      API.playPlayerScenario(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.playPlayerScenario",
    (args: any) => {
      API.playPlayerScenario(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.playPlayerAnimation",
    (args: any) => {
      API.playPlayerAnimation(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.playAnimation",
    (args: any) => {
      API.playAnimation(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.playFacialAnimation",
    (args: any) => {
      API.playFacialAnimation(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.playPlayerAnimation",
    (args: any) => {
      API.playPlayerAnimation(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.playPlayerFacialAnimation",
    (args: any) => {
      API.playPlayerFacialAnimation(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopPlayerAnimation",
    (args: any) => {
      API.stopPlayerAnimation()
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerComponentVariation",
    (args: any) => {
      API.setPlayerComponentVariation(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerClothes",
    (args: any) => {
      API.setPlayerClothes(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerAccessory",
    (args: any) => {
      API.setPlayerAccessory(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearPlayerAccessory",
    (args: any) => {
      API.clearPlayerAccessory(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearPlayerTasks",
    (args: any) => {
      API.clearPlayerTasks()
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerInvincible",
    (args: any) => {
      API.setPlayerInvincible(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerWantedLevel",
    (args: any) => {
      API.setPlayerWantedLevel(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerArmor",
    (args: any) => {
      API.setPlayerArmor(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerIntoVehicle",
    (args: any) => {
      API.setPlayerIntoVehicle(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHealth",
    (args: any) => {
      API.setPlayerHealth(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.removePlayerNametag",
    (args: any) => {
      API.removePlayerNametag(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagComponentVisibility",
    (args: any) => {
      API.setPlayerNametagComponentVisibility(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagFlagColor",
    (args: any) => {
      API.setPlayerNametagFlagColor(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagFlagAlpha",
    (args: any) => {
      API.setPlayerNametagFlagAlpha(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagWantedLevel",
    (args: any) => {
      API.setPlayerNametagWantedLevel(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagChattingText",
    (args: any) => {
      API.setPlayerNametagChattingText(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagText",
    (args: any) => {
      API.setPlayerNametagText(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerNametagHealthbarColor",
    (args: any) => {
      API.setPlayerNametagHealthbarColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerVisualDamage",
    (args: any) => {
      API.resetPlayerVisualDamage(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearPlayerBloodDamage",
    (args: any) => {
      API.clearPlayerBloodDamage(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.applyPlayerBlood",
    (args: any) => {
      API.applyPlayerBlood(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHeadOverlay",
    (args: any) => {
      API.setPlayerHeadOverlay(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerEyeColor",
    (args: any) => {
      API.setPlayerEyeColor(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHeadOverlayColor",
    (args: any) => {
      API.setPlayerHeadOverlayColor(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHeadOverlayColor",
    (args: any) => {
      API.setPlayerHeadOverlayColor(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.updatePlayerHeadBlendData",
    (args: any) => {
      API.updatePlayerHeadBlendData(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHeadBlendData",
    (args: any) => {
      API.setPlayerHeadBlendData(args[0],
        args[1],
        args[2],
        args[3],
        args[4],
        args[5],
        args[6],
        args[7],
        args[8],
        args[9],
        args[10])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerFaceFeature",
    (args: any) => {
      API.setPlayerFaceFeature(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearPlayerFacialDecorations",
    (args: any) => {
      API.clearPlayerFacialDecorations(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearPlayerDecorations",
    (args: any) => {
      API.clearPlayerDecorations(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHairColor",
    (args: any) => {
      API.setPlayerHairColor(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerEyebrows",
    (args: any) => {
      API.setPlayerEyebrows(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerChestHair",
    (args: any) => {
      API.setPlayerChestHair(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerFacePaint",
    (args: any) => {
      API.setPlayerFacePaint(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerBeard",
    (args: any) => {
      API.setPlayerBeard(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerHairStyle",
    (args: any) => {
      API.setPlayerHairStyle(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerFacialDecoration",
    (args: any) => {
      API.setPlayerFacialDecoration(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerFacialDecoration",
    (args: any) => {
      API.setPlayerFacialDecoration(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerIsDrunk",
    (args: any) => {
      API.setPlayerIsDrunk(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerStrafeClipSet",
    (args: any) => {
      API.setPlayerStrafeClipSet(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerStrafeClipSet",
    (args: any) => {
      API.resetPlayerStrafeClipSet(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerWeaponMovementClipSet",
    (args: any) => {
      API.setPlayerWeaponMovementClipSet(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerWeaponMovementClipSet",
    (args: any) => {
      API.resetPlayerWeaponMovementClipSet(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerDriveByClipSet",
    (args: any) => {
      API.setPlayerDriveByClipSet(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerDriveByClipSet",
    (args: any) => {
      API.resetPlayerDriveByClipSet(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerMovementClipset",
    (args: any) => {
      API.setPlayerMovementClipset(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetPlayerMovementClipset",
    (args: any) => {
      API.resetPlayerMovementClipset(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.applyPlayerDamagePack",
    (args: any) => {
      API.applyPlayerDamagePack(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerFacialIdleAnimOverride",
    (args: any) => {
      API.setPlayerFacialIdleAnimOverride(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearPlayerFacialIdleAnimOverride",
    (args: any) => {
      API.clearPlayerFacialIdleAnimOverride(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerWeaponAnimationOverride",
    (args: any) => {
      API.setPlayerWeaponAnimationOverride(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.requestControlOfPlayer",
    (args: any) => {
      API.requestControlOfPlayer(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopControlOfPlayer",
    (args: any) => {
      API.stopControlOfPlayer(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerWeaponTint",
    (args: any) => {
      API.setPlayerWeaponTint(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.givePlayerWeaponComponent",
    (args: any) => {
      API.givePlayerWeaponComponent(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.removePlayerWeaponComponent",
    (args: any) => {
      API.removePlayerWeaponComponent(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setPlayerSelectWeapon",
    (args: any) => {
      API.setPlayerSelectWeapon(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.removeAllPlayerWeapons",
    (args: any) => {
      API.removeAllPlayerWeapons()
    })
  EventHandler.subscribe("ClientWrapper.Set.removePlayerWeapon",
    (args: any) => {
      API.removePlayerWeapon(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.showCursor",
    (args: any) => {
      API.showCursor(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.showLoadingPrompt",
    (args: any) => {
      API.showLoadingPrompt(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.hideLoadingPrompt",
    (args: any) => {
      API.hideLoadingPrompt()
    })
  EventHandler.subscribe("ClientWrapper.Set.showHudComponentThisFrame",
    (args: any) => {
      API.showHudComponentThisFrame(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.hideHudComponentThisFrame",
    (args: any) => {
      API.hideHudComponentThisFrame(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setThermalVisionEnabled",
    (args: any) => {
      API.setThermalVisionEnabled(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setNightVisionEnabled",
    (args: any) => {
      API.setNightVisionEnabled(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.fadeScreenOut",
    (args: any) => {
      API.fadeScreenOut(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.fadeScreenIn",
    (args: any) => {
      API.fadeScreenIn(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setRadarZoom",
    (args: any) => {
      API.setRadarZoom(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.showMissionPassedMessage",
    (args: any) => {
      API.showMissionPassedMessage(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.showColoredShard",
    (args: any) => {
      API.showColoredShard(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.showOldMessage",
    (args: any) => {
      API.showOldMessage(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.showRankupMessage",
    (args: any) => {
      API.showRankupMessage(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.showWeaponPurchasedMessage",
    (args: any) => {
      API.showWeaponPurchasedMessage(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.showMpMessageLarge",
    (args: any) => {
      API.showMpMessageLarge(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.showCustomShard",
    (args: any) => {
      API.showCustomShard(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.showSimpleMessage",
    (args: any) => {
      API.showSimpleMessage(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.showMidsizedMessage",
    (args: any) => {
      API.showMidsizedMessage(args[0], args[1], args[2], args[3], args[4])
    })
  EventHandler.subscribe("ClientWrapper.Set.showPlaneMessage",
    (args: any) => {
      API.showPlaneMessage(args[0], args[1], args[2], args[3])
    })
  EventHandler.subscribe("ClientWrapper.Set.showMidsizedMessage",
    (args: any) => {
      API.showMidsizedMessage(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.setSetting",
    (args: any) => {
      API.setSetting(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.removeSetting",
    (args: any) => {
      API.removeSetting(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.playPoliceReport",
    (args: any) => {
      API.playPoliceReport(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setWeather",
    (args: any) => {
      API.setWeather(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.resetWeather",
    (args: any) => {
      API.resetWeather()
    })
  EventHandler.subscribe("ClientWrapper.Set.setNextWeather",
    (args: any) => {
      API.setNextWeather(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setWeatherTransitionType",
    (args: any) => {
      API.setWeatherTransitionType(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.transitionToWeather",
    (args: any) => {
      API.transitionToWeather(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTime",
    (args: any) => {
      API.setTime(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTimecycleModifier",
    (args: any) => {
      API.setTimecycleModifier(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setTimecycleModifierStrength",
    (args: any) => {
      API.setTimecycleModifierStrength(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearTimecycleModifier",
    (args: any) => {
      API.clearTimecycleModifier()
    })
  EventHandler.subscribe("ClientWrapper.Set.resetTime",
    (args: any) => {
      API.resetTime()
    })
  EventHandler.subscribe("ClientWrapper.Set.setSnowEnabled",
    (args: any) => {
      API.setSnowEnabled(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.createProjectile",
    (args: any) => {
      API.createProjectile(args[0], args[1], args[2], args[3], args[4], args[5])
    })
  EventHandler.subscribe("ClientWrapper.Set.createOwnedProjectile",
    (args: any) => {
      API.createOwnedProjectile(args[0], args[1], args[2], args[3], args[4], args[5], args[6])
    })
  EventHandler.subscribe("ClientWrapper.Set.loadInterior",
    (args: any) => {
      API.loadInterior(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setInteriorPropColor",
    (args: any) => {
      API.setInteriorPropColor(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.enableInteriorProp",
    (args: any) => {
      API.enableInteriorProp(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.disableInteriorProp",
    (args: any) => {
      API.disableInteriorProp(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.requestIpl",
    (args: any) => {
      API.requestIpl(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.removeIpl",
    (args: any) => {
      API.removeIpl(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setCityBlackout",
    (args: any) => {
      API.setCityBlackout(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.expandWorldLimits",
    (args: any) => {
      API.expandWorldLimits(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.setGravityLevel",
    (args: any) => {
      API.setGravityLevel(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setCloudHatTransition",
    (args: any) => {
      API.setCloudHatTransition(args[0], args[1])
    })
  EventHandler.subscribe("ClientWrapper.Set.clearCloudHat",
    (args: any) => {
      API.clearCloudHat()
    })
  EventHandler.subscribe("ClientWrapper.Set.setCloudHatOpacity",
    (args: any) => {
      API.setCloudHatOpacity(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopAllAlarms",
    (args: any) => {
      API.stopAllAlarms()
    })
  EventHandler.subscribe("ClientWrapper.Set.startAlarm",
    (args: any) => {
      API.startAlarm(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.stopAlarm",
    (args: any) => {
      API.stopAlarm(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.setGpsActive",
    (args: any) => {
      API.setGpsActive(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.toggleAIPedsSpawning",
    (args: any) => {
      API.toggleAIPedsSpawning(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.toggleVehicleFirstPersonCam",
    (args: any) => {
      API.toggleVehicleFirstPersonCam(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.toggleFirstPersonCam",
    (args: any) => {
      API.toggleFirstPersonCam(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.deleteObject",
    (args: any) => {
      API.deleteObject(args[0], args[1], args[2])
    })
  EventHandler.subscribe("ClientWrapper.Set.sleep",
    (args: any) => {
      API.sleep(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.loadAnimationDict",
    (args: any) => {
      API.loadAnimationDict(args[0])
    })
  EventHandler.subscribe("ClientWrapper.Set.Dispose",
    (args: any) => {
      API.Dispose()
    })
}

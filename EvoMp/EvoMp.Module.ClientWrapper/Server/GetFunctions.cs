using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using GrandTheftMultiplayer.Shared.Math;
using Color = GrandTheftMultiplayer.Server.Constant.Color;
using Weather = GrandTheftMultiplayer.Shared.Gta.World.Weather;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class GetFunctions : IGetFunctions //: IGetFunctions
    {
        private const int WaitTimeoutMs = 1000; // 1 sec
        private readonly IEventHandler _eventHandler;
        private readonly Random _randomHash = new Random();

        public GetFunctions(IEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="position"></param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        public async Task<string> GetStreetName(Client sender, Vector3 position)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getStreetName", position);
        }

        public async Task<string> GetDiscordPresenceActivity(Client sender)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getDiscordPresenceActivity");
        }

        public async Task<double> GetVehicleAntiRollBarBiasFront(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleAntiRollBarBiasFront", vehicleHash);
        }

        public async Task<double> GetVehicleAntiRollBarForce(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleAntiRollBarForce", vehicleHash);
        }

        public async Task<double> GetVehicleBrakeForce(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleBrakeForce", vehicleHash);
        }

        public async Task<double> GetVehicleCamberStiffness(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleCamberStiffness", vehicleHash);
        }

        public async Task<Vector3> GetVehicleCenterOfMassOffset(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getVehicleCenterOfMassOffset", vehicleHash);
        }

        public async Task<double> GetVehicleClutchChangeRateScaleDownShift(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleClutchChangeRateScaleDownShift",
                vehicleHash);
        }

        public async Task<double> GetVehicleClutchChangeRateScaleUpShift(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleClutchChangeRateScaleUpShift",
                vehicleHash);
        }

        public async Task<double> GetVehicleCollisionDamageMultiplier(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleCollisionDamageMultiplier",
                vehicleHash);
        }

        public async Task<double> GetVehicleDeformationDamageMultiplier(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleDeformationDamageMultiplier",
                vehicleHash);
        }

        public async Task<double> GetVehicleDriveInertia(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleDriveInertia", vehicleHash);
        }

        public async Task<double> GetVehicleEngineDamageMultiplier(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleEngineDamageMultiplier",
                vehicleHash);
        }

        public async Task<double> GetVehicleHandBrakeForce(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleHandBrakeForce", vehicleHash);
        }

        public async Task<Vector3> GetVehicleInertiaMultiplier(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getVehicleInertiaMultiplier", vehicleHash);
        }

        public async Task<double> GetVehicleInitialDriveForce(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleInitialDriveForce", vehicleHash);
        }

        public async Task<double> GetVehicleInitialDriveGears(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleInitialDriveGears", vehicleHash);
        }

        public async Task<double> GetVehicleMass(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMass", vehicleHash);
        }

        public async Task<double> GetVehicleMonetaryValue(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMonetaryValue", vehicleHash);
        }

        public async Task<double> GetVehiclePercentSubmerged(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehiclePercentSubmerged", vehicleHash);
        }

        public async Task<double> GetVehicleRollCenterHeightFront(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleRollCenterHeightFront",
                vehicleHash);
        }

        public async Task<double> GetVehicleRollCenterHeightRear(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleRollCenterHeightRear", vehicleHash);
        }

        public async Task<double> GetVehicleSeatOffsetDistanceX(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSeatOffsetDistanceX", vehicleHash);
        }

        public async Task<double> GetVehicleSeatOffsetDistanceY(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSeatOffsetDistanceY", vehicleHash);
        }

        public async Task<double> GetVehicleSeatOffsetDistanceZ(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSeatOffsetDistanceZ", vehicleHash);
        }

        public async Task<double> GetVehicleSteeringLock(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSteeringLock", vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionBiasFront(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionBiasFront", vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionCompressionDamping(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionCompressionDamping",
                vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionForce(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionForce", vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionLowerLimit(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionLowerLimit", vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionRaise(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionRaise", vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionReboundDamping(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionReboundDamping",
                vehicleHash);
        }

        public async Task<double> GetVehicleSuspensionUpperLimit(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleSuspensionUpperLimit", vehicleHash);
        }

        public async Task<double> GetVehicleTractionBiasFront(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleTractionBiasFront", vehicleHash);
        }

        public async Task<double> GetVehicleTractionCurveMax(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleTractionCurveMax", vehicleHash);
        }

        public async Task<double> GetVehicleTractionCurveMin(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleTractionCurveMin", vehicleHash);
        }

        public async Task<double> GetVehicleTractionLossMultiplier(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleTractionLossMultiplier",
                vehicleHash);
        }

        public async Task<double> GetVehicleTractionSpringDeltaMax(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleTractionSpringDeltaMax",
                vehicleHash);
        }

        public async Task<double> GetVehicleDriveBiasFront(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleDriveBiasFront", vehicleHash);
        }

        public async Task<double> GetVehicleBrakeBiasFront(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleBrakeBiasFront", vehicleHash);
        }

        public async Task<double> GetVehicleInitialDragCoefficiency(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleInitialDragCoefficiency",
                vehicleHash);
        }

        public async Task<double> GetVehicleInitialDriveMaxFlatVelocity(Client sender, VehicleHash vehicleHash)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleInitialDriveMaxFlatVelocity",
                vehicleHash);
        }

        public async Task<string> GetCharFromKey(Client sender, int key, bool shift, bool ctrl, bool alt)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getCharFromKey", key, shift, ctrl, alt);
        }

        public async Task<NetHandle> GetClosestProp(Client sender, Vector3 position, double radius, params int[] models)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getClosestProp", position, radius, models);
        }

        public async Task<NetHandle[]> GetNearbyProps(Client sender, Vector3 position, double radius,
            params int[] models)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getNearbyProps", position, radius,
                models);
        }

        public async Task<NetHandle[]> GetWorldProps(Client sender, params int[] models)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getWorldProps", models);
        }

        public async Task<string[]> GetAllLoadedAsiNames(Client sender)
        {
            return await GetFromClient<string[]>(sender, "ClientWrapper.Get.getAllLoadedAsiNames");
        }

        public async Task<string> GetLoadedAsiHash(Client sender, string asiName)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getLoadedAsiHash", asiName);
        }

        public async Task<string[]> GetAllActiveModDlcPacksNames(Client sender)
        {
            return await GetFromClient<string[]>(sender, "ClientWrapper.Get.getAllActiveModDlcPacksNames");
        }

        public async Task<string> GetModDlcPackHash(Client sender, string modDlcPack)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getModDlcPackHash", modDlcPack);
        }

        public async Task<string[]> GetAllModdedFileNames(Client sender)
        {
            return await GetFromClient<string[]>(sender, "ClientWrapper.Get.getAllModdedFileNames");
        }

        public async Task<string> GetModdedFileHash(Client sender, string gtaModdedFileName)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getModdedFileHash", gtaModdedFileName);
        }

        public async Task<string[]> GetAllCustomScriptsNames(Client sender)
        {
            return await GetFromClient<string[]>(sender, "ClientWrapper.Get.getAllCustomScriptsNames");
        }

        public async Task<string> GetCustomScriptHash(Client sender, string customScriptName)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getCustomScriptHash", customScriptName);
        }

        public async Task<double> GetAnimCurrentTime(Client sender, NetHandle handle, string animDict, string animName)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getAnimCurrentTime", handle, animDict,
                animName);
        }

        public async Task<double> GetAnimTotalTime(Client sender, NetHandle handle, string animDict, string animName)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getAnimTotalTime", handle, animDict,
                animName);
        }

        public async Task<double> GetAnimTotalTime(Client sender, string animDict, string animName)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getAnimTotalTime", animDict, animName);
        }

        public async Task<int> GetGameFramerate(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getGameFramerate");
        }

        public async Task<string> GetGameText(Client sender, string labelName)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getGameText", labelName);
        }

        public async Task<int> GetGameTime(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getGameTime");
        }

        public async Task<int> GetGlobalTime(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getGlobalTime");
        }

        public async Task<int> GetHashKey(Client sender, string input)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getHashKey", input);
        }

        public async Task<bool> GetAlternativeMainMenuKeyDisabled(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getAlternativeMainMenuKeyDisabled");
        }

        public async Task<string> GetCultureIsoLanguageName(Client sender)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getCultureISOLanguageName");
        }

        public async Task<double> GetMusicVolume(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getMusicVolume");
        }

        public async Task<double> GetMusicTime(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getMusicTime");
        }

        public async Task<double> GetAudioTime(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getAudioTime");
        }

        public async Task<Vector3> GetGameplayCamPos(Client sender)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getGameplayCamPos");
        }

        public async Task<Vector3> GetGameplayCamRot(Client sender)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getGameplayCamRot");
        }

        public async Task<Vector3> GetGameplayCamDir(Client sender)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getGameplayCamDir");
        }

        public async Task<double> GetBytesSentPerSecond(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getBytesSentPerSecond");
        }

        public async Task<double> GetBytesReceivedPerSecond(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getBytesReceivedPerSecond");
        }

        public async Task<int> GetControlNormal(Client sender, int control)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getControlNormal", control);
        }

        public async Task<int> GetDisabledControlNormal(Client sender, int control)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getDisabledControlNormal", control);
        }

        public async Task<double> GetFontWidth(Client sender, string text, int font, double scale)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getFontWidth", text, font, scale);
        }

        public async Task<Vector3> GetEntityPosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityPosition", entity);
        }

        public async Task<Quaternion> GetEntityQuaternion(Client sender, NetHandle entity)
        {
            return await GetFromClient<Quaternion>(sender, "ClientWrapper.Get.getEntityQuaternion", entity);
        }

        public async Task<Vector3> GetEntityRotation(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityRotation", entity);
        }

        public async Task<Vector3> GetEntityLeftPosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityLeftPosition", entity);
        }

        public async Task<Vector3> GetEntityRightPosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityRightPosition", entity);
        }

        public async Task<Vector3> GetEntityFrontPosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityFrontPosition", entity);
        }

        public async Task<Vector3> GetEntityRearPosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityRearPosition", entity);
        }

        public async Task<Vector3> GetEntityAbovePosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityAbovePosition", entity);
        }

        public async Task<Vector3> GetEntityBelowPosition(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityBelowPosition", entity);
        }

        public async Task<Vector3> GetEntityForwardVector(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityForwardVector", entity);
        }

        public async Task<Vector3> GetEntityRightVector(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityRightVector", entity);
        }

        public async Task<Vector3> GetEntityUpVector(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityUpVector", entity);
        }

        public async Task<Vector3> GetEntityVelocity(Client sender, NetHandle entity)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityVelocity", entity);
        }

        public async Task<int> GetEntityTransparency(Client sender, NetHandle entity)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getEntityTransparency", entity);
        }

        public async Task<int> GetEntityType(Client sender, NetHandle entity)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getEntityType", entity);
        }

        public async Task<int> GetEntityDimension(Client sender, NetHandle entity)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getEntityDimension", entity);
        }

        public async Task<int> GetEntityModel(Client sender, NetHandle entity)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getEntityModel", entity);
        }

        public async Task<bool> GetEntityInvincible(Client sender, NetHandle entity)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getEntityInvincible", entity);
        }

        public async Task<int> GetEntityBoneCount(Client sender, NetHandle entity)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getEntityBoneCount", entity);
        }

        public async Task<int> GetEntityBoneIndexByName(Client sender, NetHandle entity, string boneName)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getEntityBoneIndexByName", entity, boneName);
        }

        public async Task<Vector3> GetEntityBoneWorldPosition(Client sender, NetHandle entity, string boneName)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityBoneWorldPosition", entity,
                boneName);
        }

        public async Task<Vector3> GetEntityBoneWorldPosition(Client sender, NetHandle entity, Bone boneIndex)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityBoneWorldPosition", entity,
                boneIndex);
        }

        public async Task<Vector3> GetEntityBoneRelativePosition(Client sender, NetHandle entity, string boneName)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityBoneRelativePosition", entity,
                boneName);
        }

        public async Task<Vector3> GetEntityBoneRelativePosition(Client sender, NetHandle entity, Bone boneIndex)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getEntityBoneRelativePosition", entity,
                boneIndex);
        }

        public async Task<bool> GetEntityHasCollided(Client sender, NetHandle entity)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getEntityHasCollided", entity);
        }

        public async Task<bool> GetEntityCollisionless(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getEntityCollisionless", vehicle);
        }

        public async Task<dynamic> GetEntitySyncedData(Client sender, NetHandle entity, string key)
        {
            return await GetFromClient<dynamic>(sender, "ClientWrapper.Get.getEntitySyncedData", entity, key);
        }

        public async Task<string[]> GetAllEntitySyncedData(Client sender, NetHandle entity)
        {
            return await GetFromClient<string[]>(sender, "ClientWrapper.Get.getAllEntitySyncedData", entity);
        }

        public async Task<dynamic> GetWorldSyncedData(Client sender, string key)
        {
            return await GetFromClient<dynamic>(sender, "ClientWrapper.Get.getWorldSyncedData", key);
        }

        public async Task<string[]> GetAllWorldSyncedData(Client sender)
        {
            return await GetFromClient<string[]>(sender, "ClientWrapper.Get.getAllWorldSyncedData");
        }

        public async Task<Vector3> GetBlipPosition(Client sender, NetHandle blip)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getBlipPosition", blip);
        }

        public async Task<int> GetBlipColor(Client sender, NetHandle blip)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getBlipColor", blip);
        }

        public async Task<int> GetBlipSprite(Client sender, NetHandle blip)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getBlipSprite", blip);
        }

        public async Task<string> GetBlipName(Client sender, NetHandle blip)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getBlipName", blip);
        }

        public async Task<int> GetBlipTransparency(Client sender, NetHandle blip)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getBlipTransparency", blip);
        }

        public async Task<bool> GetBlipShortRange(Client sender, NetHandle blip)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getBlipShortRange", blip);
        }

        public async Task<double> GetBlipScale(Client sender, NetHandle blip)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getBlipScale", blip);
        }

        public async Task<bool> GetBlipRouteVisible(Client sender, NetHandle blip)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getBlipRouteVisible", blip);
        }

        public async Task<int> GetBlipRouteColor(Client sender, NetHandle blip)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getBlipRouteColor", blip);
        }

        public async Task<bool> GetBlipFlashing(Client sender, NetHandle blip)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getBlipFlashing", blip);
        }

        public async Task<bool> GetBlipScaleToMapZoom(Client sender, NetHandle blip)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getBlipScaleToMapZoom", blip);
        }

        public async Task<int> GetMarkerType(Client sender, NetHandle marker)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getMarkerType", marker);
        }

        public async Task<Color> GetMarkerColor(Client sender, NetHandle marker)
        {
            return await GetFromClient<Color>(sender, "ClientWrapper.Get.getMarkerColor", marker);
        }

        public async Task<Vector3> GetMarkerScale(Client sender, NetHandle marker)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getMarkerScale", marker);
        }

        public async Task<Vector3> GetMarkerDirection(Client sender, NetHandle marker)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getMarkerDirection", marker);
        }

        public async Task<bool> GetMarkerBobUpAndDown(Client sender, NetHandle marker)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getMarkerBobUpAndDown", marker);
        }

        public async Task<string> GetBoneName(Client sender, int bone)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getBoneName", bone);
        }

        public async Task<bool> GetPedCanRagdoll(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getPedCanRagdoll");
        }

        public async Task<int> GetMaxHealth(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getMaxHealth");
        }

        public async Task<string> GetPedHeadShotTextureString(Client sender, int handle)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getPedHeadShotTextureString", handle);
        }

        public async Task<Color> GetTextLabelColor(Client sender, NetHandle textLabel)
        {
            return await GetFromClient<Color>(sender, "ClientWrapper.Get.getTextLabelColor", textLabel);
        }

        public async Task<bool> GetTextLabelSeethrough(Client sender, NetHandle handle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getTextLabelSeethrough", handle);
        }

        public async Task<NetHandle> GetClosestVehicle(Client sender, Vector3 position, double radius,
            params int[] models)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getClosestVehicle", position, radius,
                models);
        }

        public async Task<NetHandle[]> GetNearbyVehicles(Client sender, Vector3 position, double radius,
            params int[] models)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getNearbyVehicles", position, radius,
                models);
        }

        public async Task<int> GetVehicleLivery(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleLivery", vehicle);
        }

        public async Task<double> GetVehicleDeluxoTransformation(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleDeluxoTransformation", vehicle);
        }

        public async Task<bool> GetVehicleSubmarineTransformed(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleSubmarineTransformed", vehicle);
        }

        public async Task<double> GetVehicleOppressorTransformation(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleOppressorTransformation", vehicle);
        }

        public async Task<int> GetCurrentVehicleRadioStationId(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getCurrentVehicleRadioStationId");
        }

        public async Task<bool> GetVehicleRadioEnabled(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleRadioEnabled");
        }

        public async Task<bool> GetVehicleRadioRetuning(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleRadioRetuning");
        }

        public async Task<bool> GetVehicleLocked(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleLocked", vehicle);
        }

        public async Task<NetHandle> GetVehicleTrailer(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getVehicleTrailer", vehicle);
        }

        public async Task<NetHandle> GetVehicleTruck(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getVehicleTruck", vehicle);
        }

        public async Task<NetHandle> GetVehicleTraileredBy(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getVehicleTraileredBy", vehicle);
        }

        public async Task<bool> GetVehicleSirenState(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleSirenState", vehicle);
        }

        public async Task<string> GetVehicleModSlotName(Client sender, NetHandle vehicle, VehicleModType modType)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getVehicleModSlotName", vehicle, modType);
        }

        public async Task<string> GetVehicleModTextLabel(Client sender, NetHandle vehicle, VehicleModType modType,
            int modValue)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getVehicleModTextLabel", vehicle, modType,
                modValue);
        }

        public async Task<string> GetVehicleLiveryName(Client sender, NetHandle vehicle, int liveryIndexr)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getVehicleLiveryName", vehicle, liveryIndexr);
        }

        public async Task<bool> GetVehicleDoorState(Client sender, NetHandle vehicle, DoorState door)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleDoorState", vehicle, door);
        }

        public async Task<bool> GetVehicleExtra(Client sender, NetHandle vehicle, int slot)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleExtra", vehicle, slot);
        }

        public async Task<string> GetVehicleNumberPlate(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getVehicleNumberPlate", vehicle);
        }

        public async Task<bool> GetVehicleEngineStatus(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleEngineStatus", vehicle);
        }

        public async Task<bool> GetVehicleSpecialLightStatus(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleSpecialLightStatus", vehicle);
        }

        public async Task<int> GetVehicleNumModCount(Client sender, NetHandle vehicle, VehicleModType modType)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleNumModCount", vehicle, modType);
        }

        public async Task<int> GetVehicleMod(Client sender, NetHandle vehicle, VehicleModType modType)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleMod", vehicle, modType);
        }

        public async Task<double> GetVehicleEngineTemperature(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleEngineTemperature", vehicle);
        }

        public async Task<double> GetVehicleTurbo(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleTurbo", vehicle);
        }

        public async Task<double> GetVehicleClutch(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleClutch", vehicle);
        }

        public async Task<double> GetVehicleThrottle(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleThrottle", vehicle);
        }

        public async Task<double> GetVehicleThrottlePower(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleThrottlePower", vehicle);
        }

        public async Task<double> GetVehicleBrakePower(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleBrakePower", vehicle);
        }

        public async Task<double> GetVehicleOilLevel(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleOilLevel", vehicle);
        }

        public async Task<double> GetVehicleFuelLevel(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleFuelLevel", vehicle);
        }

        public async Task<double> GetVehicleDirtLevel(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleDirtLevel", vehicle);
        }

        public async Task<bool> GetVehicleBulletproofTyres(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleBulletproofTyres", vehicle);
        }

        public async Task<int> GetVehicleNumberPlateStyle(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleNumberPlateStyle", vehicle);
        }

        public async Task<int> GetVehiclePearlescentColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehiclePearlescentColor", vehicle);
        }

        public async Task<int> GetVehicleWheelColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleWheelColor", vehicle);
        }

        public async Task<VehicleWheelType.VehicleWheelTypeEnum> GetVehicleWheelType(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<VehicleWheelType.VehicleWheelTypeEnum>(sender,
                "ClientWrapper.Get.getVehicleWheelType", vehicle);
        }

        public async Task<int> GetVehicleWindowTint(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleWindowTint", vehicle);
        }

        public async Task<double> GetVehicleEnginePowerMultiplier(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleEnginePowerMultiplier", vehicle);
        }

        public async Task<double> GetVehicleEngineTorqueMultiplier(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleEngineTorqueMultiplier", vehicle);
        }

        public async Task<bool> GetVehicleNeonState(Client sender, NetHandle vehicle, int slot)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleNeonState", vehicle, slot);
        }

        public async Task<Color> GetVehicleNeonColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<Color>(sender, "ClientWrapper.Get.getVehicleNeonColor", vehicle);
        }

        public async Task<int> GetVehicleDashboardColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleDashboardColor", vehicle);
        }

        public async Task<int> GetVehicleTrimColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleTrimColor", vehicle);
        }

        public async Task<string> GetVehicleDisplayName(Client sender, VehicleHash model)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getVehicleDisplayName", model);
        }

        public async Task<double> GetVehicleMaxSpeed(Client sender, VehicleHash model)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMaxSpeed", model);
        }

        public async Task<double> GetVehicleMaxBraking(Client sender, VehicleHash model)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMaxBraking", model);
        }

        public async Task<double> GetVehicleMaxTraction(Client sender, VehicleHash model)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMaxTraction", model);
        }

        public async Task<double> GetVehicleMaxAcceleration(Client sender, VehicleHash model)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMaxAcceleration", model);
        }

        public async Task<double> GetVehicleMaxOccupants(Client sender, VehicleHash model)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleMaxOccupants", model);
        }

        public async Task<VehicleClass> GetVehicleClass(Client sender, VehicleHash model)
        {
            return await GetFromClient<VehicleClass>(sender, "ClientWrapper.Get.getVehicleClass", model);
        }

        public async Task<Color> GetVehicleCustomPrimaryColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<Color>(sender, "ClientWrapper.Get.getVehicleCustomPrimaryColor", vehicle);
        }

        public async Task<Color> GetVehicleCustomSecondaryColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<Color>(sender, "ClientWrapper.Get.getVehicleCustomSecondaryColor", vehicle);
        }

        public async Task<int> GetVehiclePrimaryColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehiclePrimaryColor", vehicle);
        }

        public async Task<int> GetVehicleSecondaryColor(Client sender, NetHandle vehicle)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getVehicleSecondaryColor", vehicle);
        }

        public async Task<double> GetVehicleHealth(Client sender, NetHandle entity)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleHealth", entity);
        }

        public async Task<double> GetVehiclePetrolTankHealth(Client sender, NetHandle entity)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehiclePetrolTankHealth", entity);
        }

        public async Task<double> GetVehicleRpm(Client sender, NetHandle entity)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleRPM", entity);
        }

        public async Task<double> GetVehicleHighGear(Client sender, NetHandle entity)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleHighGear", entity);
        }

        public async Task<double> GetVehicleCurrentGear(Client sender, NetHandle entity)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getVehicleCurrentGear", entity);
        }

        public async Task<string> GetVehicleModelName(Client sender, VehicleHash model)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getVehicleModelName", model);
        }

        public async Task<bool> GetCanOpenChat(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getCanOpenChat");
        }

        public async Task<bool> GetChatVisible(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getChatVisible");
        }

        public async Task<bool> GetAlternativeVersionLabelPositionActive(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getAlternativeVersionLabelPositionActive");
        }

        public async Task<bool> GetShowWastedScreenOnDeath(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getShowWastedScreenOnDeath");
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task<bool> GetVehicleEnteringKeysDisabled(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getVehicleEnteringKeysDisabled");
        }

        public async Task<SizeF> GetScreenResolutionMantainRatio(Client sender)
        {
            return await GetFromClient<SizeF>(sender, "ClientWrapper.Get.getScreenResolutionMantainRatio");
        }

        public async Task<SizeF> GetScreenResolutionMaintainRatio(Client sender)
        {
            return await GetFromClient<SizeF>(sender, "ClientWrapper.Get.getScreenResolutionMaintainRatio");
        }

        public async Task<Size> GetScreenResolution(Client sender)
        {
            return await GetFromClient<Size>(sender, "ClientWrapper.Get.getScreenResolution");
        }

        public async Task<Vector3> GetWaypointPosition(Client sender)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getWaypointPosition");
        }

        public async Task<bool> GetHudVisible(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getHudVisible");
        }

        public async Task<string> GetUserInput(Client sender, string defaultText, int maxlen)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getUserInput", defaultText, maxlen);
        }

        public async Task<int> GetNamedRenderTargetRenderId(Client sender, string renderTargetName)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getNamedRenderTargetRenderID", renderTargetName);
        }

        public async Task<string> GetUniqueHardwareId(Client sender)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getUniqueHardwareId");
        }

        public async Task<string> GetSocialClubName(Client sender)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getSocialClubName");
        }

        public async Task<int> GetGamePlayer(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getGamePlayer");
        }

        public async Task<NetHandle> GetLocalPlayer(Client sender)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getLocalPlayer");
        }

        public async Task<bool> GetLocalPlayerInvincible(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getLocalPlayerInvincible");
        }

        public async Task<bool> GetPlayerNametagVisible(Client sender, NetHandle player)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getPlayerNametagVisible", player);
        }

        public async Task<bool> GetPlayerHealthbarVisible(Client sender, NetHandle player)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getPlayerHealthbarVisible", player);
        }

        public async Task<bool> GetPlayerArmorbarVisible(Client sender, NetHandle player)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getPlayerArmorbarVisible", player);
        }

        public async Task<NetHandle> GetLocalPlayerAimingAtEntity(Client sender)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getLocalPlayerAimingAtEntity");
        }

        public async Task<Vector3> GetPlayerAimingPoint(Client sender, NetHandle player)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getPlayerAimingPoint", player);
        }

        public async Task<int> GetPlayerTeam(Client sender, NetHandle player)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerTeam", player);
        }

        public async Task<int> GetPlayerWantedLevel(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerWantedLevel");
        }

        public async Task<bool> GetPlayerInvincible(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getPlayerInvincible");
        }

        public async Task<int> GetPlayerArmor(Client sender, NetHandle player)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerArmor", player);
        }

        public async Task<NetHandle> GetPlayerByName(Client sender, string name)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getPlayerByName", name);
        }

        public async Task<string> GetPlayerName(Client sender, NetHandle player)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getPlayerName", player);
        }

        public async Task<int> GetPlayerVehicleSeatIndex(Client sender, NetHandle player)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerVehicleSeatIndex", player);
        }

        public async Task<int> GetPlayerVehicleSeat(Client sender, NetHandle player)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerVehicleSeat", player);
        }

        public async Task<bool> GetPlayerSeatbelt(Client sender, NetHandle player)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getPlayerSeatbelt", player);
        }

        public async Task<int> GetPlayerHealth(Client sender, NetHandle player)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerHealth", player);
        }

        public async Task<Vector3> GetPlayerAimCoords(Client sender, NetHandle player)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getPlayerAimCoords", player);
        }

        public async Task<int> GetPlayerPing(Client sender, NetHandle player)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerPing", player);
        }

        public async Task<NetHandle> GetPlayerVehicle(Client sender, NetHandle player)
        {
            return await GetFromClient<NetHandle>(sender, "ClientWrapper.Get.getPlayerVehicle", player);
        }

        public async Task<int> GetPlayerHeadOverlayValue(Client sender, NetHandle player, int overlayId)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerHeadOverlayValue", player, overlayId);
        }

        public async Task<int> GetFirstParentIdForPedType(Client sender, int type)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getFirstParentIdForPedType", type);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="overlayId"></param>
        /// <returns></returns>
        public async Task<int> GetNumHeadOverlayValues(Client sender, int overlayId)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getNumHeadOverlayValues", overlayId);
        }

        public async Task<int> GetNumHairColors(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getNumHairColors");
        }

        public async Task<int> GetNumMakeupColors(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getNumMakeupColors");
        }

        public async Task<int> GetTattooZone(Client sender, string collection, string overlay)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getTattooZone", collection, overlay);
        }

        public async Task<int> GetTattooZone(Client sender, int collection, int overlay)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getTattooZone", collection, overlay);
        }

        public async Task<int> GetPlayerWeaponTint(Client sender, WeaponHash weaponHash)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getPlayerWeaponTint", weaponHash);
        }

        public async Task<int> GetWeaponAmmo(Client sender, WeaponHash weaponHash)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getWeaponAmmo", weaponHash);
        }

        public async Task<int> GetAmmoInClip(Client sender)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getAmmoInClip");
        }

        public async Task<WeaponComponent[]> GetAllWeaponComponents(Client sender, WeaponHash weapon)
        {
            return await GetFromClient<WeaponComponent[]>(sender, "ClientWrapper.Get.getAllWeaponComponents", weapon);
        }

        public async Task<WeaponHash> GetPlayerCurrentWeapon(Client sender)
        {
            return await GetFromClient<WeaponHash>(sender, "ClientWrapper.Get.getPlayerCurrentWeapon");
        }

        public async Task<string> GetWeaponName(Client sender, WeaponHash weaponHash)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getWeaponName", weaponHash);
        }

        public async Task<PointF> GetCursorPosition(Client sender)
        {
            return await GetFromClient<PointF>(sender, "ClientWrapper.Get.getCursorPosition");
        }

        public async Task<PointF> GetCursorPositionMantainRatio(Client sender)
        {
            return await GetFromClient<PointF>(sender, "ClientWrapper.Get.getCursorPositionMantainRatio");
        }

        public async Task<PointF> GetCursorPositionMaintainRatio(Client sender)
        {
            return await GetFromClient<PointF>(sender, "ClientWrapper.Get.getCursorPositionMaintainRatio");
        }

        public async Task<dynamic> GetSetting(Client sender, string name)
        {
            return await GetFromClient<dynamic>(sender, "ClientWrapper.Get.getSetting", name);
        }

        public async Task<NetHandle[]> GetStreamedPlayers(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedPlayers");
        }

        public async Task<NetHandle[]> GetStreamedVehicles(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedVehicles");
        }

        public async Task<NetHandle[]> GetStreamedObjects(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedObjects");
        }

        public async Task<NetHandle[]> GetStreamedPickups(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedPickups");
        }

        public async Task<NetHandle[]> GetStreamedPeds(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedPeds");
        }

        public async Task<NetHandle[]> GetStreamedMarkers(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedMarkers");
        }

        public async Task<NetHandle[]> GetStreamedTextLabels(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getStreamedTextLabels");
        }

        public async Task<NetHandle[]> GetAllPlayers(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllPlayers");
        }

        public async Task<NetHandle[]> GetAllVehicles(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllVehicles");
        }

        public async Task<NetHandle[]> GetAllObjects(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllObjects");
        }

        public async Task<NetHandle[]> GetAllPickups(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllPickups");
        }

        public async Task<NetHandle[]> GetAllPeds(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllPeds");
        }

        public async Task<NetHandle[]> GetAllMarkers(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllMarkers");
        }

        public async Task<NetHandle[]> GetAllTextLabels(Client sender)
        {
            return await GetFromClient<NetHandle[]>(sender, "ClientWrapper.Get.getAllTextLabels");
        }

        public async Task<Weather> GetWeather(Client sender)
        {
            return await GetFromClient<Weather>(sender, "ClientWrapper.Get.getWeather");
        }

        public async Task<Weather> GetNextWeather(Client sender)
        {
            return await GetFromClient<Weather>(sender, "ClientWrapper.Get.getNextWeather");
        }

        public async Task<double> GetWeatherTransitionType(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getWeatherTransitionType");
        }

        public async Task<TimeSpan> GetTime(Client sender)
        {
            return await GetFromClient<TimeSpan>(sender, "ClientWrapper.Get.getTime");
        }

        public async Task<Vector3> GetOffsetInWorldCoords(Client sender, NetHandle entity, Vector3 offset)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getOffsetInWorldCoords", entity, offset);
        }

        public async Task<Vector3> GetSafeCoordForPed(Client sender, Vector3 position, bool sidewalk, int flags)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getSafeCoordForPed", position, sidewalk,
                flags);
        }

        public async Task<Vector3> GetNextPositionOnStreet(Client sender, Vector3 position, bool unoccupied)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getNextPositionOnStreet", position,
                unoccupied);
        }

        public async Task<Vector3> GetNextPositionOnSidewalk(Client sender, Vector3 position)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getNextPositionOnSidewalk", position);
        }

        public async Task<Vector3> GetOffsetFromWorldCoords(Client sender, NetHandle entity, Vector3 pos)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getOffsetFromWorldCoords", entity, pos);
        }

        public async Task<string> GetZoneName(Client sender, Vector3 position)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getZoneName", position);
        }

        public async Task<string> GetZoneNameLabel(Client sender, Vector3 position)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getZoneNameLabel", position);
        }

        public async Task<double> GetGroundHeight(Client sender, Vector3 position)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getGroundHeight", position);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public async Task<int> GetInteriorAtPos(Client sender, Vector3 pos)
        {
            return await GetFromClient<int>(sender, "ClientWrapper.Get.getInteriorAtPos", pos);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public async Task<bool> GetCityBlackout(Client sender)
        {
            return await GetFromClient<bool>(sender, "ClientWrapper.Get.getCityBlackout");
        }

        public async Task<Vector3> GetWorldLimits(Client sender)
        {
            return await GetFromClient<Vector3>(sender, "ClientWrapper.Get.getWorldLimits");
        }

        public async Task<double> GetGravityLevel(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getGravityLevel");
        }

        public async Task<double> GetCloudHatOpacity(Client sender)
        {
            return await GetFromClient<double>(sender, "ClientWrapper.Get.getCloudHatOpacity");
        }

        public async Task<string> GetCurrentResourceName(Client sender)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getCurrentResourceName");
        }

        /// <summary>
        ///     Waiting for the return value of the client get function
        /// </summary>
        /// <typeparam name="T">Type of client function</typeparam>
        /// <param name="sender">Player</param>
        /// <param name="eventName">The event name</param>
        /// <param name="arguments">Event arguments</param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns>Client return value</returns>
        private async Task<T> GetFromClient<T>(Client sender, string eventName, params object[] arguments)
        {
            T returnValue = default(T);
            bool recived = false;
            // Generate unique event name 
            string uniqueEventName = "";
            while (_eventHandler.EventSubscribed(uniqueEventName) || uniqueEventName == "")
                uniqueEventName = $"{eventName}{_randomHash.Next(10000, 90000)}";

            // Bind recive event
            ServerEventHandle reciveServerEventHandle = new ServerEventHandle(OnReciveEventTriggered);
            _eventHandler.SubscribeToServerEvent(uniqueEventName, reciveServerEventHandle);

            // Trigger client event
            _eventHandler.InvokeClientEvent(sender, eventName,
                new object[] {uniqueEventName}.Concat(arguments).ToArray());

            void OnReciveEventTriggered(Client reciveSender, string reciveEventName, params object[] reciveArguments)
            {
                if (reciveEventName != uniqueEventName || !reciveArguments.Any() ||
                    !reciveSender.Equals(sender)) return;
                returnValue = (T) reciveArguments[0];
                recived = true;
            }

            return await Task.Run(() =>
            {
                DateTime startTimeoutCheck = DateTime.Now;
                while (startTimeoutCheck.AddMilliseconds(WaitTimeoutMs) > DateTime.Now && !recived)
                    Thread.Sleep(10);

                _eventHandler.UnsubscribeToServerEvent(uniqueEventName);

                // Throw Exception if timeout
                if (!recived)
                    throw new GetTimeoutException($"Timeout on ClientWrapper.Get event {uniqueEventName}");

                return returnValue;
            });
        }
    }
}

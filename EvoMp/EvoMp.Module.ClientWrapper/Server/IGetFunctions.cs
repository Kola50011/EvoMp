using System;
using System.Drawing;
using System.Threading.Tasks;
using EvoMp.Module.ClientWrapper.Server.Exceptions;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using GrandTheftMultiplayer.Shared.Math;
using Color = System.Drawing.Color;
using Weather = GrandTheftMultiplayer.Shared.Gta.World.Weather;

namespace EvoMp.Module.ClientWrapper.Server
{
    public interface IGetFunctions
    {
        /// <summary>
        ///     Returns the Streetname of position
        /// </summary>
        /// <param name="sender">Player</param>
        /// <param name="position">Position of the wanted street</param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns>streetname</returns>
        Task<string> GetStreetName(Client sender, Vector3 position);

        /// <summary>
        ///     Returns the Discord presence activity
        /// </summary>
        /// <param name="sender">Player</param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<string> GetDiscordPresenceActivity(Client sender);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="vehicleHash"></param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<double> GetVehicleAntiRollBarBiasFront(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleAntiRollBarForce(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleBrakeForce(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleCamberStiffness(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetVehicleCenterOfMassOffset(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleClutchChangeRateScaleDownShift(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleClutchChangeRateScaleUpShift(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleCollisionDamageMultiplier(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleDeformationDamageMultiplier(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleDriveInertia(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleEngineDamageMultiplier(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleHandBrakeForce(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetVehicleInertiaMultiplier(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleInitialDriveForce(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleInitialDriveGears(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMass(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMonetaryValue(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehiclePercentSubmerged(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleRollCenterHeightFront(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleRollCenterHeightRear(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSeatOffsetDistanceX(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSeatOffsetDistanceY(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSeatOffsetDistanceZ(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSteeringLock(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionBiasFront(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionCompressionDamping(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionForce(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionLowerLimit(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionRaise(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionReboundDamping(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleSuspensionUpperLimit(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleTractionBiasFront(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleTractionCurveMax(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleTractionCurveMin(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleTractionLossMultiplier(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleTractionSpringDeltaMax(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleDriveBiasFront(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleBrakeBiasFront(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleInitialDragCoefficiency(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleInitialDriveMaxFlatVelocity(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetCharFromKey(Client sender, int key, bool shift, bool ctrl, bool alt);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetClosestProp(Client sender, Vector3 position, double radius, params int[] models);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetNearbyProps(Client sender, Vector3 position, double radius,
            params int[] models);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetWorldProps(Client sender, params int[] models);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string[]> GetAllLoadedAsiNames(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetLoadedAsiHash(Client sender, string asiName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string[]> GetAllActiveModDlcPacksNames(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetModDlcPackHash(Client sender, string modDlcPack);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string[]> GetAllModdedFileNames(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetModdedFileHash(Client sender, string gtaModdedFileName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string[]> GetAllCustomScriptsNames(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetCustomScriptHash(Client sender, string customScriptName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetAnimCurrentTime(Client sender, NetHandle handle, string animDict, string animName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetAnimTotalTime(Client sender, NetHandle handle, string animDict, string animName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetAnimTotalTime(Client sender, string animDict, string animName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetGameFramerate(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetGameText(Client sender, string labelName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetGameTime(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetGlobalTime(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetHashKey(Client sender, string input);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetAlternativeMainMenuKeyDisabled(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetCultureIsoLanguageName(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetMusicVolume(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetMusicTime(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetAudioTime(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetGameplayCamPos(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetGameplayCamRot(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetGameplayCamDir(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetBytesSentPerSecond(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetBytesReceivedPerSecond(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetControlNormal(Client sender, int control);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetDisabledControlNormal(Client sender, int control);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetFontWidth(Client sender, string text, int font, double scale);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityPosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Quaternion> GetEntityQuaternion(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityRotation(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityLeftPosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityRightPosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityFrontPosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityRearPosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityAbovePosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityBelowPosition(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityForwardVector(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityRightVector(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityUpVector(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityVelocity(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetEntityTransparency(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetEntityType(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetEntityDimension(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetEntityModel(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetEntityInvincible(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetEntityBoneCount(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetEntityBoneIndexByName(Client sender, NetHandle entity, string boneName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityBoneWorldPosition(Client sender, NetHandle entity, string boneName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityBoneWorldPosition(Client sender, NetHandle entity, Bone boneIndex);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityBoneRelativePosition(Client sender, NetHandle entity, string boneName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetEntityBoneRelativePosition(Client sender, NetHandle entity, Bone boneIndex);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetEntityHasCollided(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetEntityCollisionless(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<dynamic> GetEntitySyncedData(Client sender, NetHandle entity, string key);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string[]> GetAllEntitySyncedData(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<dynamic> GetWorldSyncedData(Client sender, string key);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string[]> GetAllWorldSyncedData(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetBlipPosition(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetBlipColor(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetBlipSprite(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetBlipName(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetBlipTransparency(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetBlipShortRange(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetBlipScale(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetBlipRouteVisible(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetBlipRouteColor(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetBlipFlashing(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetBlipScaleToMapZoom(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetMarkerType(Client sender, NetHandle marker);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Color> GetMarkerColor(Client sender, NetHandle marker);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetMarkerScale(Client sender, NetHandle marker);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetMarkerDirection(Client sender, NetHandle marker);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetMarkerBobUpAndDown(Client sender, NetHandle marker);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetBoneName(Client sender, int bone);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetPedCanRagdoll(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetMaxHealth(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetPedHeadShotTextureString(Client sender, int handle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Color> GetTextLabelColor(Client sender, NetHandle textLabel);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetTextLabelSeethrough(Client sender, NetHandle handle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetClosestVehicle(Client sender, Vector3 position, double radius,
            params int[] models);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetNearbyVehicles(Client sender, Vector3 position, double radius,
            params int[] models);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleLivery(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleDeluxoTransformation(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleSubmarineTransformed(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleOppressorTransformation(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<int> GetCurrentVehicleRadioStationId(Client sender);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<bool> GetVehicleRadioEnabled(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleRadioRetuning(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleLocked(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetVehicleTrailer(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetVehicleTruck(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetVehicleTraileredBy(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleSirenState(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetVehicleModSlotName(Client sender, NetHandle vehicle, VehicleModType modType);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetVehicleModTextLabel(Client sender, NetHandle vehicle, VehicleModType modType,
            int modValue);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetVehicleLiveryName(Client sender, NetHandle vehicle, int liveryIndexr);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleDoorState(Client sender, NetHandle vehicle, DoorState door);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleExtra(Client sender, NetHandle vehicle, int slot);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetVehicleNumberPlate(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleEngineStatus(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleSpecialLightStatus(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleNumModCount(Client sender, NetHandle vehicle, VehicleModType modType);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleMod(Client sender, NetHandle vehicle, VehicleModType modType);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleEngineTemperature(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleTurbo(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleClutch(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleThrottle(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleThrottlePower(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleBrakePower(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleOilLevel(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleFuelLevel(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleDirtLevel(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleBulletproofTyres(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleNumberPlateStyle(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehiclePearlescentColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleWheelColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<VehicleWheelType.VehicleWheelTypeEnum> GetVehicleWheelType(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleWindowTint(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleEnginePowerMultiplier(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleEngineTorqueMultiplier(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetVehicleNeonState(Client sender, NetHandle vehicle, int slot);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Color> GetVehicleNeonColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleDashboardColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleTrimColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetVehicleDisplayName(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMaxSpeed(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMaxBraking(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMaxTraction(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMaxAcceleration(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleMaxOccupants(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<VehicleClass> GetVehicleClass(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Color> GetVehicleCustomPrimaryColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Color> GetVehicleCustomSecondaryColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehiclePrimaryColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetVehicleSecondaryColor(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleHealth(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehiclePetrolTankHealth(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleRpm(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleHighGear(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetVehicleCurrentGear(Client sender, NetHandle entity);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetVehicleModelName(Client sender, VehicleHash model);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetCanOpenChat(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetChatVisible(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetAlternativeVersionLabelPositionActive(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetShowWastedScreenOnDeath(Client sender);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<bool> GetVehicleEnteringKeysDisabled(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<SizeF> GetScreenResolutionMantainRatio(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<SizeF> GetScreenResolutionMaintainRatio(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Size> GetScreenResolution(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetWaypointPosition(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetHudVisible(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetUserInput(Client sender, string defaultText, int maxlen);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetNamedRenderTargetRenderId(Client sender, string renderTargetName);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetUniqueHardwareId(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetSocialClubName(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetGamePlayer(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetLocalPlayer(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetLocalPlayerInvincible(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetPlayerNametagVisible(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetPlayerHealthbarVisible(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetPlayerArmorbarVisible(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetLocalPlayerAimingAtEntity(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetPlayerAimingPoint(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerTeam(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerWantedLevel(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetPlayerInvincible(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerArmor(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetPlayerByName(Client sender, string name);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetPlayerName(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerVehicleSeatIndex(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerVehicleSeat(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<bool> GetPlayerSeatbelt(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerHealth(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetPlayerAimCoords(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerPing(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle> GetPlayerVehicle(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerHeadOverlayValue(Client sender, NetHandle player, int overlayId);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetFirstParentIdForPedType(Client sender, int type);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="overlayId"></param>
        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<int> GetNumHeadOverlayValues(Client sender, int overlayId);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetNumHairColors(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetNumMakeupColors(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetTattooZone(Client sender, string collection, string overlay);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetTattooZone(Client sender, int collection, int overlay);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetPlayerWeaponTint(Client sender, WeaponHash weaponHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetWeaponAmmo(Client sender, WeaponHash weaponHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<int> GetAmmoInClip(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<WeaponComponent[]> GetAllWeaponComponents(Client sender, WeaponHash weapon);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<WeaponHash> GetPlayerCurrentWeapon(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetWeaponName(Client sender, WeaponHash weaponHash);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<PointF> GetCursorPosition(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<PointF> GetCursorPositionMantainRatio(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<PointF> GetCursorPositionMaintainRatio(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<dynamic> GetSetting(Client sender, string name);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedPlayers(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedVehicles(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedObjects(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedPickups(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedPeds(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedMarkers(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetStreamedTextLabels(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllPlayers(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllVehicles(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllObjects(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllPickups(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllPeds(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllMarkers(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<NetHandle[]> GetAllTextLabels(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Weather> GetWeather(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Weather> GetNextWeather(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetWeatherTransitionType(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<TimeSpan> GetTime(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetOffsetInWorldCoords(Client sender, NetHandle entity, Vector3 offset);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetSafeCoordForPed(Client sender, Vector3 position, bool sidewalk, int flags);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetNextPositionOnStreet(Client sender, Vector3 position, bool unoccupied);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetNextPositionOnSidewalk(Client sender, Vector3 position);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetOffsetFromWorldCoords(Client sender, NetHandle entity, Vector3 pos);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetZoneName(Client sender, Vector3 position);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetZoneNameLabel(Client sender, Vector3 position);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetGroundHeight(Client sender, Vector3 position);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pos"></param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<int> GetInteriorAtPos(Client sender, Vector3 pos);

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns></returns>
        Task<bool> GetCityBlackout(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<Vector3> GetWorldLimits(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetGravityLevel(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<double> GetCloudHatOpacity(Client sender);

        /// <summary>
        /// </summary>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        Task<string> GetCurrentResourceName(Client sender);
    }
}

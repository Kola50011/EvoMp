using System.Drawing;
using EvoMp.Module.ClientWrapper.Server.Enums;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using GrandTheftMultiplayer.Shared.Math;
using Weather = GrandTheftMultiplayer.Shared.Gta.World.Weather;

namespace EvoMp.Module.ClientWrapper.Server
{
    public interface ISetFunctions
    {
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="activitystring"></param>
        void SetDiscordPresenceActivity(Client sender, string activitystring);

        /// <summary>
        /// </summary>
        void ResetVehicleHandlingData(Client sender, VehicleHash vehicleHash);

        /// <summary>
        /// </summary>
        void SetVehicleAntiRollBarBiasFront(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleAntiRollBarForce(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleBrakeForce(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleCamberStiffness(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleCenterOfMassOffset(Client sender, VehicleHash vehicleHash, Vector3 value);

        /// <summary>
        /// </summary>
        void SetVehicleClutchChangeRateScaleDownShift(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleClutchChangeRateScaleUpShift(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleCollisionDamageMultiplier(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleDeformationDamageMultiplier(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleDriveInertia(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleEngineDamageMultiplier(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleHandBrakeForce(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleInertiaMultiplier(Client sender, VehicleHash vehicleHash, Vector3 value);

        /// <summary>
        /// </summary>
        void SetVehicleInitialDriveForce(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleInitialDriveGears(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleMass(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleMonetaryValue(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehiclePercentSubmerged(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleRollCenterHeightFront(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleRollCenterHeightRear(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSeatOffsetDistanceX(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSeatOffsetDistanceY(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSeatOffsetDistanceZ(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSteeringLock(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionBiasFront(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionCompressionDamping(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionForce(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionLowerLimit(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionRaise(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionReboundDamping(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSuspensionUpperLimit(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleTractionBiasFront(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleTractionCurveMax(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleTractionCurveMin(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleTractionLossMultiplier(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleTractionSpringDeltaMax(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleDriveBiasFront(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleBrakeBiasFront(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleInitialDragCoefficiency(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetVehicleInitialDriveMaxFlatVelocity(Client sender, VehicleHash vehicleHash, double value);

        /// <summary>
        /// </summary>
        void SetAnimCurrentTime(Client sender, NetHandle handle, string animDict, string animName, double time);

        /// <summary>
        /// </summary>
        void SetAnimSpeed(Client sender, NetHandle handle, string animDict, string animName, int speedMultiplier);

        /// <summary>
        /// </summary>
        void DisableAlternativeMainMenuKey(Client sender, bool enable);

        /// <summary>
        /// </summary>
        void VerifyIntegrityOfCache(Client sender);

        /// <summary>
        /// </summary>
        void PreloadAnimationDictionary(Client sender, string animDictionary);

        /// <summary>
        /// </summary>
        void RequestStreamedTextureDict(Client sender, string textureDict);

        /// <summary>
        /// </summary>
        void DisposeStreamedTextureDict(Client sender, string textureDict);

        /// <summary>
        /// </summary>
        void RequestAdditionalText(Client sender, string gxtLib, int slot);

        /// <summary>
        /// </summary>
        void ClearAdditionalText(Client sender, int slot);

        /// <summary>
        /// </summary>
        void StartMusic(Client sender, string path, bool looped);

        /// <summary>
        /// </summary>
        void StopMusic(Client sender);

        /// <summary>
        /// </summary>
        void SetMusicVolume(Client sender, double volume);

        /// <summary>
        /// </summary>
        void SetMusicTime(Client sender, double time);

        /// <summary>
        /// </summary>
        void SetAudioTime(Client sender, double time);

        /// <summary>
        /// </summary>
        void PreloadAudio(Client sender, string path);

        /// <summary>
        /// </summary>
        void SetGameVolume(Client sender, double vol);

        /// <summary>
        /// </summary>
        void SetAudioVolume(Client sender, double vol);

        /// <summary>
        /// </summary>
        void PlaySoundFrontEnd(Client sender, string soundName, string soundSetName);

        /// <summary>
        /// </summary>
        void StartAudioScene(Client sender, string scene);

        /// <summary>
        /// </summary>
        void StopAudioScene(Client sender, string scene);

        /// <summary>
        /// </summary>
        void StopAllAudioScenes(Client sender);

        /// <summary>
        /// </summary>
        void PrepareMusicEvent(Client sender, string eventName);

        /// <summary>
        /// </summary>
        void TriggerMusicEvent(Client sender, string eventName);

        /// <summary>
        /// </summary>
        void CancelMusicEvent(Client sender, string eventName);

        /// <summary>
        /// </summary>
        void SetStaticEmitterEnabled(Client sender, string emitterName, bool enabled);

        /// <summary>
        /// </summary>
        void ReleaseNamedScriptAudioBank(Client sender, string audioBank);

        /// <summary>
        /// </summary>
        void PlaySoundFromCoord(Client sender, string soundName, Vector3 position);

        /// <summary>
        /// </summary>
        void PlaySoundFromCoord(Client sender, string soundName, string soundSetName, Vector3 position);

        /// <summary>
        /// </summary>
        void PlaySoundFromEntity(Client sender, NetHandle entity, string soundName, string soundSetName);

        /// <summary>
        /// </summary>
        void SetGameplayCameraActive(Client sender);

        /// <summary>
        /// </summary>
        void SetGameplayCameraShake(Client sender, string shakeType, double amplitute);

        /// <summary>
        /// </summary>
        void StopGameplayCameraShake(Client sender);

        /// <summary>
        /// </summary>
        void SetCameraBehindPlayer(Client sender);

        /// <summary>
        /// </summary>
        void SetCefDrawState(Client sender, bool state);

        /// <summary>
        /// </summary>
        void DisableControlThisFrame(Client sender, int control);

        /// <summary>
        /// </summary>
        void EnableControlThisFrame(Client sender, int control);

        /// <summary>
        /// </summary>
        void DisableAllControlsThisFrame(Client sender);

        /// <summary>
        /// </summary>
        void DisableAllControls(Client sender, bool disabled);

        /// <summary>
        /// </summary>
        void SetControlNormal(Client sender, int control, int value);

        /// <summary>
        /// </summary>
        void DrawLine(Client sender, Vector3 start, Vector3 end, int a, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void DrawGameTexture(Client sender, string dict, string txtName, double x, double y, double width,
            double height, double heading, int red, int green, int blue, int alpha);

        /// <summary>
        /// </summary>
        void DrawRectangle(Client sender, double xPos, double yPos, double wSize, double hSize, int red, int green,
            int blue, int alpha);

        /// <summary>
        /// </summary>
        void DrawText(Client sender, string caption, double xPos, double yPos, double scale, int red, int green,
            int blue, int alpha, int font, int justify, bool shadow, bool outline, int wordWrap);

        /// <summary>
        /// </summary>
        void DxDrawTexture(Client sender, string path, Point pos, Size size, double rotation);

        /// <summary>
        /// </summary>
        void CreateParticleEffectOnPosition(Client sender, string ptfxLibrary, string ptfxName, Vector3 position,
            Vector3 rotation, double scale);

        /// <summary>
        /// </summary>
        void CreateParticleEffectOnEntity(Client sender, string ptfxLibrary, string ptfxName, NetHandle entity,
            Vector3 offset, Vector3 rotation, double scale, int boneIndex);

        /// <summary>
        /// </summary>
        void CreateExplosion(Client sender, ExplosionType explosionType, Vector3 position, double damageScale);

        /// <summary>
        /// </summary>
        void CreateOwnedExplosion(Client sender, NetHandle owner, ExplosionType explosionType, Vector3 position,
            double damageScale);

        /// <summary>
        /// </summary>
        void DrawLight(Client sender, Vector3 position, int red, int green, int blue, double range, double intensity);

        /// <summary>
        /// </summary>
        void DrawLight(Client sender, Vector3 position, int red, int green, int blue, double range, double intensity,
            double shadow);

        /// <summary>
        /// </summary>
        void DrawMarker(Client sender, MarkerType markerType, Vector3 position, Vector3 direction, Vector3 rotation,
            Vector3 scale, int red, int green, int blue, int alpha, bool bobUpAndDown, bool faceCamera, bool rotateY);

        /// <summary>
        /// </summary>
        void DeleteEntity(Client sender, NetHandle handle);

        /// <summary>
        /// </summary>
        void SetEntityPosition(Client sender, NetHandle ent, Vector3 pos, bool ground);

        /// <summary>
        /// </summary>
        void SetEntityRotation(Client sender, NetHandle ent, Vector3 rot);

        /// <summary>
        /// </summary>
        void SetEntityQuaternion(Client sender, NetHandle entity, double x, double y, double z, double w);

        /// <summary>
        /// </summary>
        void SetEntityVelocity(Client sender, NetHandle entity, Vector3 velocity);

        /// <summary>
        /// </summary>
        void SetEntityTransparency(Client sender, NetHandle entity, int alpha);

        /// <summary>
        /// </summary>
        void SetEntityDimension(Client sender, NetHandle entity, int dimension);

        /// <summary>
        /// </summary>
        void SetEntityInvincible(Client sender, NetHandle entity, bool invincible);

        /// <summary>
        /// </summary>
        void SetEntityCollisionless(Client sender, NetHandle entity, bool status);

        /// <summary>
        /// </summary>
        void SetEntityPositionFrozen(Client sender, NetHandle entity, bool frozen);

        /// <summary>
        /// </summary>
        void AttachEntity(Client sender, NetHandle ent1, NetHandle ent2, string bone, Vector3 positionOffset,
            Vector3 rotationOffset);

        /// <summary>
        /// </summary>
        void AttachEntityToEntity(Client sender, NetHandle ent1, NetHandle ent2, string bone, Vector3 positionOffset,
            Vector3 rotationOffset);

        /// <summary>
        /// </summary>
        void DetachEntity(Client sender, NetHandle ent);

        /// <summary>
        /// </summary>
        void ResetEntitySyncedData(Client sender, NetHandle entity, string key);

        /// <summary>
        /// </summary>
        void ResetWorldSyncedData(Client sender, string key);

        /// <summary>
        /// </summary>
        void SetBlipPosition(Client sender, NetHandle blip, Vector3 pos);

        /// <summary>
        /// </summary>
        void SetBlipColor(Client sender, NetHandle blip, int color);

        /// <summary>
        /// </summary>
        void SetBlipSprite(Client sender, NetHandle blip, int sprite);

        /// <summary>
        /// </summary>
        void SetBlipName(Client sender, NetHandle blip, string name);

        /// <summary>
        /// </summary>
        void SetBlipTransparency(Client sender, NetHandle blip, int alpha);

        /// <summary>
        /// </summary>
        void SetBlipShortRange(Client sender, NetHandle blip, bool shortRange);

        /// <summary>
        /// </summary>
        void ShowBlipRoute(Client sender, NetHandle blip, bool show);

        /// <summary>
        /// </summary>
        void SetBlipScale(Client sender, NetHandle blip, double scale);

        /// <summary>
        /// </summary>
        void SetBlipRouteVisible(Client sender, NetHandle blip, bool visible);

        /// <summary>
        /// </summary>
        void SetBlipRouteColor(Client sender, NetHandle blip, int color);

        /// <summary>
        /// </summary>
        void SetBlipFlashing(Client sender, NetHandle blip, bool flashing);

        /// <summary>
        /// </summary>
        void SetBlipScaleToMapZoom(Client sender, NetHandle blip, bool scaleToMapZoom);

        /// <summary>
        /// </summary>
        void HideBlipOnMap(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        void ShowBlipOnMap(Client sender, NetHandle blip);

        /// <summary>
        /// </summary>
        void SetMarkerType(Client sender, NetHandle marker, int type);

        /// <summary>
        /// </summary>
        void SetMarkerColor(Client sender, NetHandle marker, int alpha, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetMarkerScale(Client sender, NetHandle marker, Vector3 scale);

        /// <summary>
        /// </summary>
        void SetMarkerDirection(Client sender, NetHandle marker, Vector3 dir);

        /// <summary>
        /// </summary>
        void SetMarkerBobUpAndDown(Client sender, NetHandle marker, bool bobUpAndDown);

        /// <summary>
        /// </summary>
        void SetMaxHealth(Client sender, int maxHealth);

        /// <summary>
        /// </summary>
        void SetPedCanRagdoll(Client sender, bool canRagdoll);

        /// <summary>
        /// </summary>
        void PlayAmbientSpeech(Client sender, NetHandle ped, string speechName, int speechModifier);

        /// <summary>
        /// </summary>
        void PlayAmbientSpeech(Client sender, NetHandle ped, string voiceName, string speechName, int speechModifier);

        /// <summary>
        /// </summary>
        void SetPedToRagdoll(Client sender, int duration, int ragdollType);

        /// <summary>
        /// </summary>
        void CancelPedRagdoll(Client sender);

        /// <summary>
        /// </summary>
        void UnregisterPedHeadShot(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetTextLabelText(Client sender, NetHandle label, string text);

        /// <summary>
        /// </summary>
        void SetTextLabelColor(Client sender, NetHandle textLabel, int alpha, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetTextLabelSeethrough(Client sender, NetHandle handle, bool seethrough);

        /// <summary>
        /// </summary>
        void SetVehicleLivery(Client sender, NetHandle vehicle, int livery);

        /// <summary>
        /// </summary>
        void SetVehicleDeluxoTransformation(Client sender, NetHandle vehicle, double value);

        /// <summary>
        /// </summary>
        void SetVehicleSubmarineTransformed(Client sender, NetHandle vehicle, bool transformed);

        /// <summary>
        /// </summary>
        void SetVehicleOppressorTransformation(Client sender, NetHandle vehicle, double value);

        /// <summary>
        /// </summary>
        void SetVehicleLocked(Client sender, NetHandle vehicle, bool locked);

        /// <summary>
        /// </summary>
        void SetVehicleRadioEnabled(Client sender, NetHandle vehicle, bool toggle);

        /// <summary>
        /// </summary>
        void SetVehicleRadioStation(Client sender, NetHandle vehicle, int radioStation);

        /// <summary>
        /// </summary>
        void FreezeVehicleRadioStation(Client sender, int radioStation);

        /// <summary>
        /// </summary>
        void UnfreezeVehicleRadioStation(Client sender, int radioStation);

        /// <summary>
        /// </summary>
        void SetVehicleRadioAutoUnfreeze(Client sender, bool toggle);

        /// <summary>
        /// </summary>
        void SetVehicleRadioLoud(Client sender, NetHandle vehicle, bool toggle);

        /// <summary>
        /// </summary>
        void SetVehicleDisablePetrolTankDamage(Client sender, NetHandle vehicle, bool toggle);

        /// <summary>
        /// </summary>
        void SetVehicleDisablePetrolTankFires(Client sender, NetHandle vehicle, bool toggle);

        /// <summary>
        /// </summary>
        void PopVehicleTyre(Client sender, NetHandle vehicle, int tyre, bool pop);

        /// <summary>
        /// </summary>
        void SetVehicleDoorState(Client sender, NetHandle vehicle, int door, bool open);

        /// <summary>
        /// </summary>
        void BreakVehicleDoor(Client sender, NetHandle vehicle, int door, bool breakDoor);

        /// <summary>
        /// </summary>
        void BreakVehicleWindow(Client sender, NetHandle vehicle, int window, bool breakWindow);

        /// <summary>
        /// </summary>
        void BreakVehicleHeadlight(Client sender, NetHandle vehicle, int headlight, bool breakHeadlight);

        /// <summary>
        /// </summary>
        void SetVehicleExtra(Client sender, NetHandle vehicle, int slot, bool enabled);

        /// <summary>
        /// </summary>
        void SetVehicleNumberPlate(Client sender, NetHandle vehicle, string plate);

        /// <summary>
        /// </summary>
        void SetVehicleEngineStatus(Client sender, NetHandle vehicle, bool turnedOn);

        /// <summary>
        /// </summary>
        void SetVehicleSpecialLightStatus(Client sender, NetHandle vehicle, bool status);

        /// <summary>
        /// </summary>
        void SetVehicleMod(Client sender, NetHandle vehicle, VehicleModType modType, int mod);

        /// <summary>
        /// </summary>
        void SetVehicleOilLevel(Client sender, NetHandle vehicle, double oilLevel);

        /// <summary>
        /// </summary>
        void SetVehicleFuelLevel(Client sender, NetHandle vehicle, double fuelLevel);

        /// <summary>
        /// </summary>
        void SetVehicleDirtLevel(Client sender, NetHandle vehicle, double dirtLevel);

        /// <summary>
        /// </summary>
        void RemoveVehicleMod(Client sender, NetHandle vehicle, VehicleModType modType);

        /// <summary>
        /// </summary>
        void SetVehicleLightsMode(Client sender, NetHandle vehicle, int mode);

        /// <summary>
        /// </summary>
        void SetVehicleBulletproofTyres(Client sender, NetHandle vehicle, bool bulletproof);

        /// <summary>
        /// </summary>
        void SetVehicleNumberPlateStyle(Client sender, NetHandle vehicle, int style);

        /// <summary>
        /// </summary>
        void SetVehiclePearlescentColor(Client sender, NetHandle vehicle, int color);

        /// <summary>
        /// </summary>
        void SetVehicleWheelColor(Client sender, NetHandle vehicle, int color);

        /// <summary>
        /// </summary>
        void SetVehicleWheelType(Client sender, NetHandle vehicle, int type);

        /// <summary>
        /// </summary>
        void SetVehicleModColor1(Client sender, NetHandle vehicle, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetVehicleModColor2(Client sender, NetHandle vehicle, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetVehicleTyreSmokeColor(Client sender, NetHandle vehicle, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetVehicleWindowTint(Client sender, NetHandle vehicle, int type);

        /// <summary>
        /// </summary>
        void ToggleVehicleGrip(Client sender, NetHandle vehicle, bool enabled);

        /// <summary>
        /// </summary>
        void SetVehicleEnginePowerMultiplier(Client sender, NetHandle vehicle, double mult);

        /// <summary>
        /// </summary>
        void SetVehicleEngineTorqueMultiplier(Client sender, NetHandle vehicle, double mult);

        /// <summary>
        /// </summary>
        void SetVehicleNeonState(Client sender, NetHandle vehicle, int slot, bool turnedOn);

        /// <summary>
        /// </summary>
        void SetVehicleNeonColor(Client sender, NetHandle vehicle, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetVehicleDashboardColor(Client sender, NetHandle vehicle, int type);

        /// <summary>
        /// </summary>
        void SetVehicleTrimColor(Client sender, NetHandle vehicle, int type);

        /// <summary>
        /// </summary>
        void SetVehiclePrimaryColor(Client sender, NetHandle vehicle, int color);

        /// <summary>
        /// </summary>
        void SetVehicleSecondaryColor(Client sender, NetHandle vehicle, int color);

        /// <summary>
        /// </summary>
        void SetVehicleCustomPrimaryColor(Client sender, NetHandle vehicle, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SetVehicleCustomSecondaryColor(Client sender, NetHandle vehicle, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void ExplodeVehicle(Client sender, NetHandle vehicle);

        /// <summary>
        /// </summary>
        void SetCanOpenChat(Client sender, bool show);

        /// <summary>
        /// </summary>
        void SetChatVisible(Client sender, bool display);

        /// <summary>
        /// </summary>
        void ToggleAlternativeVersionLabelPosition(Client sender, bool toggle);

        /// <summary>
        /// </summary>
        void SetShowWastedScreenOnDeath(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void DisableVehicleEnteringKeys(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void SetUiColor(Client sender, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void SendChatMessage(Client sender, string senderName, string text);

        /// <summary>
        /// </summary>
        void SendChatMessage(Client sender, string text);

        /// <summary>
        /// </summary>
        void SendNotification(Client sender, string text, bool flashing);

        /// <summary>
        /// </summary>
        void SendColoredNotification(Client sender, string text, int textColor, int bgColor);

        /// <summary>
        /// </summary>
        void SendColoredPictureNotification(Client sender, string body, string pic, int flash, int iconType,
            string senderName, string subject, int textColor, int bgColor, int flashRed, int flashGreen, int flashBlue,
            int flashAlpha);

        /// <summary>
        /// </summary>
        void SendPictureNotification(Client sender, string body, string pic, int flash, int iconType, string senderName,
            string subject);

        /// <summary>
        /// </summary>
        void DisplaySubtitle(Client sender, string text);

        /// <summary>
        /// </summary>
        void DisplaySubtitle(Client sender, string text, int duration);

        /// <summary>
        /// </summary>
        void DisplayHelpTextThisFrame(Client sender, string text);

        /// <summary>
        /// </summary>
        void DisplayHelpText(Client sender, string text, double time, int color, int alpha);

        /// <summary>
        /// </summary>
        void ShowShard(Client sender, string text, int timeout);

        /// <summary>
        /// </summary>
        void ShowColorShard(Client sender, string text, string description, int color1, int color2, double time);

        /// <summary>
        /// </summary>
        void ShowWeaponPurchasedShard(Client sender, string text, string weaponName, WeaponHash weapon, double time);

        /// <summary>
        /// </summary>
        void SetWaypoint(Client sender, double x, double y);

        /// <summary>
        /// </summary>
        void RemoveWaypoint(Client sender);

        /// <summary>
        /// </summary>
        void SetHudVisible(Client sender, bool visible);

        /// <summary>
        /// </summary>
        void CloseAllMenus(Client sender);

        /// <summary>
        /// </summary>
        void RegisterNamedRenderTarget(Client sender, string renderTargetName);

        /// <summary>
        /// </summary>
        void LinkNamedRenderTarget(Client sender, int model);

        /// <summary>
        /// </summary>
        void SetTextRenderId(Client sender, int renderId);

        /// <summary>
        /// </summary>
        void ReleaseNamedRenderTarget(Client sender, string renderTargetName);

        /// <summary>
        /// </summary>
        void DrawScaleformMovie(Client sender, int scaleformHandle, double x, double y, double width, double height,
            int red, int green, int blue, int alpha);

        /// <summary>
        /// </summary>
        void PlayScreenEffect(Client sender, string effectName, int duration, bool looped);

        /// <summary>
        /// </summary>
        void StopScreenEffect(Client sender, string effectName);

        /// <summary>
        /// </summary>
        void StopAllScreenEffects(Client sender);

        /// <summary>
        /// </summary>
        void LoadModel(Client sender, int model);

        /// <summary>
        /// </summary>
        void CallNative(Client sender, string hash, params object[] args);

        /// <summary>
        /// </summary>
        void Disconnect(Client sender, string reason);

        /// <summary>
        /// </summary>
        void ForceSendAimData(Client sender, bool force);

        /// <summary>
        /// </summary>
        void DisableFingerPointing(Client sender, bool disabled);

        /// <summary>
        /// </summary>
        void SetFingerPointing(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void SetFlashlightEnabled(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void DisableFlashlightToggling(Client sender, bool disabled);

        /// <summary>
        /// </summary>
        void DetonatePlayerStickies(Client sender);

        /// <summary>
        /// </summary>
        void SetPlayerNametag(Client sender, NetHandle player, string text);

        /// <summary>
        /// </summary>
        void ResetPlayerNametag(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerNametagVisible(Client sender, NetHandle player, bool show);

        /// <summary>
        /// </summary>
        void SetPlayerHealthbarVisible(Client sender, NetHandle player, bool show);

        /// <summary>
        /// </summary>
        void SetPlayerArmorbarVisible(Client sender, NetHandle player, bool show);

        /// <summary>
        /// </summary>
        void SetPlayerNametagColor(Client sender, NetHandle player, int red, int green, int blue);

        /// <summary>
        /// </summary>
        void ResetPlayerNametagColor(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerSkin(Client sender, PedHash model);

        /// <summary>
        /// </summary>
        void SetPlayerDefaultClothes(Client sender);

        /// <summary>
        /// </summary>
        void ApplyLocalPlayerRevivePatches(Client sender);

        /// <summary>
        /// </summary>
        void ReviveLocalPlayer(Client sender);

        /// <summary>
        /// </summary>
        void ResetLocalPlayerRevivePatches(Client sender);

        /// <summary>
        /// </summary>
        void SetPlayerTeam(Client sender, int team);

        /// <summary>
        /// </summary>
        void PlayPlayerScenario(Client sender, string name);

        /// <summary>
        /// </summary>
        void PlayPlayerScenario(Client sender, string name, bool playEnterAnim);

        /// <summary>
        /// </summary>
        void PlayPlayerAnimation(Client sender, string animDict, string animName, int flag, int duration);

        /// <summary>
        /// </summary>
        void PlayAnimation(Client sender, string animDict, string animName, int flag, int duration);

        /// <summary>
        /// </summary>
        void PlayFacialAnimation(Client sender, string animDict, string animName);

        /// <summary>
        /// </summary>
        void PlayPlayerAnimation(Client sender, NetHandle player, string animDict, string animName, int flag,
            int duration);

        /// <summary>
        /// </summary>
        void PlayPlayerFacialAnimation(Client sender, NetHandle player, string animDict, string animName);

        /// <summary>
        /// </summary>
        void StopPlayerAnimation(Client sender);

        /// <summary>
        /// </summary>
        void SetPlayerComponentVariation(Client sender, NetHandle player, int componentId, int drawableId,
            int textureId);

        /// <summary>
        /// </summary>
        void SetPlayerClothes(Client sender, NetHandle player, int slot, int drawable, int texture);

        /// <summary>
        /// </summary>
        void SetPlayerAccessory(Client sender, NetHandle player, int slot, int drawable, int texture);

        /// <summary>
        /// </summary>
        void ClearPlayerAccessory(Client sender, NetHandle player, int slot);

        /// <summary>
        /// </summary>
        void ClearPlayerTasks(Client sender);

        /// <summary>
        /// </summary>
        void SetPlayerInvincible(Client sender, bool invincible);

        /// <summary>
        /// </summary>
        void SetPlayerWantedLevel(Client sender, int wantedLevel);

        /// <summary>
        /// </summary>
        void SetPlayerArmor(Client sender, int armor);

        /// <summary>
        /// </summary>
        void SetPlayerIntoVehicle(Client sender, NetHandle vehicle, int seat);

        /// <summary>
        /// </summary>
        void SetPlayerHealth(Client sender, int health);

        /// <summary>
        /// </summary>
        void RemovePlayerNametag(Client sender, int nametagId);

        /// <summary>
        /// </summary>
        void SetPlayerNametagComponentVisibility(Client sender, int nametagId, int component, bool toggle);

        /// <summary>
        /// </summary>
        void SetPlayerNametagFlagColor(Client sender, int nametagId, int flag, int color);

        /// <summary>
        /// </summary>
        void SetPlayerNametagFlagAlpha(Client sender, int nametagId, int component, int alpha);

        /// <summary>
        /// </summary>
        void SetPlayerNametagWantedLevel(Client sender, int nametagId, int wantedlvl);

        /// <summary>
        /// </summary>
        void SetPlayerNametagChattingText(Client sender, int nametagId, string chattingText);

        /// <summary>
        /// </summary>
        void SetPlayerNametagText(Client sender, int nametagId, string nametag);

        /// <summary>
        /// </summary>
        void SetPlayerNametagHealthbarColor(Client sender, int nametagId, int color);

        /// <summary>
        /// </summary>
        void ResetPlayerVisualDamage(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void ClearPlayerBloodDamage(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void ApplyPlayerBlood(Client sender, NetHandle player, int boneIndex, double xRot, double yRot, double zRot,
            string woundType);

        /// <summary>
        /// </summary>
        void SetPlayerHeadOverlay(Client sender, NetHandle player, int overlayId, int partIndex, double opacity);

        /// <summary>
        /// </summary>
        void SetPlayerEyeColor(Client sender, NetHandle player, int index);

        /// <summary>
        /// </summary>
        void SetPlayerHeadOverlayColor(Client sender, NetHandle player, int overlayId, int colorType, int colorId,
            int secondColorId);

        /// <summary>
        /// </summary>
        void SetPlayerHeadOverlayColor(Client sender, NetHandle player, int overlayId, int colorType, int colorId,
            double opacity);

        /// <summary>
        /// </summary>
        void UpdatePlayerHeadBlendData(Client sender, NetHandle player, double shapeMix, double skinMix,
            double thirdMix);

        /// <summary>
        /// </summary>
        void SetPlayerHeadBlendData(Client sender, NetHandle player, int shapeFirstId, int shapeSecondId,
            int shapeThirdId, int skinFirstId, int skinSecondId, int skinThirdId, double shapeMix, double skinMix,
            double thirdMix, bool isParent);

        /// <summary>
        /// </summary>
        void SetPlayerFaceFeature(Client sender, NetHandle player, int index, double scale);

        /// <summary>
        /// </summary>
        void ClearPlayerFacialDecorations(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void ClearPlayerDecorations(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerHairColor(Client sender, NetHandle player, int hairColorId, int hairHighlightId);

        /// <summary>
        /// </summary>
        void SetPlayerEyebrows(Client sender, NetHandle player, int id, int colorId, int secondColorId, double opacity);

        /// <summary>
        /// </summary>
        void SetPlayerChestHair(Client sender, NetHandle player, int id, int colorId, int secondColorId,
            double opacity);

        /// <summary>
        /// </summary>
        void SetPlayerFacePaint(Client sender, NetHandle player, int id, double opacity);

        /// <summary>
        /// </summary>
        void SetPlayerBeard(Client sender, NetHandle player, int id, int colorId, int secondColorId, double opacity);

        /// <summary>
        /// </summary>
        void SetPlayerHairStyle(Client sender, NetHandle player, int id, int colorId, int highlightId,
            string collection, string overlay);

        /// <summary>
        /// </summary>
        void SetPlayerFacialDecoration(Client sender, NetHandle player, string collection, string overlay);

        /// <summary>
        /// </summary>
        void SetPlayerFacialDecoration(Client sender, NetHandle player, int collection, int overlay);

        /// <summary>
        /// </summary>
        void SetPlayerIsDrunk(Client sender, NetHandle player, bool isDrunk);

        /// <summary>
        /// </summary>
        void SetPlayerStrafeClipSet(Client sender, NetHandle player, string clipSet);

        /// <summary>
        /// </summary>
        void ResetPlayerStrafeClipSet(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerWeaponMovementClipSet(Client sender, NetHandle player, string clipSet);

        /// <summary>
        /// </summary>
        void ResetPlayerWeaponMovementClipSet(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerDriveByClipSet(Client sender, NetHandle player, string clipSet);

        /// <summary>
        /// </summary>
        void ResetPlayerDriveByClipSet(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerMovementClipset(Client sender, NetHandle player, string animSet, double speed);

        /// <summary>
        /// </summary>
        void ResetPlayerMovementClipset(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void ApplyPlayerDamagePack(Client sender, NetHandle player, string damagePack, double damage, double mult);

        /// <summary>
        /// </summary>
        void SetPlayerFacialIdleAnimOverride(Client sender, NetHandle player, string animName);

        /// <summary>
        /// </summary>
        void ClearPlayerFacialIdleAnimOverride(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerWeaponAnimationOverride(Client sender, NetHandle player, string animStyle);

        /// <summary>
        /// </summary>
        void RequestControlOfPlayer(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void StopControlOfPlayer(Client sender, NetHandle player);

        /// <summary>
        /// </summary>
        void SetPlayerWeaponTint(Client sender, WeaponHash weapon, WeaponTint tint);

        /// <summary>
        /// </summary>
        void GivePlayerWeaponComponent(Client sender, WeaponHash weapon, int component);

        /// <summary>
        /// </summary>
        void RemovePlayerWeaponComponent(Client sender, WeaponHash weapon, int component);

        /// <summary>
        /// </summary>
        void SetPlayerSelectWeapon(Client sender, WeaponHash weapon);

        /// <summary>
        /// </summary>
        void RemoveAllPlayerWeapons(Client sender);

        /// <summary>
        /// </summary>
        void RemovePlayerWeapon(Client sender, WeaponHash weapon);

        /// <summary>
        /// </summary>
        void ShowCursor(Client sender, bool show);

        /// <summary>
        /// </summary>
        void ShowLoadingPrompt(Client sender, string loadingText, int busySpinnerType);

        /// <summary>
        /// </summary>
        void HideLoadingPrompt(Client sender);

        /// <summary>
        /// </summary>
        void ShowHudComponentThisFrame(Client sender, int componentId);

        /// <summary>
        /// </summary>
        void HideHudComponentThisFrame(Client sender, int componentId);

        /// <summary>
        /// </summary>
        void SetThermalVisionEnabled(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void SetNightVisionEnabled(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void FadeScreenOut(Client sender, double time);

        /// <summary>
        /// </summary>
        void FadeScreenIn(Client sender, double time);

        /// <summary>
        /// </summary>
        void SetRadarZoom(Client sender, int zoom);

        /// <summary>
        /// </summary>
        void ShowMissionPassedMessage(Client sender, string message, double time);

        /// <summary>
        /// </summary>
        void ShowColoredShard(Client sender, string message, string description, int textColor, int bgColor,
            double time);

        /// <summary>
        /// </summary>
        void ShowOldMessage(Client sender, string message, double time);

        /// <summary>
        /// </summary>
        void ShowRankupMessage(Client sender, string message, string subtitle, int rank, double time);

        /// <summary>
        /// </summary>
        void ShowWeaponPurchasedMessage(Client sender, string bigMessage, string weaponName, WeaponHash weapon,
            double time);

        /// <summary>
        /// </summary>
        void ShowMpMessageLarge(Client sender, string message, string subtitle, double time);

        /// <summary>
        /// </summary>
        void ShowCustomShard(Client sender, string funcName, params object[] parameters);

        /// <summary>
        /// </summary>
        void ShowSimpleMessage(Client sender, string title, string message, double time);

        /// <summary>
        /// </summary>
        void ShowMidsizedMessage(Client sender, string title, string message, int bgColor, bool useDarkerShard,
            double time);

        /// <summary>
        /// </summary>
        void ShowPlaneMessage(Client sender, string title, string planeName, int planeHash, double time);

        /// <summary>
        /// </summary>
        void ShowMidsizedMessage(Client sender, string title, string message, int bgColor, bool useDarkerShard,
            bool condensed, double time);

        /// <summary>
        /// </summary>
        void SetSetting(Client sender, string name, object value);

        /// <summary>
        /// </summary>
        void RemoveSetting(Client sender, string name);

        /// <summary>
        /// </summary>
        void PlayPoliceReport(Client sender, string reportName);

        /// <summary>
        /// </summary>
        void SetWeather(Client sender, Weather weather);

        /// <summary>
        /// </summary>
        void ResetWeather(Client sender);

        /// <summary>
        /// </summary>
        void SetNextWeather(Client sender, Weather weather);

        /// <summary>
        /// </summary>
        void SetWeatherTransitionType(Client sender, int weatherTransitionType);

        /// <summary>
        /// </summary>
        void TransitionToWeather(Client sender, Weather weather, int duration);

        /// <summary>
        /// </summary>
        void SetTime(Client sender, int hours, int minutes);

        /// <summary>
        /// </summary>
        void SetTimecycleModifier(Client sender, string modifier);

        /// <summary>
        /// </summary>
        void SetTimecycleModifierStrength(Client sender, double strength);

        /// <summary>
        /// </summary>
        void ClearTimecycleModifier(Client sender);

        /// <summary>
        /// </summary>
        void ResetTime(Client sender);

        /// <summary>
        /// </summary>
        void SetSnowEnabled(Client sender, bool enabled, bool deepPedTracksEnabled, bool deepVehicleTracksEnabled);

        /// <summary>
        /// </summary>
        void CreateProjectile(Client sender, WeaponHash weapon, Vector3 start, Vector3 target, double damage,
            double speed, int dimension);

        /// <summary>
        /// </summary>
        void CreateOwnedProjectile(Client sender, NetHandle owner, WeaponHash weapon, Vector3 start, Vector3 target,
            double damage, double speed, int dimension);

        /// <summary>
        /// </summary>
        void LoadInterior(Client sender, Vector3 pos);

        /// <summary>
        /// </summary>
        void SetInteriorPropColor(Client sender, int interiorId, string prop, int colorId);

        /// <summary>
        /// </summary>
        void EnableInteriorProp(Client sender, int interiorId, string propName);

        /// <summary>
        /// </summary>
        void DisableInteriorProp(Client sender, int interiorId, string propName);

        /// <summary>
        /// </summary>
        void RequestIpl(Client sender, string iplName);

        /// <summary>
        /// </summary>
        void RemoveIpl(Client sender, string iplName);

        /// <summary>
        /// </summary>
        void SetCityBlackout(Client sender, bool blackout);

        /// <summary>
        /// </summary>
        void ExpandWorldLimits(Client sender, double x, double y, double z);

        /// <summary>
        /// </summary>
        void SetGravityLevel(Client sender, double gravityLevel);

        /// <summary>
        /// </summary>
        void SetCloudHatTransition(Client sender, string type, double transitionTime);

        /// <summary>
        /// </summary>
        void ClearCloudHat(Client sender);

        /// <summary>
        /// </summary>
        void SetCloudHatOpacity(Client sender, double opacity);

        /// <summary>
        /// </summary>
        void StopAllAlarms(Client sender);

        /// <summary>
        /// </summary>
        void StartAlarm(Client sender, string alarmName);

        /// <summary>
        /// </summary>
        void StopAlarm(Client sender, string alarmName);

        /// <summary>
        /// </summary>
        void SetGpsActive(Client sender, bool active);

        /// <summary>
        /// </summary>
        void ToggleAiPedsSpawning(Client sender, bool active);

        /// <summary>
        /// </summary>
        void ToggleVehicleFirstPersonCam(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void ToggleFirstPersonCam(Client sender, bool enabled);

        /// <summary>
        /// </summary>
        void DeleteObject(Client sender, Vector3 position, int modelHash, double radius = 1.0);

        /// <summary>
        /// </summary>
        void Sleep(Client sender, int ms);

        /// <summary>
        /// </summary>
        void LoadAnimationDict(Client sender, string dict);

        /// <summary>
        /// </summary>
        void Dispose(Client sender);
    }
}

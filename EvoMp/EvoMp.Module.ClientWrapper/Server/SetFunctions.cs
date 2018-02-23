using System.Drawing;
using EvoMp.Module.ClientWrapper.Server.Enums;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using GrandTheftMultiplayer.Shared.Math;
using Weather = GrandTheftMultiplayer.Shared.Gta.World.Weather;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class SetFunctions : ISetFunctions
    {
        private readonly IEventHandler _eventHandler;

        public SetFunctions(IEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="activitystring"></param>
        public void SetDiscordPresenceActivity(Client sender, string activitystring)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setDiscordPresenceActivity", activitystring);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void ResetVehicleHandlingData(Client sender, VehicleHash vehicleHash)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetVehicleHandlingData", vehicleHash);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleAntiRollBarBiasFront(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleAntiRollBarBiasFront", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleAntiRollBarForce(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleAntiRollBarForce", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleBrakeForce(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleBrakeForce", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleCamberStiffness(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCamberStiffness", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleCenterOfMassOffset(Client sender, VehicleHash vehicleHash, Vector3 value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCenterOfMassOffset", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleClutchChangeRateScaleDownShift(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleClutchChangeRateScaleDownShift",
                vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleClutchChangeRateScaleUpShift(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleClutchChangeRateScaleUpShift",
                vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleCollisionDamageMultiplier(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCollisionDamageMultiplier",
                vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDeformationDamageMultiplier(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDeformationDamageMultiplier",
                vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDriveInertia(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDriveInertia", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleEngineDamageMultiplier(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEngineDamageMultiplier", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleHandBrakeForce(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleHandBrakeForce", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleInertiaMultiplier(Client sender, VehicleHash vehicleHash, Vector3 value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleInertiaMultiplier", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleInitialDriveForce(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleInitialDriveForce", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleInitialDriveGears(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleInitialDriveGears", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleMass(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleMass", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleMonetaryValue(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleMonetaryValue", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehiclePercentSubmerged(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehiclePercentSubmerged", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleRollCenterHeightFront(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleRollCenterHeightFront", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleRollCenterHeightRear(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleRollCenterHeightRear", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSeatOffsetDistanceX(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSeatOffsetDistanceX", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSeatOffsetDistanceY(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSeatOffsetDistanceY", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSeatOffsetDistanceZ(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSeatOffsetDistanceZ", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSteeringLock(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSteeringLock", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionBiasFront(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionBiasFront", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionCompressionDamping(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionCompressionDamping",
                vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionForce(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionForce", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionLowerLimit(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionLowerLimit", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionRaise(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionRaise", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionReboundDamping(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionReboundDamping", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSuspensionUpperLimit(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSuspensionUpperLimit", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTractionBiasFront(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTractionBiasFront", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTractionCurveMax(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTractionCurveMax", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTractionCurveMin(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTractionCurveMin", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTractionLossMultiplier(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTractionLossMultiplier", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTractionSpringDeltaMax(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTractionSpringDeltaMax", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDriveBiasFront(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDriveBiasFront", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleBrakeBiasFront(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleBrakeBiasFront", vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleInitialDragCoefficiency(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleInitialDragCoefficiency", vehicleHash,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleInitialDriveMaxFlatVelocity(Client sender, VehicleHash vehicleHash, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleInitialDriveMaxFlatVelocity",
                vehicleHash, value);
        }

        /// <summary>
        /// </summary>
        public void SetAnimCurrentTime(Client sender, NetHandle handle, string animDict, string animName, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setAnimCurrentTime", handle, animDict, animName,
                time);
        }

        /// <summary>
        /// </summary>
        public void SetAnimSpeed(Client sender, NetHandle handle, string animDict, string animName, int speedMultiplier)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setAnimSpeed", handle, animDict, animName,
                speedMultiplier);
        }

        /// <summary>
        /// </summary>
        public void DisableAlternativeMainMenuKey(Client sender, bool enable)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableAlternativeMainMenuKey", enable);
        }

        /// <summary>
        /// </summary>
        public void VerifyIntegrityOfCache(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.verifyIntegrityOfCache");
        }

        /// <summary>
        /// </summary>
        public void PreloadAnimationDictionary(Client sender, string animDictionary)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.preloadAnimationDictionary", animDictionary);
        }

        /// <summary>
        /// </summary>
        public void RequestStreamedTextureDict(Client sender, string textureDict)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.requestStreamedTextureDict", textureDict);
        }

        /// <summary>
        /// </summary>
        public void DisposeStreamedTextureDict(Client sender, string textureDict)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disposeStreamedTextureDict", textureDict);
        }

        /// <summary>
        /// </summary>
        public void RequestAdditionalText(Client sender, string gxtLib, int slot)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.requestAdditionalText", gxtLib, slot);
        }

        /// <summary>
        /// </summary>
        public void ClearAdditionalText(Client sender, int slot)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearAdditionalText", slot);
        }

        /// <summary>
        /// </summary>
        public void StartMusic(Client sender, string path, bool looped)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.startMusic", path, looped);
        }

        /// <summary>
        /// </summary>
        public void StopMusic(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopMusic");
        }

        /// <summary>
        /// </summary>
        public void SetMusicVolume(Client sender, double volume)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMusicVolume", volume);
        }

        /// <summary>
        /// </summary>
        public void SetMusicTime(Client sender, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMusicTime", time);
        }

        /// <summary>
        /// </summary>
        public void SetAudioTime(Client sender, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setAudioTime", time);
        }

        /// <summary>
        /// </summary>
        public void PreloadAudio(Client sender, string path)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.preloadAudio", path);
        }

        /// <summary>
        /// </summary>
        public void SetGameVolume(Client sender, double vol)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGameVolume", vol);
        }

        /// <summary>
        /// </summary>
        public void SetAudioVolume(Client sender, double vol)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setAudioVolume", vol);
        }

        /// <summary>
        /// </summary>
        public void PlaySoundFrontEnd(Client sender, string soundName, string soundSetName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playSoundFrontEnd", soundName, soundSetName);
        }

        /// <summary>
        /// </summary>
        public void StartAudioScene(Client sender, string scene)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.startAudioScene", scene);
        }

        /// <summary>
        /// </summary>
        public void StopAudioScene(Client sender, string scene)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopAudioScene", scene);
        }

        /// <summary>
        /// </summary>
        public void StopAllAudioScenes(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopAllAudioScenes");
        }

        /// <summary>
        /// </summary>
        public void PrepareMusicEvent(Client sender, string eventName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.prepareMusicEvent", eventName);
        }

        /// <summary>
        /// </summary>
        public void TriggerMusicEvent(Client sender, string eventName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.triggerMusicEvent", eventName);
        }

        /// <summary>
        /// </summary>
        public void CancelMusicEvent(Client sender, string eventName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.cancelMusicEvent", eventName);
        }

        /// <summary>
        /// </summary>
        public void SetStaticEmitterEnabled(Client sender, string emitterName, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setStaticEmitterEnabled", emitterName, enabled);
        }

        /// <summary>
        /// </summary>
        public void ReleaseNamedScriptAudioBank(Client sender, string audioBank)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.releaseNamedScriptAudioBank", audioBank);
        }

        /// <summary>
        /// </summary>
        public void PlaySoundFromCoord(Client sender, string soundName, Vector3 position)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playSoundFromCoord", soundName, position);
        }

        /// <summary>
        /// </summary>
        public void PlaySoundFromCoord(Client sender, string soundName, string soundSetName, Vector3 position)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playSoundFromCoord", soundName, soundSetName,
                position);
        }

        /// <summary>
        /// </summary>
        public void PlaySoundFromEntity(Client sender, NetHandle entity, string soundName, string soundSetName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playSoundFromEntity", entity, soundName,
                soundSetName);
        }

        /// <summary>
        /// </summary>
        public void SetGameplayCameraActive(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGameplayCameraActive");
        }

        /// <summary>
        /// </summary>
        public void SetGameplayCameraShake(Client sender, string shakeType, double amplitute)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGameplayCameraShake", shakeType, amplitute);
        }

        /// <summary>
        /// </summary>
        public void StopGameplayCameraShake(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopGameplayCameraShake");
        }

        /// <summary>
        /// </summary>
        public void SetCameraBehindPlayer(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCameraBehindPlayer");
        }

        /// <summary>
        /// </summary>
        public void SetCefDrawState(Client sender, bool state)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCefDrawState", state);
        }

        /// <summary>
        /// </summary>
        public void DisableControlThisFrame(Client sender, int control)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableControlThisFrame", control);
        }

        /// <summary>
        /// </summary>
        public void EnableControlThisFrame(Client sender, int control)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.enableControlThisFrame", control);
        }

        /// <summary>
        /// </summary>
        public void DisableAllControlsThisFrame(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableAllControlsThisFrame");
        }

        /// <summary>
        /// </summary>
        public void DisableAllControls(Client sender, bool disabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableAllControls", disabled);
        }

        /// <summary>
        /// </summary>
        public void SetControlNormal(Client sender, int control, int value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setControlNormal", control, value);
        }

        /// <summary>
        /// </summary>
        public void DrawLine(Client sender, Vector3 start, Vector3 end, int a, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawLine", start, end, a, red, green, blue);
        }

        /// <summary>
        /// </summary>
        public void DrawGameTexture(Client sender, string dict, string txtName, double x, double y, double width,
            double height, double heading, int red, int green, int blue, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawGameTexture", dict, txtName, x, y, width,
                height, heading, red, green, blue, alpha);
        }

        /// <summary>
        /// </summary>
        public void DrawRectangle(Client sender, double xPos, double yPos, double wSize, double hSize, int red,
            int green, int blue, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawRectangle", xPos, yPos, wSize, hSize, red,
                green, blue, alpha);
        }

        /// <summary>
        /// </summary>
        public void DrawText(Client sender, string caption, double xPos, double yPos, double scale, int red, int green,
            int blue, int alpha, int font, int justify, bool shadow, bool outline, int wordWrap)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawText", caption, xPos, yPos, scale, red,
                green, blue, alpha, font, justify, shadow, outline, wordWrap);
        }

        /// <summary>
        /// </summary>
        public void DxDrawTexture(Client sender, string path, Point pos, Size size, double rotation)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.dxDrawTexture", path, pos, size, rotation);
        }

        /// <summary>
        /// </summary>
        public void CreateParticleEffectOnPosition(Client sender, string ptfxLibrary, string ptfxName, Vector3 position,
            Vector3 rotation, double scale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.createParticleEffectOnPosition", ptfxLibrary,
                ptfxName, position, rotation, scale);
        }

        /// <summary>
        /// </summary>
        public void CreateParticleEffectOnEntity(Client sender, string ptfxLibrary, string ptfxName, NetHandle entity,
            Vector3 offset, Vector3 rotation, double scale, int boneIndex)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.createParticleEffectOnEntity", ptfxLibrary,
                ptfxName, entity, offset, rotation, scale, boneIndex);
        }

        /// <summary>
        /// </summary>
        public void CreateExplosion(Client sender, ExplosionType explosionType, Vector3 position, double damageScale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.createExplosion", explosionType, position,
                damageScale);
        }

        /// <summary>
        /// </summary>
        public void CreateOwnedExplosion(Client sender, NetHandle owner, ExplosionType explosionType, Vector3 position,
            double damageScale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.createOwnedExplosion", owner, explosionType,
                position, damageScale);
        }

        /// <summary>
        /// </summary>
        public void DrawLight(Client sender, Vector3 position, int red, int green, int blue, double range,
            double intensity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawLight", position, red, green, blue, range,
                intensity);
        }

        /// <summary>
        /// </summary>
        public void DrawLight(Client sender, Vector3 position, int red, int green, int blue, double range,
            double intensity, double shadow)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawLight", position, red, green, blue, range,
                intensity, shadow);
        }

        /// <summary>
        /// </summary>
        public void DrawMarker(Client sender, MarkerType markerType, Vector3 position, Vector3 direction,
            Vector3 rotation, Vector3 scale, int red, int green, int blue, int alpha, bool bobUpAndDown,
            bool faceCamera, bool rotateY)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawMarker", markerType, position, direction,
                rotation, scale, red, green, blue, alpha, bobUpAndDown, faceCamera, rotateY);
        }

        /// <summary>
        /// </summary>
        public void DeleteEntity(Client sender, NetHandle handle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.deleteEntity", handle);
        }

        /// <summary>
        /// </summary>
        public void SetEntityPosition(Client sender, NetHandle ent, Vector3 pos, bool ground)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityPosition", ent, pos, ground);
        }

        /// <summary>
        /// </summary>
        public void SetEntityRotation(Client sender, NetHandle ent, Vector3 rot)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityRotation", ent, rot);
        }

        /// <summary>
        /// </summary>
        public void SetEntityQuaternion(Client sender, NetHandle entity, double x, double y, double z, double w)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityQuaternion", entity, x, y, z, w);
        }

        /// <summary>
        /// </summary>
        public void SetEntityVelocity(Client sender, NetHandle entity, Vector3 velocity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityVelocity", entity, velocity);
        }

        /// <summary>
        /// </summary>
        public void SetEntityTransparency(Client sender, NetHandle entity, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityTransparency", entity, alpha);
        }

        /// <summary>
        /// </summary>
        public void SetEntityDimension(Client sender, NetHandle entity, int dimension)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityDimension", entity, dimension);
        }

        /// <summary>
        /// </summary>
        public void SetEntityInvincible(Client sender, NetHandle entity, bool invincible)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityInvincible", entity, invincible);
        }

        /// <summary>
        /// </summary>
        public void SetEntityCollisionless(Client sender, NetHandle entity, bool status)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityCollisionless", entity, status);
        }

        /// <summary>
        /// </summary>
        public void SetEntityPositionFrozen(Client sender, NetHandle entity, bool frozen)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityPositionFrozen", entity, frozen);
        }

        /// <summary>
        /// </summary>
        public void AttachEntity(Client sender, NetHandle ent1, NetHandle ent2, string bone, Vector3 positionOffset,
            Vector3 rotationOffset)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.attachEntity", ent1, ent2, bone, positionOffset,
                rotationOffset);
        }

        /// <summary>
        /// </summary>
        public void AttachEntityToEntity(Client sender, NetHandle ent1, NetHandle ent2, string bone,
            Vector3 positionOffset, Vector3 rotationOffset)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.attachEntityToEntity", ent1, ent2, bone,
                positionOffset, rotationOffset);
        }

        /// <summary>
        /// </summary>
        public void DetachEntity(Client sender, NetHandle ent)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.detachEntity", ent);
        }

        /// <summary>
        /// </summary>
        public void ResetEntitySyncedData(Client sender, NetHandle entity, string key)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetEntitySyncedData", entity, key);
        }

        /// <summary>
        /// </summary>
        public void ResetWorldSyncedData(Client sender, string key)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetWorldSyncedData", key);
        }

        /// <summary>
        /// </summary>
        public void SetBlipPosition(Client sender, NetHandle blip, Vector3 pos)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipPosition", blip, pos);
        }

        /// <summary>
        /// </summary>
        public void SetBlipColor(Client sender, NetHandle blip, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipColor", blip, color);
        }

        /// <summary>
        /// </summary>
        public void SetBlipSprite(Client sender, NetHandle blip, int sprite)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipSprite", blip, sprite);
        }

        /// <summary>
        /// </summary>
        public void SetBlipName(Client sender, NetHandle blip, string name)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipName", blip, name);
        }

        /// <summary>
        /// </summary>
        public void SetBlipTransparency(Client sender, NetHandle blip, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipTransparency", blip, alpha);
        }

        /// <summary>
        /// </summary>
        public void SetBlipShortRange(Client sender, NetHandle blip, bool shortRange)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipShortRange", blip, shortRange);
        }

        /// <summary>
        /// </summary>
        public void ShowBlipRoute(Client sender, NetHandle blip, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showBlipRoute", blip, show);
        }

        /// <summary>
        /// </summary>
        public void SetBlipScale(Client sender, NetHandle blip, double scale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipScale", blip, scale);
        }

        /// <summary>
        /// </summary>
        public void SetBlipRouteVisible(Client sender, NetHandle blip, bool visible)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipRouteVisible", blip, visible);
        }

        /// <summary>
        /// </summary>
        public void SetBlipRouteColor(Client sender, NetHandle blip, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipRouteColor", blip, color);
        }

        /// <summary>
        /// </summary>
        public void SetBlipFlashing(Client sender, NetHandle blip, bool flashing)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipFlashing", blip, flashing);
        }

        /// <summary>
        /// </summary>
        public void SetBlipScaleToMapZoom(Client sender, NetHandle blip, bool scaleToMapZoom)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipScaleToMapZoom", blip, scaleToMapZoom);
        }

        /// <summary>
        /// </summary>
        public void HideBlipOnMap(Client sender, NetHandle blip)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.hideBlipOnMap", blip);
        }

        /// <summary>
        /// </summary>
        public void ShowBlipOnMap(Client sender, NetHandle blip)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showBlipOnMap", blip);
        }

        /// <summary>
        /// </summary>
        public void SetMarkerType(Client sender, NetHandle marker, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerType", marker, type);
        }

        /// <summary>
        /// </summary>
        public void SetMarkerColor(Client sender, NetHandle marker, int alpha, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerColor", marker, alpha, red, green,
                blue);
        }

        /// <summary>
        /// </summary>
        public void SetMarkerScale(Client sender, NetHandle marker, Vector3 scale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerScale", marker, scale);
        }

        /// <summary>
        /// </summary>
        public void SetMarkerDirection(Client sender, NetHandle marker, Vector3 dir)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerDirection", marker, dir);
        }

        /// <summary>
        /// </summary>
        public void SetMarkerBobUpAndDown(Client sender, NetHandle marker, bool bobUpAndDown)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerBobUpAndDown", marker, bobUpAndDown);
        }

        /// <summary>
        /// </summary>
        public void SetMaxHealth(Client sender, int maxHealth)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMaxHealth", maxHealth);
        }

        /// <summary>
        /// </summary>
        public void SetPedCanRagdoll(Client sender, bool canRagdoll)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPedCanRagdoll", canRagdoll);
        }

        /// <summary>
        /// </summary>
        public void PlayAmbientSpeech(Client sender, NetHandle ped, string speechName, int speechModifier)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playAmbientSpeech", ped, speechName,
                speechModifier);
        }

        /// <summary>
        /// </summary>
        public void PlayAmbientSpeech(Client sender, NetHandle ped, string voiceName, string speechName,
            int speechModifier)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playAmbientSpeech", ped, voiceName, speechName,
                speechModifier);
        }

        /// <summary>
        /// </summary>
        public void SetPedToRagdoll(Client sender, int duration, int ragdollType)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPedToRagdoll", duration, ragdollType);
        }

        /// <summary>
        /// </summary>
        public void CancelPedRagdoll(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.cancelPedRagdoll");
        }

        /// <summary>
        /// </summary>
        public void UnregisterPedHeadShot(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.unregisterPedHeadShot", player);
        }

        /// <summary>
        /// </summary>
        public void SetTextLabelText(Client sender, NetHandle label, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextLabelText", label, text);
        }

        /// <summary>
        /// </summary>
        public void SetTextLabelColor(Client sender, NetHandle textLabel, int alpha, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextLabelColor", textLabel, alpha, red, green,
                blue);
        }

        /// <summary>
        /// </summary>
        public void SetTextLabelSeethrough(Client sender, NetHandle handle, bool seethrough)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextLabelSeethrough", handle, seethrough);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleLivery(Client sender, NetHandle vehicle, int livery)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleLivery", vehicle, livery);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDeluxoTransformation(Client sender, NetHandle vehicle, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDeluxoTransformation", vehicle, value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSubmarineTransformed(Client sender, NetHandle vehicle, bool transformed)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSubmarineTransformed", vehicle,
                transformed);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleOppressorTransformation(Client sender, NetHandle vehicle, double value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleOppressorTransformation", vehicle,
                value);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleLocked(Client sender, NetHandle vehicle, bool locked)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleLocked", vehicle, locked);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleRadioEnabled(Client sender, NetHandle vehicle, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleRadioEnabled", vehicle, toggle);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleRadioStation(Client sender, NetHandle vehicle, int radioStation)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleRadioStation", vehicle, radioStation);
        }

        /// <summary>
        /// </summary>
        public void FreezeVehicleRadioStation(Client sender, int radioStation)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.freezeVehicleRadioStation", radioStation);
        }

        /// <summary>
        /// </summary>
        public void UnfreezeVehicleRadioStation(Client sender, int radioStation)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.unfreezeVehicleRadioStation", radioStation);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleRadioAutoUnfreeze(Client sender, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleRadioAutoUnfreeze", toggle);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleRadioLoud(Client sender, NetHandle vehicle, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleRadioLoud", vehicle, toggle);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDisablePetrolTankDamage(Client sender, NetHandle vehicle, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDisablePetrolTankDamage", vehicle,
                toggle);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDisablePetrolTankFires(Client sender, NetHandle vehicle, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDisablePetrolTankFires", vehicle,
                toggle);
        }

        /// <summary>
        /// </summary>
        public void PopVehicleTyre(Client sender, NetHandle vehicle, int tyre, bool pop)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.popVehicleTyre", vehicle, tyre, pop);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDoorState(Client sender, NetHandle vehicle, int door, bool open)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDoorState", vehicle, door, open);
        }

        /// <summary>
        /// </summary>
        public void BreakVehicleDoor(Client sender, NetHandle vehicle, int door, bool breakDoor)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.breakVehicleDoor", vehicle, door, breakDoor);
        }

        /// <summary>
        /// </summary>
        public void BreakVehicleWindow(Client sender, NetHandle vehicle, int window, bool breakWindow)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.breakVehicleWindow", vehicle, window,
                breakWindow);
        }

        /// <summary>
        /// </summary>
        public void BreakVehicleHeadlight(Client sender, NetHandle vehicle, int headlight, bool breakHeadlight)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.breakVehicleHeadlight", vehicle, headlight,
                breakHeadlight);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleExtra(Client sender, NetHandle vehicle, int slot, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleExtra", vehicle, slot, enabled);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleNumberPlate(Client sender, NetHandle vehicle, string plate)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNumberPlate", vehicle, plate);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleEngineStatus(Client sender, NetHandle vehicle, bool turnedOn)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEngineStatus", vehicle, turnedOn);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSpecialLightStatus(Client sender, NetHandle vehicle, bool status)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSpecialLightStatus", vehicle, status);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleMod(Client sender, NetHandle vehicle, VehicleModType modType, int mod)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleMod", vehicle, modType, mod);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleOilLevel(Client sender, NetHandle vehicle, double oilLevel)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleOilLevel", vehicle, oilLevel);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleFuelLevel(Client sender, NetHandle vehicle, double fuelLevel)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleFuelLevel", vehicle, fuelLevel);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDirtLevel(Client sender, NetHandle vehicle, double dirtLevel)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDirtLevel", vehicle, dirtLevel);
        }

        /// <summary>
        /// </summary>
        public void RemoveVehicleMod(Client sender, NetHandle vehicle, VehicleModType modType)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removeVehicleMod", vehicle, modType);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleLightsMode(Client sender, NetHandle vehicle, int mode)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleLightsMode", vehicle, mode);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleBulletproofTyres(Client sender, NetHandle vehicle, bool bulletproof)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleBulletproofTyres", vehicle,
                bulletproof);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleNumberPlateStyle(Client sender, NetHandle vehicle, int style)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNumberPlateStyle", vehicle, style);
        }

        /// <summary>
        /// </summary>
        public void SetVehiclePearlescentColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehiclePearlescentColor", vehicle, color);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleWheelColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleWheelColor", vehicle, color);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleWheelType(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleWheelType", vehicle, type);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleModColor1(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleModColor1", vehicle, red, green, blue);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleModColor2(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleModColor2", vehicle, red, green, blue);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTyreSmokeColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTyreSmokeColor", vehicle, red, green,
                blue);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleWindowTint(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleWindowTint", vehicle, type);
        }

        /// <summary>
        /// </summary>
        public void ToggleVehicleGrip(Client sender, NetHandle vehicle, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.toggleVehicleGrip", vehicle, enabled);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleEnginePowerMultiplier(Client sender, NetHandle vehicle, double mult)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEnginePowerMultiplier", vehicle, mult);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleEngineTorqueMultiplier(Client sender, NetHandle vehicle, double mult)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEngineTorqueMultiplier", vehicle,
                mult);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleNeonState(Client sender, NetHandle vehicle, int slot, bool turnedOn)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNeonState", vehicle, slot, turnedOn);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleNeonColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNeonColor", vehicle, red, green, blue);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleDashboardColor(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDashboardColor", vehicle, type);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleTrimColor(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTrimColor", vehicle, type);
        }

        /// <summary>
        /// </summary>
        public void SetVehiclePrimaryColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehiclePrimaryColor", vehicle, color);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleSecondaryColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSecondaryColor", vehicle, color);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleCustomPrimaryColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCustomPrimaryColor", vehicle, red,
                green, blue);
        }

        /// <summary>
        /// </summary>
        public void SetVehicleCustomSecondaryColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCustomSecondaryColor", vehicle, red,
                green, blue);
        }

        /// <summary>
        /// </summary>
        public void ExplodeVehicle(Client sender, NetHandle vehicle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.explodeVehicle", vehicle);
        }

        /// <summary>
        /// </summary>
        public void SetCanOpenChat(Client sender, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCanOpenChat", show);
        }

        /// <summary>
        /// </summary>
        public void SetChatVisible(Client sender, bool display)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setChatVisible", display);
        }

        /// <summary>
        /// </summary>
        public void ToggleAlternativeVersionLabelPosition(Client sender, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.toggleAlternativeVersionLabelPosition", toggle);
        }

        /// <summary>
        /// </summary>
        public void SetShowWastedScreenOnDeath(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setShowWastedScreenOnDeath", enabled);
        }

        /// <summary>
        /// </summary>
        public void DisableVehicleEnteringKeys(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableVehicleEnteringKeys", enabled);
        }

        /// <summary>
        /// </summary>
        public void SetUiColor(Client sender, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setUiColor", red, green, blue);
        }

        /// <summary>
        /// </summary>
        public void SendChatMessage(Client sender, string senderName, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sendChatMessage", senderName, text);
        }

        /// <summary>
        /// </summary>
        public void SendChatMessage(Client sender, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sendChatMessage", text);
        }

        /// <summary>
        /// </summary>
        public void SendNotification(Client sender, string text, bool flashing)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sendNotification", text, flashing);
        }

        /// <summary>
        /// </summary>
        public void SendColoredNotification(Client sender, string text, int textColor, int bgColor)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sendColoredNotification", text, textColor,
                bgColor);
        }

        /// <summary>
        /// </summary>
        public void SendColoredPictureNotification(Client sender, string body, string pic, int flash, int iconType,
            string senderName, string subject, int textColor, int bgColor, int flashRed, int flashGreen, int flashBlue,
            int flashAlpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sendColoredPictureNotification", body, pic,
                flash, iconType, senderName, subject, textColor, bgColor, flashRed, flashGreen, flashBlue, flashAlpha);
        }

        /// <summary>
        /// </summary>
        public void SendPictureNotification(Client sender, string body, string pic, int flash, int iconType,
            string senderName, string subject)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sendPictureNotification", body, pic, flash,
                iconType, senderName, subject);
        }

        /// <summary>
        /// </summary>
        public void DisplaySubtitle(Client sender, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.displaySubtitle", text);
        }

        /// <summary>
        /// </summary>
        public void DisplaySubtitle(Client sender, string text, int duration)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.displaySubtitle", text, duration);
        }

        /// <summary>
        /// </summary>
        public void DisplayHelpTextThisFrame(Client sender, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.displayHelpTextThisFrame", text);
        }

        /// <summary>
        /// </summary>
        public void DisplayHelpText(Client sender, string text, double time, int color, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.displayHelpText", text, time, color, alpha);
        }

        /// <summary>
        /// </summary>
        public void ShowShard(Client sender, string text, int timeout)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showShard", text, timeout);
        }

        /// <summary>
        /// </summary>
        public void ShowColorShard(Client sender, string text, string description, int color1, int color2, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showColorShard", text, description, color1,
                color2, time);
        }

        /// <summary>
        /// </summary>
        public void ShowWeaponPurchasedShard(Client sender, string text, string weaponName, WeaponHash weapon,
            double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showWeaponPurchasedShard", text, weaponName,
                weapon, time);
        }

        /// <summary>
        /// </summary>
        public void SetWaypoint(Client sender, double x, double y)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setWaypoint", x, y);
        }

        /// <summary>
        /// </summary>
        public void RemoveWaypoint(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removeWaypoint");
        }

        /// <summary>
        /// </summary>
        public void SetHudVisible(Client sender, bool visible)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setHudVisible", visible);
        }

        /// <summary>
        /// </summary>
        public void CloseAllMenus(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.closeAllMenus");
        }

        /// <summary>
        /// </summary>
        public void RegisterNamedRenderTarget(Client sender, string renderTargetName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.registerNamedRenderTarget", renderTargetName);
        }

        /// <summary>
        /// </summary>
        public void LinkNamedRenderTarget(Client sender, int model)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.linkNamedRenderTarget", model);
        }

        /// <summary>
        /// </summary>
        public void SetTextRenderId(Client sender, int renderId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextRenderID", renderId);
        }

        /// <summary>
        /// </summary>
        public void ReleaseNamedRenderTarget(Client sender, string renderTargetName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.releaseNamedRenderTarget", renderTargetName);
        }

        /// <summary>
        /// </summary>
        public void DrawScaleformMovie(Client sender, int scaleformHandle, double x, double y, double width,
            double height, int red, int green, int blue, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.drawScaleformMovie", scaleformHandle, x, y,
                width, height, red, green, blue, alpha);
        }

        /// <summary>
        /// </summary>
        public void PlayScreenEffect(Client sender, string effectName, int duration, bool looped)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playScreenEffect", effectName, duration, looped);
        }

        /// <summary>
        /// </summary>
        public void StopScreenEffect(Client sender, string effectName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopScreenEffect", effectName);
        }

        /// <summary>
        /// </summary>
        public void StopAllScreenEffects(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopAllScreenEffects");
        }

        /// <summary>
        /// </summary>
        public void LoadModel(Client sender, int model)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.loadModel", model);
        }

        /// <summary>
        /// </summary>
        public void CallNative(Client sender, string hash, params object[] args)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.callNative", hash, args);
        }

        /// <summary>
        /// </summary>
        public void Disconnect(Client sender, string reason)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disconnect", reason);
        }

        /// <summary>
        /// </summary>
        public void ForceSendAimData(Client sender, bool force)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.forceSendAimData", force);
        }

        /// <summary>
        /// </summary>
        public void DisableFingerPointing(Client sender, bool disabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableFingerPointing", disabled);
        }

        /// <summary>
        /// </summary>
        public void SetFingerPointing(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setFingerPointing", enabled);
        }

        /// <summary>
        /// </summary>
        public void SetFlashlightEnabled(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setFlashlightEnabled", enabled);
        }

        /// <summary>
        /// </summary>
        public void DisableFlashlightToggling(Client sender, bool disabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableFlashlightToggling", disabled);
        }

        /// <summary>
        /// </summary>
        public void DetonatePlayerStickies(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.detonatePlayerStickies");
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametag(Client sender, NetHandle player, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametag", player, text);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerNametag(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerNametag", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagVisible(Client sender, NetHandle player, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagVisible", player, show);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHealthbarVisible(Client sender, NetHandle player, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHealthbarVisible", player, show);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerArmorbarVisible(Client sender, NetHandle player, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerArmorbarVisible", player, show);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagColor(Client sender, NetHandle player, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagColor", player, red, green,
                blue);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerNametagColor(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerNametagColor", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerSkin(Client sender, PedHash model)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerSkin", model);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerDefaultClothes(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerDefaultClothes");
        }

        /// <summary>
        /// </summary>
        public void ApplyLocalPlayerRevivePatches(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.applyLocalPlayerRevivePatches");
        }

        /// <summary>
        /// </summary>
        public void ReviveLocalPlayer(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.reviveLocalPlayer");
        }

        /// <summary>
        /// </summary>
        public void ResetLocalPlayerRevivePatches(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetLocalPlayerRevivePatches");
        }

        /// <summary>
        /// </summary>
        public void SetPlayerTeam(Client sender, int team)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerTeam", team);
        }

        /// <summary>
        /// </summary>
        public void PlayPlayerScenario(Client sender, string name)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playPlayerScenario", name);
        }

        /// <summary>
        /// </summary>
        public void PlayPlayerScenario(Client sender, string name, bool playEnterAnim)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playPlayerScenario", name, playEnterAnim);
        }

        /// <summary>
        /// </summary>
        public void PlayPlayerAnimation(Client sender, string animDict, string animName, int flag, int duration)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playPlayerAnimation", animDict, animName, flag,
                duration);
        }

        /// <summary>
        /// </summary>
        public void PlayAnimation(Client sender, string animDict, string animName, int flag, int duration)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playAnimation", animDict, animName, flag,
                duration);
        }

        /// <summary>
        /// </summary>
        public void PlayFacialAnimation(Client sender, string animDict, string animName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playFacialAnimation", animDict, animName);
        }

        /// <summary>
        /// </summary>
        public void PlayPlayerAnimation(Client sender, NetHandle player, string animDict, string animName, int flag,
            int duration)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playPlayerAnimation", player, animDict, animName,
                flag, duration);
        }

        /// <summary>
        /// </summary>
        public void PlayPlayerFacialAnimation(Client sender, NetHandle player, string animDict, string animName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playPlayerFacialAnimation", player, animDict,
                animName);
        }

        /// <summary>
        /// </summary>
        public void StopPlayerAnimation(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopPlayerAnimation");
        }

        /// <summary>
        /// </summary>
        public void SetPlayerComponentVariation(Client sender, NetHandle player, int componentId, int drawableId,
            int textureId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerComponentVariation", player,
                componentId, drawableId, textureId);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerClothes(Client sender, NetHandle player, int slot, int drawable, int texture)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerClothes", player, slot, drawable,
                texture);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerAccessory(Client sender, NetHandle player, int slot, int drawable, int texture)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerAccessory", player, slot, drawable,
                texture);
        }

        /// <summary>
        /// </summary>
        public void ClearPlayerAccessory(Client sender, NetHandle player, int slot)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearPlayerAccessory", player, slot);
        }

        /// <summary>
        /// </summary>
        public void ClearPlayerTasks(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearPlayerTasks");
        }

        /// <summary>
        /// </summary>
        public void SetPlayerInvincible(Client sender, bool invincible)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerInvincible", invincible);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerWantedLevel(Client sender, int wantedLevel)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerWantedLevel", wantedLevel);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerArmor(Client sender, int armor)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerArmor", armor);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerIntoVehicle(Client sender, NetHandle vehicle, int seat)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerIntoVehicle", vehicle, seat);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHealth(Client sender, int health)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHealth", health);
        }

        /// <summary>
        /// </summary>
        public void RemovePlayerNametag(Client sender, int nametagId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removePlayerNametag", nametagId);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagComponentVisibility(Client sender, int nametagId, int component, bool toggle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagComponentVisibility", nametagId,
                component, toggle);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagFlagColor(Client sender, int nametagId, int flag, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagFlagColor", nametagId, flag,
                color);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagFlagAlpha(Client sender, int nametagId, int component, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagFlagAlpha", nametagId, component,
                alpha);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagWantedLevel(Client sender, int nametagId, int wantedlvl)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagWantedLevel", nametagId,
                wantedlvl);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagChattingText(Client sender, int nametagId, string chattingText)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagChattingText", nametagId,
                chattingText);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagText(Client sender, int nametagId, string nametag)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagText", nametagId, nametag);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerNametagHealthbarColor(Client sender, int nametagId, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagHealthbarColor", nametagId,
                color);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerVisualDamage(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerVisualDamage", player);
        }

        /// <summary>
        /// </summary>
        public void ClearPlayerBloodDamage(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearPlayerBloodDamage", player);
        }

        /// <summary>
        /// </summary>
        public void ApplyPlayerBlood(Client sender, NetHandle player, int boneIndex, double xRot, double yRot,
            double zRot, string woundType)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.applyPlayerBlood", player, boneIndex, xRot, yRot,
                zRot, woundType);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHeadOverlay(Client sender, NetHandle player, int overlayId, int partIndex, double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHeadOverlay", player, overlayId,
                partIndex, opacity);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerEyeColor(Client sender, NetHandle player, int index)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerEyeColor", player, index);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHeadOverlayColor(Client sender, NetHandle player, int overlayId, int colorType,
            int colorId, int secondColorId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHeadOverlayColor", player, overlayId,
                colorType, colorId, secondColorId);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHeadOverlayColor(Client sender, NetHandle player, int overlayId, int colorType,
            int colorId, double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHeadOverlayColor", player, overlayId,
                colorType, colorId, opacity);
        }

        /// <summary>
        /// </summary>
        public void UpdatePlayerHeadBlendData(Client sender, NetHandle player, double shapeMix, double skinMix,
            double thirdMix)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.updatePlayerHeadBlendData", player, shapeMix,
                skinMix, thirdMix);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHeadBlendData(Client sender, NetHandle player, int shapeFirstId, int shapeSecondId,
            int shapeThirdId, int skinFirstId, int skinSecondId, int skinThirdId, double shapeMix, double skinMix,
            double thirdMix, bool isParent)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHeadBlendData", player, shapeFirstId,
                shapeSecondId, shapeThirdId, skinFirstId, skinSecondId, skinThirdId, shapeMix, skinMix, thirdMix,
                isParent);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerFaceFeature(Client sender, NetHandle player, int index, double scale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerFaceFeature", player, index, scale);
        }

        /// <summary>
        /// </summary>
        public void ClearPlayerFacialDecorations(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearPlayerFacialDecorations", player);
        }

        /// <summary>
        /// </summary>
        public void ClearPlayerDecorations(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearPlayerDecorations", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHairColor(Client sender, NetHandle player, int hairColorId, int hairHighlightId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHairColor", player, hairColorId,
                hairHighlightId);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerEyebrows(Client sender, NetHandle player, int id, int colorId, int secondColorId,
            double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerEyebrows", player, id, colorId,
                secondColorId, opacity);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerChestHair(Client sender, NetHandle player, int id, int colorId, int secondColorId,
            double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerChestHair", player, id, colorId,
                secondColorId, opacity);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerFacePaint(Client sender, NetHandle player, int id, double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerFacePaint", player, id, opacity);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerBeard(Client sender, NetHandle player, int id, int colorId, int secondColorId,
            double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerBeard", player, id, colorId,
                secondColorId, opacity);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerHairStyle(Client sender, NetHandle player, int id, int colorId, int highlightId,
            string collection, string overlay)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHairStyle", player, id, colorId,
                highlightId, collection, overlay);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerFacialDecoration(Client sender, NetHandle player, string collection, string overlay)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerFacialDecoration", player, collection,
                overlay);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerFacialDecoration(Client sender, NetHandle player, int collection, int overlay)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerFacialDecoration", player, collection,
                overlay);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerIsDrunk(Client sender, NetHandle player, bool isDrunk)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerIsDrunk", player, isDrunk);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerStrafeClipSet(Client sender, NetHandle player, string clipSet)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerStrafeClipSet", player, clipSet);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerStrafeClipSet(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerStrafeClipSet", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerWeaponMovementClipSet(Client sender, NetHandle player, string clipSet)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerWeaponMovementClipSet", player,
                clipSet);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerWeaponMovementClipSet(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerWeaponMovementClipSet", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerDriveByClipSet(Client sender, NetHandle player, string clipSet)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerDriveByClipSet", player, clipSet);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerDriveByClipSet(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerDriveByClipSet", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerMovementClipset(Client sender, NetHandle player, string animSet, double speed)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerMovementClipset", player, animSet,
                speed);
        }

        /// <summary>
        /// </summary>
        public void ResetPlayerMovementClipset(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetPlayerMovementClipset", player);
        }

        /// <summary>
        /// </summary>
        public void ApplyPlayerDamagePack(Client sender, NetHandle player, string damagePack, double damage,
            double mult)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.applyPlayerDamagePack", player, damagePack,
                damage, mult);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerFacialIdleAnimOverride(Client sender, NetHandle player, string animName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerFacialIdleAnimOverride", player,
                animName);
        }

        /// <summary>
        /// </summary>
        public void ClearPlayerFacialIdleAnimOverride(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearPlayerFacialIdleAnimOverride", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerWeaponAnimationOverride(Client sender, NetHandle player, string animStyle)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerWeaponAnimationOverride", player,
                animStyle);
        }

        /// <summary>
        /// </summary>
        public void RequestControlOfPlayer(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.requestControlOfPlayer", player);
        }

        /// <summary>
        /// </summary>
        public void StopControlOfPlayer(Client sender, NetHandle player)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopControlOfPlayer", player);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerWeaponTint(Client sender, WeaponHash weapon, WeaponTint tint)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerWeaponTint", weapon, tint);
        }

        /// <summary>
        /// </summary>
        public void GivePlayerWeaponComponent(Client sender, WeaponHash weapon, int component)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.givePlayerWeaponComponent", weapon, component);
        }

        /// <summary>
        /// </summary>
        public void RemovePlayerWeaponComponent(Client sender, WeaponHash weapon, int component)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removePlayerWeaponComponent", weapon, component);
        }

        /// <summary>
        /// </summary>
        public void SetPlayerSelectWeapon(Client sender, WeaponHash weapon)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerSelectWeapon", weapon);
        }

        /// <summary>
        /// </summary>
        public void RemoveAllPlayerWeapons(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removeAllPlayerWeapons");
        }

        /// <summary>
        /// </summary>
        public void RemovePlayerWeapon(Client sender, WeaponHash weapon)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removePlayerWeapon", weapon);
        }

        /// <summary>
        /// </summary>
        public void ShowCursor(Client sender, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showCursor", show);
        }

        /// <summary>
        /// </summary>
        public void ShowLoadingPrompt(Client sender, string loadingText, int busySpinnerType)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showLoadingPrompt", loadingText,
                busySpinnerType);
        }

        /// <summary>
        /// </summary>
        public void HideLoadingPrompt(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.hideLoadingPrompt");
        }

        /// <summary>
        /// </summary>
        public void ShowHudComponentThisFrame(Client sender, int componentId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showHudComponentThisFrame", componentId);
        }

        /// <summary>
        /// </summary>
        public void HideHudComponentThisFrame(Client sender, int componentId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.hideHudComponentThisFrame", componentId);
        }

        /// <summary>
        /// </summary>
        public void SetThermalVisionEnabled(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setThermalVisionEnabled", enabled);
        }

        /// <summary>
        /// </summary>
        public void SetNightVisionEnabled(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setNightVisionEnabled", enabled);
        }

        /// <summary>
        /// </summary>
        public void FadeScreenOut(Client sender, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.fadeScreenOut", time);
        }

        /// <summary>
        /// </summary>
        public void FadeScreenIn(Client sender, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.fadeScreenIn", time);
        }

        /// <summary>
        /// </summary>
        public void SetRadarZoom(Client sender, int zoom)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setRadarZoom", zoom);
        }

        /// <summary>
        /// </summary>
        public void ShowMissionPassedMessage(Client sender, string message, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showMissionPassedMessage", message, time);
        }

        /// <summary>
        /// </summary>
        public void ShowColoredShard(Client sender, string message, string description, int textColor, int bgColor,
            double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showColoredShard", message, description,
                textColor, bgColor, time);
        }

        /// <summary>
        /// </summary>
        public void ShowOldMessage(Client sender, string message, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showOldMessage", message, time);
        }

        /// <summary>
        /// </summary>
        public void ShowRankupMessage(Client sender, string message, string subtitle, int rank, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showRankupMessage", message, subtitle, rank,
                time);
        }

        /// <summary>
        /// </summary>
        public void ShowWeaponPurchasedMessage(Client sender, string bigMessage, string weaponName, WeaponHash weapon,
            double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showWeaponPurchasedMessage", bigMessage,
                weaponName, weapon, time);
        }

        /// <summary>
        /// </summary>
        public void ShowMpMessageLarge(Client sender, string message, string subtitle, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showMpMessageLarge", message, subtitle, time);
        }

        /// <summary>
        /// </summary>
        public void ShowCustomShard(Client sender, string funcName, params object[] parameters)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showCustomShard", funcName, parameters);
        }

        /// <summary>
        /// </summary>
        public void ShowSimpleMessage(Client sender, string title, string message, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showSimpleMessage", title, message, time);
        }

        /// <summary>
        /// </summary>
        public void ShowMidsizedMessage(Client sender, string title, string message, int bgColor, bool useDarkerShard,
            double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showMidsizedMessage", title, message, bgColor,
                useDarkerShard, time);
        }

        /// <summary>
        /// </summary>
        public void ShowPlaneMessage(Client sender, string title, string planeName, int planeHash, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showPlaneMessage", title, planeName, planeHash,
                time);
        }

        /// <summary>
        /// </summary>
        public void ShowMidsizedMessage(Client sender, string title, string message, int bgColor, bool useDarkerShard,
            bool condensed, double time)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.showMidsizedMessage", title, message, bgColor,
                useDarkerShard, condensed, time);
        }

        /// <summary>
        /// </summary>
        public void SetSetting(Client sender, string name, object value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setSetting", name, value);
        }

        /// <summary>
        /// </summary>
        public void RemoveSetting(Client sender, string name)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removeSetting", name);
        }

        /// <summary>
        /// </summary>
        public void PlayPoliceReport(Client sender, string reportName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.playPoliceReport", reportName);
        }

        /// <summary>
        /// </summary>
        public void SetWeather(Client sender, Weather weather)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setWeather", weather);
        }

        /// <summary>
        /// </summary>
        public void ResetWeather(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetWeather");
        }

        /// <summary>
        /// </summary>
        public void SetNextWeather(Client sender, Weather weather)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setNextWeather", weather);
        }

        /// <summary>
        /// </summary>
        public void SetWeatherTransitionType(Client sender, int weatherTransitionType)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setWeatherTransitionType",
                weatherTransitionType);
        }

        /// <summary>
        /// </summary>
        public void TransitionToWeather(Client sender, Weather weather, int duration)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.transitionToWeather", weather, duration);
        }

        /// <summary>
        /// </summary>
        public void SetTime(Client sender, int hours, int minutes)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTime", hours, minutes);
        }

        /// <summary>
        /// </summary>
        public void SetTimecycleModifier(Client sender, string modifier)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTimecycleModifier", modifier);
        }

        /// <summary>
        /// </summary>
        public void SetTimecycleModifierStrength(Client sender, double strength)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTimecycleModifierStrength", strength);
        }

        /// <summary>
        /// </summary>
        public void ClearTimecycleModifier(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearTimecycleModifier");
        }

        /// <summary>
        /// </summary>
        public void ResetTime(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.resetTime");
        }

        /// <summary>
        /// </summary>
        public void SetSnowEnabled(Client sender, bool enabled, bool deepPedTracksEnabled,
            bool deepVehicleTracksEnabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setSnowEnabled", enabled, deepPedTracksEnabled,
                deepVehicleTracksEnabled);
        }

        /// <summary>
        /// </summary>
        public void CreateProjectile(Client sender, WeaponHash weapon, Vector3 start, Vector3 target, double damage,
            double speed, int dimension)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.createProjectile", weapon, start, target, damage,
                speed, dimension);
        }

        /// <summary>
        /// </summary>
        public void CreateOwnedProjectile(Client sender, NetHandle owner, WeaponHash weapon, Vector3 start,
            Vector3 target, double damage, double speed, int dimension)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.createOwnedProjectile", owner, weapon, start,
                target, damage, speed, dimension);
        }

        /// <summary>
        /// </summary>
        public void LoadInterior(Client sender, Vector3 pos)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.loadInterior", pos);
        }

        /// <summary>
        /// </summary>
        public void SetInteriorPropColor(Client sender, int interiorId, string prop, int colorId)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setInteriorPropColor", interiorId, prop,
                colorId);
        }

        /// <summary>
        /// </summary>
        public void EnableInteriorProp(Client sender, int interiorId, string propName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.enableInteriorProp", interiorId, propName);
        }

        /// <summary>
        /// </summary>
        public void DisableInteriorProp(Client sender, int interiorId, string propName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.disableInteriorProp", interiorId, propName);
        }

        /// <summary>
        /// </summary>
        public void RequestIpl(Client sender, string iplName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.requestIpl", iplName);
        }

        /// <summary>
        /// </summary>
        public void RemoveIpl(Client sender, string iplName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.removeIpl", iplName);
        }

        /// <summary>
        /// </summary>
        public void SetCityBlackout(Client sender, bool blackout)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCityBlackout", blackout);
        }

        /// <summary>
        /// </summary>
        public void ExpandWorldLimits(Client sender, double x, double y, double z)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.expandWorldLimits", x, y, z);
        }

        /// <summary>
        /// </summary>
        public void SetGravityLevel(Client sender, double gravityLevel)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGravityLevel", gravityLevel);
        }

        /// <summary>
        /// </summary>
        public void SetCloudHatTransition(Client sender, string type, double transitionTime)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCloudHatTransition", type, transitionTime);
        }

        /// <summary>
        /// </summary>
        public void ClearCloudHat(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.clearCloudHat");
        }

        /// <summary>
        /// </summary>
        public void SetCloudHatOpacity(Client sender, double opacity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCloudHatOpacity", opacity);
        }

        /// <summary>
        /// </summary>
        public void StopAllAlarms(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopAllAlarms");
        }

        /// <summary>
        /// </summary>
        public void StartAlarm(Client sender, string alarmName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.startAlarm", alarmName);
        }

        /// <summary>
        /// </summary>
        public void StopAlarm(Client sender, string alarmName)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.stopAlarm", alarmName);
        }

        /// <summary>
        /// </summary>
        public void SetGpsActive(Client sender, bool active)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGpsActive", active);
        }

        /// <summary>
        /// </summary>
        public void ToggleAiPedsSpawning(Client sender, bool active)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.toggleAIPedsSpawning", active);
        }

        /// <summary>
        /// </summary>
        public void ToggleVehicleFirstPersonCam(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.toggleVehicleFirstPersonCam", enabled);
        }

        /// <summary>
        /// </summary>
        public void ToggleFirstPersonCam(Client sender, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.toggleFirstPersonCam", enabled);
        }

        /// <summary>
        /// </summary>
        public void DeleteObject(Client sender, Vector3 position, int modelHash, double radius = 1.0)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.deleteObject", position, modelHash, radius);
        }

        /// <summary>
        /// </summary>
        public void Sleep(Client sender, int ms)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.sleep", ms);
        }

        /// <summary>
        /// </summary>
        public void LoadAnimationDict(Client sender, string dict)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.loadAnimationDict", dict);
        }

        /// <summary>
        /// </summary>
        public void Dispose(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.Dispose");
        }
    }
}

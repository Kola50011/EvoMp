using EvoMp.Module.ClientWrapper.Enums;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
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

        public void SetSetting(Client sender, string name, dynamic value)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setSetting", name, value);
        }
        public void SetGameplayCameraActive(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGameplayCameraActive");
        }
        public void SetCanOpenChat(Client sender, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setCanOpenChat", show);
        }
        public void SetUiColor(Client sender, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setUiColor", red, green, blue);
        }
        public void SetEntityInvincible(Client sender, NetHandle entity, bool invincible)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityInvincible", entity, invincible);
        }
        public void SetVehicleLivery(Client sender, NetHandle vehicle, double livery)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleLivery", vehicle, livery);
        }
        public void SetVehicleLocked(Client sender, NetHandle vehicle, bool locked)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleLocked", vehicle, locked);
        }
        public void SetVehicleDoorState(Client sender, NetHandle vehicle, DoorState door, bool open)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDoorState", vehicle, (int)door, open);
        }
        public void SetVehicleExtra(Client sender, NetHandle vehicle, int slot, bool enabled)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleExtra", vehicle, slot, enabled);
        }
        public void SetVehicleNumberPlate(Client sender, NetHandle vehicle, string plate)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNumberPlate", vehicle, plate);
        }
        public void SetVehicleEngineStatus(Client sender, NetHandle vehicle, bool turnedOn)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEngineStatus", vehicle, turnedOn);
        }
        public void SetVehicleSpecialLightStatus(Client sender, NetHandle vehicle, bool status)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSpecialLightStatus", vehicle, status);
        }
        public void SetEntityCollisionless(Client sender, NetHandle entity, bool status)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityCollisionless", entity, status);
        }
        public void SetVehicleMod(Client sender, NetHandle vehicle, int slot, int modType)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleMod", vehicle, slot, modType);
        }
        public void SetVehicleBulletproofTyres(Client sender, NetHandle vehicle, bool bulletproof)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleBulletproofTyres", vehicle, bulletproof);
        }
        public void SetVehicleNumberPlateStyle(Client sender, NetHandle vehicle, int style)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNumberPlateStyle", vehicle, style);
        }
        public void SetVehiclePearlescentColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehiclePearlescentColor", vehicle, color);
        }
        public void SetVehicleWheelColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleWheelColor", vehicle, color);
        }
        public void SetVehicleWheelType(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleWheelType", vehicle, type);
        }
        public void SetVehicleModColor1(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleModColor1", vehicle, red, green, blue);
        }
        public void SetVehicleModColor2(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleModColor2", vehicle, red, green, blue);
        }
        public void SetVehicleTyreSmokeColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTyreSmokeColor", vehicle, red, green, blue);
        }
        public void SetVehicleWindowTint(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleWindowTint", vehicle, type);
        }
        public void SetVehicleEnginePowerMultiplier(Client sender, NetHandle vehicle, double mult)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEnginePowerMultiplier", vehicle, mult);
        }
        public void SetVehicleEngineTorqueMultiplier(Client sender, NetHandle vehicle, double mult)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleEngineTorqueMultiplier", vehicle, mult);
        }
        public void SetVehicleNeonState(Client sender, NetHandle vehicle, int slot, bool turnedOn)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNeonState", vehicle, slot, turnedOn);
        }
        public void SetVehicleNeonColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleNeonColor", vehicle, red, green, blue);
        }
        public void SetVehicleDashboardColor(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleDashboardColor", vehicle, type);
        }
        public void SetVehicleTrimColor(Client sender, NetHandle vehicle, int type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleTrimColor", vehicle, type);
        }
        public void SetPlayerNametag(Client sender, NetHandle player, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametag", player, text);
        }
        public void SetPlayerNametagVisible(Client sender, NetHandle player, bool show)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagVisible", player, show);
        }
        public void SetPlayerNametagColor(Client sender, NetHandle player, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerNametagColor", player, red, green, blue);
        }
        public void SetPlayerSkin(Client sender, int model)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerSkin", model);
        }
        public void SetPlayerDefaultClothes(Client sender)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerDefaultClothes");
        }
        public void SetPlayerTeam(Client sender, int team)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerTeam", team);
        }
        public void SetVehiclePrimaryColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehiclePrimaryColor", vehicle, color);
        }
        public void SetVehicleSecondaryColor(Client sender, NetHandle vehicle, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleSecondaryColor", vehicle, color);
        }
        public void SetVehicleCustomPrimaryColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCustomPrimaryColor", vehicle, red, green, blue);
        }
        public void SetVehicleCustomSecondaryColor(Client sender, NetHandle vehicle, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setVehicleCustomSecondaryColor", vehicle, red, green, blue);
        }
        public void SetPlayerClothes(Client sender, NetHandle player, int slot, int drawable, int texture)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerClothes", player, slot, drawable, texture);
        }
        public void SetPlayerAccessory(Client sender, NetHandle player, int slot, int drawable, int texture)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerAccessory", player, slot, drawable, texture);
        }
        public void SetEntityPositionFrozen(Client sender, NetHandle entity, bool frozen)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityPositionFrozen", entity, frozen);
        }
        public void SetEntityVelocity(Client sender, NetHandle entity, Vector3 velocity)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityVelocity", entity, velocity);
        }
        public void SetPlayerWeaponTint(Client sender, WeaponHash weapon, WeaponTint tint)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerWeaponTint", weapon, tint);
        }
        public void SetEntityPosition(Client sender, NetHandle entity, Vector3 position)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityPosition", entity, position);
        }
        public void SetEntityRotation(Client sender, NetHandle entity, Vector3 rotation)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityRotation", entity, rotation);
        }
        public void SetPlayerIntoVehicle(Client sender, NetHandle vehicle, int seat)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerIntoVehicle", vehicle, seat);
        }
        public void SetPlayerHealth(Client sender, double health)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerHealth", health);
        }
        public void SetTextLabelText(Client sender, NetHandle label, string text)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextLabelText", label, text);
        }
        public void SetTextLabelColor(Client sender, NetHandle textLabel, int alpha, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextLabelColor", textLabel, alpha, red, green, blue);
        }
        public void SetTextLabelSeethrough(Client sender, NetHandle handle, bool seethrough)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTextLabelSeethrough", handle, seethrough);
        }
        public void SetPlayerInvincible(Client sender, bool invinc)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerInvincible", invinc);
        }
        public void SetPlayerWantedLevel(Client sender, int wantedLevel)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerWantedLevel", wantedLevel);
        }
        public void SetPlayerArmor(Client sender, int armor)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setPlayerArmor", armor);
        }
        public void SetBlipPosition(Client sender, NetHandle blip, Vector3 position)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipPosition", blip, position);
        }
        public void SetWaypoint(Client sender, double x, double y)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setWaypoint", x, y);
        }
        public void SetBlipColor(Client sender, NetHandle blip, int color)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipColor", blip, color);
        }
        public void SetBlipSprite(Client sender, NetHandle blip, int sprite)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipSprite", blip, sprite);
        }
        public void SetBlipName(Client sender, NetHandle blip, string name)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipName", blip, name);
        }
        public void SetBlipTransparency(Client sender, NetHandle blip, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipTransparency", blip, alpha);
        }
        public void SetBlipShortRange(Client sender, NetHandle blip, bool shortRange)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipShortRange", blip, shortRange);
        }
        public void SetBlipScale(Client sender, NetHandle blip, double scale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setBlipScale", blip, scale);
        }
        public void SetChatVisible(Client sender, bool display)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setChatVisible", display);
        }
        public void SetHudVisible(Client sender, bool visible)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setHudVisible", visible);
        }
        public void SetMarkerType(Client sender, NetHandle marker, MarkerType type)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerType", marker, type);
        }
        public void SetMarkerColor(Client sender, NetHandle marker, int alpha, int red, int green, int blue)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerColor", marker, alpha, red, green, blue);
        }
        public void SetMarkerScale(Client sender, NetHandle marker, Vector3 scale)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerScale", marker, scale);
        }
        public void SetMarkerDirection(Client sender, NetHandle marker, Vector3 dir)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setMarkerDirection", marker, dir);
        }
        public void SetAudioTime(Client sender, int seconds)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setAudioTime", seconds);
        }
        public void SetGameVolume(Client sender, int vol)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setGameVolume", vol);
        }
        public void SetEntityTransparency(Client sender, NetHandle entity, int alpha)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityTransparency", entity, alpha);
        }
        public void SetEntityDimension(Client sender, NetHandle entity, int dimension)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setEntityDimension", entity, dimension);
        }
        public void SetWeather(Client sender, Weather weather)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setWeather", weather);
        }
        public void SetTime(Client sender, int hours, int minutes)
        {
            _eventHandler.InvokeClientEvent(sender, "ClientWrapper.Set.setTime", hours, minutes);
        }


        //TODO: implement
        //setCameraShake(cam: GTANetwork.Javascript.GlobalCamera, shakeType: string, amplitute: number): void;
        //setCameraPosition(cam: GTANetwork.Javascript.GlobalCamera, pos: Vector3): void;
        //setCameraRotation(cam: GTANetwork.Javascript.GlobalCamera, rotation: Vector3): void;
        //setCameraFov(cam: GTANetwork.Javascript.GlobalCamera, fov: number): void;
        //setActiveCamera(camera: GTANetwork.Javascript.GlobalCamera): void;
        //public boolean setEntitySyncedData(entity: GTANetwork.Util.LocalHandle, key: string, data: any): ;
        //public boolean setWorldSyncedData(key: string, data: any): ;

        //setCefBrowserSize(browser: GTANetwork.GUI.Browser, width: number, height: number): void;
        //setCefBrowserHeadless(browser: GTANetwork.GUI.Browser, headless: boolean): void;
        //setCefBrowserPosition(browser: GTANetwork.GUI.Browser, xPos: number, yPos: number): void;

        //public void setMenuBannerSprite(menu: NativeUI.UIMenu, string spritedict, string spritename);
        //public void setMenuBannerTexture(menu: NativeUI.UIMenu, string path);
        //public void setMenuBannerRectangle(menu: NativeUI.UIMenu, alpha: number, red: number, green: number, blue: number);
        //public void setMenuTitle(menu: NativeUI.UIMenu, string title);
        //public void setMenuSubtitle(menu: NativeUI.UIMenu, string text);
    }
}

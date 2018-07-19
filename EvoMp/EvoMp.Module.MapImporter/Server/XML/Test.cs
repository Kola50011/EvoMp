namespace EvoMp.Module.MapImporter.Server.XML
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SpoonerPlacements
    {

        private SpoonerPlacementsInfo infoField;

        private string noteField;

        private SpoonerPlacementsAudioFile audioFileField;

        private bool clearDatabaseField;

        private byte clearWorldField;

        private bool clearMarkersField;

        private SpoonerPlacementsIPLsToLoad iPLsToLoadField;

        private object iPLsToRemoveField;

        private object interiorsToEnableField;

        private object interiorsToCapField;

        private object weatherToSetField;

        private bool startTaskSequencesOnLoadField;

        private SpoonerPlacementsReferenceCoords referenceCoordsField;

        private SpoonerPlacementsPlacement[] placementField;

        /// <remarks/>
        public SpoonerPlacementsInfo info {
            get {
                return this.infoField;
            }
            set {
                this.infoField = value;
            }
        }

        /// <remarks/>
        public string Note {
            get {
                return this.noteField;
            }
            set {
                this.noteField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsAudioFile AudioFile {
            get {
                return this.audioFileField;
            }
            set {
                this.audioFileField = value;
            }
        }

        /// <remarks/>
        public bool ClearDatabase {
            get {
                return this.clearDatabaseField;
            }
            set {
                this.clearDatabaseField = value;
            }
        }

        /// <remarks/>
        public byte ClearWorld {
            get {
                return this.clearWorldField;
            }
            set {
                this.clearWorldField = value;
            }
        }

        /// <remarks/>
        public bool ClearMarkers {
            get {
                return this.clearMarkersField;
            }
            set {
                this.clearMarkersField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsIPLsToLoad IPLsToLoad {
            get {
                return this.iPLsToLoadField;
            }
            set {
                this.iPLsToLoadField = value;
            }
        }

        /// <remarks/>
        public object IPLsToRemove {
            get {
                return this.iPLsToRemoveField;
            }
            set {
                this.iPLsToRemoveField = value;
            }
        }

        /// <remarks/>
        public object InteriorsToEnable {
            get {
                return this.interiorsToEnableField;
            }
            set {
                this.interiorsToEnableField = value;
            }
        }

        /// <remarks/>
        public object InteriorsToCap {
            get {
                return this.interiorsToCapField;
            }
            set {
                this.interiorsToCapField = value;
            }
        }

        /// <remarks/>
        public object WeatherToSet {
            get {
                return this.weatherToSetField;
            }
            set {
                this.weatherToSetField = value;
            }
        }

        /// <remarks/>
        public bool StartTaskSequencesOnLoad {
            get {
                return this.startTaskSequencesOnLoadField;
            }
            set {
                this.startTaskSequencesOnLoadField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsReferenceCoords ReferenceCoords {
            get {
                return this.referenceCoordsField;
            }
            set {
                this.referenceCoordsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("Placement")]
        public SpoonerPlacementsPlacement[] Placement {
            get {
                return this.placementField;
            }
            set {
                this.placementField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsInfo
    {

        private string nameField;

        private byte dimensionField;

        private string creatorIngameNameField;

        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public byte Dimension {
            get {
                return this.dimensionField;
            }
            set {
                this.dimensionField = value;
            }
        }

        /// <remarks/>
        public string CreatorIngameName {
            get {
                return this.creatorIngameNameField;
            }
            set {
                this.creatorIngameNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsAudioFile
    {

        private ushort volumeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort volume {
            get {
                return this.volumeField;
            }
            set {
                this.volumeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsIPLsToLoad
    {

        private bool load_mp_mapsField;

        private bool load_sp_mapsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool load_mp_maps {
            get {
                return this.load_mp_mapsField;
            }
            set {
                this.load_mp_mapsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool load_sp_maps {
            get {
                return this.load_sp_mapsField;
            }
            set {
                this.load_sp_mapsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsReferenceCoords
    {

        private decimal xField;

        private decimal yField;

        private decimal zField;

        /// <remarks/>
        public decimal X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }

        /// <remarks/>
        public decimal Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }

        /// <remarks/>
        public decimal Z {
            get {
                return this.zField;
            }
            set {
                this.zField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacement
    {

        private string modelHashField;

        private byte typeField;

        private bool dynamicField;

        private bool frozenPosField;

        private string hashNameField;

        private uint initialHandleField;

        private SpoonerPlacementsPlacementVehicleProperties vehiclePropertiesField;

        private SpoonerPlacementsPlacementObjectProperties objectPropertiesField;

        private byte opacityLevelField;

        private ushort lodDistanceField;

        private bool isVisibleField;

        private ushort maxHealthField;

        private ushort healthField;

        private bool hasGravityField;

        private bool isOnFireField;

        private bool isInvincibleField;

        private bool isBulletProofField;

        private bool isCollisionProofField;

        private bool isExplosionProofField;

        private bool isFireProofField;

        private bool isMeleeProofField;

        private bool isOnlyDamagedByPlayerField;

        private SpoonerPlacementsPlacementPositionRotation positionRotationField;

        private SpoonerPlacementsPlacementAttachment attachmentField;

        /// <remarks/>
        public string ModelHash {
            get {
                return this.modelHashField;
            }
            set {
                this.modelHashField = value;
            }
        }

        /// <remarks/>
        public byte Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public bool Dynamic {
            get {
                return this.dynamicField;
            }
            set {
                this.dynamicField = value;
            }
        }

        /// <remarks/>
        public bool FrozenPos {
            get {
                return this.frozenPosField;
            }
            set {
                this.frozenPosField = value;
            }
        }

        /// <remarks/>
        public string HashName {
            get {
                return this.hashNameField;
            }
            set {
                this.hashNameField = value;
            }
        }

        /// <remarks/>
        public uint InitialHandle {
            get {
                return this.initialHandleField;
            }
            set {
                this.initialHandleField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehicleProperties VehicleProperties {
            get {
                return this.vehiclePropertiesField;
            }
            set {
                this.vehiclePropertiesField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementObjectProperties ObjectProperties {
            get {
                return this.objectPropertiesField;
            }
            set {
                this.objectPropertiesField = value;
            }
        }

        /// <remarks/>
        public byte OpacityLevel {
            get {
                return this.opacityLevelField;
            }
            set {
                this.opacityLevelField = value;
            }
        }

        /// <remarks/>
        public ushort LodDistance {
            get {
                return this.lodDistanceField;
            }
            set {
                this.lodDistanceField = value;
            }
        }

        /// <remarks/>
        public bool IsVisible {
            get {
                return this.isVisibleField;
            }
            set {
                this.isVisibleField = value;
            }
        }

        /// <remarks/>
        public ushort MaxHealth {
            get {
                return this.maxHealthField;
            }
            set {
                this.maxHealthField = value;
            }
        }

        /// <remarks/>
        public ushort Health {
            get {
                return this.healthField;
            }
            set {
                this.healthField = value;
            }
        }

        /// <remarks/>
        public bool HasGravity {
            get {
                return this.hasGravityField;
            }
            set {
                this.hasGravityField = value;
            }
        }

        /// <remarks/>
        public bool IsOnFire {
            get {
                return this.isOnFireField;
            }
            set {
                this.isOnFireField = value;
            }
        }

        /// <remarks/>
        public bool IsInvincible {
            get {
                return this.isInvincibleField;
            }
            set {
                this.isInvincibleField = value;
            }
        }

        /// <remarks/>
        public bool IsBulletProof {
            get {
                return this.isBulletProofField;
            }
            set {
                this.isBulletProofField = value;
            }
        }

        /// <remarks/>
        public bool IsCollisionProof {
            get {
                return this.isCollisionProofField;
            }
            set {
                this.isCollisionProofField = value;
            }
        }

        /// <remarks/>
        public bool IsExplosionProof {
            get {
                return this.isExplosionProofField;
            }
            set {
                this.isExplosionProofField = value;
            }
        }

        /// <remarks/>
        public bool IsFireProof {
            get {
                return this.isFireProofField;
            }
            set {
                this.isFireProofField = value;
            }
        }

        /// <remarks/>
        public bool IsMeleeProof {
            get {
                return this.isMeleeProofField;
            }
            set {
                this.isMeleeProofField = value;
            }
        }

        /// <remarks/>
        public bool IsOnlyDamagedByPlayer {
            get {
                return this.isOnlyDamagedByPlayerField;
            }
            set {
                this.isOnlyDamagedByPlayerField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementPositionRotation PositionRotation {
            get {
                return this.positionRotationField;
            }
            set {
                this.positionRotationField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementAttachment Attachment {
            get {
                return this.attachmentField;
            }
            set {
                this.attachmentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehicleProperties
    {

        private SpoonerPlacementsPlacementVehiclePropertiesColours coloursField;

        private sbyte liveryField;

        private string numberPlateTextField;

        private byte numberPlateIndexField;

        private byte wheelTypeField;

        private bool wheelsInvisibleField;

        private object engineSoundNameField;

        private sbyte windowTintField;

        private bool bulletProofTyresField;

        private decimal dirtLevelField;

        private decimal paintFadeField;

        private byte roofStateField;

        private bool sirenActiveField;

        private bool engineOnField;

        private ushort engineHealthField;

        private bool lightsOnField;

        private byte isRadioLoudField;

        private byte lockStatusField;

        private SpoonerPlacementsPlacementVehiclePropertiesNeons neonsField;

        private SpoonerPlacementsPlacementVehiclePropertiesDoorsOpen doorsOpenField;

        private SpoonerPlacementsPlacementVehiclePropertiesDoorsBroken doorsBrokenField;

        private SpoonerPlacementsPlacementVehiclePropertiesTyresBursted tyresBurstedField;

        private SpoonerPlacementsPlacementVehiclePropertiesModExtras modExtrasField;

        private SpoonerPlacementsPlacementVehiclePropertiesMods modsField;

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesColours Colours {
            get {
                return this.coloursField;
            }
            set {
                this.coloursField = value;
            }
        }

        /// <remarks/>
        public sbyte Livery {
            get {
                return this.liveryField;
            }
            set {
                this.liveryField = value;
            }
        }

        /// <remarks/>
        public string NumberPlateText {
            get {
                return this.numberPlateTextField;
            }
            set {
                this.numberPlateTextField = value;
            }
        }

        /// <remarks/>
        public byte NumberPlateIndex {
            get {
                return this.numberPlateIndexField;
            }
            set {
                this.numberPlateIndexField = value;
            }
        }

        /// <remarks/>
        public byte WheelType {
            get {
                return this.wheelTypeField;
            }
            set {
                this.wheelTypeField = value;
            }
        }

        /// <remarks/>
        public bool WheelsInvisible {
            get {
                return this.wheelsInvisibleField;
            }
            set {
                this.wheelsInvisibleField = value;
            }
        }

        /// <remarks/>
        public object EngineSoundName {
            get {
                return this.engineSoundNameField;
            }
            set {
                this.engineSoundNameField = value;
            }
        }

        /// <remarks/>
        public sbyte WindowTint {
            get {
                return this.windowTintField;
            }
            set {
                this.windowTintField = value;
            }
        }

        /// <remarks/>
        public bool BulletProofTyres {
            get {
                return this.bulletProofTyresField;
            }
            set {
                this.bulletProofTyresField = value;
            }
        }

        /// <remarks/>
        public decimal DirtLevel {
            get {
                return this.dirtLevelField;
            }
            set {
                this.dirtLevelField = value;
            }
        }

        /// <remarks/>
        public decimal PaintFade {
            get {
                return this.paintFadeField;
            }
            set {
                this.paintFadeField = value;
            }
        }

        /// <remarks/>
        public byte RoofState {
            get {
                return this.roofStateField;
            }
            set {
                this.roofStateField = value;
            }
        }

        /// <remarks/>
        public bool SirenActive {
            get {
                return this.sirenActiveField;
            }
            set {
                this.sirenActiveField = value;
            }
        }

        /// <remarks/>
        public bool EngineOn {
            get {
                return this.engineOnField;
            }
            set {
                this.engineOnField = value;
            }
        }

        /// <remarks/>
        public ushort EngineHealth {
            get {
                return this.engineHealthField;
            }
            set {
                this.engineHealthField = value;
            }
        }

        /// <remarks/>
        public bool LightsOn {
            get {
                return this.lightsOnField;
            }
            set {
                this.lightsOnField = value;
            }
        }

        /// <remarks/>
        public byte IsRadioLoud {
            get {
                return this.isRadioLoudField;
            }
            set {
                this.isRadioLoudField = value;
            }
        }

        /// <remarks/>
        public byte LockStatus {
            get {
                return this.lockStatusField;
            }
            set {
                this.lockStatusField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesNeons Neons {
            get {
                return this.neonsField;
            }
            set {
                this.neonsField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesDoorsOpen DoorsOpen {
            get {
                return this.doorsOpenField;
            }
            set {
                this.doorsOpenField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesDoorsBroken DoorsBroken {
            get {
                return this.doorsBrokenField;
            }
            set {
                this.doorsBrokenField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesTyresBursted TyresBursted {
            get {
                return this.tyresBurstedField;
            }
            set {
                this.tyresBurstedField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesModExtras ModExtras {
            get {
                return this.modExtrasField;
            }
            set {
                this.modExtrasField = value;
            }
        }

        /// <remarks/>
        public SpoonerPlacementsPlacementVehiclePropertiesMods Mods {
            get {
                return this.modsField;
            }
            set {
                this.modsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesColours
    {

        private byte primaryField;

        private byte secondaryField;

        private byte pearlField;

        private byte rimField;

        private byte mod1_aField;

        private sbyte mod1_bField;

        private sbyte mod1_cField;

        private byte mod2_aField;

        private sbyte mod2_bField;

        private bool isPrimaryColourCustomField;

        private bool isSecondaryColourCustomField;

        private byte tyreSmoke_RField;

        private byte tyreSmoke_GField;

        private byte tyreSmoke_BField;

        private byte lrInteriorField;

        private byte lrDashboardField;

        /// <remarks/>
        public byte Primary {
            get {
                return this.primaryField;
            }
            set {
                this.primaryField = value;
            }
        }

        /// <remarks/>
        public byte Secondary {
            get {
                return this.secondaryField;
            }
            set {
                this.secondaryField = value;
            }
        }

        /// <remarks/>
        public byte Pearl {
            get {
                return this.pearlField;
            }
            set {
                this.pearlField = value;
            }
        }

        /// <remarks/>
        public byte Rim {
            get {
                return this.rimField;
            }
            set {
                this.rimField = value;
            }
        }

        /// <remarks/>
        public byte Mod1_a {
            get {
                return this.mod1_aField;
            }
            set {
                this.mod1_aField = value;
            }
        }

        /// <remarks/>
        public sbyte Mod1_b {
            get {
                return this.mod1_bField;
            }
            set {
                this.mod1_bField = value;
            }
        }

        /// <remarks/>
        public sbyte Mod1_c {
            get {
                return this.mod1_cField;
            }
            set {
                this.mod1_cField = value;
            }
        }

        /// <remarks/>
        public byte Mod2_a {
            get {
                return this.mod2_aField;
            }
            set {
                this.mod2_aField = value;
            }
        }

        /// <remarks/>
        public sbyte Mod2_b {
            get {
                return this.mod2_bField;
            }
            set {
                this.mod2_bField = value;
            }
        }

        /// <remarks/>
        public bool IsPrimaryColourCustom {
            get {
                return this.isPrimaryColourCustomField;
            }
            set {
                this.isPrimaryColourCustomField = value;
            }
        }

        /// <remarks/>
        public bool IsSecondaryColourCustom {
            get {
                return this.isSecondaryColourCustomField;
            }
            set {
                this.isSecondaryColourCustomField = value;
            }
        }

        /// <remarks/>
        public byte tyreSmoke_R {
            get {
                return this.tyreSmoke_RField;
            }
            set {
                this.tyreSmoke_RField = value;
            }
        }

        /// <remarks/>
        public byte tyreSmoke_G {
            get {
                return this.tyreSmoke_GField;
            }
            set {
                this.tyreSmoke_GField = value;
            }
        }

        /// <remarks/>
        public byte tyreSmoke_B {
            get {
                return this.tyreSmoke_BField;
            }
            set {
                this.tyreSmoke_BField = value;
            }
        }

        /// <remarks/>
        public byte LrInterior {
            get {
                return this.lrInteriorField;
            }
            set {
                this.lrInteriorField = value;
            }
        }

        /// <remarks/>
        public byte LrDashboard {
            get {
                return this.lrDashboardField;
            }
            set {
                this.lrDashboardField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesNeons
    {

        private bool leftField;

        private bool rightField;

        private bool frontField;

        private bool backField;

        private byte rField;

        private byte gField;

        private byte bField;

        /// <remarks/>
        public bool Left {
            get {
                return this.leftField;
            }
            set {
                this.leftField = value;
            }
        }

        /// <remarks/>
        public bool Right {
            get {
                return this.rightField;
            }
            set {
                this.rightField = value;
            }
        }

        /// <remarks/>
        public bool Front {
            get {
                return this.frontField;
            }
            set {
                this.frontField = value;
            }
        }

        /// <remarks/>
        public bool Back {
            get {
                return this.backField;
            }
            set {
                this.backField = value;
            }
        }

        /// <remarks/>
        public byte R {
            get {
                return this.rField;
            }
            set {
                this.rField = value;
            }
        }

        /// <remarks/>
        public byte G {
            get {
                return this.gField;
            }
            set {
                this.gField = value;
            }
        }

        /// <remarks/>
        public byte B {
            get {
                return this.bField;
            }
            set {
                this.bField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesDoorsOpen
    {

        private bool backLeftDoorField;

        private bool backRightDoorField;

        private bool frontLeftDoorField;

        private bool frontRightDoorField;

        private bool hoodField;

        private bool trunkField;

        private bool trunk2Field;

        /// <remarks/>
        public bool BackLeftDoor {
            get {
                return this.backLeftDoorField;
            }
            set {
                this.backLeftDoorField = value;
            }
        }

        /// <remarks/>
        public bool BackRightDoor {
            get {
                return this.backRightDoorField;
            }
            set {
                this.backRightDoorField = value;
            }
        }

        /// <remarks/>
        public bool FrontLeftDoor {
            get {
                return this.frontLeftDoorField;
            }
            set {
                this.frontLeftDoorField = value;
            }
        }

        /// <remarks/>
        public bool FrontRightDoor {
            get {
                return this.frontRightDoorField;
            }
            set {
                this.frontRightDoorField = value;
            }
        }

        /// <remarks/>
        public bool Hood {
            get {
                return this.hoodField;
            }
            set {
                this.hoodField = value;
            }
        }

        /// <remarks/>
        public bool Trunk {
            get {
                return this.trunkField;
            }
            set {
                this.trunkField = value;
            }
        }

        /// <remarks/>
        public bool Trunk2 {
            get {
                return this.trunk2Field;
            }
            set {
                this.trunk2Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesDoorsBroken
    {

        private bool backLeftDoorField;

        private bool backRightDoorField;

        private bool frontLeftDoorField;

        private bool frontRightDoorField;

        private bool hoodField;

        private bool trunkField;

        private bool trunk2Field;

        /// <remarks/>
        public bool BackLeftDoor {
            get {
                return this.backLeftDoorField;
            }
            set {
                this.backLeftDoorField = value;
            }
        }

        /// <remarks/>
        public bool BackRightDoor {
            get {
                return this.backRightDoorField;
            }
            set {
                this.backRightDoorField = value;
            }
        }

        /// <remarks/>
        public bool FrontLeftDoor {
            get {
                return this.frontLeftDoorField;
            }
            set {
                this.frontLeftDoorField = value;
            }
        }

        /// <remarks/>
        public bool FrontRightDoor {
            get {
                return this.frontRightDoorField;
            }
            set {
                this.frontRightDoorField = value;
            }
        }

        /// <remarks/>
        public bool Hood {
            get {
                return this.hoodField;
            }
            set {
                this.hoodField = value;
            }
        }

        /// <remarks/>
        public bool Trunk {
            get {
                return this.trunkField;
            }
            set {
                this.trunkField = value;
            }
        }

        /// <remarks/>
        public bool Trunk2 {
            get {
                return this.trunk2Field;
            }
            set {
                this.trunk2Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesTyresBursted
    {

        private bool frontLeftField;

        private bool frontRightField;

        private bool _2Field;

        private bool _3Field;

        private bool backLeftField;

        private bool backRightField;

        private bool _6Field;

        private bool _7Field;

        private bool _8Field;

        /// <remarks/>
        public bool FrontLeft {
            get {
                return this.frontLeftField;
            }
            set {
                this.frontLeftField = value;
            }
        }

        /// <remarks/>
        public bool FrontRight {
            get {
                return this.frontRightField;
            }
            set {
                this.frontRightField = value;
            }
        }

        /// <remarks/>
        public bool _2 {
            get {
                return this._2Field;
            }
            set {
                this._2Field = value;
            }
        }

        /// <remarks/>
        public bool _3 {
            get {
                return this._3Field;
            }
            set {
                this._3Field = value;
            }
        }

        /// <remarks/>
        public bool BackLeft {
            get {
                return this.backLeftField;
            }
            set {
                this.backLeftField = value;
            }
        }

        /// <remarks/>
        public bool BackRight {
            get {
                return this.backRightField;
            }
            set {
                this.backRightField = value;
            }
        }

        /// <remarks/>
        public bool _6 {
            get {
                return this._6Field;
            }
            set {
                this._6Field = value;
            }
        }

        /// <remarks/>
        public bool _7 {
            get {
                return this._7Field;
            }
            set {
                this._7Field = value;
            }
        }

        /// <remarks/>
        public bool _8 {
            get {
                return this._8Field;
            }
            set {
                this._8Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesModExtras
    {

        private bool _1Field;

        private bool _2Field;

        private bool _2FieldSpecified;

        /// <remarks/>
        public bool _1 {
            get {
                return this._1Field;
            }
            set {
                this._1Field = value;
            }
        }

        /// <remarks/>
        public bool _2 {
            get {
                return this._2Field;
            }
            set {
                this._2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool _2Specified {
            get {
                return this._2FieldSpecified;
            }
            set {
                this._2FieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementVehiclePropertiesMods
    {

        private string _0Field;

        private string _1Field;

        private string _2Field;

        private string _3Field;

        private string _4Field;

        private string _5Field;

        private string _6Field;

        private string _7Field;

        private string _8Field;

        private string _9Field;

        private string _10Field;

        private string _11Field;

        private string _12Field;

        private string _13Field;

        private string _14Field;

        private string _15Field;

        private string _16Field;

        private bool _17Field;

        private bool _18Field;

        private bool _19Field;

        private bool _20Field;

        private bool _21Field;

        private bool _22Field;

        private string _23Field;

        private string _24Field;

        private string _25Field;

        private string _26Field;

        private string _27Field;

        private string _28Field;

        private string _29Field;

        private string _30Field;

        private string _31Field;

        private string _32Field;

        private string _33Field;

        private string _34Field;

        private string _35Field;

        private string _36Field;

        private string _37Field;

        private string _38Field;

        private string _39Field;

        private string _40Field;

        private string _41Field;

        private string _42Field;

        private string _43Field;

        private string _44Field;

        private string _45Field;

        private string _46Field;

        private string _47Field;

        private string _48Field;

        /// <remarks/>
        public string _0 {
            get {
                return this._0Field;
            }
            set {
                this._0Field = value;
            }
        }

        /// <remarks/>
        public string _1 {
            get {
                return this._1Field;
            }
            set {
                this._1Field = value;
            }
        }

        /// <remarks/>
        public string _2 {
            get {
                return this._2Field;
            }
            set {
                this._2Field = value;
            }
        }

        /// <remarks/>
        public string _3 {
            get {
                return this._3Field;
            }
            set {
                this._3Field = value;
            }
        }

        /// <remarks/>
        public string _4 {
            get {
                return this._4Field;
            }
            set {
                this._4Field = value;
            }
        }

        /// <remarks/>
        public string _5 {
            get {
                return this._5Field;
            }
            set {
                this._5Field = value;
            }
        }

        /// <remarks/>
        public string _6 {
            get {
                return this._6Field;
            }
            set {
                this._6Field = value;
            }
        }

        /// <remarks/>
        public string _7 {
            get {
                return this._7Field;
            }
            set {
                this._7Field = value;
            }
        }

        /// <remarks/>
        public string _8 {
            get {
                return this._8Field;
            }
            set {
                this._8Field = value;
            }
        }

        /// <remarks/>
        public string _9 {
            get {
                return this._9Field;
            }
            set {
                this._9Field = value;
            }
        }

        /// <remarks/>
        public string _10 {
            get {
                return this._10Field;
            }
            set {
                this._10Field = value;
            }
        }

        /// <remarks/>
        public string _11 {
            get {
                return this._11Field;
            }
            set {
                this._11Field = value;
            }
        }

        /// <remarks/>
        public string _12 {
            get {
                return this._12Field;
            }
            set {
                this._12Field = value;
            }
        }

        /// <remarks/>
        public string _13 {
            get {
                return this._13Field;
            }
            set {
                this._13Field = value;
            }
        }

        /// <remarks/>
        public string _14 {
            get {
                return this._14Field;
            }
            set {
                this._14Field = value;
            }
        }

        /// <remarks/>
        public string _15 {
            get {
                return this._15Field;
            }
            set {
                this._15Field = value;
            }
        }

        /// <remarks/>
        public string _16 {
            get {
                return this._16Field;
            }
            set {
                this._16Field = value;
            }
        }

        /// <remarks/>
        public bool _17 {
            get {
                return this._17Field;
            }
            set {
                this._17Field = value;
            }
        }

        /// <remarks/>
        public bool _18 {
            get {
                return this._18Field;
            }
            set {
                this._18Field = value;
            }
        }

        /// <remarks/>
        public bool _19 {
            get {
                return this._19Field;
            }
            set {
                this._19Field = value;
            }
        }

        /// <remarks/>
        public bool _20 {
            get {
                return this._20Field;
            }
            set {
                this._20Field = value;
            }
        }

        /// <remarks/>
        public bool _21 {
            get {
                return this._21Field;
            }
            set {
                this._21Field = value;
            }
        }

        /// <remarks/>
        public bool _22 {
            get {
                return this._22Field;
            }
            set {
                this._22Field = value;
            }
        }

        /// <remarks/>
        public string _23 {
            get {
                return this._23Field;
            }
            set {
                this._23Field = value;
            }
        }

        /// <remarks/>
        public string _24 {
            get {
                return this._24Field;
            }
            set {
                this._24Field = value;
            }
        }

        /// <remarks/>
        public string _25 {
            get {
                return this._25Field;
            }
            set {
                this._25Field = value;
            }
        }

        /// <remarks/>
        public string _26 {
            get {
                return this._26Field;
            }
            set {
                this._26Field = value;
            }
        }

        /// <remarks/>
        public string _27 {
            get {
                return this._27Field;
            }
            set {
                this._27Field = value;
            }
        }

        /// <remarks/>
        public string _28 {
            get {
                return this._28Field;
            }
            set {
                this._28Field = value;
            }
        }

        /// <remarks/>
        public string _29 {
            get {
                return this._29Field;
            }
            set {
                this._29Field = value;
            }
        }

        /// <remarks/>
        public string _30 {
            get {
                return this._30Field;
            }
            set {
                this._30Field = value;
            }
        }

        /// <remarks/>
        public string _31 {
            get {
                return this._31Field;
            }
            set {
                this._31Field = value;
            }
        }

        /// <remarks/>
        public string _32 {
            get {
                return this._32Field;
            }
            set {
                this._32Field = value;
            }
        }

        /// <remarks/>
        public string _33 {
            get {
                return this._33Field;
            }
            set {
                this._33Field = value;
            }
        }

        /// <remarks/>
        public string _34 {
            get {
                return this._34Field;
            }
            set {
                this._34Field = value;
            }
        }

        /// <remarks/>
        public string _35 {
            get {
                return this._35Field;
            }
            set {
                this._35Field = value;
            }
        }

        /// <remarks/>
        public string _36 {
            get {
                return this._36Field;
            }
            set {
                this._36Field = value;
            }
        }

        /// <remarks/>
        public string _37 {
            get {
                return this._37Field;
            }
            set {
                this._37Field = value;
            }
        }

        /// <remarks/>
        public string _38 {
            get {
                return this._38Field;
            }
            set {
                this._38Field = value;
            }
        }

        /// <remarks/>
        public string _39 {
            get {
                return this._39Field;
            }
            set {
                this._39Field = value;
            }
        }

        /// <remarks/>
        public string _40 {
            get {
                return this._40Field;
            }
            set {
                this._40Field = value;
            }
        }

        /// <remarks/>
        public string _41 {
            get {
                return this._41Field;
            }
            set {
                this._41Field = value;
            }
        }

        /// <remarks/>
        public string _42 {
            get {
                return this._42Field;
            }
            set {
                this._42Field = value;
            }
        }

        /// <remarks/>
        public string _43 {
            get {
                return this._43Field;
            }
            set {
                this._43Field = value;
            }
        }

        /// <remarks/>
        public string _44 {
            get {
                return this._44Field;
            }
            set {
                this._44Field = value;
            }
        }

        /// <remarks/>
        public string _45 {
            get {
                return this._45Field;
            }
            set {
                this._45Field = value;
            }
        }

        /// <remarks/>
        public string _46 {
            get {
                return this._46Field;
            }
            set {
                this._46Field = value;
            }
        }

        /// <remarks/>
        public string _47 {
            get {
                return this._47Field;
            }
            set {
                this._47Field = value;
            }
        }

        /// <remarks/>
        public string _48 {
            get {
                return this._48Field;
            }
            set {
                this._48Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementObjectProperties
    {

        private byte textureVariationField;

        /// <remarks/>
        public byte TextureVariation {
            get {
                return this.textureVariationField;
            }
            set {
                this.textureVariationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementPositionRotation
    {

        private decimal xField;

        private decimal yField;

        private decimal zField;

        private double pitchField;

        private double rollField;

        private decimal yawField;

        /// <remarks/>
        public decimal X {
            get {
                return this.xField;
            }
            set {
                this.xField = value;
            }
        }

        /// <remarks/>
        public decimal Y {
            get {
                return this.yField;
            }
            set {
                this.yField = value;
            }
        }

        /// <remarks/>
        public decimal Z {
            get {
                return this.zField;
            }
            set {
                this.zField = value;
            }
        }

        /// <remarks/>
        public double Pitch {
            get {
                return this.pitchField;
            }
            set {
                this.pitchField = value;
            }
        }

        /// <remarks/>
        public double Roll {
            get {
                return this.rollField;
            }
            set {
                this.rollField = value;
            }
        }

        /// <remarks/>
        public decimal Yaw {
            get {
                return this.yawField;
            }
            set {
                this.yawField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SpoonerPlacementsPlacementAttachment
    {

        private bool isAttachedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool isAttached {
            get {
                return this.isAttachedField;
            }
            set {
                this.isAttachedField = value;
            }
        }
    }
}

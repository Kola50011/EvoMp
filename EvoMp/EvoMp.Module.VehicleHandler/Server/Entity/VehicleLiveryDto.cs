using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleLiveries")]
    public class VehicleLiveryDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("VehicleLiveryId")]
        public int VehicleLiveryId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Index("IX_VehicleHashAndValue", 1, IsUnique = true)]
        public VehicleHash VehicleHash { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Index("IX_VehicleHashAndValue", 2, IsUnique = true)]
        public int Value { get; set; }
    }
}

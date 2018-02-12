using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleColors")]
    public class VehicleColorDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public int VehicleColorId { get; set; }

        [Index("IX_RGB", 1, IsUnique = true)]
        [Column("Red", Order = 1)]
        public int Red { get; set; }

        [Index("IX_RGB", 2, IsUnique = true)]
        [Column("Green", Order = 2)]
        public int Green { get; set; }

        [Index("IX_RGB", 3, IsUnique = true)]
        [Column("Blue", Order = 3)]
        public int Blue { get; set; }
    }
}

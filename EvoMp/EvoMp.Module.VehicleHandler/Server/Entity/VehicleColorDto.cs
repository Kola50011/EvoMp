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

        [Key]
        [Column("Red", Order = 1)]
        public int Red { get; set; }

        [Key]
        [Column("Green", Order = 2)]
        public int Green { get; set; }

        [Key]
        [Column("Blue", Order = 3)]
        public int Blue { get; set; }
    }
}

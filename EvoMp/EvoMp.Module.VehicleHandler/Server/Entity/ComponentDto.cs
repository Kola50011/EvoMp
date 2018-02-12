using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleComponents")]
    public class ComponentDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ComponentId { get; set; }

        [Index("IX_SlotAndValue", 1, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Slot { get; set; }

        [Index("IX_SlotAndValue", 2, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Value { get; set; }
    }
}

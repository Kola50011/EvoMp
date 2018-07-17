using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.MapHandler.Server.Entity
{
    [Table("Maps")]
    public class MapDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("MapId")]
        public int MapId { get; set; }

        [Column("Dimension")] public int Dimension { get; set; }

        [Column("Name")] public string Name { get; set; }

        /// <summary>
        ///     Map Objects
        /// </summary>
        public ICollection<MapObjectDto> MapObjects { get; set; }
    }
}

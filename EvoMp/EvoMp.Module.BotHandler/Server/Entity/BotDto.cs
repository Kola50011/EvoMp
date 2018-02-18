using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.ClientHandler.Server.Entity;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.BotHandler.Server.Entity
{
    [Table("Bots")]
    public class BotDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("BotId")]
        public int BotId { get; set; }

        /// <summary>
        /// The name of the bot
        /// </summary>
        [Index("IX_NameClient", 1, IsUnique = true)]
        [MaxLength(60)]
        [Column("BotName", TypeName = "NVARCHAR")]
        public string BotName { get; set; }

        [Column("VehicleId")]
        public int VehicleId { get; set; }

        /// <summary>
        /// The vehicle of the bot
        /// </summary>
        [ForeignKey("VehicleId")]
        [NotMapped]
        public VehicleDto Vehicle { get; set; }

        [Index("IX_NameClient", 2, IsUnique = true)]
        [Column("OwnerId")]
        public int OwnerId { get; set; }

        /// <summary>
        /// The owner of the bot
        /// </summary>
        [NotMapped] [ForeignKey("OwnerId")] public ClientDto Owner { get; set; }


        /// <summary>
        ///     Bot waypoints
        /// </summary>
        public ICollection<BotWaypointDto> Waypoints { get; set; }
    }
}

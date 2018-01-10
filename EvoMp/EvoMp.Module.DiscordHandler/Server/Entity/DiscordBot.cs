using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.DiscordHandler.Server.Entity
{
    public class DiscordBot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("DiscordID")]
        public ulong DiscordId { get; set; }

        [Column("Token")]
        public string Token { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.UserHandler.Entity;

namespace EvoMp.Module.DiscordHandler.Entity
{
    public class DiscordServerMember

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("IngameUser")]
        public User User { get; set; }

        [Column("DiscordID")]
        public ulong DiscordId { get; set; }

        [Column("Nickalert")]
        public string Nickalert { get; set; }
    }
}
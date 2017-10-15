using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.DiscordHandler.Entity
{
  public class DiscordBotChannel

  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DiscordBot")]
    public DiscordBot DiscordBot { get; set; }

    [Column("ChannelID")]
    public ulong ChannelId { get; set; }

    [Column("ChannelName")]
    public string ChannelName { get; set; }
  }
}
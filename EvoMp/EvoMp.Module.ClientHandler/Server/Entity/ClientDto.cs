using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.ClientHandler.Server.Entity
{
    [Table("Clients")]
    public class ClientDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to set an username to register an account")]
        [MaxLength(32, ErrorMessage = "Your username can be up to 32 characters")]
        [MinLength(3, ErrorMessage = "Your username needs to be at least 3 characters")]
        [Index(IsUnique = true)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(16, ErrorMessage = "Your Social Club Name should not extend 16 characters")]
        [MinLength(3, ErrorMessage = "Your Social Club Name needs to be at least 3 characters")]
        [Column("Social_club_name")]
        public string SocialClubName { get; set; }

        [Required(ErrorMessage = "You have to set an password to register an account")]
        [Column("Password")]
        public string PasswordHash { get; set; }

        [Required] [Column("Salt")] public string Salt { get; set; }

        [Required(ErrorMessage = "You have to set an email to register an account")]
        [Column("Email")]
        public string Email { get; set; }

        [Required] [Column("Hwid")] public string HwId { get; set; }

        [Required] [Column("Created")] public DateTime Created { get; set; } = DateTime.Now;

        [Required] [Column("LastUpdate")] public DateTime LastUpdate { get; set; } = DateTime.Now;

        [Required] [Column("LastLogin")] public DateTime LastLogin { get; set; } = DateTime.Now;
    }
}

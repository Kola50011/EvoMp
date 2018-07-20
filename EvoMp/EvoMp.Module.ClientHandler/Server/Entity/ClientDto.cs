using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared.Math;

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

        [Required]
        [Column("Salt")]
        public string Salt { get; set; }

        [Required(ErrorMessage = "You have to set an email to register an account")]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Hwid")]
        public string HwId { get; set; }

        [Required]
        [Column("Created")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        [Column("LastUpdate")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        [Required]
        [Column("LastLogin")]
        public DateTime LastLogin { get; set; } = DateTime.Now;

        [NotMapped]
        public Vector3 Position {
            get => new Vector3(PosX, PosY, PosZ);
            set {
                PosX = value.X;
                PosY = value.Y;
                PosZ = value.Z;
            }
        }

        [NotMapped]
        public Vector3 Rotation {
            get => new Vector3(RotX, RotY, RotZ);
            set {
                RotX = value.X;
                RotY = value.Y;
                RotZ = value.Z;
            }
        }

        [Column("PosX")]
        private double PosX { get; set; }

        [Column("PosY")]
        private double PosY { get; set; }

        [Column("PosZ")]
        private double PosZ { get; set; }

        [Column("RotX")]
        private double RotX { get; set; }

        [Column("RotY")]
        private double RotY { get; set; }

        [Column("RotZ")]
        private double RotZ { get; set; }

        [Column("SkinHash")]
        public PedHash SkinHash { get; set; }

        [Column("Points")]
        public int Points { get; set; }
    }
}

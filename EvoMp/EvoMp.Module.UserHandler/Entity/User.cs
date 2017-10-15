using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.UserHandler.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to set an username to register an account")]
        [MaxLength(32, ErrorMessage = "Your username can be up to 32 characters")]
        [MinLength(3, ErrorMessage = "Your username needs to be at least 3 characters")]
        [Index(IsUnique = true)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(32)]
        [MinLength(3)]
        [Column("social_club_name")]
        public string SocialClubName { get; set; }

        [MaxLength(32)]
        [MinLength(3)]
        [Index(IsUnique = true)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [MaxLength(32, ErrorMessage = "Your first name can be up to 32 characters")]
        [MinLength(3, ErrorMessage = "Your last name needs to be at least 3 characters")]
        [Index(IsUnique = true)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You have to set an password to register an account")]
        [Column("password")]
        public string PasswordHash { get; set; }

        [Required]
        [Column("salt")]
        public string Salt { get; set; }

        [Required(ErrorMessage = "You have to set an email to register an account")]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("hwid")]
        public string HwId { get; set; }

        [Required]
        [Column("created")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        [Column("last_update")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        [Required]
        [Column("last_login")]
        public DateTime LastLogin { get; set; } = DateTime.Now;

        //Top of the Mt Chilad X:450.718 Y:5566.614 Z:806.183 
        [Required]
        [Column("pos_x")]
        public float PosX { get; set; } = (float) 450.718;

        [Required]
        [Column("pos_y")]
        public float PosY { get; set; } = (float) 5566.614;

        [Required]
        [Column("pos_z")]
        public float PosZ { get; set; } = (float) 806.183;

        [Required]
        [Column("rot_x")]
        public float RotX { get; set; } = 0;

        [Required]
        [Column("rot_y")]
        public float RotY { get; set; } = 0;

        [Required]
        [Column("rot_z")]
        public float RotZ { get; set; } = 0;
    }
}
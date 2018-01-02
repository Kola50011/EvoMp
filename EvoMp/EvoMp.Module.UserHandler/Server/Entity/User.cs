using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.UserHandler.Entity
{
    public class User
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
        [MaxLength(32)]
        [MinLength(3)]
        [Column("Social_club_name")]
        public string SocialClubName { get; set; }

        //[MaxLength(32)]
        //[MinLength(3)]
        //[Index(IsUnique = true)]
        [Column("First_name")]
        public string FirstName { get; set; }

        [MaxLength(32, ErrorMessage = "Your first name can be up to 32 characters")]
        [MinLength(3, ErrorMessage = "Your last name needs to be at least 3 characters")]
        //[Index(IsUnique = true)]
        [Column("Last_name")]
        public string LastName { get; set; }

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

        //Top of the Mt Chilad X:450.718 Y:5566.614 Z:806.183 
        [Required]
        [Column("PosX")]
        public float PosX { get; set; } = (float) 450.718;

        [Required]
        [Column("PosY")]
        public float PosY { get; set; } = (float) 5566.614;

        [Required]
        [Column("PosZ")]
        public float PosZ { get; set; } = (float) 806.183;

        [Required]
        [Column("RotX")]
        public float RotX { get; set; } = 0;

        [Required]
        [Column("RotY")]
        public float RotY { get; set; } = 0;

        [Required]
        [Column("RotZ")]
        public float RotZ { get; set; } = 0;
    }
}
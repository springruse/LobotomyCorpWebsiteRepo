using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureSQLTest.Models
{
    public class BioWeapon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Weapon_Name { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public string Attack_Type { get; set; }
        [Required]
        public int Attack_Damage { get; set; }
        [Required]
        public string Attack_Speed { get; set; }
        [Required]
        public string Weapon_Range { get; set; }
        [Required]
        public string Weapon_Description { get; set; }
    }
}

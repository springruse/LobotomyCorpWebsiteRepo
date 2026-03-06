using AzureSQLTest.Models;

namespace AzureSQLTest.Data
{
    public class BioWeaponDbService :IBioWeaponable
    {
        private ApplicationDbContext Context { get; set; }

        public BioWeaponDbService(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<BioWeapon> GetBioWeapons()
        {
            return Context.BioWeapons.ToList();
            
        }

        public void AddBioWeapon(BioWeapon bioWeapon)
        {
                Context.BioWeapons.Add(bioWeapon);
                Context.SaveChanges();
        }
        public void UpdateBioWeapon(BioWeapon bioWeapon)
        {
            var existing = Context.BioWeapons.Find(bioWeapon.Id);
            if (existing != null)
            {
                existing.Weapon_Name = bioWeapon.Weapon_Name;
                existing.Cost = bioWeapon.Cost;
                existing.Grade = bioWeapon.Grade;
                existing.Attack_Type = bioWeapon.Attack_Type;
                existing.Attack_Damage = bioWeapon.Attack_Damage;
                existing.Attack_Speed = bioWeapon.Attack_Speed;
                existing.Weapon_Range = bioWeapon.Weapon_Range;
                existing.Weapon_Description = bioWeapon.Weapon_Description;
                Context.SaveChanges();
            }
        }

        public void DeleteBioWeapon(int id)
        {
            var bioWeapon = Context.BioWeapons.Find(id);
            if (bioWeapon != null)
            {
                Context.BioWeapons.Remove(bioWeapon);
                Context.SaveChanges();
            }
        }


    }
}

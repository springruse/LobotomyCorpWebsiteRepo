using AzureSQLTest.Models;

namespace AzureSQLTest.Data
{
    public interface IBioWeaponable
    {
        public List<BioWeapon> GetBioWeapons();
        public void AddBioWeapon(BioWeapon bioWeapon);
        public void UpdateBioWeapon(BioWeapon bioWeapon);
        public void DeleteBioWeapon(int id);

    }
}

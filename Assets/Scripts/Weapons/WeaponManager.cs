using UnityEngine;
namespace Weapons
{
    public static class WeaponManager
    {
        private static readonly WeaponDataBase _weaponDataBase;

        static WeaponManager()
        {
            _weaponDataBase = Resources.Load("WeaponDataBase") as WeaponDataBase;
        }

        public static Weapon GetWeaponData(int id)
        {
            return _weaponDataBase.WeaponData[id];
        }
    }
}

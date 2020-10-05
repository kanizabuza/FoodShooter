using System;
using UnityEngine;
using Weapons;

namespace Players
{
    [DefaultExecutionOrder(1)]
    public class MagazineManager : MonoBehaviour
    {
        [NonSerialized] public PlayerMagazineInfo magazineInfo;
        private WeaponBase weapon;

        private void Start()
        {
            weapon = GetComponentInChildren<WeaponBase>();
            magazineInfo = new PlayerMagazineInfo(weapon.WeaponInfo.MaxAmmo);
        }
    }
}


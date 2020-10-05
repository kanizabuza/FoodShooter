using UnityEngine;

namespace Players
{
    /// <summary>
    /// Playerのアイテムの情報
    /// </summary>
    public struct PlayerMagazineInfo
    {
        private int currentAmmo;
        private readonly int maxAmmo;

        public int NowAmmo
        {
            get => currentAmmo;
            set => currentAmmo = Mathf.Clamp(value, 0, maxAmmo);

        }

        public PlayerMagazineInfo(int maxAmmo)
        {
            this.maxAmmo = maxAmmo;
            this.currentAmmo = maxAmmo;
        }
    }
}

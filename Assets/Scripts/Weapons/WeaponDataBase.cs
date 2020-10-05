using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu]
    internal class WeaponDataBase : ScriptableObject
    {
        [SerializeField] private Weapon[] _weaponData;
        public Weapon[] WeaponData => _weaponData;
    }

    [System.Serializable]
    public struct Weapon
    {
        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private float _shotInterval;
        [SerializeField] private int _power;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private float _recoilX;
        [SerializeField] private float _recoilY;
        [SerializeField] private float _accuracy;
        [SerializeField] private GameObject _bullet;

        public string Name => _name;
        public int ID => _id;
        public WeaponType WeaponType => _weaponType;
        public float ShotInterval => _shotInterval;
        public int Power => _power;
        public int MaxAmmo => _maxAmmo; //装弾数
        public float RecoilX => _recoilX; //反動・次の時間まで打てない
        public float RecoilY => _recoilY; //反動・次の時間まで打てない

        public float Accuracy => _accuracy; //誤差
        //public Sprite WeaponIcon;
        public GameObject Bullet => _bullet;
    }

    public enum WeaponType
    {
        SemiAuto,
        FullAuto,
    }
}
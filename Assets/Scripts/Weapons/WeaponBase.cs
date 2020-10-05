//using Photon.Pun;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private GameObject _muzzle;
        [SerializeField] private int _weaponId;
        public int WeaponId => _weaponId;
        private Weapon _weapon;
        public Weapon WeaponInfo => _weapon;
        private Camera _myCamera;

        //AudioSource aSource;
        //AudioClip aClip;

        private void Start()
        {
            _myCamera = GetComponentInParent<Camera>();
            _weapon = WeaponManager.GetWeaponData(0);

            //aSource = GameObject.Find("SEAudio").GetComponent<AudioSource>();
            //aClip = Resources.Load("Fire") as AudioClip;
        }

        public virtual void Fire()
        {
            Ray ray = _myCamera.ScreenPointToRay(new Vector3(Screen.width / 2f + 17, Screen.height / 2f - 15, 0) + new Vector3(Random.Range(-_weapon.Accuracy, _weapon.Accuracy), Random.Range(-_weapon.Accuracy, _weapon.Accuracy), 0));
            RaycastHit hit;
            var point = new Vector3();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                point = hit.point;
            }
            else
            {
                point = ray.origin + ray.direction * 1000;
            }

            _muzzle.transform.LookAt(point);

            //aSource.Stop();
            //aSource.clip = aClip;
            //aSource.Play();

            _myCamera.transform.localEulerAngles += new Vector3(WeaponManager.GetWeaponData(_weaponId).RecoilX, WeaponManager.GetWeaponData(_weaponId).RecoilY, 0);

            Instantiate(_weapon.Bullet,_muzzle.transform.position,_muzzle.transform.rotation);

            //pun入れたらコメント消して
            //PhotonNetwork.Instantiate(weapon.Bullet.name, muzzle.transform.position, muzzle.transform.rotation);
        }

    }
}


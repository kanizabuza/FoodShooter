using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Weapons;

namespace Players
{
    public class PlayerShoot : MonoBehaviour
    {
        private PlayerInput _input;
        private MagazineManager _magazineManager;
        private WeaponBase _weapon;
        private bool _onReload;

        private void Start()
        {
            _input = GetComponent<PlayerInput>();
            _magazineManager = GetComponent<MagazineManager>();
            _weapon = GetComponentInChildren<WeaponBase>();

            _input.FullAutoStream
                //.Where(_ => !GameManager.Instance.IsGameEnd)
                .ThrottleFirst(TimeSpan.FromSeconds(_weapon.WeaponInfo.ShotInterval))
                //.Where(_ => photonView.IsMine)
                .Where(_ => _weapon.WeaponInfo.WeaponType == WeaponType.FullAuto)
                .Where(_ => _magazineManager.magazineInfo.NowAmmo > 0)
                .Subscribe(_ => {
                    _weapon.Fire();
                    _magazineManager.magazineInfo.NowAmmo--;
                }).AddTo(gameObject);

            
            _input.SemiAutoStream
                //.Where(_ => !GameManager.Instance.IsGameEnd)
                .Where(_ => _weapon.WeaponInfo.WeaponType == WeaponType.SemiAuto)
                .Where(_ => _magazineManager.magazineInfo.NowAmmo > 0)
                //.Where(_ => photonView.IsMine)
                .Subscribe(_ => {
                    _weapon.Fire();
                    _magazineManager.magazineInfo.NowAmmo--;
                }).AddTo(gameObject);

            _input.ReloadStream
                //.Where(_ => !GameManager.Instance.IsGameEnd)
                //.Where(_ => photonView.IsMine)
                .Where(_ => !_onReload)
                .Subscribe(_ => Reload());
        }

        private void Reload()
        {
            if (_magazineManager.magazineInfo.NowAmmo >= _weapon.WeaponInfo.MaxAmmo) { return; }

            _onReload = true;

            _magazineManager.magazineInfo.NowAmmo += _weapon.WeaponInfo.MaxAmmo;

            _onReload = false;
        }
    }
}


using System;
using UnityEngine;

namespace Weapons.Bullets
{
    /// <summary>
    /// これを継承したクラスをバレットにアタッチしよーね。
    /// </summary>
    /// TODO: 距離減衰とかやるかも
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] private float speed;
        protected float Speed => speed;
        [SerializeField] private float power;
        public float Power => power;
        protected string TargetTag = "Player";

        protected virtual void Start()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * Speed;
            Destroy(gameObject, 5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(TargetTag)) { return; }

            //TODO: ここでダメージ
            Debug.Log("Hit!!");
        }
    }
}

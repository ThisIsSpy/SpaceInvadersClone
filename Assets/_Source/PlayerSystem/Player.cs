using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemySystem;
using HUDSystem;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        [field: SerializeField] public AudioClip DeathSFX { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public GameObject Projectile {  get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        public Rigidbody2D Rb => _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<EnemyProjectile>())
            {
                Health -= collision.gameObject.GetComponent<EnemyProjectile>().Damage;
                if (Health <= 0)
                {
                    GameOverListener.ShowGameOver();
                    AudioSource.PlayOneShot(DeathSFX);
                    Destroy(gameObject);
                }
            }
        }
    }
}

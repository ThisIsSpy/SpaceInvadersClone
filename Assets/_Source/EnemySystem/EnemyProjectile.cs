using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyProjectile : MonoBehaviour
    {
        private AudioSource _audioSource;
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public AudioClip[] SFX { get; private set; }
        private void Awake()
        {
            _audioSource = GameObject.FindWithTag("SFXPlayer").GetComponent<AudioSource>();
            _audioSource.PlayOneShot(SFX[0]);
        }
        private void Update()
        {
            DestroyOnScreenExit();
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Player>())
            {
                Destroy(gameObject);
            }
        }
        private void DestroyOnScreenExit()
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPosition.y > Screen.height || screenPosition.y < 0)
            {
                _audioSource.PlayOneShot(SFX[1]);
                Destroy(gameObject);
            }
        }
    }
}

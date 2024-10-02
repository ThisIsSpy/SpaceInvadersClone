using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem;
using ScoreSystem;

namespace EnemySystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float MovementIncrement { get; private set; }
        [field: SerializeField] public float ScorePrize { get; private set; }
        [field: SerializeField] public GameObject Projectile { get; private set; }
        public Rigidbody2D Rb => _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerProjectile>())
            {
                Health -= collision.gameObject.GetComponent<PlayerProjectile>().Damage;
                if (Health <= 0)
                {
                    ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                    scoreManager.AddToScore(ScorePrize);
                    Destroy(gameObject);
                }
            }
        }
        public void Attack()
        {
            GameObject projectileCopy = Instantiate(Projectile, new Vector3(transform.position.x,transform.position.y-1,1), new Quaternion(0,0,0,0));
            EnemyProjectile projectileProperties = projectileCopy.GetComponent<EnemyProjectile>();
            Rigidbody2D projectileRb = projectileCopy.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(-1 * projectileProperties.Speed * projectileCopy.transform.up, ForceMode2D.Impulse);
        }
    }
}

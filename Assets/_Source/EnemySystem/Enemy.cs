using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class Enemy : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public GameObject Projectile { get; private set; }
        public Rigidbody2D Rb => _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health -= 10;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

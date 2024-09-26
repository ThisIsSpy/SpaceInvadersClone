using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public GameObject Projectile {  get; private set; }
        public Rigidbody2D Rb => _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}

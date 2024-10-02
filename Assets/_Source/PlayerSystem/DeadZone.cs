using EnemySystem;
using HUDSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class DeadZone : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                GameOverListener.ShowGameOver();
                Destroy(FindObjectOfType<Player>());
            }
        }
    }
}
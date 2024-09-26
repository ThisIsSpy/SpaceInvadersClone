using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public static class PlayerCombat
    {
        public static void Shoot(GameObject projectile, Player player)
        {
            GameObject projectileCopy = Object.Instantiate(projectile, player.transform.position, player.transform.rotation);
            Projectile projectileProperties = projectileCopy.GetComponentInChildren<Projectile>();
            Rigidbody2D projectileRb = projectileCopy.GetComponentInChildren<Rigidbody2D>();
            projectileRb.AddForce(projectileCopy.transform.up * projectileProperties.Speed, ForceMode2D.Impulse);
            
        }
    }
}


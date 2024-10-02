using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public static class PlayerCombat
    {
        public static void Shoot(GameObject projectile, Player player)
        {
            GameObject projectileCopy = Object.Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y+1,0)/*player.transform.position*/, player.transform.rotation);
            PlayerProjectile projectileProperties = projectileCopy.GetComponent<PlayerProjectile>();
            Rigidbody2D projectileRb = projectileCopy.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(projectileCopy.transform.up * projectileProperties.Speed, ForceMode2D.Impulse);
            
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInvoker
    {
        private Player _player;

        public PlayerInvoker(Player player)
        {
            _player = player;
        }
        public void InvokeMove()
        {
            PlayerMovement.Move(_player.Rb, _player.MovementSpeed);
        }
        public void InvokeShoot()
        {
            PlayerCombat.Shoot(_player.Projectile,_player);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public static class PlayerMovement
    {
        public static void Move(Rigidbody2D rb, float movementSpeed)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2 (xMove, 0) * movementSpeed;
        }
    }
}

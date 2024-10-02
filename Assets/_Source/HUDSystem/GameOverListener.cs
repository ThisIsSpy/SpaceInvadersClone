using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace HUDSystem
{
    public static class GameOverListener
    {
        public static void ShowGameOver()
        {
            GameObject.FindObjectOfType<GameOverScreen>().gameObject.transform.position = Vector3.zero;
        }
    }
}

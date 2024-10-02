using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreManager : MonoBehaviour
    {
        private float _score;
        private void Awake()
        {
            _score = 0;
        }
        public void AddToScore(float addedScore)
        {
            _score += addedScore;
        }
        public float GetScore()
        {
            return _score;
        }
    }
}

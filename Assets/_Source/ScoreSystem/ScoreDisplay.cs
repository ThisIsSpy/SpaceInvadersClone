using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreDisplay : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }
        private ScoreManager _scoreManager;

        private void Awake()
        {
            ScoreText.text = "0";
            _scoreManager = FindObjectOfType<ScoreManager>();
        }
        private void Update()
        {
            ScoreText.text = $"{_scoreManager.GetScore()}";
        }
    }
}
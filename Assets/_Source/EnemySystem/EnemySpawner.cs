using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private GameObject[,] _enemyArr = new GameObject[4,10];
        private float _ogStartingX;
        private float _ogStartingY;
        [field: SerializeField] public float StartingX { get; private set; }
        [field: SerializeField] public float StartingY { get; private set; }
        [field: SerializeField] public GameObject Enemy { get; private set; }

        private void Awake()
        {
            _ogStartingX = StartingX;
            _ogStartingY = StartingY;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    _enemyArr[i, j] = Instantiate(Enemy, new Vector3(StartingX,StartingY,0), new Quaternion(0,0,0,0));
                    StartingX += 1;
                }
                StartingY -= 1;
                StartingX = _ogStartingX;
            }
        }
    }
}

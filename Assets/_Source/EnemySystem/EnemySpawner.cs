using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace EnemySystem
{
    public class EnemySpawner : MonoBehaviour
    {
        private GameObject[,] _enemyArr = new GameObject[4,10];
        private float _ogStartingX;
        private float _ogStartingY;
        private float _ogInterval;
        private int _direction;
        private bool _mustChangeDirection;
        private Vector3 _center;
        [field: SerializeField] public float Interval { get; private set; }
        [field: SerializeField] public float StartingX { get; private set; }
        [field: SerializeField] public float StartingY { get; private set; }
        [field: SerializeField] public int GridHeight { get; private set; }
        [field: SerializeField] public int GridLength { get; private set; }
        [field: SerializeField] public GameObject Enemy { get; private set; }
        IEnumerator EnemyAttackCoroutine()
        {
            yield return new WaitForSeconds(Random.Range(1,5));
            bool _hasFired = false;
            for(int i = 0; i < GridHeight; i++)
            {
                for(int j = 0; j < GridLength; j++)
                {
                    if (_enemyArr[i,j] == null)
                    {
                        continue;
                    }
                    if (Random.Range(1, 10) % 2 == 0)
                    {
                        _enemyArr[i,j].GetComponent<Enemy>().Attack();
                        _hasFired = true;
                        break;
                    }
                }
                if (_hasFired)
                {
                    Debug.Log("Broken");
                    break;
                }
            }
            StartCoroutine(EnemyAttackCoroutine());
        }
        IEnumerator EnemyMovementSideToSideCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridLength; j++)
                {
                    if (_enemyArr[i, j] == null)
                    {
                        continue;
                    }
                    _enemyArr[i, j].transform.position = Vector3.MoveTowards(_enemyArr[i, j].transform.position, new Vector3(_enemyArr[i, j].transform.position.x + (_enemyArr[i, j].GetComponent<Enemy>().MovementSpeed * _direction), _enemyArr[i, j].transform.position.y, _enemyArr[i, j].transform.position.z),0.2f);
                    if(j == 0 || j == 9)
                    {
                        if (Mathf.Abs(Vector3.Distance(_enemyArr[i,j].transform.position,_center)) >= 8)
                        {
                            _mustChangeDirection = true;
                        }
                    }
                    yield return new WaitForSeconds(Interval);
                }
            }
            if(_mustChangeDirection)
            {
                _direction *= -1;
                _mustChangeDirection = false;
                StartCoroutine(EnemyMovementDownCoroutine());
            }
            else
            {
                StartCoroutine(EnemyMovementSideToSideCoroutine());
            }
            
        }
        IEnumerator EnemyMovementDownCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            for(int i = 0; i < GridHeight; i++)
            {
                for (int j = 0;j < GridLength; j++)
                {
                    if (_enemyArr[i, j] == null)
                    {
                        continue;
                    }
                    _enemyArr[i, j].transform.position = Vector3.MoveTowards(_enemyArr[i, j].transform.position, new Vector3(_enemyArr[i, j].transform.position.x, _enemyArr[i, j].transform.position.y - _enemyArr[i, j].GetComponent<Enemy>().MovementSpeed, _enemyArr[i, j].transform.position.z),0.2f);
                }
                yield return new WaitForSeconds(Interval);
            }
            StartCoroutine(EnemyMovementSideToSideCoroutine());
        }
        private void Awake()
        {
            _ogStartingX = StartingX;
            _ogStartingY = StartingY;
            _ogInterval = Interval;
            _direction = 1;
            _mustChangeDirection = false;
            Interval = 0.2f;
            _center = transform.TransformPoint(Vector3.zero);
            for(int i = 0; i < GridHeight; i++)
            {
                for(int j = 0; j < GridLength; j++)
                {
                    _enemyArr[i, j] = Instantiate(Enemy, new Vector3(StartingX,StartingY,0), new Quaternion(0,0,0,0));
                    StartingX++;
                }
                StartingY--;
                StartingX = _ogStartingX;
            }
            StartCoroutine(EnemyAttackCoroutine());
            StartCoroutine(EnemyMovementSideToSideCoroutine());
        }
        private void Update()
        {
            int intervalChange = 0;
            foreach (GameObject enemy in _enemyArr)
            {
                if(enemy == null)
                {
                    intervalChange++;
                }
            }
            Interval = _ogInterval - (intervalChange/15);
        }
    }
}

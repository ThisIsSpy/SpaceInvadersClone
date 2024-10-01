using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    private void Update()
    {
        DestroyOnScreenExit();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void DestroyOnScreenExit()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }
}

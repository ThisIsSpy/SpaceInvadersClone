using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundPlayerToScreen : MonoBehaviour
{
    private Camera _camera;
    private Vector2 screenMin;
    private Vector2 screenMax;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        _camera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void LateUpdate()
    {
        screenMin = _camera.ViewportToWorldPoint(Vector2.zero);
        screenMax = _camera.ViewportToWorldPoint(Vector2.one);
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenMin.x + objectWidth, screenMax.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenMin.y + objectHeight, screenMax.y - objectHeight);
        transform.position = viewPos;
    }
}

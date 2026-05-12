using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollBoxArea : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public Vector2 GetRandomPoint()
    {
        Bounds bounds = boxCollider.bounds;
        return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
    }

    public Vector2 Clamp(Vector2 position)
    {
        Bounds bounds = boxCollider.bounds;
        return new Vector2(Mathf.Clamp(position.x, bounds.min.x, bounds.max.x), Mathf.Clamp(position.y, bounds.min.y, bounds.max.y));
    }

    public Bounds GetBounds() => boxCollider.bounds;
}

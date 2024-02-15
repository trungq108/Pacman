using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public  List<Vector2> availableDirection = new List<Vector2>();

    private void Start()
    {
        availableDirection.Clear();
        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.right);
        CheckAvailableDirection(Vector2.left);
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0f, direction, 1f, obstacleLayer);
        if(hit.collider == null)
        {
            availableDirection.Add(direction);
        }
    }
}

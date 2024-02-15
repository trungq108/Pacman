using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8f;
    public Vector2 direction;
    public Vector2 nextDirection;
    private Vector3 startPosition;
    public Rigidbody2D rigibody;
    public LayerMask obstacleLayer;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }
    private void Start()
    {
        resetState();
    }

    public void resetState()
    {
        nextDirection = Vector2.zero;
        transform.position = startPosition;
        rigibody.isKinematic = false;
        enabled = true;
    }

    private void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }

    }
    private void FixedUpdate()
    {
        Vector2 positon = transform.position;
        Vector2 move = direction * Time.fixedDeltaTime * speed;
        rigibody.MovePosition(positon + move);
    }
    public void SetDirection(Vector2 direct)
    {
        if (!Occupied(direct))
        {
            direction = direct;
            nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = direct;
        }
    }
    private bool Occupied(Vector2 direct)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, direct, 1.5f, obstacleLayer);
        return hit.collider != null;
    }

}

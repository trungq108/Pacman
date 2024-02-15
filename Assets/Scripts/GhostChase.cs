using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehavior
{
    private void OnDisable()
    {
        ghost.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (node != null && this.enabled && !ghost.frightended.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;
            foreach(Vector2 availableDirection in node.availableDirection)
            {
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y, 0f);
                float distance = (ghost.target.position - newPosition).sqrMagnitude;
                if(distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }
            ghost.movement.SetDirection(direction);
        }                     
    }
}

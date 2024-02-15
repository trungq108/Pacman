using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehavior
{
    private void OnDisable()
    {
        ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (node != null && this.enabled && !ghost.frightended.enabled)
        {
            int index = Random.Range(0,node.availableDirection.Count);
            if(node.availableDirection.Count > 1 && node.availableDirection[index] == -ghost.movement.direction)
            {
                index++;
                if(index >= node.availableDirection.Count)
                {
                    index = 0;
                }
            }
            ghost.movement.SetDirection(node.availableDirection[index]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        if(gameObject.activeInHierarchy)
        {
           StartCoroutine(ExitTransition());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            ghost.movement.SetDirection(-ghost.movement.direction);
        }
    }
    private IEnumerator ExitTransition()
    {
        ghost.movement.SetDirection(Vector2.up);
        ghost.movement.rigibody.isKinematic = true;
        ghost.movement.enabled = false;

        Vector3 position = transform.position;
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(position, outside.position, elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < duration)
        {
            ghost.SetPosition(Vector3.Lerp(inside.position, outside.position, elapsed/duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        ghost.movement.SetDirection(new Vector2(Random.value < 0.5 ? -1.0f : 1.0f , 0.0f));
        ghost.movement.rigibody.isKinematic =false;
        ghost.movement.enabled = true;
    }
}

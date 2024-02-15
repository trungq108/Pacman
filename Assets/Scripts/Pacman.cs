using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    private Movement moveMent;
    private SpriteRenderer spriteRenderer;
    public AnimatedSprite deathSequence;
    private Collider2D collider;
    private void Awake()
    {
        moveMent = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) 
        {
            moveMent.SetDirection(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveMent.SetDirection(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveMent.SetDirection(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveMent.SetDirection(Vector2.down);
        }
        float angle = Mathf.Atan2(moveMent.direction.y, moveMent.direction.x);
        transform.rotation=Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
    public void ResetState()
    {
        enabled = true;
        spriteRenderer.enabled = true;
        collider.enabled = true;
        deathSequence.enabled = false;
        moveMent.resetState();
        this.gameObject.SetActive(true);
    }
    public void DeathSequence()
    {
        enabled = false;
        collider.enabled = false;
        spriteRenderer.enabled=false;
        moveMent.enabled = false;
        deathSequence.enabled = true;
        deathSequence.Restart();
    }

}

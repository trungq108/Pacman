using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    public Sprite up;
    public Sprite down;
    public Sprite right;
    public Sprite left;

    private SpriteRenderer spriteRenderer;
    private Movement movement;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<Movement>();
    }
    private void Update()
    {
        if(movement.direction == Vector2.up)
        {
            spriteRenderer.sprite = up;
        }
        else if (movement.direction == Vector2.down)
        {
            spriteRenderer.sprite = down;
        }
        else if (movement.direction == Vector2.right)
        {
            spriteRenderer.sprite = right;
        }
        else if (movement.direction == Vector2.left)
        {
            spriteRenderer.sprite = left;
        }
    }
}

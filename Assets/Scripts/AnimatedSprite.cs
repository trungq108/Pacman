using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float animationTime = 0.25f;
    public int animationFrame;
    public bool loop;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    void Advance()
    {
        if(!spriteRenderer.enabled)
        {
            return;
        }
        animationFrame++;
        if(animationFrame >= sprites.Length && loop)
        {
            animationFrame = 0;
        }
        if (animationFrame >= 0 && animationFrame < sprites.Length) 
        {
            spriteRenderer.sprite = sprites[animationFrame];
        }
    }
    public void Restart()
    {
        animationFrame = -1;
        Advance();
    }
}

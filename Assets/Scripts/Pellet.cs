using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public class Pellet : MonoBehaviour
{
    public int point = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eaten();
        }          
    } 
    protected virtual void Eaten()
    {
        GameManager.Instance.PelletEeten(this);
    }
    
}
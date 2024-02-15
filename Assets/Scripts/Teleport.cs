using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Ghost")
        {
            other.transform.position = connection.position;
        }
    }
}

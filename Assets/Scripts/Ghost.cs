using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ghost : MonoBehaviour
{
    public int point = 200;
    public Movement movement { get; private set; }
    public GhostHome home { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightended { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostBehavior initiaBehavior;
    public Transform target;

    private void Awake()
    {
        movement= GetComponent<Movement>();
        home = GetComponent<GhostHome>();
        chase = GetComponent<GhostChase>();
        frightended = GetComponent<GhostFrightened>();
        scatter = GetComponent<GhostScatter>();
    }
    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.resetState();
        frightended.Disable();
        chase.Disable();
        scatter.Enable();
        if (home != initiaBehavior)
        {
            home.Disable();
        }
        if (initiaBehavior != null)
        {
            initiaBehavior.Enable();
        }
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
            {
                if (frightended.enabled)
                {
                    GameManager.Instance.GhostEaten(this);
                }
                else
                {
                    GameManager.Instance.PacmanEaten();
                }
            }
    }

}

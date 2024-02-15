using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Pacman pacMan;
    public Ghost[] ghosts;
    public Transform pellets;

    private int live = 3;
    private int score = 0;
    private int ghostMutiplier = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        NewGame();
    }
    private void Update()
    {
        if(Input.anyKeyDown && live <= 0)
        {
            NewGame();
        }
    }
    void NewGame()
    {
        SetLive(3);
        SetScore(0);
        NewRound();
    }
    void NewRound()
    {
        foreach (Transform pellet in pellets) 
        {
            pellets.gameObject.SetActive(true);
        }
        ResetState();
    }
    void ResetState()
    {
        for(int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }
        pacMan.ResetState();

    }
    void GameOver()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }
        pacMan.gameObject.SetActive(false);
    }
    public void PacmanEaten()
    {
        pacMan.DeathSequence();
        SetLive(live - 1);
        if(live > 0)
        {
            Invoke(nameof(ResetState), 1.0f);
        }
        else
        {
            GameOver();
        }
    }
    public void GhostEaten(Ghost ghost)
    {
        int point = ghost.point * ghostMutiplier;
        SetScore(score + point);
        ghostMutiplier++;
    }
    void SetLive(int lives)
    {
        live = lives; 
    }
    void SetScore(int scores)
    {
        score = scores;
    }
    public void PelletEeten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);
        SetScore(score + pellet.point);
        if (IsClear())
        {
            pacMan.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }

    }
    public void PowerPelletEaten(PowerPellet pellet)
    {
        for(int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].frightended.Enable(pellet.duration);
        }

        PelletEeten(pellet);
        CancelInvoke(nameof(ResetGhostMutiplied));
        Invoke(nameof(ResetGhostMutiplied), pellet.duration);
    }
    private bool IsClear() 
    { 
        foreach(Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
    private void ResetGhostMutiplied()
    {
        ghostMutiplier = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    public BoxSpawner box_Spawner;

    [HideInInspector]
    public BoxScript currentBox;

    private int moveCount;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        AudioManager.instance.Play("ThemeDroppingBox");
        box_Spawner.SpawnBox();
    }

    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 0.1f);
    }

    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void CountScore()
    {

        moveCount++;
        ScoringBar.instance.IncrementScore(1f);

        if (moveCount == 6)
        {
            // RestartGame();
        }

    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public bool CheckMoveCountIs0()
    {
        if (moveCount == 0)
        {
            return true;
        }
        return false;
    }

    public bool CheckIsWon(int maxPoint)
    {
        if (moveCount == maxPoint)
        {
            return true;
        }
        return false;
    }
}

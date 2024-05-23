using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;

    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public static GameManager instance;

    public enum GameState
    { 
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver, // Game does not finish
        GameEnd // Game Finish
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        if (levels.Length > 0)
        {
            ChangeState(GameState.Briefing, levels[currentLevelIndex]);
        }
    }

    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitiateLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
            default:
                break;
        }
    }

    private void StartBriefing()
    {
        Debug.Log("Briefing started");
        ChangeState(GameState.LevelStart, currentLevel);
    }

    private void InitiateLevel()
    {
        Debug.Log("Level start");
        currentLevel.StartLevel();
        ChangeState(GameState.LevelIn, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("Level in " + currentLevel.gameObject.name);
    }

    private void CompleteLevel()
    {
        Debug.Log("Level end");
        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);
    }

    private void GameOver()
    {
        Debug.Log("Game over, you lose");
    }

    private void GameEnd()
    {
        Debug.Log("Game end, you win");
    }
}

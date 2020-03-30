using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;



public class GameManager : Manager<GameManager>
{
    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED,
        POSTGAME
    }

    public GameObject[] SystemPrefabs;

    List<GameObject> _instancedSystemPrefabs;

    GameState _currentGameState = GameState.PREGAME;

    string _currentLevelName = string.Empty;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set { _currentGameState = value; }
    }

    private void Start()
    {
        _instancedSystemPrefabs = new List<GameObject>();

        InstantiateSystemPrefabs();

    }

    private void Update()
    {
        if (_currentGameState == GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //TogglePause();
        }
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {

        if (_currentLevelName == "MainGameScene")
        {
            UpdateState(GameState.RUNNING);
            //Instance.InitSessions();
        }

        Debug.Log("Load Complete.");
    }


    void UpdateState(GameState state)
    {
        GameState previousGameState = _currentGameState;
        _currentGameState = state;

        switch (_currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1.0f;
                break;

            case GameState.RUNNING:
                Time.timeScale = 1.0f;
                break;

            case GameState.PAUSED:
                Time.timeScale = 0.0f;
                break;

            default:
                break;
        }

        //OnGameStateChanged.Invoke(_currentGameState, previousGameState);
    }

    void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instancedSystemPrefabs.Add(prefabInstance);
        }
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        ao.completed += OnLoadOperationComplete; // Delegate

        _currentLevelName = levelName;
    }

    public void UpdateLevel(string levelName)
    {
        _currentLevelName = levelName;
        OnLoadOperationComplete(null);
    }


    protected void OnDestroy()
    {
        if (_instancedSystemPrefabs == null)
            return;

        for (int i = 0; i < _instancedSystemPrefabs.Count; ++i)
        {
            Destroy(_instancedSystemPrefabs[i]);
        }
        _instancedSystemPrefabs.Clear();
    }

    public void StartGame()
    {
        LoadLevel("MainGameScene");
    }

   
}
using UnityEngine;

public class GameStateManager
{
    public delegate void GameStateChangeHandler(GameStates newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameStateManager();
            }
            return _instance;
        }
    }

    public GameStates CurrentGameState { get; private set; }
    public void SetState(GameStates newGameState)
    {
        if (newGameState == CurrentGameState)
        {
            return;
        }
        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}

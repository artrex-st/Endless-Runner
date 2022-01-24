using UnityEngine;

public sealed class EventManager : MonoBehaviour
{
    [SerializeField] private GameMode _gameMode;
    [SerializeField] private SaveGame _saveGame;
    [SerializeField] private PlayerController _playerControl;
    [SerializeField] private PlayerCollision _playerCollision;
    [SerializeField] private PlayerAnimationController _playerAnimationController;    
    [SerializeField] private AudioController _audioController;
    [SerializeField] private MainHUD _mainHUD;
    [SerializeField] private MainOverlay _mainOverlay;
    [SerializeField] private StartOverlay _startOverlay;
    [SerializeField] private SettingOverlay _settingOverlay;
    private void OnEnable()
    {
        _playerCollision.OnPlayerColliderHited += _gameMode.OnColision;        
        _playerControl.OnStartedTriggerAnimation += _playerAnimationController.OnStartedTriggerAnimation;
        _playerControl.OnStartedBoolAnimation += _playerAnimationController.OnStartedBoolAnimation;

        _audioController.OnLoadingSettingsData += _saveGame.OnLoadingSettingsData;
        _audioController.OnSavedSettingsData += _saveGame.OnSavedSettingsData;
        
        _gameMode.OnLoadingScoreData +=_saveGame.OnLoadingScoreData;
        _gameMode.OnSavedScoreData += _saveGame.OnSavedScoreData;
        _startOverlay.OnLoadingScoreData += _saveGame.OnLoadingScoreData;
        
        _settingOverlay.OnDeletedData += _saveGame.OnDeletedData;

        _mainHUD.OnPauseGame += _gameMode.OnPauseGame;
        _mainHUD.OnResumeGame += _gameMode.OnResumeGame;
        _mainHUD.OnClickedQuitGame += _gameMode.OnClickedQuitGame;
        _mainOverlay.OnStartedRun += _gameMode.OnStartedRun;
        _mainOverlay.OnOverlayStatusCalled += _gameMode.OnOverlayStatusCalled;

        _gameMode.OnStartedGameAnimation += _playerAnimationController.OnStartedGameAnimation;
    }
    private void OnDisable()
    {
        _playerCollision.OnPlayerColliderHited -= _gameMode.OnColision;        
        _playerControl.OnStartedTriggerAnimation -= _playerAnimationController.OnStartedTriggerAnimation;
        _playerControl.OnStartedBoolAnimation -= _playerAnimationController.OnStartedBoolAnimation;

        _audioController.OnLoadingSettingsData -= _saveGame.OnLoadingSettingsData;
        _audioController.OnSavedSettingsData -= _saveGame.OnSavedSettingsData;

        _gameMode.OnLoadingScoreData -=_saveGame.OnLoadingScoreData;
        _gameMode.OnSavedScoreData -= _saveGame.OnSavedScoreData;
        _startOverlay.OnLoadingScoreData -= _saveGame.OnLoadingScoreData;
        
        _settingOverlay.OnDeletedData -= _saveGame.OnDeletedData;
        
        _mainHUD.OnPauseGame -= _gameMode.OnPauseGame;
        _mainHUD.OnResumeGame -= _gameMode.OnResumeGame;
        _mainHUD.OnClickedQuitGame -= _gameMode.OnClickedQuitGame;
        _mainOverlay.OnStartedRun -= _gameMode.OnStartedRun;
        _mainOverlay.OnOverlayStatusCalled -= _gameMode.OnOverlayStatusCalled;

        _gameMode.OnStartedGameAnimation += _playerAnimationController.OnStartedGameAnimation;
    }
}

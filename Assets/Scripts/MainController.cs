using Ui;
using Game;
using Profile;
using UnityEngine;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private TrailRenderer _trailRenderer;
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsMenuController _settingsMenuController;


    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    private void DisposeAllControllers()
    {
        
        _mainMenuController?.Dispose();
        _settingsMenuController?.Dispose();
        _gameController?.Dispose();
    }

    protected override void OnDispose()
    {
        DisposeAllControllers();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                DisposeAllControllers();
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Settings:
                DisposeAllControllers();
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Game:
                DisposeAllControllers();
                _gameController = new GameController(_profilePlayer);
                break;
            default:
                DisposeAllControllers();
                break;
        }
    }
}

using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{ 
 
    private const float SpeedCar = 15f;
    private const GameState InitialState = GameState.Start;

    [SerializeField] private Transform _placeForUi;
    [SerializeField] private TrailRenderer _trailRenderer;
    
    private MainController _mainController;


    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(SpeedCar, InitialState, TransportType.Boat);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}

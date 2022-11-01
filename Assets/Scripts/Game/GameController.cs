using Game.Car;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tool;

namespace Game
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            LoadTransportController(profilePlayer.transportType);
        }

        private void LoadTransportController(TransportType transportType)
        {
            TransportController transportController;
            switch (transportType)
            {
                case TransportType.Car:
                    transportController = new CarController();
                    break;
                case TransportType.Boat:
                    transportController = new BoatController();
                    break;
                default:
                    transportController = null;
                    break;

            }

            if (transportController != null)
            {
                AddController(transportController);
            }
        }
    }
}

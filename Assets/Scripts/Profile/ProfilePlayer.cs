using Game.Boat;
using Game.Car;
using Tool;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public TransportModel CurrentCar;
        public TransportType transportType;


        public ProfilePlayer(float speedCar, GameState initialState, TransportType transportType) : this(speedCar)
        {
            CurrentState.Value = initialState;
            this.transportType = transportType;

            LoadCar(speedCar);
        }

        private void LoadCar(float speedCar)
        {
            switch (transportType)
            {
                case TransportType.Car:
                    CurrentCar = new CarModel(speedCar);
                    break;
                case TransportType.Boat:
                    CurrentCar = new BoatModel(speedCar);
                    break;
                default:
                    CurrentCar = null;
                    break;
            }
        }

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
        }
    }
}

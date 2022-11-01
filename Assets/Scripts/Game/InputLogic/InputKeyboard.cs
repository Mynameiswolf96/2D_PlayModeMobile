using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputKeyboard : BaseInputView
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);


        private void Move()
        {
            Vector3 direction = CalcDirection();
            float moveValue = _speed * Time.deltaTime * direction.x;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
                OnRightMove(abs);
            else
                OnLeftMove(abs);
        }

        private Vector3 CalcDirection()
        {
            Vector3 direction = Vector3.zero;
            direction.x = Input.GetAxis(HORIZONTAL_AXIS);

            return direction;
        }
    }
}

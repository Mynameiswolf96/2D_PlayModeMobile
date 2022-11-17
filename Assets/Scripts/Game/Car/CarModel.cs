using System.Collections;
using System.Collections.Generic;
using Features.Shed.Upgrade;
using UnityEngine;

namespace Game.Car
{


    internal class CarModel : IUpgradable
    {
        private readonly float _defaultSpeed;
        
        public float Speed { get; set; }

        public CarModel(float speed)
        {
            _defaultSpeed = speed;
            Speed = speed;
        }

        public void Restore() =>
            Speed = _defaultSpeed;
    }
}
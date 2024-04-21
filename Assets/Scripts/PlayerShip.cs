using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerShip : MonoBehaviour , CannonBallCollision
    {
        CannonBall cannonBall;
        [SerializeField] float _shipHealth;
        void Update()
        {
            
        }
        public void OnCannonBallHit()
        {
            Debug.Log(cannonBall.CannonBallDamage);
            Debug.Log(_shipHealth);
            _shipHealth = _shipHealth;
        }
    }
}

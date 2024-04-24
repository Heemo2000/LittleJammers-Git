using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerShip : MonoBehaviour , CannonBallCollision
    {
        CannonBall cannonBall;
        [SerializeField] GameObject _preFabCannonBall;
        [SerializeField] int _shipHealth;
        void Awake()
        {
            cannonBall = _preFabCannonBall.GetComponent<CannonBall>();
        }
        void Update()
        {
            
        }
        public void OnCannonBallHit()
        {
            _shipHealth = _shipHealth - cannonBall.CannonBallDamage;
            Debug.Log(_shipHealth);
            if(_shipHealth <= 0)
            {
                Destroy(gameObject);
                // Destroy Animation
            }
        }
    }
}

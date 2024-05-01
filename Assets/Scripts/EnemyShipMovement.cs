using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemyShipMovement : Movement
    {
        [Header("Enemy settings")]
        [SerializeField]private Transform target;
        [SerializeField]private float stoppingDistance;
        [Min(0.0f)]
        [SerializeField]private float maxRayCheckDistance = 100.0f;
        [SerializeField]private LayerMask playerMask;
        private bool _isTargetInFront;

        private float _requiredRudderTurn = 0.0f;

        // Update is called once per frame
        protected override void Update()
        {
            float squareDistance = Vector2.SqrMagnitude(target.position - transform.position);
            Debug.Log("Square Distance: " +squareDistance);
            if(squareDistance > stoppingDistance * stoppingDistance)
            {
                base.isAnchored = false;
                
                Vector2 direction = (target.position - transform.position).normalized;
                
                _requiredRudderTurn = direction.x == 0.0f ? 0.0f : Mathf.Sign(direction.x);
                if(_isTargetInFront)
                {
                    Debug.DrawLine(transform.position, target.position, Color.green);
                    _requiredRudderTurn = 0.0f;
                }
                else
                {
                    base.SailPos += base.sailTurnSpeed;    
                }
                if(_requiredRudderTurn == 0.0f)
                {
                    RudderTurn = 0.0f;
                }
                else
                {
                    RudderTurn += _requiredRudderTurn * base.rudderTurnSpeed;
                }
                
            }
            else
            {
                base.isAnchored = true;
            }
            base.Update();
        }

        private void FixedUpdate() 
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + transform.up * maxRayCheckDistance, playerMask.value);
            _isTargetInFront = hit.collider != null;
        }
    }
}

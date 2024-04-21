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

        // Update is called once per frame
        protected override void Update()
        {
            float squareDistance = Vector2.SqrMagnitude(target.position - transform.position);
            if(squareDistance > stoppingDistance * stoppingDistance)
            {
                Debug.Log("Following player");
                Vector2 direction = (target.position - transform.position).normalized;
                base.SailPos += direction.y * base.sailTurnSpeed;
                RudderTurn += direction.x * rudderTurnSpeed;
            }
            base.Update();
        }
    }
}

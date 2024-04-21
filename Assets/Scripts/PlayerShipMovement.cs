using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerShipMovement : Movement
    {
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        protected override void Update()
        {
            //let you turn tha sail
            base.SailPos += Input.GetAxis("Vertical") * sailTurnSpeed;
            float rudderInput = Input.GetAxis("Horizontal");
            RudderTurn += rudderInput * rudderTurnSpeed;
            base.Update();
        }
    }
}

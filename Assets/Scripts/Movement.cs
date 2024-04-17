using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Movement : MonoBehaviour
    {
        public bool doUseWind;
        public float sailTurnSpeed;
        public float turnSpeed;
        public float rudderTurnSpeed;
        public float speed;
        public GameObject ship;
        public GameObject windIndicator;
        public GameObject sail;
        public GameObject rudder;
        public bool isAnchored;
        
    
        private float windDirection;
        private bool isWindChangeSet;
    	private float windTimer;
    	private float windDownTime;
        private float windChange;
        private float localWind;
        private float sailPos;
        private float rudderTurn;
        private float windModifier;
    
        void Update()
        {
        
            //Do wind Thingis.
        	if(!isWindChangeSet)
    		{
    			SetWindChange();
    		}
    		else
    		{
    			ChangeWind();
    		} 
    
            //turns wind indicator arrow
            windIndicator.transform.rotation = Quaternion.Euler(0, 0, windDirection);   
    
            //let you turn tha sail
            sailPos += Input.GetAxis("Vertical") * sailTurnSpeed;
            sailPos = Mathf.Clamp(sailPos, -90f, 90f);
            sail.transform.localRotation = Quaternion.Euler(0, 0, sailPos); 
    
            //calculates wind relative to the sail.
            if (doUseWind)
            {   
                Quaternion shipRotation = transform.rotation;
                float windToShip = Quaternion.Angle(Quaternion.Euler(0, 0, windDirection), shipRotation);
                Quaternion sailRotation = sail.transform.rotation;
                windModifier = Quaternion.Angle(Quaternion.Euler(0, 0, windDirection), sailRotation);
                if (windModifier < -180)
                {
                    windModifier += 360;
                }
                if (windModifier > 180)
                {
                    windModifier -= 360;
                }
                //If in upwind, this would put the anchor down. No way out though. But it could be useful for some mechanic later on, to slightly punish going upwind.
                
                //if (Mathf.Abs(windToShip) > 175)
                // {
                //     isAnchored = true;
                // }
                windModifier = Mathf.Clamp01(Mathf.Abs(windModifier) / 90f);
            }
            else
            {
                windModifier = 1;
            }
    
            //calculations for moving the ship
            float rudderInput = Input.GetAxis("Horizontal");
            rudderTurn += rudderInput * rudderTurnSpeed;
            rudderTurn = Mathf.Clamp(rudderTurn, -35, 35);
            float turnAmount = rudderTurn * turnSpeed * Time.deltaTime;
            rudder.transform.localRotation = Quaternion.Euler(0, 0, rudderTurn);
            float speedWithWind = speed * windModifier;
    
            //actualy moves the ship
            if (!isAnchored)
            {
            transform.Translate(Vector3.up * speedWithWind * Time.deltaTime);
            transform.Rotate(Vector3.forward, -turnAmount);
            }
    
    
            
        }
    
        //Randomize where the wind will move
        void SetWindChange ()
    	{
    		if (windDownTime <= 0)
    		{
            //NUMBERS ARE FOR DEBUGING!!! CHANGE LATER!!!
    		windTimer = Random.Range(15f, 45f);
    		windChange = Random.Range(-0.003f, 0.003f);
    		isWindChangeSet = true;
    		}
    		else
    		{
    			windDownTime -= Time.deltaTime;
    		}
    	}
    
        //aply the wind changes
        void ChangeWind ()
    	{
    		windDirection += windChange;
    		windTimer -= Time.deltaTime;
    
        	if (windDirection > 180)
            {
                windDirection -= 360;
            }
    
            if (windDirection < -180)
            {
                windDirection += 360;
            }
    
    		if (windTimer <= 0)
    		{
    			windDownTime = Random.Range(30f, 120f);
    			isWindChangeSet = false;	
    		}
    	}
    }

}

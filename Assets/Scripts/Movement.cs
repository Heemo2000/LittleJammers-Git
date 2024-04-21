using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Movement : MonoBehaviour
    {       
        public bool isAnchored;

        [SerializeField]
        protected float sailTurnSpeed;

        [SerializeField]
        private float _turnSpeed;

        [SerializeField]
        protected float rudderTurnSpeed;

        [SerializeField]
        private float _maxSpeed;

        [SerializeField]
        private GameObject _sail;

        [SerializeField]
        private GameObject _rudder;

        [SerializeField]
        private GameObject _windIndicator;
        

        private float _windDirection;
        private float _sailPos;
        private float _rudderTurn;
        private float _windModifier;
        private float _realTurnSpeed;

        public float SailPos { get => _sailPos; set => _sailPos = value; }
        public float RudderTurn { get => _rudderTurn; set => _rudderTurn = value; }

        protected virtual void Update()
        {
            _realTurnSpeed = _turnSpeed;
            //went a bit overboard with keeping things private, but this was faster anyway.
            _windDirection = _windIndicator.transform.rotation.z;

    
            _sailPos = Mathf.Clamp(_sailPos, -90f, 90f);
            _sail.transform.localRotation = Quaternion.Euler(0, 0, _sailPos); 
    
            //calculates wind relative to the sail.
            Quaternion shipRotation = transform.rotation;
            Quaternion sailRotation = _sail.transform.rotation;
            float windToSail = Quaternion.Angle(Quaternion.Euler(0, 0, _windDirection + 90f), sailRotation);
            windToSail = Mathf.Repeat(windToSail + 180f, 360f) - 180f;
            if (_sailPos < 0)
            {
                windToSail -= 180f;
                windToSail = Mathf.Abs(windToSail);
            }

            //HeadWind
            if (windToSail >= 150f)
            {
                _windModifier = 0.2f;
                _realTurnSpeed *= 0.5f;
            }
            // 1/4 wind
            else if (windToSail >= 120)
            {
                _windModifier = 0.5f;
            }
            //FullWind
            else if (windToSail >= -30)
            {
                _windModifier = 1f;
            }
            else 
            {
                _windModifier = 0.75f;
            }


    
            //calculations for moving the ship
            
            
            RudderTurn = Mathf.Clamp(RudderTurn, -35, 35);
            float turnAmount = RudderTurn * _realTurnSpeed * Time.deltaTime;
            _rudder.transform.localRotation = Quaternion.Euler(0, 0, RudderTurn);
            float speedWithWind = _maxSpeed * _windModifier;
    
            //actualy moves the ship
            if (!isAnchored)
            {
            transform.Translate(Vector3.up * speedWithWind * Time.deltaTime);
            transform.Rotate(Vector3.forward, -turnAmount);
            }
    
    
            
        }
    }
}

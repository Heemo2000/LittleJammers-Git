using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] GameObject _firePoint;
        [SerializeField] GameObject _cannonBall;
        private bool _cannonFired;
        private void Start()
        {
            _cannonFired = false;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(!_cannonFired)
                {
                    _cannonFired = true;
                    Instantiate(_cannonBall, _firePoint.transform.position, _firePoint.transform.rotation);
                    StartCoroutine("CountDown");
                }
            }
        }
        IEnumerator CountDown()
        {
            yield return new WaitForSeconds(2);
            _cannonFired = false;
        }
    }
}

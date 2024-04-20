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
            if (Input.GetKeyDown(KeyCode.Space) && (_cannonFired = false))
            {
                _cannonFired = true;
                Instantiate(_cannonBall, _firePoint.transform.position, _firePoint.transform.rotation);
            }
        }
        IEnumerator CountDown()
        {
            if (_cannonFired)
            {
                yield return new WaitForSeconds(4);
            }
            _cannonFired = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private float _windDirection;
    private bool _isWindChangeSet;
    private float _windTimer;
    private float _windDownTime;
    private float _windChange;

    // Update is called once per frame
    void Update()
    {   
        //Randomize Wind Change and counts down.
        if(!_isWindChangeSet)
    	{
		    if (_windDownTime <= 0)
    		{
                //NUMBERS ARE FOR DEBUGING!!! CHANGE LATER!!!
    		    _windTimer = Random.Range(15f, 45f);
    		    _windChange = Random.Range(-0.003f, 0.003f);
    		    _isWindChangeSet = true;
    		}
    		else
    		{
    			_windDownTime -= Time.deltaTime;
    		}  
        } 	
        //apply wind chanfes
    	else
    	{
    		_windDirection += _windChange;
    		_windTimer -= Time.deltaTime;
            _windDirection = Mathf.Repeat(_windDirection + 180f, 360f) - 180f;
            
            if (_windTimer <= 0)
    		{
    			_windDownTime = Random.Range(30f, 120f);
    			_isWindChangeSet = false;	
    		}
    	} 

        //turns wind indicator arrow
        transform.rotation = Quaternion.Euler(0, 0, _windDirection);
    }
}

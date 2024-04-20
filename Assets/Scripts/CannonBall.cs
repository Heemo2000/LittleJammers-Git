using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float _cannonBallSpeed;
    [SerializeField] Rigidbody2D _rb;
    void Start()
    {
        _rb.velocity = Vector3.right * _cannonBallSpeed;
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        // Destroy Animation
    }
}

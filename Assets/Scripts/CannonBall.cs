using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float _cannonBallSpeed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] int _cannonBallDamage;
    public int CannonBallDamage
    {
        get { return _cannonBallDamage; }
    }
    void Start()
    {
        _rb.velocity = Vector3.right * _cannonBallSpeed;
        Destroy(gameObject, 5);
    }
    // What happens after collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        // Destroy Animation
        collision.collider.GetComponent<CannonBallCollision>()?.OnCannonBallHit();
    }
}

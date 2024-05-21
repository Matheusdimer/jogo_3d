using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 10;
    public float maximumVelocity = 3;
    
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var axis = Input.GetAxis("Horizontal");

        if (_rigidbody.velocity.magnitude < maximumVelocity)
        {
            _rigidbody.AddForce(new Vector3(axis * forceMultiplier, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hazard")) return;
        GameManager.GameOver();
        Destroy(gameObject);
    }
}

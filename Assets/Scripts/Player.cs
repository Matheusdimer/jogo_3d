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
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (_rigidbody.velocity.magnitude < maximumVelocity)
        {
            _rigidbody.AddForce(new Vector3(horizontal * forceMultiplier, 0, vertical * forceMultiplier));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hazard")) return;
        GameManager.GameOver();
        Destroy(gameObject);
    }
}

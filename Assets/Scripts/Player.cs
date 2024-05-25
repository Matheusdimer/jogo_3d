using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 10;
    public float maximumVelocity = 3;
    public float jumpForce = 0.5f;

    public GameManager gameManager;
    
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            gameManager.GameOver();
            return;
        }
        
        var xAxis = Input.GetAxis("Horizontal");
        var zAxis = Input.GetAxis("Vertical");
        
        var xVelocity = _rigidbody.velocity.x;
        var zVelocity = _rigidbody.velocity.z;
        
        _rigidbody.AddForce(new Vector3(CalculateForce(xVelocity, xAxis), 0, CalculateForce(zVelocity, zAxis)));

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private float CalculateForce(float axisVelocity, float axis)
    {
        // Direções contrárias, adiciona força
        if ((axisVelocity < 0 && axis > 0) || (axisVelocity > 0 && axis < 0))
        {
            return axis * forceMultiplier;
        }

        // Mesma direção, checa se não ultrapassou a velocidade máxima
        if (Math.Abs(axisVelocity) < maximumVelocity)
        {
            return axis * forceMultiplier;
        }

        return 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hazard")) return;
        gameManager.GameOver();
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            gameManager.IncrementScore();
        }
    }
    
    public bool IsGrounded() {
        float rayLength = 1.1f; // Adjust based on your character's size
        if (Physics.Raycast(transform.position, Vector3.down, out _, rayLength)) {
            return true;
        }
        return false;
    }
}

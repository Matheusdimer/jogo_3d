using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{

    private MeshCollider m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10),1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
        }
    }
}

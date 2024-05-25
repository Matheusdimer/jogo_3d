using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField] private float fov;

    private void LateUpdate()
    {
        if (player == null) return;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - fov);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    [Range(1, 10)]
    public float smoothness;

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (player != null)
        {
            //TargetPosition is the PlayerPosition
            Vector3 playerPosition = player.position;

            //These are the Constraints of the Camera
            playerPosition.z = transform.position.z;
            if (playerPosition.x < 0) playerPosition.x = 0;
            if (playerPosition.x > 20) playerPosition.x = 20;
            if (playerPosition.y < 0) playerPosition.y = 0;

            //Here we create the Smoothvectorfor the CameraPosition
            Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothness * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}

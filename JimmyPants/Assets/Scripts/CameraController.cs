using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //Camera follows player
    public float offset; //Number to offset camera position
    public float offsetSmoothing; //Smooth camera motion when offsets
    private Vector3 playerPosition; //Store players postion

    void Start()
    {
        
    }
    void Update()
    {
        //Camera follows player on x and y axis
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        //Player's direction to the right
        if(player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else //to the left
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        //How the camera catches up to the player and how smooth
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}

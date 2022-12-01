using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float projectileMoveSpeed;

    void Update()
    {
        //Moves the projectile to the left
        transform.position += Vector3.left * projectileMoveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Gameover on player collision
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameStateManager.GameOver();

        }

        //Despawns the projectile when colliding w/ a despawner
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Despawns the projectile when triggered w/ a despawner
        if (collision.CompareTag("Despawn"))
        {
            Destroy(gameObject);
        }
    }
}

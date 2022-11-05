using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool search;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bindingObj;
    [SerializeField] private float binding;



    void Start()
    {
        search = true;
        GameObject.Instantiate(bindingObj, new Vector3(binding, this.transform.position.y, this.transform.position.z), this.transform.rotation);
        GameObject.Instantiate(bindingObj, new Vector3(binding*-1, this.transform.position.y, this.transform.position.z), this.transform.rotation);
    }

    void Update()
    {
        if (search)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime, this.GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime * -1, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Binding")
        {
            if(search == true)
            {
                search = false;
            } else
            {
                search = true;
            }
        }//end binding
    }//end trigger
    private void OnColisionEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            //GameStateManager.GameOver();
        }//end killPlayer
    }//end collision
}

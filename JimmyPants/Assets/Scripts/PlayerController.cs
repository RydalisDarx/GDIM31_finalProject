using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects.
                             //We can apply forces to move a rigidbody.
    [SerializeField]
    private float force;   //Force to apply to the rigidbody
    private bool surfaced; //Player in contact with floor

    private void Awake()
    {
        //GetComponent() accesses RigidBody2D and stores in rb variable
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()   //Inputs are recorded every frame
    {
        //Moving along x axis
        float xInp = Input.GetAxisRaw("Horizontal");

        //Here is where some force is added to the ridged body (rb)
        rb.velocity = new Vector2(xInp * force, rb.velocity.y);

        /*
        //Make the player turn/flip when moving left and right
        if (xInp > 0.01f)
            transform.localScale = Vector3.one;
        else if (xInp < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        */

        //Detect if the space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space) && surfaced)
        {
            Jump(); //Player/rigidbody/bird jumps                                                
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, force); //Player jump mechanic
        //Player is not touching floor
        surfaced = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for player contact with floor/ground
        if(collision.gameObject.tag == "Floor")
        {
            //Player is in contact with floor
            surfaced = true;
        }

        if (collision.collider.tag == "GameOver")
        {
            //If collision occurs with another collider we call the GameOver() function from GameStateManager
            GameStateManager.GameOver();
            Debug.Log("Player flew into a pillar.");
        }
    }
}

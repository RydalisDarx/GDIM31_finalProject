using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D player;  //The rigid body is a Unity class that is used for physics objects.
                             //We can apply forces to move a rigidbody.
    [SerializeField]
    private float force;   //Force to apply to the rigidbody
    
    private float xInp = 0f; //Movement left right

    //Make sure player is in contact with floor to jump
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer; //specify layer "ground"
    private bool surfaced; //Player in contact with floor

    //Player Animation
    private Animator playerAnim;


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()   //Inputs are recorded every frame
    {
        //find position of groundCheck object, use players radius(circle around players feet), check for overlap of ground to be true/false
        surfaced = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Moving along x axis
        xInp = Input.GetAxis("Horizontal");

        //Here is where some force is added to the ridged body (player)
        //Moving left or right on x axis
        if(xInp > 0f){ 
            player.velocity = new Vector2(xInp * force, player.velocity.y);
        }
        else if(xInp < 0f){
            player.velocity = new Vector2(xInp * force, player.velocity.y);    
        }
        else{ //not moving
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //Detect if the space key is pressed down and player is in contact with ground
        //If both are true, the player jumps
        if (Input.GetKeyDown(KeyCode.Space) && surfaced)
        {
            player.velocity = new Vector2(player.velocity.x, force); //Player jump mechanic                                               
        }

        //update speed operator in animator
        playerAnim.SetFloat("Force", Mathf.Abs(player.velocity.x));
        //update boolean for player on ground or not
        playerAnim.SetBool("OnGround", surfaced);
    }
}

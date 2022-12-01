using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool isFinished; //Check that player did collide with collectible finish

    //Player Animation
    private Animator playerAnim;

    private Vector3 respawnLoc; //Location where the player starts/respawns
    public GameObject killBox;

    public Text collectedText;

    [SerializeField]
    private AudioSource jumpSound; //Jump sound element
    [SerializeField]
    private AudioSource finishSound; //Level completed sound element
    [SerializeField]
    private AudioSource deathSound; //Death sound element

    void Start()
    {
        player = GetComponent<Rigidbody2D>(); 
        playerAnim = GetComponent<Animator>();
        respawnLoc = transform.position; //Store position of player at start of game
        collectedText.text = "Pant Collection: " + Collectibles.totalCollected + "/3"; //Text for collected UI
    }

    void Update()   //Inputs are recorded every frame
    {
        //find position of groundCheck object, use players radius(circle around players feet), check for overlap of ground to be true/false
        surfaced = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //Moving along x axis
        xInp = Input.GetAxis("Horizontal");

        //Here is where some force is added to the ridged body (player)
        //Moving left or right on x axis
        if(xInp > 0f){ 
            player.velocity = new Vector2(xInp * force, player.velocity.y);
            transform.localScale = new Vector2(1.047133f, 0.9223106f); 
        }
        else if(xInp < 0f){
            player.velocity = new Vector2(xInp * force, player.velocity.y);
            transform.localScale = new Vector2(-1.047133f, 0.9223106f); //Flip player sprite
        }
        else{ //not moving
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //Detect if the space key is pressed down and player is in contact with ground
        //If both are true, the player jumps
        if (Input.GetKeyDown(KeyCode.Space) && surfaced)
        {
            jumpSound.Play(); //Play jump sound
            player.velocity = new Vector2(player.velocity.x, force); //Player jump mechanic                                               
        }

        //update speed operator in animator
        playerAnim.SetFloat("Force", Mathf.Abs(player.velocity.x));
        //update boolean for player on ground or not
        playerAnim.SetBool("OnGround", surfaced);

        //killBox follows player along x axis and stays same on y axis
        killBox.transform.position = new Vector2(transform.position.x, killBox.transform.position.y);
    }

    //Player runs into collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "GameOver")
        {
            deathSound.Play();
            transform.position = respawnLoc; //if killbox contact, back to original respawn
        }
        else if(collision.tag == "NextLevel" && !isFinished)
        {
            finishSound.Play();
            isFinished = true;
            //on collision enter the next level/scene in index
            Invoke("CompleteLevel", 2f);
        }
        else if(collision.tag == "PantCollected")
        {
            //Total collected throughout levels
            Collectibles.totalCollected += 1;

            //Display amount collected so far
            collectedText.text = "Pant Collection: " + Collectibles.totalCollected + "/3";

            //Disable after collected
            collision.gameObject.SetActive(false);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsycheMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public Vector2 direction;
    public Vector3 mousePosition;
    public Animator animator;
    
    //speeds for run/walk
	
    public float moveSpeed;
	public float defaultWalkSpeed = 10f;
    public float defaultRunSpeed = 25f;
    public float walkSpeed;
    public float runSpeed;
    public int movementPowerUP = 0;
	private float movementPowerUpTimer = 0;

    public float forceMultiplier = 1000;

    // Start is called before the first frame update
    void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    boundaryClamping();
	    float verticalPos = Input.GetAxis("Vertical");
	    float horizontalPos = Input.GetAxis("Horizontal");
	    
		//hold shift to walk
		if (Input.GetKey(KeyCode.LeftShift))
		{
       		moveSpeed = walkSpeed;
		} else {
       		moveSpeed = runSpeed;
		}

		//movementPowerUp
		if(movementPowerUP > 0)
		{
			walkSpeed = defaultWalkSpeed * 0.1f;
			runSpeed = defaultRunSpeed * 0.1f;
		}
		else
		{
			walkSpeed = defaultWalkSpeed;
			runSpeed = defaultRunSpeed;
		}

		movementPowerUpTimer += Time.deltaTime;
		if(movementPowerUpTimer >= 1)
		{
			movementPowerUP--;
			movementPowerUpTimer = 0;
		}
		
       
		//use mouse or key controls to move
		if (Input.GetMouseButton(0))
		{
       		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       		direction = (mousePosition - transform.position).normalized;
       		movement = new Vector2(direction.x, direction.y) * moveSpeed;
		} else {
       		movement = new Vector2(horizontalPos,verticalPos) * moveSpeed;
		}
    }
    
    // FixedUpdate is called every physics detection step  
    void FixedUpdate()
    {
		movePsyche(movement);
    }
    
   // Constrains Psyche prefab to screen boundaries 
    void boundaryClamping()
   {
		// Clamps player object to size x by y screen
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f),
		Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
   }

    // Type of movement Psyche will have
    // We can change this function if/when needed  
    void movePsyche(Vector2 direction)
    {
        // sets parameters that determine animation to use
		animator.SetFloat("verticalDistance", direction.y * Time.deltaTime);
		animator.SetFloat("horizontalDistance", direction.x * Time.deltaTime);
		rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime));
    }

    // Applies pushback to player on collision, we can 
    // get rid of the entire function if the pushback 
    // is not needed
    void OnTriggerEnter2D(Collider2D enemyCollider)
    {
	    if (enemyCollider.CompareTag("Asteroid") && enemyCollider.gameObject.GetComponent<Asteroid>().health == 1)
	    {
            // asteroid collision consumed
            enemyCollider.gameObject.GetComponent<Asteroid>().health = 0;
		    // Reduces player's life
        	GameObject.Find("Health").GetComponent<HealthUI>().health--;
		    // Applies force to player
		    rb.AddForce(Vector3.down * forceMultiplier);
	    }
    }
}

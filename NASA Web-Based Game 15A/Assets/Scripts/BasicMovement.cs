using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public Vector2 direction;
    public Vector3 mousePosition;
    
    //speeds for run/walk
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       //hold shift to walk
       if (Input.GetKey(KeyCode.LeftShift))
       {
       		moveSpeed = walkSpeed;
       		print("moveSpeed: " + moveSpeed.ToString("F0"));
       } else {
       		moveSpeed = runSpeed;
       		print("moveSpeed: " + moveSpeed.ToString("F0"));
       }

       if (Input.GetMouseButton(0))
       {
       		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       		direction = (mousePosition - transform.position).normalized;
       		movement = new Vector2(direction.x, direction.y) * moveSpeed;
       } else {
       		movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
       }
    }
     
    // FixedUpdate is called every physics detection step  
    void FixedUpdate()
    {
		movePsyche(movement);
    }

    // Type of movement Psyche will have
    // We can change this function if/when needed  
    void movePsyche(Vector2 direction)
    {
		rb.MovePosition((Vector2)transform.position + (direction * Time.deltaTime));
    }
}

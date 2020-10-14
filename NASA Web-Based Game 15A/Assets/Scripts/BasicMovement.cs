using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
  
    // Start is called before the first frame update
    void Start()
    {
	rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
	rb.MovePosition((Vector2)transform.position + (25 * direction * Time.deltaTime));
    }
}

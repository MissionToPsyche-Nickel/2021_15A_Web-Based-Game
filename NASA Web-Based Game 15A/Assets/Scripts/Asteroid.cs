using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Animator animator;
    public bool collision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D objectCollider)
    {
        collision = true;
        animator.SetBool("destroyed", collision);
        collision = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Animator animator;
    public bool collision = false;
    float bottomY;
    float leftX;
    float rightX;
    public float health = 1;

    private void Start()
    {
        bottomY = GameObject.Find("GameController").GetComponent<GameStart>().lowerLeftXY.y;
        leftX = GameObject.Find("GameController").GetComponent<GameStart>().lowerLeftXY.x;
        rightX = GameObject.Find("GameController").GetComponent<GameStart>().lowerRightXY.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY - 2 || transform.position.x < leftX - 2 || transform.position.x > rightX + 2)
        {
            Destroy(gameObject);
        }
    }
    
    public void destroyAsteroid()
    {
        // Plays sound upon collision
        SoundManager.instance.PlaySound("CollisionSound");
        
        //plays destroyed animation
        collision = true;
        animator.SetBool("destroyed", collision);
		collision = false;
    }
    
    void OnTriggerEnter2D(Collider2D objectCollider)
    {
        if (objectCollider.CompareTag("Psyche") && health == 1)
        {
            destroyAsteroid();
        }
    }
}

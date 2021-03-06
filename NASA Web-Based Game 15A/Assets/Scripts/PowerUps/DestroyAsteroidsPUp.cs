using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroidsPUp : MonoBehaviour
{
    private float lifespan = 12f;
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D objectCollider)
    {
        if (objectCollider.CompareTag("Psyche"))
        {          
            // destroy all asteroids
            foreach(GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid"))
            {
                asteroid.GetComponent<Asteroid>().destroyAsteroid();
            }           
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float asteroidSpawnTimeMin = 1f;
    public float asteroidSpawnTimeMax = 3f;
    public float lastAsteroidTime = -100f;
    private float astSize = 0; 
    //private float w = Screen.width;
    //private float h = Screen.height;
    

    public float leftSide;
    public float rightSide;

    public List<GameObject> asteroids = new List<GameObject>();
 
    // Update is called once per frame
    void Update()
    {
        // Launch asteroids
        if (Time.time - lastAsteroidTime > Random.Range(asteroidSpawnTimeMin, asteroidSpawnTimeMax))
        {
            lastAsteroidTime = Time.time;
            // create instance and set position and velocity
            GameObject asteroid = Instantiate(asteroidPrefab);
            astSize = Random.Range(.01f, .03f);
            asteroid.transform.localScale = new Vector2(astSize, astSize);
            asteroid.transform.position = new Vector3(Random.Range(leftSide, rightSide), transform.position.y + 6, 0);
            asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-4f, 4f), Random.Range(-10f, -.3f), 0).normalized * Random.Range(.1f, 10f);
            asteroids.Add(asteroid);
        }        
    }
}

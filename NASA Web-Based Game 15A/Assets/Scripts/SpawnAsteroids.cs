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
 
    // Update is called once per frame
    void Update()
    {
        // Launch asteroids
        if (Time.time - lastAsteroidTime > Random.Range(asteroidSpawnTimeMin, asteroidSpawnTimeMax))
        {
            lastAsteroidTime = Time.time;
            // create instance and set position and velocity
            GameObject asteroid = Instantiate(asteroidPrefab);
            astSize = Random.Range(.02f, .04f);
            asteroid.transform.localScale = new Vector2(astSize, astSize);
            asteroid.transform.position = new Vector3(Random.Range(leftSide, rightSide), transform.position.y + 6, 0);
            

            /*GameObject asteroid = Instantiate(asteroidPrefab);
            asteroid.transform.position = new Vector3(Random.Range(gameObject.GetComponent<GameStart>().upperLeftXY.x, 
            	gameObject.GetComponent<GameStart>().upperRightXY.x), gameObject.GetComponent<GameStart>().upperRightXY.y, 0);*/

            asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1, 0) * 0.1f;
        }        
    }
}

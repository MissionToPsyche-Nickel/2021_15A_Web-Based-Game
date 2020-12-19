using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    public bool fullscreen = false;

    public Camera cam;
    public Vector2 upperLeftXY;
    public Vector2 upperRightXY;
    public Vector2 lowerLeftXY;
    public Vector2 lowerRightXY;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // does nothing
        Screen.SetResolution(width, height, fullscreen);
        // play background music
        SoundManager.currentSound.PlaySound("Background");

        // find the game coordinates from screen size
        Vector3 upperLeftScreen = new Vector3(0, Screen.height, 0);
        //print("upperLeftScreen:" + upperLeftScreen);
        upperLeftXY = new Vector2(cam.ScreenToWorldPoint(upperLeftScreen).x, cam.ScreenToWorldPoint(upperLeftScreen).y);
        //print("upperLeftXY:" + upperLeftXY);

        Vector3 upperRightScreen = new Vector3(Screen.width, Screen.height, 0);
        //print("upperRightScreen:" + upperRightScreen);
        upperRightXY = new Vector2(cam.ScreenToWorldPoint(upperRightScreen).x, cam.ScreenToWorldPoint(upperRightScreen).y);
        //print("upperRightXY:" + upperRightXY);

        Vector3 lowerLeftScreen = new Vector3(0, 0, 0);
        //print("lowerLeftScreen:" + lowerLeftScreen);
        lowerLeftXY = new Vector2(cam.ScreenToWorldPoint(lowerLeftScreen).x, cam.ScreenToWorldPoint(lowerLeftScreen).y);
        //print("lowerLeftXY:" + lowerLeftXY);

        Vector3 lowerRightScreen = new Vector3(Screen.width, 0, 0);
        //print("lowerRightScreen:" + lowerRightScreen);
        lowerRightXY = new Vector2(cam.ScreenToWorldPoint(lowerRightScreen).x, cam.ScreenToWorldPoint(lowerRightScreen).y);
        //print("lowerRightXY:" + lowerRightXY);
    }

    // Update is called once per frame
    void Update()
    {
       if(gameOver)
        {
            SoundManager.currentSound.StopSound("Background");
            Time.timeScale = 0;
            GameObject.Find("Psyche").GetComponent<Renderer>().enabled = false;
        }
    }
}

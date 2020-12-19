using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //rate of scrollin
    public float speed = 1f;

    //do not change the clap the the background height
    //the player will jolt whenever the child background switches
    //over
    public float screenClampPos = 10;

    [HideInInspector]
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //changes the position of the parent background based every LateUpdate
        float newPos = Mathf.Repeat(-speed * Time.time, screenClampPos);
        transform.position = startPos + Vector3.up * newPos;
    }
}

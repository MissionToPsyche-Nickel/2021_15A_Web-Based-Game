using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryClamping : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {   
        // Clamps player object to size x by y screen 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f),
		    Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }
}

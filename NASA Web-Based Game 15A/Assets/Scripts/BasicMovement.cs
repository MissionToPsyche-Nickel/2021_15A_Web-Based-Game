using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 25;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * 25;
        transform.Translate(x,y,0);
    }
}

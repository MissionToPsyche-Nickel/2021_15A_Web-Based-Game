using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
// This script translates the 3D background for a scrolling effect


public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    public Renderer quadRender;
    public string sortLayer = "Background";
    public int sortOrder = 0;

    private void Start()
    {
        // places the background at the very bottom of the order
        quadRender.sortingLayerName = sortLayer;
        quadRender.sortingOrder = sortOrder;
    }
    void Update()
    {
        //the 3d texture continues to transform its position each update
        quadRender.material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);   
    }
}

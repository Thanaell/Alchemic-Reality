using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
//Script for testing purposes, not used in the game
public class setColor : MonoBehaviour
{
    public Color color;

    void Start()
    {
        
        //Get the Renderer component from the object
        var objectRenderer = GetComponent<Renderer>();
        //Call SetColor using the shader property name "_Color" and setting the color
        objectRenderer.material.SetColor("_Color", color);
        //objectRenderer.material.color = Color.red;
        
        // to color all children
        GetChildRecursive(this.gameObject);
    }

    private void GetChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            if (child.GetComponent<Renderer>()) {
                child.GetComponent<Renderer>().material.color = Color.red; //change color to red
            }
            GetChildRecursive(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

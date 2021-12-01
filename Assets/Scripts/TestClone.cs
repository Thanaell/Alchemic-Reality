using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClone : MonoBehaviour
{

    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Instantiate(myPrefab, GetComponent<Transform>());
    }
}

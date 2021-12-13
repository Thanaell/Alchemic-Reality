using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        TestSubject testSubject = other.GetComponentInChildren<TestSubject>();
        if (testSubject)
        {
            testSubject.FetchTestSubject();
            Debug.Log("fetching test subject");
        }
    }
}

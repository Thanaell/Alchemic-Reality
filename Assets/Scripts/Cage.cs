using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("TestSubject"))
        {
			TestSubject testSubject = other.GetComponentInChildren<TestSubject>();
            testSubject.FetchTestSubject();
            Debug.Log("fetching test subject");
        }
		Debug.Log("cage collided");
    }
}

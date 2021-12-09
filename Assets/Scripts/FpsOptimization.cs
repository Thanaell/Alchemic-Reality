using UnityEngine;
//using Vuforia;
using UnityEngine.UI;
using System.Collections;

public class FpsOptimization : MonoBehaviour
{
    public float deltaTime;
	private float fps;
	 
    void Start()
    {
        OnVuforiaStarted();
    }
    
    void OnVuforiaStarted()
    {
        QualitySettings.vSyncCount = 0;
        UnityEngine.Application.targetFrameRate = 30;
    }

     /*void Update () {
		 deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
         fps = 1.0f / deltaTime;
         Debug.Log(Mathf.Ceil(fps).ToString()); // show fps in log
     }*/
}
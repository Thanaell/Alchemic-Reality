using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    [SerializeField]
    protected Animator m_animator;
    [SerializeField]
    private float waitingTimeSec = 2f; //Waiting time for the animation to execute

    private Ingredient manipulatedIngredient = null;

    private void OnTriggerEnter(Collider other)
    {
        if(! manipulatedIngredient)
        {
            Ingredient ingredient = other.GetComponent<Ingredient>();
            Debug.Log(ingredient);
            manipulatedIngredient = ingredient;
            playAnimation(true);
            timer = waitingTimeSec;
        }
        
    }

    private float timer = 0;

    private void OnTriggerStay(Collider other)
    {
        if (manipulatedIngredient)
        {
            if (timer > 0)
            {
                timer = timer - Time.fixedDeltaTime;
            }
            else
            {
                playAnimation(false);
                actOn(manipulatedIngredient);
                manipulatedIngredient = null;
                timer = waitingTimeSec;
            }
        }
    }




       /* private void OnTriggerExit(Collider other)
    {
            if (manipulatedIngredient)
            {
                manipulatedIngredient = null;
                timer = waitingTimeSec;
            }
    }*/


    protected abstract void actOn(Ingredient ingredient);

    protected abstract void playAnimation(bool play);
}

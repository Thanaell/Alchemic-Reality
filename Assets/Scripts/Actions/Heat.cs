using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : Action
{

    /*private void OnTriggerEnter(Collider other)
    {
        Ingredient ingredient = other.GetComponent<Ingredient>();
        Debug.Log(ingredient);
        actOn(ingredient);
    }*/



    override protected void actOn(Ingredient ingredient)
    {
        Debug.Log(ingredient);
        ingredient.Burn();
    }

    protected override void playAnimation(bool play)
    {
        if (m_animator)
        {
            m_animator.SetBool("Burn", play);
        }
    }
}

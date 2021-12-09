using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heat : Action
{


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

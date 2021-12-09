using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : Action
{

    override protected void actOn(Ingredient ingredient)
    {
        Debug.Log(ingredient);
        ingredient.Slice();
    }

    protected override void playAnimation(bool play)
    {
        if (m_animator)
        {
            m_animator.SetBool("Slice", play);
        }
    }
}

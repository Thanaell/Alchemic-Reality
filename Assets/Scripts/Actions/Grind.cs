using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grind : Action
{
    override protected void actOn(Ingredient ingredient)
    {
        Debug.Log(ingredient);
        ingredient.Grind();
    }

    protected override void playAnimation(bool play)
    {
        if (m_animator)
        {
            m_animator.SetBool("Grind", play);
        }
    }
}

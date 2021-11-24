using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Ingredient
{
    public virtual void Slice()
    {
        //mushroom slicing
        this.transform.localScale = 0.5f * this.transform.localScale;
        setState(IngredientState.SLICED);
    }
}

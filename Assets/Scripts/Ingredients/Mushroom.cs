using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Ingredient
{
    public override void Slice()
    {
        Debug.Log("derived");
        //mushroom slicing
        this.transform.localScale = 0.5f * this.transform.localScale;
        setState(IngredientState.SLICED);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : Action
{
    override protected void actOn(Ingredient ingredient)
    {
        ingredient.Slice();
    }
}

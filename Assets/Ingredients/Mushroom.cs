using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Ingredient
{
    
    /*[SerializeField]
    private Object Full, Sliced, Powder;
    [SerializeField]
    private Material Burned;

    private Object currentModel;*/
    public override bool Slice()
    {
        //Debug.Log("derived");
        //mushroom slicing
        if (base.Slice())
        {
            this.transform.localScale = 0.5f * this.transform.localScale;
            return true;
        }
        return false;
    }

    public override void Grind()
    {
        base.Grind();
        //Mushroom grind
    }

    public override void Burn()
    {
        base.Burn();
        //Mushroom burn
    }

    public override void Reset()
    {
        base.Reset();
        //transform
    }
}

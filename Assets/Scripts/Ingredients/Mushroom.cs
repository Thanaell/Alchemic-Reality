using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Ingredient
{
    
    public override bool Slice()
    {
        //Debug.Log("derived");
        //mushroom slicing
        if (base.Slice())
        {
            this.transform.localScale = 0.5f * this.transform.localScale; //To edit out, only for tests
            if (m_Sliced)
            {
                Destroy(m_currentModel);
                m_currentModel = Instantiate(m_Sliced, GetComponent<Transform>());
            }
            if (StateContains(IngredientState.BURNED))
            {
                addBurnTexture();
            }
            return true;
        }
        return false;
    }

    public override void Grind()
    {        if (! StateContains(IngredientState.POWDER))
        {
            base.Grind();
            if (m_Powder)
            {
                Destroy(m_currentModel);
                m_currentModel = Instantiate(m_Powder, GetComponent<Transform>());
            }
            if (StateContains(IngredientState.BURNED))
            {
                addBurnTexture();
            }
        }

    }

    public override void Burn()
    {
        if(!StateContains(IngredientState.BURNED))
        {
            base.Burn();
            addBurnTexture();
        }
        
    }

    private void addBurnTexture()
    {
        
        if (StateContains(IngredientState.POWDER))
        {
            if (m_Burned.burnedPowder)
            {
                Material currentMat = m_currentModel.GetComponentInChildren<Material>();
                currentMat = m_Burned.burnedPowder; //To test
            }
        } else if (StateContains(IngredientState.SLICED))
        {
            if (m_Burned.burnedSliced)
            {
                Material currentMat = m_currentModel.GetComponentInChildren<Material>();
                currentMat = m_Burned.burnedSliced; //To test
            }
        } else
        {
            if (m_Burned.burnedFull)
            {
                Material currentMat = m_currentModel.GetComponentInChildren<Material>();
                currentMat = m_Burned.burnedFull; //To test
            }
        }
    }

    public override void Reset()
    {
        base.Reset();
        if (m_Full)
        {
            Destroy(m_currentModel);
            m_currentModel = Instantiate(m_Full, GetComponent<Transform>());
        }
    }
}

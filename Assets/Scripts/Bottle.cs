using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    //Effect m_effectToApply;
    public Effect m_effectToApply = Effect.CHANGE_COLOR_TO_RED; //for test
    private static Dictionary<string, Material> PotionColor = new Dictionary<string, Material>();

    private bool m_isWater = true;

    private bool m_justCreated = false;

    static Bottle()
    {
        //TODO fill in the potion colors (in PtionColor), with the key corresponding to the AlchemyBook
    }

   public void createPotion(Cauldron cauldron)
    {
        computeEffect(cauldron.mixIngredients());
    }


    public void computeEffect(Effect effect)
    {
        m_effectToApply = effect;
        Material newMaterial = null;
        if (PotionColor.TryGetValue(AlchemyBook.SearchColor(m_effectToApply), out newMaterial))
        {
            //TODO indispensable : change color/texture of potion to match the effect
        }

    }

    private void usePotion(TestSubject testSubject)
    {
        testSubject.applyEffect(m_effectToApply);
        m_isWater = true;
        //TODO indispensable reset the potion
    }

    public void OnTriggerEnter(Collider other)
    {
        timer = waitingTimeSec;
        if (other.gameObject.layer == LayerMask.NameToLayer("TestSubject"))
        {
            TestSubject testSubject = other.GetComponent<TestSubject>();
            if (testSubject && readyForAction)
            {
                usePotion(testSubject);
                readyForAction = false;
                
            }

        } else if (other.gameObject.layer == LayerMask.NameToLayer("Cauldron"))
        {
            Cauldron cauldron = other.GetComponent<Cauldron>();
            if (cauldron)
            {
                if (m_isWater)
                {
                    createPotion(cauldron);
                    m_isWater = false;
                    m_justCreated = true;
                    cauldron.ResetIngredients();
                }
            }

        }
        
    }

    [SerializeField]
    private float waitingTimeSec = 2f; //Waiting time for the bottle's action to execute
    private bool readyForAction;
    private float timer = 0;

    private void OnTriggerStay(Collider other)
    {
        if (timer > 0)
        {
            timer = timer - Time.fixedDeltaTime;
        }
        else
        {
            readyForAction = true;
            timer = waitingTimeSec;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Cauldron cauldron = other.GetComponent<Cauldron>();
        if (cauldron)
        {
            if (! m_isWater && m_justCreated)
            {
                m_justCreated = false; //To avoid reseting the ingredients if we put and remove a potion in the cauldron
                cauldron.ResetIngredients();
            }
        }
    }
}

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

    /// <summary>
    /// The content of the bottle which will change color
    /// </summary>
    [SerializeField]
    private GameObject m_bottleFill;

    /// <summary>
    /// The materials for the color of the list. Order is important !
    /// Element 0 is water
    /// </summary>
    [SerializeField]
    private static List<Material> m_materialList = new List<Material>();


    /// <summary>
    /// Set to true to add a timer to the cauldron before creating the potion
    /// </summary>
    [SerializeField]
    private bool CauldronHasTimer = false;

    static Bottle()
    {
        //TODO fill in the potion colors (in PotionColor), with the key corresponding to the AlchemyBook
        int i = 0;

        if(m_materialList.Capacity > i)
        {
            PotionColor.Add("water", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            //TODO as much as needed: PotionColor.Add("name of the color", m_materialList[i]);
            i++;
        }

    }

   public bool createPotion(Cauldron cauldron)
    {
        Effect effect = cauldron.mixIngredients();
        computeEffect(effect);
        return effect != Effect.NO_EFFECT;
        
    }


    public void computeEffect(Effect effect)
    {
        m_effectToApply = effect;
        changeColor(AlchemyBook.SearchColor(m_effectToApply));

    }

    private void usePotion(TestSubject testSubject)
    {
        testSubject.applyEffect(m_effectToApply);
        resetPotion();
        
    }

    /// <summary>
    /// Reset the potion color & effect. Set isWater to true;
    /// </summary>
    private void resetPotion()
    {
        m_isWater = true;
        computeEffect(Effect.NO_EFFECT);
    }

    private void changeColor(string color)
    {
        Material newMaterial = null;

        if (PotionColor.TryGetValue(color, out newMaterial))
        {
            Material currentMat = m_bottleFill.GetComponentInChildren<Material>();
            currentMat = newMaterial;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        timer = waitingTimeSec;
        if (other.gameObject.layer == LayerMask.NameToLayer("TestSubject"))
        {
            TestSubject testSubject = other.GetComponent<TestSubject>();
            if (testSubject && ! isWaiting)
            {
                isWaiting = true; //Start the timer
                
            }

        } else if (other.gameObject.layer == LayerMask.NameToLayer("Cauldron"))
        {
            Cauldron cauldron = other.GetComponent<Cauldron>();
            if(!CauldronHasTimer)
            {
                if (cauldron)
                {
                    if (m_isWater)
                    {
                        if (createPotion(cauldron))
                        {
                            m_isWater = false;
                            m_justCreated = true;
                        }
                        cauldron.ResetIngredients();
                    }
                }
            } else
            {
                if (cauldron && !isWaiting)
                {
                    if (m_isWater)
                    {
                        isWaiting = true; //Start the timer
                    }
                }
            }
        }

    }

    [SerializeField]
    private float waitingTimeSec = 2f; //Waiting time for the bottle's action to execute (testSubject & cauldron (if set to true))
    private bool isWaiting;
    private float timer;

    private void OnTriggerStay(Collider other)
    {
        if (isWaiting)
        {
            if (timer > 0)
            {
                timer = timer - Time.fixedDeltaTime;
            }
            else
            {
                isWaiting = false;
                TestSubject testSubject = other.GetComponent<TestSubject>();
                if (testSubject)
                {
                    usePotion(testSubject);
                }

                if (CauldronHasTimer)
                {
                    Cauldron cauldron = other.GetComponent<Cauldron>();
                    if (cauldron)
                    {
                        if (m_isWater)
                        {
                            if (createPotion(cauldron))
                            {
                                m_isWater = false;
                                m_justCreated = true;
                            }
                            cauldron.ResetIngredients();
                        }
                    }
                }
                
                
                timer = waitingTimeSec;
            }
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

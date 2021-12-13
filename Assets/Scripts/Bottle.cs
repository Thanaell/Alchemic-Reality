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
    private List<Material> m_materialList = new List<Material>();


    /// <summary>
    /// Set to true to add a timer to the cauldron before creating the potion
    /// </summary>
    [SerializeField]
    private bool CauldronHasTimer = false;

    static Bottle()
    {
        

    }

    public void Start()
    {
        applyBottleColor();
        /*not needed anymore, see applyBottleColor(); instead
        int i = 0;

        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("water", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("blue", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("souffre", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("violet", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("green", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("orange", m_materialList[i]);
            i++;
        }
        if (m_materialList.Capacity > i)
        {
            PotionColor.Add("red", m_materialList[i]);
            i++;
        }*/
    }

    public bool createPotion(Cauldron cauldron)
    {
        Effect effect = cauldron.mixIngredients();
        computeEffect(effect);
        return effect != Effect.NO_EFFECT;
        
    }

    // gives a custom color for the Bottle based on its effect
    // all cases not implemented yet
    private void applyBottleColor()
    {
        Renderer bottleRenderer = m_bottleFill.GetComponent<Renderer>();
        switch (m_effectToApply)
        {
            case Effect.CHANGE_COLOR_TO_RED:
                //new Color(r,g,b,a)
                bottleRenderer.material.color = Color.red;
                break;
            case Effect.CHANGE_COLOR_TO_BLUE:
                bottleRenderer.material.color = Color.blue;
                break;
            case Effect.CHANGE_COLOR_TO_YELLOW:
                bottleRenderer.material.color = Color.yellow;
                break;
            case Effect.CHANGE_SIZE_TO_2:
                bottleRenderer.material.color = new Color(0.9f, 0.1f, 0.9f, 0.9f);
                break;
            case Effect.CHANGE_SIZE_TO_0_5:
                bottleRenderer.material.color = new Color(0.7f, 0.2f, 0.7f, 0.6f);
                break;
            case Effect.ANIM_JUMP:
                bottleRenderer.material.color = Color.grey;
                break;
            case Effect.ANIM_FALL:
                bottleRenderer.material.color = Color.black;
                break;
            case Effect.ANIM_NOD:
                bottleRenderer.material.color = new Color(0.9f, 0.9f, 0.3f, 0.9f);
                break;
            case Effect.ANIM_LOOK_AT_STOMACH:
                bottleRenderer.material.color = new Color(0.2f, 0.2f, 0.2f, 0.9f);
                break;
            case Effect.ANIM_SPINNING:
                bottleRenderer.material.color = new Color(0.4f, 0.9f, 0.1f, 0.9f);
                break;
            case Effect.ANIM_FLYING:
                bottleRenderer.material.color = new Color(0.1f, 0.2f, 0.9f, 0.9f);
                break;
            case Effect.ANIM_FLAPPING:
                bottleRenderer.material.color = new Color(0.1f, 0.5f, 1f, 0.9f);
                break;
            case Effect.ANIM_JUMP_FLAPPING:
                bottleRenderer.material.color = new Color(0.9f, 0.2f, 1f, 0.9f);
                break;
            case Effect.ANIM_LOOK_AT_STOMACH_GREEN:
                bottleRenderer.material.color = new Color(0.2f, 0.9f, 0.1f, 0.9f);
                break;
            case Effect.ANIM_FALL_RED:
                bottleRenderer.material.color = new Color(0.9f, 0.2f, 0.2f, 0.9f);
                break;
            case Effect.ANIM_SPINNING_YELLOW:
                bottleRenderer.material.color = new Color(0.9f, 0.9f, 0.2f, 0.9f);
                break;
            case Effect.ANIM_SPINNING_FLAPPING:
                bottleRenderer.material.color = new Color(0.7f, 0.3f, 0.9f, 0.9f);
                break;
            case Effect.ANIM_ROLLING:
                bottleRenderer.material.color = new Color(0.1f, 0.9f, 0.2f, 0.9f);
                break;
            case Effect.ANIM_FLYING_SIZE_2:
                bottleRenderer.material.color = Color.cyan;
                break;
            default:
                break;
        }
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

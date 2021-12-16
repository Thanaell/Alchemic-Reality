using UnityEngine;
using System.Collections.Generic;

public class TestSubject : MonoBehaviour
{
    [SerializeField]
    protected GameObject testSubject_Prefab;
    
    protected Animator m_animator;

    protected GameObject m_model;

    [SerializeField]
    private int statesHealthNumber = 1; //At least 1 : full health

    [SerializeField]
    private int currentState = 0;

    private List<int> stateHealthValues = new List<int>();

    /// <summary>
    /// The max health for any testsubject
    /// </summary>
    [SerializeField]
    private int MAXHEALTH = 15; 
        
    private int maxHealth = 10; //This one is random

    [SerializeField]
    private int currentHealth;

    private bool isDead = false;

    public void Start()
    {
		//for test
		//m_model = Instantiate(testSubject_Prefab, GetComponent<Transform>()); //Instanciate as child
        //m_animator = m_model.GetComponentInChildren<Animator>();
    }



    public void FetchTestSubject()
    {
        if (testSubject_Prefab)
        {
            if (m_model)
            {
                Destroy(m_model);
            }
            m_model = Instantiate(testSubject_Prefab, GetComponent<Transform>()); //Instanciate as child
            m_animator = m_model.GetComponentInChildren<Animator>();
            InitHealth();
        }
    }

    /// <summary>
    /// Apply the effect of the AlchemyBook to the testSubject, depending on the action
    /// </summary>
    /// <param name="effect"></param>
    public bool applyEffect(Effect effect)
    {
        if(!isDead)
        {
            PotionAction potionAction = AlchemyBook.SearchActionOnTestSubject(effect);
            AlchemyBook.ActionOnTestSubject action = potionAction.action;
            if (action != null)
            {
                action(this);
                ComputeEffectOnHealth(potionAction.sicknessValue);
            }
            return true;
        }
        return false;
    }

    public Animator GetAnimator()
    {
        return m_animator;
    }

    /// <summary>
    /// The gameObject to use for manipulating the testSubject.
    /// Is originaly created from the prefab given to the TestSubject script.
    /// </summary>
    /// <returns></returns>
    public GameObject GetModel()
    {
        return m_model;
    }

    private void InitHealth()
    {
        this.maxHealth = Random.Range(statesHealthNumber, this.MAXHEALTH);
        this.currentHealth = maxHealth;
        this.isDead = false;
        this.currentState = 0;
        computeHealthStateList();
    }


    private void ComputeEffectOnHealth(int sicknessValue)
    {
        this.currentHealth -= sicknessValue;
        for(int i = 0; i<stateHealthValues.Capacity; i++)
        {
            if(currentHealth < stateHealthValues[i] && currentState<= i)
            {
                currentState++;
                if(currentState == statesHealthNumber - 1)
                {
                    isDead = true;
                }
                computeHealthState();
                break;
            }
        }
    }

    private void computeHealthStateList()
    {
        stateHealthValues.Clear();
        if(statesHealthNumber != 0)
        {
            int healthPortion = maxHealth / statesHealthNumber;
            if(statesHealthNumber > 1)
            {
                healthPortion = maxHealth / statesHealthNumber-1; //Because death is 0, and cutting in 2 is 3 states : all, half and nothing. Death is nothing and count as a state.
            }
            for(int i = 0; i<statesHealthNumber +1; i++)
            {
                stateHealthValues.Add(maxHealth - (healthPortion * i));
            }
        }
        
    }

    private void computeHealthState()
    {
        //GetAnimator().SetInteger("", currentState); //TODO
    }
}

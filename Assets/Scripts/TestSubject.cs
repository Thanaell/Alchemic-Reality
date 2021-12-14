using UnityEngine;

public class TestSubject : MonoBehaviour
{
    [SerializeField]
    protected GameObject testSubject_Prefab;
    
    protected Animator m_animator;

    protected GameObject m_model;

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
        }
    }

    /// <summary>
    /// Apply the effect of the AlchemyBook to the testSubject, depending on the action
    /// </summary>
    /// <param name="effect"></param>
    public void applyEffect(Effect effect)
    {
        AlchemyBook.ActionOnTestSubject action = AlchemyBook.SearchActionOnTestSubject(effect);
        if (action != null)
        {
            action(this);
        }
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
}

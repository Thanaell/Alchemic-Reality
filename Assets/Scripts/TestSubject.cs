using UnityEngine;

public class TestSubject : MonoBehaviour
{
    [SerializeField]
    protected GameObject testSubject_Prefab;
    
    protected Animator m_animator;

    protected GameObject m_model;

    public void Start()
    {
        //Save data
    }



    public void ChangeTestSubject()
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

    public GameObject GetModel()
    {
        return m_model;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenuEffects : MonoBehaviour
{

    [SerializeField] private Image[] m_MenuEffects;
    [SerializeField] private AudioSource m_PunchSound;

    private Image m_EnabledImage;

    [SerializeField] private Animator m_TitleScreenAnimator;

    private float m_CooldownTime = 2;
    private float m_RandomAnimationTime = 5;

    // Use this for initialization
    void Start()
    {
        m_EnabledImage = m_MenuEffects[0];
    }

    // Update is called once per frame
    void Update()
    {
        int rn = Random.Range(0, 8);
        m_CooldownTime -= Time.deltaTime;
        m_RandomAnimationTime -= Time.deltaTime; 

        if (m_CooldownTime < 0)
        {
            if (!m_MenuEffects[rn].IsActive())
            {
                m_PunchSound.Play();
                m_EnabledImage.enabled = false;
                m_MenuEffects[rn].enabled = true;
                m_EnabledImage = m_MenuEffects[rn];
                m_CooldownTime = Random.Range(0.5f, 2);
            }
        }
        if(m_RandomAnimationTime < 0)
        {
            m_RandomAnimationTime = 5;
            m_TitleScreenAnimator.SetTrigger("ShakeT");
        }
    }
}

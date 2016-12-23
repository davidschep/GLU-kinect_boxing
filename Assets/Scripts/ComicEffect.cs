using UnityEngine;
using System.Collections;

public class ComicEffect : MonoBehaviour
{
    [SerializeField]
    private float m_DestroyTime = 0.6f;
    private float m_Timer = 0f;

    /*
    Void Start with sound and screenshake effect (remember only feedback effects in this class, health and such in another class.
    */

    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= m_DestroyTime)
            Destroy(gameObject);
    }
}
using UnityEngine;
using System.Collections;

public class ComicEffect : MonoBehaviour
{
    [SerializeField]
    private float m_DestroyTime = 0.4f;
    private float m_Timer = 0f;

    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= m_DestroyTime)
            Destroy(gameObject);
    }
}
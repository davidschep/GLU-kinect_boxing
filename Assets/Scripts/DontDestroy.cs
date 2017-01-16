using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private Toggle m_TwoCameraToggle;
    private bool m_bTwoCameraToggle = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ToggleCameras()
    {
        m_bTwoCameraToggle = m_TwoCameraToggle.isOn;
    }

}

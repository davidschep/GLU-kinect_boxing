using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartStopMenu : MonoBehaviour {

    [SerializeField]private Light[] m_Ligts;
    private bool m_StartLevel = false;

    public void Startlevel()
    {
        m_StartLevel = true;
    }
    public void StopGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (m_StartLevel)
        {
            for (int i = 0; i < m_Ligts.Length; i++)
            {
                m_Ligts[i].range -= 3 * Time.deltaTime;
            }
            if (m_Ligts[1].range < 5)
                SceneManager.LoadScene("BoxingScene2");
        }
    }
}

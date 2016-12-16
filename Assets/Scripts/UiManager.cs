using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiManager : MonoBehaviour {

    [SerializeField]
    private Text[] m_UiElements;


    private void PlayerstatsUpdater(int[] playershealtharray, int rounds = 0)
    {
        m_UiElements[0].text = rounds.ToString();

        for (int i = 0; i < playershealtharray.Length; i++)
        {
            m_UiElements[1 + i].text = playershealtharray[i].ToString();
        }
    }

    private void TimerstatsUpdater(float time)
    {
        m_UiElements[1].text = Mathf.RoundToInt(time).ToString();
    }

}

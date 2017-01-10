using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
#region classVariables

    private GameObject[] m_PlayersArray;

    [SerializeField]private UiManager m_UiManager;

    private bool m_bRoundStartOver = false;

    private float m_fRoundTime;
    private float m_fCoolDownTimer;

    private static int m_iPlayerHealth;
    private int m_iRounds;

    private int[] m_iPlayerPoints;
    private int[] m_iPlayerWins;

    public static int Playerhealth
    {
        get { return m_iPlayerHealth; }
    }
    public GameObject[] Players
    {
        get { return m_PlayersArray; }
    }

#endregion

    private void Start()
    {
        m_iRounds = 1;
        m_fRoundTime = 5f;
        m_fCoolDownTimer = 5f;

        m_iPlayerHealth = 100;

        InitPlayersWithTag("Player");

        m_iPlayerWins = new int[m_PlayersArray.Length];

        for (int i = 0; i < m_PlayersArray.Length; i++)
        {
            m_iPlayerWins[i] = 0;
        }

        PlayerManager.PlayerDowned += IsRoundOver;
        PlayerManager.PlayerDowned += RestartVariables;

    }

    private void RestartVariables()
    {
        m_iRounds = 1;
        m_fRoundTime = 60f;
        m_fCoolDownTimer = 5f;

        m_bRoundStartOver = false;
    }

    private void Update()
    {

        if (m_bRoundStartOver)
        {
            m_fRoundTime -= Time.deltaTime;
            m_UiManager.m_RoundUIElements[0].text = Mathf.RoundToInt(m_fRoundTime).ToString();
            m_UiManager.m_RoundUIElements[1].text = "";
            m_UiManager.m_RoundUIElements[2].text = "Wins: " + m_iPlayerWins[0].ToString();

            //Zet hem aan zodra player 2 er is
            //m_UiManager.m_RoundUIElements[3].text = "Wins: " + m_iPlayerWins[1].ToString();
        }
        else if(!m_bRoundStartOver)
        {
            m_fCoolDownTimer -= Time.deltaTime;
            m_UiManager.m_RoundUIElements[1].text = Mathf.RoundToInt(m_fCoolDownTimer).ToString();
            if (m_fCoolDownTimer < 0)
                m_bRoundStartOver = true;
        }


        if (m_fRoundTime < 0)
        {
            IsRoundOver();
            RestartVariables();
        }
        //IsRoundOver(isroundover);
    }
    /// <summary>
    /// Puts all the objects with a certain tag in the m_arPlayers array 
    /// </summary>
    /// <param name="tag"></param>
    private void InitPlayersWithTag(string tag)
    {
        m_PlayersArray = GameObject.FindGameObjectsWithTag(tag);
        Debug.Log("Players found: " + m_PlayersArray.Length);

    }

    /// <summary>
    /// Checks the bool if its true and then executes the function
    /// </summary>
    /// <param name="roundover"></param>
    private void IsRoundOver()
    {

            bool[] playerdown = GetComponent<PlayerManager>().PlayerDown;
            RoundCounter(playerdown);

    }
    private void RoundCounter(bool[] playerdown)
    {
        if (playerdown[0])
        {

            //Player 2 won
            m_iPlayerWins[1]++;
            Debug.Log("Player wins: " + m_iPlayerWins[1]);
            m_UiManager.m_RoundUIElements[3].text = "Wins: " + m_iPlayerWins[0].ToString();
        }
        else if(playerdown[1])
        {
            //Player 1 won
            m_iPlayerWins[0] += 1;
            Debug.Log("Player wins: " + m_iPlayerWins[0]);
            m_UiManager.m_RoundUIElements[2].text = "Wins: " + m_iPlayerWins[0].ToString();
        }
        else
        {
            m_UiManager.m_RoundUIElements[2].text = "Draw!";
            m_UiManager.m_RoundUIElements[3].text = "Draw!";
        }

    }
}

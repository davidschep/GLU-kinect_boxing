using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
#region classVariables

    private GameObject[] m_PlayersArray;

    private Vector3[] m_PlayerOriginTransform;
    private Quaternion[] m_PlayerOriginRotation;

    private bool m_bRoundOver;
    private bool m_bRoundStart;

    private float m_fRoundTime;

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
        m_fRoundTime = 60;

        m_iPlayerHealth = 100;

        InitPlayersWithTag("Player");

        m_iPlayerWins = new int[m_PlayersArray.Length];
        m_iPlayerWins[0] = 0;
        m_iPlayerWins[1] = 0;

        StartCoroutine(CountDownTimer(10f));

    }

    private void Update()
    {
        bool isroundover = CountdownTimer(m_fRoundTime);
        IsRoundOver(isroundover);
    }
    /// <summary>
    /// Puts all the objects with a certain tag in the m_arPlayers array 
    /// </summary>
    /// <param name="tag"></param>
    private void InitPlayersWithTag(string tag)
    {
        m_PlayersArray = GameObject.FindGameObjectsWithTag(tag);
        Debug.Log("Players found: " + m_PlayersArray.Length);

        m_PlayerOriginRotation = new Quaternion[m_PlayersArray.Length];
        m_PlayerOriginTransform = new Vector3[m_PlayersArray.Length];

        for (int i = 0; i < m_PlayersArray.Length; i++)
        {
            m_PlayerOriginTransform[i] = m_PlayersArray[i].transform.position;
            m_PlayerOriginRotation[i] = m_PlayersArray[i].transform.rotation;
        }

    }
    /// <summary>
    /// Counts down and returns a bool when it reaches 0
    /// </summary>
    /// <param name="countdowntime"></param>
    private bool CountdownTimer(float countdowntime)
    {
        countdowntime -= Time.deltaTime;
        if (countdowntime < 0)
            return true;
        return false;
    }

    /// <summary>
    /// Checks the bool if its true and then executes the function
    /// </summary>
    /// <param name="roundover"></param>
    private void IsRoundOver(bool roundover)
    {
        if (roundover)
        {
            for (int i = 0; i < m_PlayersArray.Length; i++)
            {
                m_PlayersArray[i].transform.position = m_PlayerOriginTransform[i];
                m_PlayersArray[i].transform.rotation = m_PlayerOriginRotation[i];

            }

            bool[] playerdown = GetComponent<PlayerManager>().PlayerDown;
            RoundCounter(playerdown);

        }
    }
    private void RoundCounter(bool[] playerdown)
    {
        if (playerdown[0])
        {
            //Player 2 won
            m_iPlayerWins[1]++;
        }
        else
        {
            //Player 1 won
            m_iPlayerWins[0]++;
        }

    }

    private IEnumerator CountDownTimer(float time = 3)
    {
        while(time > 0)
        {
            time -= Time.deltaTime;

            if (time < 1)
                yield return true;
        }
    }

}

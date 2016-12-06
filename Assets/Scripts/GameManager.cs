using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
#region classVariables

    private GameObject[] m_gPlayers;

    private Vector3[] m_vPlayerOriginTransform;
    private Quaternion[] m_qPlayerOriginRotation;

    private bool m_bRoundOver;
    private float m_fRoundTime;

    public int m_iPlayerHealth;
    private int m_iRounds;

    private int[] m_iPlayerPoints;
    private int[] m_iPlayerWins;

    public int Playerhealth
    {
        get { return m_iPlayerHealth; }
    }
    public GameObject[] Players
    {
        get { return m_gPlayers; }
    }

#endregion

    private void Start()
    {
        m_iRounds = 1;
        m_fRoundTime = 60;

        m_iPlayerHealth = 100;

        m_iPlayerWins[0] = 0;
        m_iPlayerWins[1] = 0;

        InitPlayersWithTag("Player");
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
        m_gPlayers = GameObject.FindGameObjectsWithTag(tag);
        Debug.Log("Players found: " + m_gPlayers.Length);

        for (int i = 0; i < m_gPlayers.Length; i++)
        {
            m_vPlayerOriginTransform[i] = m_gPlayers[i].transform.position;
            m_qPlayerOriginRotation[i] = m_gPlayers[i].transform.rotation;
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
    private void CheckIfPlayerDown()
    {

    }
    /// <summary>
    /// Checks the bool if its true and then executes the function
    /// </summary>
    /// <param name="roundover"></param>
    private void IsRoundOver(bool roundover)
    {
        if (roundover)
        {
            for (int i = 0; i < m_gPlayers.Length; i++)
            {
                m_gPlayers[i].transform.position = m_vPlayerOriginTransform[i];
                m_gPlayers[i].transform.rotation = m_qPlayerOriginRotation[i];
                //int health = m_gPlayers[i].GetComponent<PlayerManager>().m_iHealth;
                //health = m_iPlayerHealth;
            }
            //bool playerwon = GetComponent<PlayerManager>().PlayerWon;
            RoundCounter(playerwon);

        }
    }
    private void RoundCounter(bool playerwon)
    {
        if (playerwon)
        {
            //Player 1 won
            m_iPlayerWins[0]++;
        }
        else
        {
            //Player 2 won
            m_iPlayerWins[1]++;
        }

    }
}

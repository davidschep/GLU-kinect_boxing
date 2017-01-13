using UnityEngine;
using System.Collections;
namespace BoxDetox
{
    public class GameManager : MonoBehaviour
    {
        #region classVariables

        private GameObject[] m_PlayersArray;

        [SerializeField]
        private UiManager m_UiManager;

        private static int m_iPlayerHealth;
        private int m_TotalRounds;

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

        private float m_Timer;
        [SerializeField]
        private float m_RoundTime = 60f;
        [SerializeField]
        private float m_CountDownTime = 5f;
        public TimerState m_TimerState = TimerState.Waiting;

        #endregion

        private void Start()
        {
            m_TotalRounds = 1;
            m_Timer = m_CountDownTime;

            m_iPlayerHealth = 100;

            InitPlayersWithTag("Player");

            m_iPlayerWins = new int[m_PlayersArray.Length];

            for (int i = 0; i < m_PlayersArray.Length; i++)
                m_iPlayerWins[i] = 0;
        }

        private void Update()
        {
            m_Timer -= Time.deltaTime;
            switch (m_TimerState)
            {
                case TimerState.Waiting:
                    m_TimerState = TimerState.CountingDown;
                    m_Timer = m_CountDownTime;
                    break;
                case TimerState.CountingDown:
                    m_UiManager.m_Centre.text = Mathf.RoundToInt(m_Timer).ToString();
                    if (m_Timer <= 0)
                    {
                        m_TimerState = TimerState.Playing;
                        m_Timer = m_RoundTime;
                        m_UiManager.m_Centre.text = "";
                    }
                    break;
                case TimerState.Playing:
                    m_UiManager.m_TopCentre.text = Mathf.RoundToInt(m_Timer).ToString();
                    if(m_Timer <= 0)
                    {
                        m_TotalRounds++;
                        m_UiManager.m_TopCentre.text = "Draw!";
                        m_TimerState = TimerState.Waiting;
                    }
                    break;
            }
        }

        private void InitPlayersWithTag(string tag)
        {
            m_PlayersArray = GameObject.FindGameObjectsWithTag(tag);
        }

        public void GameWon(int playerWon)
        {
            if (playerWon == 0)
            {
                m_iPlayerWins[0]++;
                m_UiManager.m_PlayerWins[0].text = "Wins: " + m_iPlayerWins[0].ToString();
                m_TimerState = TimerState.Waiting;
                m_UiManager.m_TopCentre.text = "Player 1 wins!";
            }
            else
            {
                m_iPlayerWins[1]++;
                m_UiManager.m_PlayerWins[1].text = "Wins: " + m_iPlayerWins[0].ToString();
                m_TimerState = TimerState.Waiting;
                m_UiManager.m_TopCentre.text = "Player 2 wins!";
            }
        }
    }

    public enum TimerState
    {
        Playing, CountingDown, Waiting
    };
}
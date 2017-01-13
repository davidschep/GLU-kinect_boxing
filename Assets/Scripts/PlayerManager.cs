using UnityEngine;
using System.Collections;

namespace BoxDetox
{
    public class PlayerManager : MonoBehaviour
    {
        private GameObject[] m_PlayersArray;

        [SerializeField]
        private UiManager m_UiManager;

        private int[] m_iPlayersHealthArray = new int[2];

        public int[] PlayersHealthArray
        {
            get { return m_iPlayersHealthArray; }
        }

        private void Start()
        {
            RoundVariablesSet();
        }

        private void Update()
        {
            CheckIfDown();
            m_UiManager.m_PlayerHealthBars[0].fillAmount = (float)m_iPlayersHealthArray[0] / 100f;
            m_UiManager.m_PlayerHealthBars[1].fillAmount = (float)m_iPlayersHealthArray[0] / 100f;
        }

        private void RoundVariablesSet()
        {
            m_iPlayersHealthArray[0] = GameManager.Playerhealth;
            m_iPlayersHealthArray[1] = GameManager.Playerhealth;
        }

        /// <summary>
        /// Checks if the players health is 0
        /// </summary>
        private void CheckIfDown()
        {
            if (m_iPlayersHealthArray[0] < 0)
            {
                GetComponent<GameManager>().GameWon(0);
                RoundVariablesSet();
            }
            else if (m_iPlayersHealthArray[1] < 0)
            {
                GetComponent<GameManager>().GameWon(1);
                RoundVariablesSet();
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public delegate void CheckIfDownDelegate();
    public static event CheckIfDownDelegate PlayerDowned;

    private GameObject[] m_PlayersArray;

    [SerializeField] private UiManager m_UiManager;

    private bool[] m_bPlayersDownArray = new bool[2];
    private int[] m_iPlayersHealthArray = new int[2];

    public int[] PlayersHealthArray
    {
        get { return m_iPlayersHealthArray; }
    }
    public bool[] PlayerDown
    {
        get { return m_bPlayersDownArray; }
    }


    private void Start()
    {
        RoundVariablesSet();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //m_iPlayersHealthArray[0] -= 10;
            m_iPlayersHealthArray[1] -= 10;
        }
        CheckIfDown();
        //De health van player 1
        m_UiManager.m_HealthElements[0].value = m_iPlayersHealthArray[0];
        //De health van player 2
        m_UiManager.m_HealthElements[1].value = m_iPlayersHealthArray[1];
    }

    private void RoundVariablesSet()
    {
        m_iPlayersHealthArray[0] = GameManager.Playerhealth;
        m_iPlayersHealthArray[1] = GameManager.Playerhealth;

        m_bPlayersDownArray[0] = false;
        m_bPlayersDownArray[1] = false;

    }
    /// <summary>
    /// Checks if the players health is 0
    /// </summary>
    private void CheckIfDown()
    {
        if (m_iPlayersHealthArray[0] < 0)
        {
            m_bPlayersDownArray[0] = true;
            PlayerDowned();
            RoundVariablesSet();
        }
        else if(m_iPlayersHealthArray[1] < 0)
        {
            m_bPlayersDownArray[1] = true;
            PlayerDowned();
            RoundVariablesSet();
        }
    }

    public void OnPlayerPunch(Limb limb, GameObject hitObject)
    {
        
    }
}

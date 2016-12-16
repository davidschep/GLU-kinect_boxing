using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    private GameObject[] m_PlayersArray;

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
        RoundStart();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckIfDown();
    }

    private void RoundStart()
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
            m_bPlayersDownArray[0] = true;
        else
            m_bPlayersDownArray[1] = true;
    }

    public void OnPlayerPunch(Limb limb, GameObject hitObject)
    {
        
    }
}

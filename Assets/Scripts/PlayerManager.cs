using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    private GameObject[] m_PlayersArray;

    private bool m_bPlayerDown;

    private int m_iPlayerHealth;

    public bool PlayerDown
    {
        get { return m_bPlayerDown; }
    }


    private void Start()
    {
        RoundStart();
    }

    private void RoundStart()
    {
        m_iPlayerHealth = GameManager.Playerhealth;
        m_bPlayerDown = false;
    }

    // Update is called once per frame
    private void Update()
    {

    }
}

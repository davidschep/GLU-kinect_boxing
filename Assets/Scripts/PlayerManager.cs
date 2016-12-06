using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    private GameObject[] m_gPlayers;

    private bool m_bPlayerDown;

    private int m_iPlayerHealth;

    public bool PlayerDown
    {
        get { return m_bPlayerDown; }
    }


    private void Start()
    {
        m_iPlayerHealth = GetComponent<GameManager>().Playerhealth;
        m_bPlayerDown = false;
    }

    // Update is called once per frame
    private void Update()
    {

    }
}

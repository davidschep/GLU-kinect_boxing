using UnityEngine;
using System.Collections;

namespace BoxDetox
{
    public class PunchCollider : MonoBehaviour
    {
        [SerializeField]
        private Limb m_Limb = Limb.LeftHand;
        [SerializeField]
        private PlayerManager m_PlayerManager;
        [SerializeField]
        private int m_PlayerId = 1;
        [SerializeField]
        private int m_Damage = 10;

        private Transform m_SpineTransform;
        private bool m_ReadyToPunch = true;
        private float m_TimeAgoHardPunch;

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag != "Player" + m_PlayerId.ToString() && col.gameObject.tag != "Untagged")
            {
                if (m_ReadyToPunch)
                {
                    m_ReadyToPunch = false;
                    if (m_PlayerManager.GetComponent<GameManager>().m_TimerState == TimerState.Playing)
                        if (col.gameObject.name.Contains("Hand")) // blocked so exit this method
                        {
                            m_PlayerManager.GetComponent<EffectsManager>().InstantiateEffect(transform.position, true);
                        }
                        else
                        {
                            m_PlayerManager.GetComponent<EffectsManager>().InstantiateEffect(transform.position, false);
                            if (Time.time - m_TimeAgoHardPunch < 0.5f)
                            {
                                if(m_PlayerId == 2)
                                m_PlayerManager.PlayersHealthArray[0] -= m_Damage * 2;
                                else
                                    m_PlayerManager.PlayersHealthArray[1] -= m_Damage * 2;
                            }
                            else
                            {
                                if (m_PlayerId == 2)
                                    m_PlayerManager.PlayersHealthArray[0] -= m_Damage;
                                else
                                    m_PlayerManager.PlayersHealthArray[1] -= m_Damage;
                            }
                        }
                }
            }
        }

        void Start()
        {
            m_PlayerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
            m_SpineTransform = transform.parent.parent.parent.parent.parent;
        }

        void Update()
        {
            float distanceArmToCentre = Mathf.Abs(transform.position.x - m_SpineTransform.position.x);
            if (distanceArmToCentre < 2)
            {
                m_ReadyToPunch = true;
                float distanceArmSideways = Mathf.Abs(transform.position.z - m_SpineTransform.position.z);
                if (distanceArmSideways > 3)
                {
                    m_TimeAgoHardPunch = Time.time;
                }
            }
        }
    }
}

namespace BoxDetox
{
    public enum Limb
    {
        LeftHand, RightHand, LeftFoot, RightFoot
    };
}
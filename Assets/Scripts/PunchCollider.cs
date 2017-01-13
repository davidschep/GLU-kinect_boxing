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

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag != "Player" + m_PlayerId.ToString() && col.gameObject.tag != "Untagged")
            {
                PlayerManager playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
                playerManager.GetComponent<EffectsManager>().InstantiateEffect(transform.position);
                if (playerManager.GetComponent<GameManager>().m_TimerState == TimerState.Playing)
                    if (m_PlayerId == 1)
                        playerManager.PlayersHealthArray[1]--;
                    else
                        playerManager.PlayersHealthArray[0]--;
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
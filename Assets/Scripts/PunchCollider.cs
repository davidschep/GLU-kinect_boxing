using UnityEngine;
using System.Collections;

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
        if (col.gameObject.tag != "Player" + m_PlayerId.ToString())
        {
            // punch
            // spawn punch icon here
            Debug.Log(col.gameObject.tag);
            GameObject.Find("GameManager").GetComponent<EffectsManager>().InstantiateEffect(transform.position);
        }
    }
}

public enum Limb
{
    LeftHand, RightHand, LeftFoot, RightFoot
};
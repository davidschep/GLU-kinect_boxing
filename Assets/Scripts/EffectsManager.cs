using UnityEngine;
using System.Collections;

public class EffectsManager : MonoBehaviour {

    [SerializeField]
    private GameObject m_Effect;
    [SerializeField]
    private Sprite[] m_EffectSprites = new Sprite[5];

    public void InstantiateEffect(Vector3 effectPosition)
    {
        GameObject instantiatedEffect = GameObject.Instantiate(m_Effect, effectPosition, new Quaternion()) as GameObject;
        instantiatedEffect.GetComponent<SpriteRenderer>().sprite = m_EffectSprites[Random.Range(0, m_EffectSprites.Length)];
    }
}
using UnityEngine;
using System.Collections;

namespace BoxDetox
{
    public class EffectsManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject m_Effect;
        [SerializeField]
        private Sprite[] m_EffectSprites = new Sprite[5];
        [SerializeField]
        private Sprite m_MissSprite;

        [SerializeField]
        private AudioClip m_PunchSound;

        private AudioSource m_AudioSource;

        void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void InstantiateEffect(Vector3 effectPosition, bool miss)
        {
            m_AudioSource.PlayOneShot(m_PunchSound);
            GameObject instantiatedEffect = GameObject.Instantiate(m_Effect, effectPosition + new Vector3(0, 0, -7), new Quaternion()) as GameObject;
            if (miss)
                instantiatedEffect.GetComponent<SpriteRenderer>().sprite = m_MissSprite;
            else
                instantiatedEffect.GetComponent<SpriteRenderer>().sprite = m_EffectSprites[Random.Range(0, m_EffectSprites.Length)];
        }
    }
}
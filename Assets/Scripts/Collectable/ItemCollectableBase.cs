using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public ParticleSystem itemParticleSystem;
    public string compareTag;
    public float timeToHide;
    public GameObject graphicItem;
    
    [Header("Sound")]
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void HideItens()
    {
        if (graphicItem != null)
        {
            graphicItem.SetActive(false);
        }
        Invoke("HideObject", timeToHide);
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (itemParticleSystem != null)
        {
            itemParticleSystem.transform.SetParent(null);
            itemParticleSystem.Play();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

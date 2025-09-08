using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioClip collectClip; // som do item
    private AudioSource audioSource; // componente que vai tocar

    private void Awake()
    {
        // pega ou adiciona automaticamente um AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null)
        {
            graphicItem.SetActive(false);
        }
        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }

        if (collectClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(collectClip);
        }
    }
}

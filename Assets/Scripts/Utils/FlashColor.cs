using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color flashColor = Color.red;
    public float flashDuration = 0.3f;

    private Tween _currentTween;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Flash();
        }
    }
    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color  = Color.white);
        }
        foreach (var sprite in spriteRenderers)
        {
           _currentTween = sprite.DOColor(flashColor, flashDuration).SetLoops(2,LoopType.Yoyo);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRenderAnim : MonoBehaviour
{

    public Sprite[] SpriteAnimList;

    /// <summary>
    /// 每隔多少秒播放下次图片
    /// </summary>
    public float Interval = 0.5f;
    
    
    private SpriteRenderer spriteRenderer;

    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        if (SpriteAnimList == null ||SpriteAnimList.Length == 0)
        {
            yield return  null;
        }

        for (int i = 0; i < SpriteAnimList.Length; i++)
        {
            spriteRenderer.sprite = SpriteAnimList[i];
            yield return new WaitForSeconds(Interval);
        }

        StopCoroutine(StartAnim());
        StartCoroutine(StartAnim());
    }
    
}

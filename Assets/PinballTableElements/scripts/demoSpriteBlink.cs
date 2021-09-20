using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoSpriteBlink : MonoBehaviour
{
    private const string COROUTINE_NAME = "CycleText";

    public SpriteRenderer sprite_mesh;
    public Sprite[] text_sprite;
    public float blinkspeed = 0.5f;
    public float max_cycle = 4;

    private int bid = 0;

    void OnEnable()
    {
        StartCoroutine(COROUTINE_NAME);
    }

    private void OnDisable()
    {
        StopCoroutine(COROUTINE_NAME);
        bid = 0;
        SetHighlighted();
    }

    private void SetHighlighted()
    {
        sprite_mesh.sprite = text_sprite[bid];
    }

    IEnumerator BlinkTarget()
    {
        while (true)
        { 
            yield return new WaitForSeconds(blinkspeed);
            SetHighlighted();
            bid++;
            if (bid >= max_cycle) bid = 0;
        }
    }
}

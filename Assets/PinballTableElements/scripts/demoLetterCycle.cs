using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoLetterCycle : MonoBehaviour
{
    public SpriteRenderer[] sprite_mesh;
    public Sprite[] text_sprite;
    public Sprite[] text_sprite_highlight;
    public float blinkspeed = 0.5f;
    private int bid = 0;

    void OnEnable()
    {
        StartCoroutine("CycleText");
    }

    private void OnDisable()
    {
        StopCoroutine("CycleText");
        bid = 0;
        ResetHighlight();
    }

    private void ResetHighlight()
    {
        for (int i = 0; i < text_sprite.Length; i++)
            sprite_mesh[i].sprite = text_sprite[i];
    }
    
    IEnumerator CycleText()
    {
        while (true) 
        {
            yield return new WaitForSeconds(blinkspeed);
            ResetHighlight();
            sprite_mesh[bid].sprite = text_sprite_highlight[bid];
            bid += 1;
            if (bid >= text_sprite.Length) bid = 0;
        }
    }
}

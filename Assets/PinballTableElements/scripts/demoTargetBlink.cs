using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoTargetBlink : MonoBehaviour
{
    public MeshFilter target_mesh;
    public Mesh[] target_mesh_states;
    public float blinkspeed = 0.5f;
    public float max_cycle = 4;
    private int bid = 0;

    void OnEnable()
    {
        StartCoroutine("BlinkTarget");
    }

    private void OnDisable()
    {
        StopCoroutine("BlinkTarget");
        bid = 0;
        SetHighlighted();
    }

    private void SetHighlighted()
    {
        target_mesh.mesh = target_mesh_states[bid];
    }

    IEnumerator BlinkTarget()
    {
        while (true) 
        { 
            yield return new WaitForSeconds(blinkspeed);
            SetHighlighted();
            bid += 1;
            if (bid >= max_cycle) bid = 0;
        }
    }
}

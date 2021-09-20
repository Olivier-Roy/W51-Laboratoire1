using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoTargetBlink : MonoBehaviour
{
    private const string COROUTINE_NAME = "BlinkTarget";

    public MeshFilter target_mesh;
    public Mesh[] target_mesh_states;
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
        target_mesh.mesh = target_mesh_states[bid];
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool showed = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        interact(); 
    }

    void interact()
    {
        if (Input.GetKeyDown(KeyCode.H) && showed == true)
        {
            showed = false;
            spriteRenderer.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.H) && showed == false)
        {
            showed = true;
            spriteRenderer.enabled = true;
        }
    }
}

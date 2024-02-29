using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomArea : MonoBehaviour
{
    public float decreaseSpeed = 0.1f; 
    private bool decreaseable = false;
    public bool hid = false;

    private SpriteRenderer spriteRenderer;
    private Color currentColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
    }

    void Update()
    {
        decreaseOpacity();
        increaseOpacity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        decreaseable = true;
        hid = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        decreaseable = false;
        hid = false;
    }

    void decreaseOpacity()
    {
        if(decreaseable == true && currentColor.a >= 0)
        {
            currentColor.a -= decreaseSpeed * Time.deltaTime;
            spriteRenderer.color = currentColor;
        }
        
    }

    void increaseOpacity()
    {
        if (decreaseable == false && currentColor.a <= 1)
        {
            currentColor.a += decreaseSpeed * Time.deltaTime;
            spriteRenderer.color = currentColor;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaflet : MonoBehaviour
{
    private bool interactable = false;

    public GameObject leaflet;
    private SpriteRenderer leafletSpriterenderer;
    public GameObject player;

    void Start()
    {
        leafletSpriterenderer = leaflet.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (interactable)
        {
            interact();
        }

        if(player != null)
        {
            if (player.transform.position != this.gameObject.transform.position)
                {
                    leafletSpriterenderer.enabled = false;
                }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            interactable = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            interactable = false;
        }
        
    }

    void interact()
    {
        if (player != null)
        {
            if (Input.GetKeyDown(KeyCode.R) == true && player != null)
            {
                leafletSpriterenderer.enabled = true;
                player.transform.position = this.gameObject.transform.position;
            }
        }
    }
}

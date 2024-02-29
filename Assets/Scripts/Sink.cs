using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    private float startTime;
    //private float waterStartTime;
    private float duration = 25 * 1; 
    //private float pryDuration = 31;
    private float elapsedTime;
    private bool mirrorMonsterSpawnable = true;
    private bool mirrorMonsterSpawn = false;
    public GameObject mirrorMonster;
    private bool waterStart = false;
    private double waterLevel = 0;
    private bool interactable = false;
    private bool interacting = false;

    public Animator animator;
    void Start()
    {
        startTime = Time.time;
        //waterStartTime = Time.time;
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        animator.SetFloat("elapsedTime", elapsedTime);

        if (elapsedTime >= duration && mirrorMonsterSpawnable == true)
        {
            mirrorMonsterSpawnable = false;
            waterStart = true;
            waterLevel = 10;
        }

        if (waterLevel > 0 && waterStart == true)
        {
            interact();
        }
        else if (waterLevel <= 0 && waterStart == true)
        {
            restart();
        }

        if (mirrorMonsterSpawnable == false && waterLevel == 100 && mirrorMonsterSpawn == false)
        {
            mirrorMonsterSpawn = true;
            animator.SetBool("closet_monster_out", true);
        }

        /*if (elapsedTime >= pryDuration && mirrorMonsterSpawnable == false && mirrorMonsterSpawn == false)
        {
            restart();
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }

    void interact()
    {
        if(interacting == false && waterStart == true && Input.GetKey(KeyCode.E) != true)
        {
            waterLevel = waterLevel + 0.01;
        }
        else if (interactable == true && waterStart == true && Input.GetKey(KeyCode.E) == true)
        {
            interacting = true;
            waterLevel = waterLevel - 0.01;
        }
        else if (Input.GetKeyUp(KeyCode.E) == true)
        {
            interacting = false;
        }
    }

    /*void waterFlow()
    {

    }

    void playerClosingWater()
    {

    }*/

    public void restart()
    {
        waterStart = false;
        startTime = Time.time;
        mirrorMonsterSpawnable = true;
    }
}

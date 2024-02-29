using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bed;
    public GameObject window;
    public static GameObject staticPlayer;
    public static GameObject staticBed;
    public static GameObject staticWindow;
    void Start()
    {
        staticPlayer = player;
        staticBed = bed;
        staticWindow = window;
    }
}

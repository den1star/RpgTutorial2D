﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance =  Instantiate(UIScreen).GetComponent<UIFade>();
        }
        if (PlayerController.instance == null)
        {
            PlayerController.instance =  Instantiate(player).GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
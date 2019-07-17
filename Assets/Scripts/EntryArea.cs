using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryArea : MonoBehaviour
{
    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerController.instance.areaTransitionName == areaTransitionName)
        {
            PlayerController.instance.transform.position = this.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

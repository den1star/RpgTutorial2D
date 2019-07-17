using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string areatoload;
    public string areaTransitionName;
    public EntryArea entryArea;
    // Start is called before the first frame update
    void Start()
    {
        entryArea.areaTransitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(areatoload,LoadSceneMode.Single);
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}

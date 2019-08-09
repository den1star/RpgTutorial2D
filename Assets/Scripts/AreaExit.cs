using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string areatoload;
    public string areaTransitionName;
    public EntryArea entryArea;
    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;
    // Start is called before the first frame update
    void Start()
    {
        entryArea.areaTransitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <=0f)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areatoload);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //SceneManager.LoadScene(areatoload,LoadSceneMode.Single);
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}

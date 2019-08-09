using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Image fadeImage;
    public float moveSpeed;
    bool fadeToBlack;
    bool fadeFromBlack;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 1f, moveSpeed * Time.deltaTime));
            if (fadeImage.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
        if (fadeFromBlack)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 0f, moveSpeed * Time.deltaTime));
            if (fadeImage.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false;
    }
    public void FadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;
    }
}

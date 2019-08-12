using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] public GameObject dialogBox;
    [SerializeField] GameObject nameBox;
    [SerializeField] Text dialogText;
    [SerializeField] Text nameText;

    public string[] dialogLines;
    public int currentLine;
    private bool justStarted;

    public static DialogManager instance;
    void Start()
    {
        instance = this;
        dialogBox.SetActive(false);
        //dialogText.text = dialogLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        PlayerController.instance.canMove = true;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }
    public void ShowDialog(string[] newLine,bool isPerson)
    {
        dialogLines = newLine;
        currentLine = 0;
        CheckIfName();
        if (!isPerson)
        {
            nameBox.SetActive(false);
        }
        else
        {
            nameBox.SetActive(true);
        }

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;

        PlayerController.instance.canMove = false;
    }
    private void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }
}

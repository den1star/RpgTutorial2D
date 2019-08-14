using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] public string charName;
    [SerializeField] public int playerLevel;
    [SerializeField] public int currentEXP;
    [SerializeField] public int currentHP;
    [SerializeField] public int maxHP=9999;
    [SerializeField] public int currentMP;
    [SerializeField] public int maxMP=9999;
    [SerializeField] public int strength;
    [SerializeField] public int defence;
    [SerializeField] public int wpnPwr;
    [SerializeField] public int armrPwr;
    [SerializeField] public string equipedWpn;
    [SerializeField] public string equipenArmr;
    [SerializeField] public Sprite charImage;
    [SerializeField] public int[] expToNextLevel;
    [SerializeField] public int maxLevel = 99;
    [SerializeField] public int baseEXP = 1000;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;
        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        } 
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if (playerLevel < maxLevel)
        {
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];
                playerLevel++;
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }
                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;
                maxMP = Mathf.FloorToInt(maxMP * 1.05f);
                currentMP = maxMP;
            } 
        }
        if (playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}

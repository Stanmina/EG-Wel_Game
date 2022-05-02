using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gongratulations : MonoBehaviour
{
    public static Gongratulations instance;
    public int currentScene;
    public Levels level;

    [SerializeField] Text yourTime;

    [SerializeField] GameObject[] stars;
    [SerializeField] GameObject[] cupIcon;
    [SerializeField] GameObject[] lockIcon;
    [SerializeField] GameObject[] tTBText;
    [SerializeField] Button[] buttons;

    private string lvlText;

    void Start()
    {
        if (instance is null)
            instance = this;
    }

    void Update() => yourTime.text = FormatTime(level.playTime);

    public void Levels(int currentLevel)
    {
        string[] Level01Times = { "0:10" , "0:15" , "0:30" };
        string[] Level02Times = { "0:30" , "0:45" , "0:60" };
        string[] Level03Times = { "0:15" , "0:25" , "0:45" };

        if (currentLevel == 0)
        {
            print(level.playTime);
            for (int i = 0; i < Level01Times.Length; i++)
                tTBText[i].GetComponent<Text>().text = Level01Times[i];
            lvlText = "Level02";

            if (level.playTime < 50f)
            {
                print("bronze");
                putStars(0);
                //stars[0].SetActive(true);
            }
            if (level.playTime < 25f)
            {
                print("silver");
                putStars(1);
                /*for (int x = 0; x < 2; x++)
                    stars[x].SetActive(true);*/
            }
            if (level.playTime < 10f)
            {
                print("gold");
                putStars(2);
                //cupIcon[2].SetActive(true);
                /*for (int x = 0; x < 3; x++)
                    stars[x].SetActive(true);*/
            }
        }
        if (currentLevel == 1)
        {
            for (int i = 0; i < Level02Times.Length; i++)
                tTBText[i].GetComponent<Text>().text = Level02Times[i];
            lvlText = "Level03";

            if (level.playTime < 60f)
            {
                lockIcon[0].SetActive(false);
                cupIcon[0].SetActive(true);
                stars[0].SetActive(true);
            }
            if (level.playTime < 45f)
            {
                lockIcon[1].SetActive(false);
                cupIcon[1].SetActive(true);
                for (int x = 0; x < 2; x++)
                    stars[x].SetActive(true);
            }
            if (level.playTime < 30f)
            {
                lockIcon[2].SetActive(false);
                cupIcon[2].SetActive(true);
                for (int x = 0; x < 3; x++)
                    stars[x].SetActive(true);
            }
        }
        if (currentLevel == 2)
        {
            for (int i = 0; i < Level03Times.Length; i++)
                tTBText[i].GetComponent<Text>().text = Level03Times[i];

            lvlText = "Level04";
            if (level.playTime < 45f)
            {
                lockIcon[0].SetActive(false);
                cupIcon[0].SetActive(true);
                stars[0].SetActive(true);
            }
            if (level.playTime < 25f)
            {
                lockIcon[1].SetActive(false);
                cupIcon[1].SetActive(true);
                for (int x = 0; x < 2; x++)
                    stars[x].SetActive(true);
            }
            if (level.playTime < 15f)
            {
                lockIcon[2].SetActive(false);
                cupIcon[2].SetActive(true);
                for (int x = 0; x < 3; x++)
                    stars[x].SetActive(true);
            }
        }
    }

    private void putStars(int value)
    {
        lockIcon[value].SetActive(false);
        cupIcon[value].SetActive(true);
        for (int x = 0; x < value+1; x++)
            stars[x].SetActive(true);
    }

    public string FormatTime(float time) => Math.Round(time, 3).ToString();

    public void LoadScene()
    {
        print(lvlText);
        SceneManager.LoadScene(lvlText);
    }
}

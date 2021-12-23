using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController Instance;
    string[] RandSimbols;

    string[] level1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
    string[] level2 = { "й", "ц", "у", "к", "е", "н" };
    string[] level3 = { "г", "ш", "щ", "з", "х", "ъ" };
    string[] level4 = { "ф", "ы", "в", "а", "п" };
    string[] level5 = { "р", "о", "л", "д", "ж", "э" };
    string[] level6 = { "я", "ч", "с", "м", "и" };
    string[] level7 = { "т", "ь", "б", "ю" };
    string[] level8 = { "й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з", "х", "ъ" };
    string[] level9 = { "ф", "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э" };
    int currentNumb;
    int rand;

    int nextLevel = 20;
    int timer;

    [SerializeField]
    Text outSimbols;

    [SerializeField]
    Text characterBalance;


    [SerializeField]
    Text TimerText;

    [SerializeField]
    Text LevelText;

    [SerializeField]
    GameObject Result;

    [SerializeField]
    GameObject[] ResultText;

    int level;

    bool isPlay;


    private void Awake()
    {
        Instance = this;
        LevelControl();
        isPlay = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            if (nextLevel == 0)
            {
                nextLevel = 30;                
                LevelControl();
                rand = Random.Range(0, RandSimbols.Length);
            }

            outSimbols.text = "" + RandSimbols[rand];
            characterBalance.text = "Осталось : " + nextLevel;

            if (Input.inputString == RandSimbols[rand])
            {

                while (true)
                {
                    if (currentNumb != rand)
                    {
                        currentNumb = rand;
                        break;
                    }

                    rand = Random.Range(0, RandSimbols.Length);
                }
                PlayerControl.Instance.MovementPlayer();
                nextLevel--;

            }


        }

    }

    void LevelControl() 
    {

        switch (level)
        {
            case 0:
                RandSimbols = level1;
                LevelText.text = "" + level;
                break;
            case 1:
                print("LV2");
                RandSimbols = level2;
                LevelText.text = "" + level;
                break;
            case 2:
                print("LV3");
                RandSimbols = level3;
                LevelText.text = "" + level;
                break;
            case 3:
                print("LV4");
                RandSimbols = level4;
                LevelText.text = "" + level;
                break;
            case 4:
                print("LV5");
                RandSimbols = level5;
                LevelText.text = "" + level;
                break;
            case 5:
                print("LV6");
                RandSimbols = level6;
                LevelText.text = "" + level;
                break;
            case 6:
                print("LV7");
                RandSimbols = level7;
                LevelText.text = "" + level;
                break;
            case 7:
                print("LV8");
                RandSimbols = level8;
                LevelText.text = "" + level;
                break;
            case 8:
                print("LV9");
                RandSimbols = level9;
                LevelText.text = "" + level;
                break;
            case 9:
                print("достиг финала, молодец!");

                break;
        }
    }

    public void Restart() 
    {

        PlayerControl.Instance.ResetGame();
        EnemyControll.Instance.RestartGame();
        timer = 0;
        nextLevel = 30;
        Time.timeScale = 1;
    }
    public void StartGame() 
    {
        Result.SetActive(false);
        Time.timeScale = 1;
        isPlay = true;
        rand = Random.Range(0, RandSimbols.Length);
        currentNumb = rand;
        StartCoroutine(Timer());
        EnemyControll.Instance.PlayGame();
        Restart();
        timer = 0;
        nextLevel = 30;
    }

    bool isStopGame;
    public void StopGame() 
    {
        isStopGame = !isStopGame;
        if (isStopGame)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    
    public void NextLevel(bool playerNextLevel) 
    {
        Result.SetActive(true);

        for (int i = 0; i < ResultText.Length; i++)
            ResultText[i].SetActive(false);


        if (playerNextLevel)
        {

            ResultText[0].SetActive(true);
            level++;
            Restart();
            LevelControl();
            print("Level "+ level);
        }
        else
        {
            ResultText[1].SetActive(true);
            Restart();
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator Timer() 
    {


        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer++;
            TimerText.text = "" + timer.ToString("D2");           
        }

    }
}

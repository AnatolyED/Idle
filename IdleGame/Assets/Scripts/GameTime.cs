using System;
using System.Collections;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static Action onActionOverTime;

    [field: SerializeField]
    public int Hours { get; private set; }
    [field: SerializeField]
    public int Minets { get; private set; }
    [field: SerializeField]
    public int Seconds { get; private set; }

    public GameStage GameStages { get; set; }

    private void Start()
    {
        
    }

    private IEnumerator GameTimer()
    {
        while (true)
        {
            if (Seconds < 60)
            {
                Seconds += 1;
            }
            else if(Seconds >= 59 && Minets < 60)
            {
                Minets += 1;
                Seconds = 0;
            }
            else
            {
                Hours += 1;
                Minets = 0;
                Seconds = 0;
            }
            GameStage();
        }
    }

    public  void GameStage()
    {
        if(Minets <= 2)
        {
            GameStages = global::GameStage.FirstStage;
        }
        else if (Minets <= 4)
        {
            GameStages = global::GameStage.SecondStage;
        }
        else if(Minets > 6)
        {
            GameStages = global::GameStage.ThirdStage;
        }
        //сделать скрипт из которого можно получать контроллеры и передавать/получать данные
    }
}

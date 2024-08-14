using System;
using System.Collections;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public static Action<GameStage> onActionOverTime;

    [field: SerializeField]
    public int Hours { get; private set; }
    [field: SerializeField]
    public int Minets { get; private set; }
    [field: SerializeField]
    public int Seconds { get; private set; }

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
            yield return new WaitForSeconds(1f);
        }
    }

    public  void SelectGameStage()
    {
        if(Minets <= 2)
        {
            onActionOverTime(GameStage.FirstStage);
        }
        else if (Minets <= 4)
        {
            onActionOverTime(GameStage.SecondStage);
        }
        else if(Minets > 6)
        {
            onActionOverTime(GameStage.ThirdStage);
        }
        //сделать скрипт из которого можно получать контроллеры и передавать/получать данные
    }
}

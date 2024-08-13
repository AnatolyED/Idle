using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [SerializeField]
    private short _numWeaponAttack;
    [SerializeField]
    private List<GameObject> _projectilePrefabs = new List<GameObject>();
    [SerializeField]
    private List<Weapon> _weapons = new List<Weapon>();

    public static Action onShot;

    private void Start()
    {
        GameTime.onActionOverTime += SelectStage;

        StartCoroutine(WeaponsControll());
    }

    private IEnumerator WeaponsControll()
    {

        while (true)
        {
            onShot?.Invoke();

            yield return new WaitForSeconds(2f);
        }
    }

    private void SelectStage()
    {

    }

    private void SelectWeapons()
    {
        System.Random rnd = new System.Random();
        short[] weaponSelected = new short[_numWeaponAttack];
        
    }
    private void SelectProjectiles(short[] weaponSelected)
    {
        System.Random rnd = new System.Random();
        
        for (int i = 0; i < _weapons.Count ;i++)
        {
            _weapons[i]._projectilePrefab = _projectilePrefabs[rnd.Next(0, _projectilePrefabs.Count)];
        }
    }

    public void SelectGameStage(GameStage gameStage)
    {
        switch (gameStage)
        {
            case GameStage.FirstStage:
                
                break;
            case GameStage.SecondStage:
                break;
            case GameStage.ThirdStage:
                break;
            default:
                break;
        }
    }
}

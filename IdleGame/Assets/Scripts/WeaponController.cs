using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _projectilePrefabs = new List<GameObject>();
    [SerializeField]
    private float _weaponShotingCounts;
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private float _reloadingShotTime;
    [SerializeField]
    private List<Weapon> _weapon;

    public static Action<GameObject, float> OnShoot;

    private void Start()
    {
        StartCoroutine(FullCycleOfWeapons());
    }

    private IEnumerator FullCycleOfWeapons()
    {
        yield return new WaitForSeconds(0.5f);

        System.Random rnd = new System.Random();
        int countWeaponToFire;
        List<Weapon> selectedWeapons = new List<Weapon>();

        while (true)
        {
            countWeaponToFire = rnd.Next(0, _weapon.Count);

            for (int i = 0; i < countWeaponToFire; i++)
            {
                GameObject projectile = Instantiate(_projectilePrefabs[rnd.Next(0,_projectilePrefabs.Count)]);
                _weapon[i].ToShoot(projectile, _projectileSpeed);
            }
            yield return new WaitForSeconds(_reloadingShotTime);
        }
    }

    private List<Weapon> SelectWeapons(System.Random rnd)
    {
        List<Weapon> weapons = new List<Weapon>();
        short weaponSelected;
        for (int i = 0; i < _weaponShotingCounts; i++)
        {
            weaponSelected = (short)rnd.Next(0, _weapon.Count);
            if ()
            {
                if(Array.Exists(SelectWeapo))
            }
        }
    }
}

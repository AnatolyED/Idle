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
    private int countWeaponToFire;
    [SerializeField]
    private List<Weapon> _weapon;

    private Coroutine _shootCycle;

    public static Action<GameObject, float> OnShoot;

    private void Start()
    {
        _shootCycle = StartCoroutine(FullCycleOfWeapons());
    }

    private void OnEnable()
    {
        Player.onDeath += StopShootCycle;
    }

    private void OnDisable()
    {
        Player.onDeath -= StopShootCycle;
    }

    private IEnumerator FullCycleOfWeapons()
    {
        yield return new WaitForSeconds(0.5f);

        System.Random rnd = new System.Random();
        List<Weapon> selectedWeapons = new List<Weapon>();

        while (true)
        {
            countWeaponToFire = rnd.Next(0, _weapon.Count);
            selectedWeapons = SelectWeapons(rnd);

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
            if (weapons.Contains(_weapon[weaponSelected]))
            {
                weapons.Add(_weapon[weaponSelected]);
            }
            else
            {
                i--;
            }
        }
        return weapons;
    }

    private void StopShootCycle()
    {
        StopCoroutine(_shootCycle);
    }
}

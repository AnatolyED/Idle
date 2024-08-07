using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private WeaponDirection _weaponDirection;

    public GameObject _projectilePrefab;

    private void OnEnable()
    {
        WeaponsController.onShot += Shot;
    }
    private void OnDisable()
    {
        WeaponsController.onShot -= Shot;
    }

    public void Shot()
    {
        GameObject projectile;
        switch (_weaponDirection)
        {
            case WeaponDirection.Left:
                CreateProjectile(out projectile);
                //Vector2.right
                break;
            case WeaponDirection.Right:
                CreateProjectile(out projectile);
                //Vector2.left

                break;
            default:
                break;
        }
    }

    private GameObject CreateProjectile(out GameObject projectile)
    {
        projectile = Instantiate(_projectilePrefab);

        return projectile;
    }
}

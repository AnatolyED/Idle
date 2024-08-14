using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponDirection _weaponDirection;
    [SerializeField] public float _attackSpeed;

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
        GameObject projectile = Instantiate(_projectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(projectile.transform.forward * _attackSpeed, ForceMode2D.Impulse);
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

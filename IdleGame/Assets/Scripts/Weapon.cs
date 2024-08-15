using UnityEngine;

public class Weapon : MonoBehaviour
{
    [field: SerializeField]
    public RectTransform RectTransform { get; private set; }
    [field: SerializeField]
    public WeaponDirection direction { get; private set; }
    public bool Shot;


    private void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }
    public void ToShoot(GameObject projectile,float projectileSpeed)
    {
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectile.transform.SetParent(RectTransform, false);

        switch (direction)
        {
            case WeaponDirection.Left:
                projectileRb.AddForce(Vector2.right * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
                break;
            case WeaponDirection.Right:
                projectileRb.AddForce(Vector2.left * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
                break;
            default:
                break;
        }

    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData _projectileData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathObject")
            Destroy(this.gameObject);
    }
}

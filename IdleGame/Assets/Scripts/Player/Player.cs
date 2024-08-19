using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action onDeath;

    [field: SerializeField]
    public PlayerScalesAbility AbilityScaleForPlayer { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" ||
            collision.gameObject.tag == "DeathObject")
        {
             onDeath?.Invoke();
        }
    }
}

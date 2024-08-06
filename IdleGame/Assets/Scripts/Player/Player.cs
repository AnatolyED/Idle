using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [field: SerializeField]
    public PlayerScalesAbility AbilityScaleForPlayer { get; private set; }

    public static Action onDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" ||
            collision.gameObject.tag == "DeathObject")
        {
            onDeath?.Invoke();
        }
    }
}

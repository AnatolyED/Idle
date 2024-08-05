using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    public PlayerScalesAbility _playerScaleAblitys { get; private set; }

    public UnityEvent OnDeath;

    private void Start()
    {
        OnDeath.AddListener(gameObject.GetComponent<PlayerController>().Death);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" ||
            collision.gameObject.tag == "DeathObject")
        {
            OnDeath?.Invoke();
        }
    }
}

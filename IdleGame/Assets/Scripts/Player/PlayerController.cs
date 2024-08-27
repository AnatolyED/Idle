using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private InputAction _jumpAction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpAction = InputSystem.actions.FindAction("Jump");
        StartCoroutine(Jump());
    }

    private void OnEnable()
    {
        Player.onDeath += Death;
    }

    private void OnDisable()
    {
        Player.onDeath -= Death;
    }

    private IEnumerator Jump() 
    {

        while (true)
        {
            if (_jumpAction.IsPressed())
            {
                _rb.AddForce(new Vector2(0, 0.5f),ForceMode2D.Impulse);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void Death()
    {
        _rb.bodyType = RigidbodyType2D.Static;
    }
}

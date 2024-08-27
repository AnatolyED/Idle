using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Character.Controller
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RtTransform { get; private set; }
        [field: SerializeField] public Rigidbody2D Rb { get; private set; }
        private InputAction _jumpAction;

        private void Start()
        {
            RtTransform = GetComponent<RectTransform>();
            Rb = GetComponent<Rigidbody2D>();
            _jumpAction = InputSystem.actions.FindAction("Jump");

            StartCoroutine(Jump());
        }

        private IEnumerator Jump()
        {

            while (true)
            {
                if (_jumpAction.IsPressed())
                {
                    Rb.AddForce(new Vector2(0, 0.5f), ForceMode2D.Impulse);
                }

                yield return new WaitForFixedUpdate();
            }
        }
    }
}
using UnityEngine;

public abstract class Base : MonoBehaviour
{
    [field: SerializeField]
    public float BonusTime { get; private set; }
}

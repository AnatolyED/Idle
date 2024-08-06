using UnityEngine;

[System.Serializable]
public struct ProjectileData
{
    [field: SerializeField]
    public ProjectileType Type { get; private set; }
    [field: SerializeField]
    public float SpeedScale { get; private set; }
    [field: SerializeField]
    public Rigidbody2D Rigidbody { get; private set;}
}

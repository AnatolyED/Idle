using UnityEngine;

[System.Serializable]
public struct ProjectileData
{
    [field: SerializeField]
    public float SpeedScale { get; private set; }
    [field: SerializeField]
    public ProjectileType Type { get; private set; }
}

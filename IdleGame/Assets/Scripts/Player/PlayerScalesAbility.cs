using UnityEngine;

[System.Serializable]
public struct PlayerScalesAbility
{
    [field: SerializeField]
    public float SpeedScale { get; private set; }
    [field: SerializeField]
    public float SizeScale { get; private set; }
    [field: SerializeField]
    public float WeightScale { get; private set; }

}

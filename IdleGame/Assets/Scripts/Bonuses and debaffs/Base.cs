using UnityEngine;

[System.Serializable]
public class Base : MonoBehaviour
{
    [field: SerializeField]
    public float BonusTime { get; private set; }
    [field: SerializeField]
    public BuffVariable buffVariable { get; private set; }

    public Base(float bonusTime)
    {
        BonusTime = bonusTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
    }
}

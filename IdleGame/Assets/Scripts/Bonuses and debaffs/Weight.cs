using System.Collections;
using UnityEngine;

[System.Serializable]
public class Weight : Base
{
    [field: SerializeField]
    public float WeightScale { get; private set; }
    public Weight(float bonusTime, float weightScale) : base(bonusTime)
    {
        WeightScale = weightScale;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        other.gameObject.GetComponent<Player>().StartCoroutine(ChangeWeight(other.gameObject.GetComponent<Rigidbody2D>()));
        Destroy(gameObject);
    }

    private IEnumerator ChangeWeight(Rigidbody2D rb)
    {
        float weight = rb.mass;

        switch (buffVariable)
        {
            case BuffVariable.Positive:
                rb.mass -= WeightScale;
                break;
            case BuffVariable.Negative:
                rb.mass += WeightScale;
                break;
            default:
                Debug.Log("Ошибка в выборе типа бафа!");
                break;
        }

        yield return new WaitForSeconds(BonusTime);

        rb.mass = weight;
    }
}

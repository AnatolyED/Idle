using System.Collections;
using UnityEngine;

[System.Serializable]
public class Size : Base
{
    [field: SerializeField]
    public float SizeScale { get; private set; }
    public Size(int bonusTime, float sizeScale): base(bonusTime)
    {
        SizeScale = sizeScale;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        other.gameObject.GetComponent<Player>().StartCoroutine(ChangeSize(other.gameObject.GetComponent<RectTransform>()));
        Destroy(gameObject);
    }

    private IEnumerator ChangeSize(RectTransform transform)
    {
        Vector2 initialScale = transform.sizeDelta;

        switch (buffVariable)
        {
            case BuffVariable.Positive:
                transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialScale.x * SizeScale);
                transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, initialScale.y * SizeScale);
                break;
            case BuffVariable.Negative:
                transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialScale.x / SizeScale);
                transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, initialScale.y / SizeScale);
                break;
            default:
                Debug.Log("Ошибка в выборе типа бафа!");
                break;
        }

        yield return new WaitForSeconds(BonusTime);

        transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialScale.x);
        transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, initialScale.y);
    }
}

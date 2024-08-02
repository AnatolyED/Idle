using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Size : Base
{
    [field: SerializeField]
    public float SizeScale { get; private set; }
   
    public void ChangeSize(RectTransform transform,BuffVariable buffVariable)
    {
        Vector3 initialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        transform.localScale = buffVariable == BuffVariable.Positive ? 
            new Vector3(initialScale.x, initialScale.y, initialScale.z) * 2 : 
            new Vector3(initialScale.x, initialScale.y, initialScale.z) / 2;

        new WaitForSeconds(BonusTime);

        transform.localScale = initialScale;
    }
}

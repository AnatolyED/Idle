using UnityEngine;

public class Item : MonoBehaviour
{
    public string Title { get; private set; }
    public int Price { get; private set; }
    public Color ItemType { get; private set; }

    public void Constructor(string title, int price, Color itemType)
    {
        Title = title;
        Price = price;
        ItemType = itemType;
    }
}

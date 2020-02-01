using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<invObject> items;
    public Helmet helmet;
    public BodyArmor bodyArmor;
    public Trinket trinket;
    public int money;
    public HealthItem healthItem;

    public void addItem(GameObject newItemObject)
    {
        invObject newItem = newItemObject.GetComponent<invObject>();
        if(newItem.amount != 0)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(items[i].name == newItem.name)
                {
                    items[i].amount += newItem.amount;
                    Object.Destroy(newItemObject);
                }
            }
        }
        else
        {
            items.Add(newItem);
            Object.Destroy(newItemObject);
        }
    }

    public void removeItem(invObject itemToRemove)
    {
        items.Remove(itemToRemove);
    }

}

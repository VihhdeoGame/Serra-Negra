using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager inventoryManager;

    public static InventoryManager Inventory {get{return inventoryManager;}}

    private Items inventory;

    private void Awake()
    {
        if(inventoryManager != null && inventoryManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            inventoryManager = this;
        }

        inventory = new Items();
    }

    public void AddItemtoInventory(int key,int _amount,string _name_PT=null,string _name_EN=null, bool _isStorable=false, string _description_PT = null,string _description_EN = null, Sprite _sprite = null)
    {
        if(inventory.items.ContainsKey(key))
        {
            inventory.items[key].amount += _amount;
        }
        else
        {
            Item _item = new Item(_name_PT,_name_EN, _isStorable, _description_PT,_description_EN, _sprite, _amount);
            inventory.items.Add(key,_item);
        }        
    }
    public Items GetInventory(){ return inventory; }
}

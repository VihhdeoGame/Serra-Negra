using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public string name;
    public bool isStorable;
    public string description;
    public Sprite sprite;
    public int amount;

    public Item(string _name, bool _isStorable, string _description, Sprite _sprite, int _amount)
    {
        this.name = _name;
        this.isStorable = _isStorable;
        this.description = _description;
        this.sprite = _sprite;
        this.amount = _amount;        
    }
}
[Serializable]
public class Items
{
    public Dictionary<int,Item> items;

    public Items()
    {
        items = new Dictionary<int, Item>();
    }
}

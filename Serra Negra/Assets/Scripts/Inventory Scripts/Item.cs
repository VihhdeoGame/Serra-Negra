using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public string name_PT;
    public string name_EN;
    public bool isStorable;
    public string description_PT;
    public string description_EN;
    public Sprite sprite;
    public int amount;

    public Item(string _name_PT, string _name_EN, bool _isStorable, string _description_PT, string _description_EN, Sprite _sprite, int _amount)
    {
        this.name_PT = _name_PT;
        this.name_EN = _name_EN;
        this.isStorable = _isStorable;
        this.description_PT = _description_PT;
        this.description_EN = _description_EN;
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

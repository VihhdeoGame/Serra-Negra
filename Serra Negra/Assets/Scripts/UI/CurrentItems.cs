using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItems : MonoBehaviour
{
    [SerializeField]
    GameObject itemPrefab;
    List<DisplayItem> clones;
    private void OnEnable()
    {
        clones = new List<DisplayItem>();
        UpdateItems(InventoryManager.Inventory.GetInventory().items);     
    }
    private void OnDisable()
    {
        CleanList();        
    }

    void UpdateItems(Dictionary<int,Item> _inventory)
    {
        foreach(Item item in _inventory.Values)
        {
            if(item.isStorable && item.amount>0)
            {
                GameObject instance = Instantiate(itemPrefab,this.transform);
                clones.Add(instance.GetComponent<DisplayItem>());
                clones[clones.Count-1].item = item;
                instance.SetActive(true);
            }
        }
    }
    void CleanList()
    {
        for (int i = 0; i < clones.Count; i++)
        {
            Destroy(clones[i].gameObject);            
        }
    }
}

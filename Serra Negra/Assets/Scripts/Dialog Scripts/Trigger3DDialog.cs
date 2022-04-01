using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Trigger3DDialog : TriggerDialog
{
#if UNITY_EDITOR
    [CustomEditor(typeof(Trigger3DDialog))]
    public class Trigger3DDialogEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Trigger3DDialog triggerDialog = (Trigger3DDialog)target;
            triggerDialog.containsItem = EditorGUILayout.Toggle("Contains Item/Flag?", triggerDialog.containsItem);

            if (triggerDialog.containsItem)
            {
                EditorGUILayout.LabelField("Item");
                triggerDialog.item.name = EditorGUILayout.TextField("Name", triggerDialog.item.name);
                triggerDialog.item.amount = EditorGUILayout.IntField("Amount", triggerDialog.item.amount);
                triggerDialog.item.description = EditorGUILayout.TextField("Description", triggerDialog.item.description);
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Sprite");
                triggerDialog.item.sprite = (Sprite)EditorGUILayout.ObjectField(triggerDialog.item.sprite, typeof(Sprite), true);
                EditorGUILayout.EndHorizontal();
                triggerDialog.item.isStorable = EditorGUILayout.Toggle("Is it Storable?", triggerDialog.item.isStorable);
            }
            triggerDialog.requiredCheck = EditorGUILayout.Toggle("Requires an Item Check?", triggerDialog.requiredCheck);
            if (triggerDialog.requiredCheck)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Required Item ID", GUILayout.MaxWidth(100));
                triggerDialog.requiredItemKey = EditorGUILayout.IntField(triggerDialog.requiredItemKey);
                EditorGUILayout.LabelField("Required Item Amount", GUILayout.MaxWidth(130));
                triggerDialog.requiredAmount = EditorGUILayout.IntField(triggerDialog.requiredAmount);
                EditorGUILayout.EndHorizontal();
            }
        }
    }
#endif
    private GameObject crosshair;
    protected override void Start() 
    {
        base.Start();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        sfxPlayer = FindObjectOfType<PlayerController>().SfxPlayer;
    }
    protected override void UpdateDisplay(bool active)
    {
        crosshair.SetActive(active);
    }
    protected override void FinalInteraction()
    {
        OpenDoor();
    }
    public void OpenDoor()
    {
        Item _item = InventoryManager.Inventory.GetInventory().items[requiredItemKey];
        _item.amount -= requiredAmount;
        Destroy(this.gameObject);
    }
}

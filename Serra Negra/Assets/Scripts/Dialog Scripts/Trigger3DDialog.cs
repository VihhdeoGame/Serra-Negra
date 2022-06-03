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
    private GenericCanvas shackCanvas;
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
                triggerDialog.item.name_PT = EditorGUILayout.TextField("Name PT", triggerDialog.item.name_PT);
                triggerDialog.item.name_EN = EditorGUILayout.TextField("Name EN", triggerDialog.item.name_EN);
                triggerDialog.item.amount = EditorGUILayout.IntField("Amount", triggerDialog.item.amount);
                triggerDialog.item.description_PT = EditorGUILayout.TextField("Description PT", triggerDialog.item.description_PT);
                triggerDialog.item.description_EN = EditorGUILayout.TextField("Description EN", triggerDialog.item.description_EN);
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
                if(GUILayout.Button("Add Required ID"))
                {
                    triggerDialog.arrayCount++;
                    triggerDialog.dummy = new int[triggerDialog.requiredItemKey.Length];
                    triggerDialog.requiredItemKey.CopyTo(triggerDialog.dummy,0);
                    triggerDialog.requiredItemKey = new int[triggerDialog.arrayCount];
                    triggerDialog.dummy.CopyTo(triggerDialog.requiredItemKey,0);
                    triggerDialog.dummy = new int[triggerDialog.requiredAmount.Length];
                    triggerDialog.requiredAmount.CopyTo(triggerDialog.dummy,0);
                    triggerDialog.requiredAmount = new int[triggerDialog.arrayCount];
                    triggerDialog.dummy.CopyTo(triggerDialog.requiredAmount,0);
                }
                if(GUILayout.Button("Remove Required ID"))
                {
                    if(triggerDialog.arrayCount > 0)
                    {
                        triggerDialog.arrayCount--;
                        triggerDialog.dummy = new int[triggerDialog.requiredItemKey.Length-1];
                        for (int i = 0; i < triggerDialog.dummy.Length; i++)
                        {
                            triggerDialog.dummy[i] = triggerDialog.requiredItemKey[i]; 
                        }
                        triggerDialog.requiredItemKey = new int[triggerDialog.arrayCount];
                        triggerDialog.dummy.CopyTo(triggerDialog.requiredItemKey,0);
                        triggerDialog.dummy = new int[triggerDialog.requiredAmount.Length-1];
                        for (int i = 0; i < triggerDialog.dummy.Length; i++)
                        {
                            triggerDialog.dummy[i] = triggerDialog.requiredAmount[i]; 
                        }
                        triggerDialog.requiredAmount = new int[triggerDialog.arrayCount];
                        triggerDialog.dummy.CopyTo(triggerDialog.requiredAmount,0);
                    }
                }
                EditorGUILayout.EndHorizontal();

                for (int i = 0; i < triggerDialog.requiredItemKey.Length; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Required Item ID", GUILayout.MaxWidth(100));
                    triggerDialog.requiredItemKey[i] = EditorGUILayout.IntField(triggerDialog.requiredItemKey[i]);
                    EditorGUILayout.LabelField("Required Item Amount", GUILayout.MaxWidth(130));
                    triggerDialog.requiredAmount[i] = EditorGUILayout.IntField(triggerDialog.requiredAmount[i]);
                    EditorGUILayout.EndHorizontal();
                }
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
        shackCanvas = FindObjectOfType<GenericCanvas>(true);
    }
    protected override void UpdateDisplay(bool active)
    {
        crosshair.SetActive(active);
    }
    protected override void FinalInteraction()
    {
        base.FinalInteraction();
    }
    public void OpenDoor()
    {
        for (int i = 0; i < requiredItemKey.Length; i++)
        {
            Item _item = InventoryManager.Inventory.GetInventory().items[requiredItemKey[i]];
            _item.amount -= requiredAmount[i];
        }
    }
    public void DeleteObject()
    {
        Destroy(this.gameObject);
    }
    public void OpenShack()
    {
        StopAllCoroutines();
        StartCoroutine(OShack());   
        IEnumerator OShack()
        {
            FadeManager.Fade.FadeIn();
            yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
            FindObjectOfType<CursorController>().is2D = true;
            FindObjectOfType<CursorController>().EnableCursor();
            shackCanvas.Show();
            FadeManager.Fade.FadeOut();
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Trigger2DDialog : TriggerDialog
{
    
#if UNITY_EDITOR
    [CustomEditor(typeof(Trigger2DDialog))]
    public class Trigger2DDialogEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Trigger2DDialog triggerDialog = (Trigger2DDialog)target;
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

    [SerializeField]
    int nextBackground;
    SpriteRenderer backgoundSprite;
    Object[] backgrounds;
    protected override void Start() 
    {
        base.Start();
        backgrounds = Resources.LoadAll("Backgrounds", typeof(Sprite));
        sfxPlayer = GameObject.FindGameObjectWithTag("SFXPlayer").GetComponent<AudioSource>();
        backgoundSprite = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>();
    }
    protected override void FinalInteraction()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeBackgound());      
    }
    IEnumerator ChangeBackgound()
    {
        FadeManager.Fade.FadeIn();
        yield return new WaitForSeconds(FadeManager.Fade.WaitTime);
        backgoundSprite.sprite = (Sprite)backgrounds[nextBackground];
        FadeManager.Fade.FadeOut();
    }
}

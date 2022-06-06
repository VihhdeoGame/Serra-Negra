using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextSettingsData", menuName = "ScriptableObjects/TextSettings")]
public class TextSettingsScriptableObject : ScriptableObject
{
    [SerializeField]
    private TextSpeed textSpeed;
    public TextSpeed TextSpeed{get {return textSpeed;}  set{this.textSpeed = value;}}
    [SerializeField]
    private float[] speed;
    public float Speed{get{return speed[(int)textSpeed];}}
    [SerializeField]
    private bool auto;
    public bool Auto{get{return auto;} set{this.auto = value;}}

}
    public enum TextSpeed{Slow = 0, Normal = 1, Fast = 2}
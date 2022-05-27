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
    private FontSize fontSize;
    public FontSize FontSize{get{return fontSize;} set{this.fontSize = value;}}

    [SerializeField]
    private float[] size;
    public float Size{get{return size[(int)fontSize];}}
}
    public enum TextSpeed{Slow = 0, Normal = 1, Fast = 2}
    public enum FontSize{Small = 0, Medium = 1, Large = 2}
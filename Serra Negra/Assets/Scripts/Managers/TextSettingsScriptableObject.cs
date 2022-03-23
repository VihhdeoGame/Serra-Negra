using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextSettingsData", menuName = "ScriptableObjects/TextSettings")]
public class TextSettingsScriptableObject : ScriptableObject
{
    [SerializeField]
    private TextSpeed textSpeed;
    public TextSpeed TextSpeed{set{this.textSpeed = value;}}
    [SerializeField]
    private float[] speed;
    public float Speed{get{return speed[(int)textSpeed];}}

    [SerializeField]
    private FontSize fontSize;
    public FontSize FontSize{get{return fontSize;} set{this.fontSize = value;}}
}
    public enum TextSpeed{Slow = 0, Normal = 1, Fast = 2}
    public enum FontSize{Small = 10, Medium = 20, Large = 30}
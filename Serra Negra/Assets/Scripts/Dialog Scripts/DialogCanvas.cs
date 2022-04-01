using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogCanvas : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    TextMeshProUGUI textBox;
    [SerializeField]
    TextMeshProUGUI nameBox;
    [SerializeField]
    Image speakerSprite;
    public GameObject Canvas{get{return canvas;}}
    public TextMeshProUGUI TextBox {get {return textBox;}}
    public TextMeshProUGUI NameBox {get {return nameBox;}}
    public Image SpeakerSprite {get {return speakerSprite;}}
}

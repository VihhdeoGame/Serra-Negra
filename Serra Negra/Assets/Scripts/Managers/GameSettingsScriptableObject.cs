using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameSettingsData", menuName = "ScriptableObjects/GameSettings")]
public class GameSettingsScriptableObject : ScriptableObject
{
    [SerializeField] 
    private GameLanguageType gameLanguage;
    public GameLanguageType GameLanguage {get {return gameLanguage;} set {this.gameLanguage = value;}}
/*    [SerializeField]
    private QualityType gameQuality;
    public QualityType GameQuality {get {return gameQuality;} set {this.gameQuality = value;}} */
}
public enum GameLanguageType {PT_BR = 0,EN_US = 1}
//public enum QualityType {Low = 0, Medium = 1, High = 2, Very_High = 3, Ultra = 4}

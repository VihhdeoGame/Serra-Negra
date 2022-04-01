using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsData", menuName = "ScriptableObjects/GameSettings")]
public class GameSettingsScriptableObject : ScriptableObject
{
    [SerializeField] 
    private GameLanguageType gameLanguage;
    public GameLanguageType GameLanguage {get {return gameLanguage;} set {this.gameLanguage = value;}}
}
public enum GameLanguageType {PT_BR = 0,EN_US = 1}
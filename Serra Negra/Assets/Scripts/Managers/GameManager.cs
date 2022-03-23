using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerData", menuName = "ScriptableObjects/GameManager")]
public class GameManager : SingletonScriptableObject<GameManager>
{
    [SerializeField]
    private GameSettingsScriptableObject gameSettings;
    public static GameSettingsScriptableObject GameSettings{get {return Instance.gameSettings;}}
    [SerializeField]
    private TextSettingsScriptableObject textSettings;
    public static TextSettingsScriptableObject TextSettings{get {return Instance.textSettings;}}
    [SerializeField]
    private AudioSettingsScriptableObject audioSettings;
    public static AudioSettingsScriptableObject AudioSettings{get {return Instance.audioSettings;}}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void FirstInitialize()
    {

    }
}

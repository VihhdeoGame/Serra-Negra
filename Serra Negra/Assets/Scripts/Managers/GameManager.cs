using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerData", menuName = "ScriptableObjects/GameManager")]
public class GameManager : SingletonScriptableObject<GameManager>
{
    [SerializeField]
    private GameSettingsScriptableObject gameSettings;
    public static GameSettingsScriptableObject GameSettings{get {return Instance.gameSettings;}}
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void FirstInitialize()
    {

    }
}

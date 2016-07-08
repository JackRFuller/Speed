using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Level Data", menuName = "Data Objects/Level Data", order = 1)]
public class LevelData : ScriptableObject
{
    public GameObject m_levelPrefab;
    public levelType LevelType;

    public enum levelType
    {
        TimeTrial,
    }
}

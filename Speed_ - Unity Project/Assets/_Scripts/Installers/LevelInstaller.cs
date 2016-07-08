using UnityEngine;
using System.Collections;

public class LevelInstaller : Singleton<LevelInstaller>
{

    [SerializeField] private levelType LevelType;
    [SerializeField] private dataPath UserName;

    [SerializeField] private int m_LevelID;
    private LevelData m_LevelData;

    [SerializeField] private enum levelType
    {
        Building,
        Testing,
    }

    [SerializeField] private enum dataPath
    {
        Jack,
        Chris,
    }

    [Header("Objects To Spawn")]
    [SerializeField] private GameObject player;
    
    void OnEnable()
    {
        if(LevelType == levelType.Testing)
            GetLevelDetails();

    }

    void GetLevelDetails()
    {
        string _dataPath = "LevelData/";

        if (UserName == dataPath.Jack)
            _dataPath += "Jack/";
        else _dataPath += "Chris/";

        string _levelName = "Level " + m_LevelID.ToString();

        m_LevelData = Resources.Load(_dataPath+_levelName, typeof(LevelData)) as LevelData;

        LoadInPhysicalObjects();

        LoadInLevelControllers();
    }

    void LoadInPhysicalObjects()
    {
        GameObject _level = (GameObject) Instantiate(m_LevelData.m_levelPrefab);
        GameObject _player = (GameObject) Instantiate(player);
    }

    void LoadInLevelControllers()
    {
        switch(m_LevelData.LevelType)
        {
            case (LevelData.levelType.TimeTrial):
                LoadInTimeTrialController();
                break;
        }
    }

    void LoadInTimeTrialController()
    {
        GameObject _levelController = Resources.Load("GameModeControllers/TimeTrialController", typeof(GameObject)) as GameObject;
        _levelController = (GameObject) Instantiate(_levelController);
    }
}

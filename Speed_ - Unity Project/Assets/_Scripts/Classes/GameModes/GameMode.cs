using UnityEngine;
using System.Collections;

public class GameMode : Singleton<GameMode>
{
    [Header("UI")]
    [SerializeField] protected GameObject m_MainCanvas;

    private float levelTimer;

    public float LevelTimer
    {
        get { return levelTimer; }
    }

    public virtual void OnEnable()
    {
        LoadInUI();
    }

    public virtual void LoadInUI()
    {
        GameObject _UI = (GameObject) Instantiate(m_MainCanvas);        
    }

    public virtual void Update()
    {
        RunTimer();
    }

    void RunTimer()
    {
        levelTimer += Time.smoothDeltaTime;
    }
}

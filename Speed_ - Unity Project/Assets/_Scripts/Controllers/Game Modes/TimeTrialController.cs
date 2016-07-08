using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimeTrialController : Singleton<TimeTrialController>
{
    private float timer;
    public float Timer
    {
        get { return timer; }
    }
    private bool isRunningTimer = true;

    private float totalRunningTime;
    public float TotalRunningTime
    {
        get { return totalRunningTime; }
    }

    public event Action HitCheckpoint;
    public event Action StopTimer;

    private List<float> CheckpointTimes = new List<float>();

    void Start()
    {
        //Assign to Events
        StopTimer += StopRunningTimer;
        HitCheckpoint += AddCheckpointTime;
    }

    void Update()
    {
        if(isRunningTimer)
            RunTimer();
    }

    void RunTimer()
    {
        timer += Time.smoothDeltaTime;
    }

    void StopRunningTimer()
    {
        isRunningTimer = false;
    }

    void AddCheckpointTime()
    {
        CheckpointTimes.Add(timer);
    }







}

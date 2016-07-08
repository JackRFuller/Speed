using UnityEngine;
using System.Collections;

public class PlayerController : Singleton<PlayerController>
{
    private Vector3 initialSpawnPosition;
    private Vector3 lastCheckpointPosition;
    public Vector3 CheckpointSpawnPosition
    {
        set { lastCheckpointPosition = value; }
    }

    [Header("Health")]
    [SerializeField] private float maxHealth;
    private float currentHealth;

    [Header("Height Damage")]
    [SerializeField] private CharacterController cc;
    [SerializeField] private float maxFallHeightBeforeDamage;
    private float startingHeight;
    private float endHeight;
    private bool hasFallen = false;

    void Start()
    {
        GetInitialSpawnPosition();

        //Set Delegate Functions
        SetSoftResetFunctions();
        SetHardResetFunctions();
    }

    void SetInitialHealth()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(!cc.isGrounded)
            GetStartingHeightPosition();

        //if(cc.isGrounded && hasFallen)
        //    CalculateFallingDistance();
    }

    void GetStartingHeightPosition()
    {
        startingHeight = transform.position.y;

        hasFallen = true;
    }

    //void CalculateFallingDistance()
    //{
    //    endHeight = transform.position.y;

    //    if (endHeight < startingHeight)
    //    {
    //        float _difference = startingHeight
    //}

#region Spawning

    void GetInitialSpawnPosition()
    {
        initialSpawnPosition = PlayerSpawnBehaviour.Instance.PlayerSpawnPosition;

        //Set the Checkpoint To Be Player Spawn Pos
        lastCheckpointPosition = initialSpawnPosition;

        SetToInitialSpawnPosition();
    }

    void SetToInitialSpawnPosition()
    {
        transform.localPosition = initialSpawnPosition;
    }

    void SetToLastCheckpointPosition()
    {
        transform.localPosition = lastCheckpointPosition;
    }

    #endregion

#region Resetting

    void SetSoftResetFunctions()
    {
        ResetController.Instance.SoftReset += SetToLastCheckpointPosition;
    }

    void SetHardResetFunctions()
    {
        ResetController.Instance.HardReset += SetToInitialSpawnPosition;
    }

#endregion


}

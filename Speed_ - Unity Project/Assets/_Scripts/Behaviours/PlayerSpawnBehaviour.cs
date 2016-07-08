using UnityEngine;
using System.Collections;

public class PlayerSpawnBehaviour : Singleton<PlayerSpawnBehaviour> {

	private Vector3 playerSpawnPosition;

    public Vector3 PlayerSpawnPosition
    {
        get { return playerSpawnPosition; }
    }

    public override void Awake()
    {
        base.Awake();

        SetSpawnPosition();
    }

    void SetSpawnPosition()
    {
        playerSpawnPosition = transform.localPosition;
    }
    
}

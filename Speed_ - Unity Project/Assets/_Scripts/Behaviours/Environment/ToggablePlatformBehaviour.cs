using UnityEngine;
using System.Collections;
using ProBuilder2.Triangulator.Geometry;

public class ToggablePlatformBehaviour :PlatformBehaviour
{
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private MeshRenderer targetMesh;
    [SerializeField] private Collider targetCollider;

    [SerializeField] private bool isStartingActive;

    void Start()
    {
        SetPlatformState();
    }

    public override void ActivateSwitchBehaviour()
    {
        base.ActivateSwitchBehaviour();

        SetPlatformState();
    }

    void SetPlatformState()
    {
        if (isStartingActive)
            TurnOnPlatform();
        else
        {
            TurnOffPlatform();
        }
    }

    void TurnOnPlatform()
    {
        targetMesh.material = activeMaterial;
        targetCollider.enabled = true;

        isStartingActive = false;
    }

    void TurnOffPlatform()
    {
        targetMesh.material = inactiveMaterial;
        targetCollider.enabled = false;

        isStartingActive = true;
    }
	
}

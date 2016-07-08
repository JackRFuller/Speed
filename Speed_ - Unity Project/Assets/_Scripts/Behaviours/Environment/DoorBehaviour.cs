using UnityEngine;
using System.Collections;

public class DoorBehaviour : PlatformBehaviour
{
    [Header("Movement Attributes")]
    [SerializeField] private float openingTime;
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private float targetRotation;

    private Vector3 startingRotation;
    private Vector3 endRotation;
    private float timeStartedLerping;

    private bool isShut;

    private bool isMoving;

    public override void ActivateSwitchBehaviour()
    {
        base.ActivateSwitchBehaviour();

        if (!isMoving)
        {
            if (isShut)
                OpenDoor();
            else ShutDoor();
        }
    }

    void Update()
    {
        if(isMoving)
            LerpToTargetRotation();
    }

    void LerpToTargetRotation()
    {
        float _timeSinceLerping = Time.time - timeStartedLerping;
        float percentageComplete = _timeSinceLerping/openingTime;

        transform.eulerAngles = Vector3.Lerp(startingRotation, endRotation,movementCurve.Evaluate(percentageComplete));

        if (percentageComplete > 1.0f)
        {
            isMoving = false;

            if (isShut)
                isShut = false;
            else isShut = true;
        }
           

    }

    void OpenDoor()
    {
        startingRotation = transform.localEulerAngles;
        endRotation = startingRotation;

        endRotation.y += targetRotation;

        StartLerp();

    }

    void ShutDoor()
    {
        startingRotation = transform.localEulerAngles;
        endRotation = startingRotation;

        endRotation.y -= targetRotation;

        StartLerp();
    }

    void StartLerp()
    {
        timeStartedLerping = Time.time;
        isMoving = true;
    }
}

using UnityEngine;
using System.Collections;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] private SwitchType switchType;
    [SerializeField] private Transform[] targets;
    [SerializeField] private float delayBetweenActivation;
    private bool hasActivatedSwitch = false;

    private enum SwitchType
    {
        Single,
        Repeatable,
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasActivatedSwitch)
            {
                StartCoroutine(TriggerSwitch());
            }

            if (switchType == SwitchType.Single)
                hasActivatedSwitch = true;

        }
    }

    IEnumerator TriggerSwitch()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SendMessage("ActivateSwitchBehaviour", SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(delayBetweenActivation);
        }
    }
}

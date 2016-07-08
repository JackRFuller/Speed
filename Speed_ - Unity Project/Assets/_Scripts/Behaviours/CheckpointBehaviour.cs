using UnityEngine;
using System.Collections;

public class CheckpointBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.CheckpointSpawnPosition = transform.localPosition;
            Debug.Log("Set New Checkpoint");
        }
    }
}

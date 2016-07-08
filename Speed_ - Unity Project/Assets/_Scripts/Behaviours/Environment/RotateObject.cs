using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotationDirection;
	
	// Update is called once per frame
	void Update ()
    {
	    Rotate();
	}

    void Rotate()
    {
        transform.Rotate(rotationDirection * Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;

public class ResetController : Singleton<ResetController>
{
    public delegate void softReset();
    public softReset SoftReset;

    public delegate void hardReset();
    public hardReset HardReset;

	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyUp(KeyCode.Tab))
	        TriggerSoftReset();

	    if (Input.GetKeyUp(KeyCode.R))
	        TriggerHardReset();
	}

    void TriggerSoftReset()
    {
        SoftReset();
    }

    void TriggerHardReset()
    {
        HardReset();
    }
}

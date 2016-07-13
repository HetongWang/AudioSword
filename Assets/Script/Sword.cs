using UnityEngine;
using System.Collections;

public class Sword : WandController {

    public float mVelocityThreshold;

    protected override void Start()
    {
        base.Start();
        INIParser ini = new INIParser();
        TextAsset configAsset = Resources.Load("Config/config.ini") as TextAsset;
        ini.Open(configAsset);
        mVelocityThreshold = (float)ini.ReadValue("sword", "velocity_threshold", 0.0);
    }

    protected override void updateStatus()
    {
        if (rig.velocity.magnitude > mVelocityThreshold)
        {
            mActive = true;
        }
        else
        {
            mActive = false;
        }
    }
}

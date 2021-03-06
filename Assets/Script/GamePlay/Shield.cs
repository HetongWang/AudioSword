﻿using UnityEngine;
using System.Collections;

public class Shield : WandController {

    protected float mVelocityThreshold;

	// Use this for initialization
    protected override void Start () {
        base.Start();
		index = 1;
        mType = TYPE.SHIELD;
        INIParser ini = new INIParser();
        TextAsset configAsset = Resources.Load("Config/config.ini") as TextAsset;
        ini.Open(configAsset);
        mVelocityThreshold = (float)ini.ReadValue("shield", "velocity_threshold", 0.0);
    }

    protected override void updateStatus() {
         mActive = true;
    }
}

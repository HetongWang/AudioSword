﻿using UnityEngine;
using System.Collections;

public class Sword : WandController {

    protected float mVelocityThreshold;

    protected override void Start() {
        base.Start();
        mType = TYPE.SWORD;
        INIParser ini = new INIParser();
        TextAsset configAsset = Resources.Load("Config/config.ini") as TextAsset;
        ini.Open(configAsset);
        mVelocityThreshold = (float)ini.ReadValue("sword", "velocity_threshold", 0.0);
    }

    protected override void updateStatus() {
        if (mRig.velocity.magnitude >= mVelocityThreshold) {
            mActive = true;
        } else {
            mActive = false;
        }
    }
}

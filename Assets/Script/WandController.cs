﻿using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

    public TYPE mType;
    public Player mPlayer;
    protected bool mActive;
    protected Rigidbody mRig;

    protected virtual void Start()
    {
        mRig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        updateStatus();
    }

    private void OnTriggerEnter(Collider collider)
    {
        TuneBase obj = collider.GetComponent<TuneBase>();
        if (obj != null && isActive() && obj.mType == mType)
        {
            obj.getHit(this);
            mPlayer.addScore(obj.getScore());
        }
    }

    protected virtual void updateStatus() { }

    public bool isActive()
    {
        return mActive;
    }
}

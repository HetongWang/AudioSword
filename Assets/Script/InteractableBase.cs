﻿using UnityEngine;
using System.Collections;

public enum TYPE { SHIELD, SWORD };

// this class is the base class of tune object
public class InteractableBase : MonoBehaviour {

    public TYPE mType;
    protected int score = 0;
    protected Vector3 mDestination;
    protected float mVelocity = 1f;

    private void Start()
    {
        mDestination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        WandController controller = collider.GetComponent<WandController>();
        if (controller != null && controller.isActive() && controller.mType == mType)
        {
            destory();
        }
    }

    // called when object is hit
    public virtual void destory() { }

    public Vector3 getDestination()
    {
        return mDestination;
    }

    public void setDestination(Vector3 pos)
    {
        mDestination = pos;
    }
}

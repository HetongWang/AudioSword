using UnityEngine;
using System.Collections;
using System;

public enum TYPE { SHIELD, SWORD };

// this class is the base class of tune object
public class TuneBase : MonoBehaviour {
    static public float USER_SCALE = 2;
    public TYPE mType;
    
    protected int mScore = 0;
    protected Vector3 mDeparture;
    protected Vector3 mDestination;
    protected float mVelocity;
    //public int mDeparture_x, mDeparture_y, mDeparture_z;

    protected virtual void Start()
    {
        mDestination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public virtual void getHit(WandController wand)
    {
        destory();
    }

    // called when object is hit
    public virtual void destory() { }

    public int getScore()
    {
        return mScore;
    }

    public Vector3 getDeparture()
    {
        return mDeparture;
    }

    public void setDestination(Vector3 pos)
    {
        mDestination = pos;
    }
}

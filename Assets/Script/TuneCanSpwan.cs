using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TuneCanSpwan : IComparable{
    public int mDepartureTime; // in ms
    static public float USER_SCALE = 2;
    public TYPE mType;

    protected int mScore = 0;
    public Vector3 mDeparture;
    protected Vector3 mDestination;
    public float mVelocity;
    public TuneCanSpwan(float x, float y, float z, float v, TYPE type, int hitTime)
    {
        mDeparture = new Vector3(x, y, z);
        mVelocity = v;
        mType = type;
        mDepartureTime = Math.Max(0,(int)(hitTime - (mDeparture.magnitude) * 1000 / v));
    }



    // Update is called once per frame
    void Update () {
	
	}


    public int CompareTo(object obj)
    {
        return (mDepartureTime > ((TuneCanSpwan)obj).mDepartureTime) ? 1 : 0;
    }
}

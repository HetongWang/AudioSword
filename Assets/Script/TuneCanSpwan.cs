using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TuneCanSpwan : IComparable{
    public int mDepartureTime; // in ms
    static public float USER_SCALE = 1f;
    public TYPE mType;

    public int mScore = 0;
    public Vector3 mDeparture;
    protected Vector3 mDestination;
    public float mVelocity;
    public int mHitTime;

    public GameObject obj;
    

    public TuneCanSpwan(float x, float y, float z, float v, TYPE type, int hitTime) {
        mDeparture = new Vector3(x, y, z);
        mVelocity = v;
        mType = type;
        mHitTime = hitTime;
        mDepartureTime = Math.Max(0,(int)(hitTime - ((mDeparture - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude - USER_SCALE) * 1000 / v));
    }



    // Update is called once per frame
    void Update () {
	
	}


    public int CompareTo(object obj) {
        return (mDepartureTime - ((TuneCanSpwan)obj).mDepartureTime);
    }
}   

using UnityEngine;
using System.Collections;
using System;

public enum TYPE { SHIELD, SWORD };

// this class is the base class of tune object
public class TuneBase : MonoBehaviour {
    static public float USER_SCALE = 2;
    public TYPE mType;
    
    protected int mScore = 0;
    protected Vector3 mVelocity;
    //public int mDeparture_x, mDeparture_y, mDeparture_z;

    protected virtual void Start()
    {
    }

    protected virtual void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = mVelocity;
    }

    public virtual void getHit(WandController wand)
    {
        destory();
        Debug.Log ("get hit");
    }

    // called when object is hit
    public virtual void destory() 
	{
		Destroy (gameObject);
	}

    public int getScore()
    {
        return mScore;
    }

    public void setVelocity(Vector3 v)
    {
        mVelocity = v;
    }
}

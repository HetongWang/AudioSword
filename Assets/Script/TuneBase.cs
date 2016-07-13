using UnityEngine;
using System.Collections;

public enum TYPE { SHIELD, SWORD };

// this class is the base class of tune object
public class TuneBase : MonoBehaviour {

    public TYPE mType;
    protected int mScore = 0;
    protected Vector3 mDeparture;
    protected Vector3 mDestination;
    protected float mVelocity;

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

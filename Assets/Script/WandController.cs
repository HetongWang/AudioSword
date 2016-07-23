using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

    public TYPE mType;
    [HideInInspector]
    public Player mPlayer;
    protected bool mActive;
    protected Rigidbody mRig;

    protected virtual void Start() {
        mRig = GetComponent<Rigidbody>();
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update() {
        updateStatus();
    }

    private void OnTriggerEnter(Collider collider) {
        TuneBase obj = collider.GetComponent<TuneBase>();
        if (obj != null && isActive() && obj.mType == mType)
		{
            obj.getHit(this);
            mPlayer.addScore(obj.getScore());
            // 这里震动
            SteamVR_Controller.Input(0).TriggerHapticPulse(100);
        }
    }

    protected virtual void updateStatus() { }

    public bool isActive() {
        return mActive;
    }
}

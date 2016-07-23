using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

    public TYPE mType;
    [HideInInspector]
    public Player mPlayer;
    protected bool mActive;
    protected Rigidbody mRig;
	protected int index;

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
			Debug.Log (mType.ToString());
			Debug.Log (obj.mType.ToString());
            obj.getHit(this);
            mPlayer.addScore(obj.getScore());
			StartCoroutine (LongVibration (0.5f, 0.5f));
        }
    }

    protected virtual void updateStatus() { }

    public bool isActive() {
        return mActive;
    }

	IEnumerator LongVibration(float length, float strength) {
	    for(float i = 0; i < length; i += Time.deltaTime) {
    	    SteamVR_Controller.Input(index).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
    	    yield return null;
    	}
	}

}

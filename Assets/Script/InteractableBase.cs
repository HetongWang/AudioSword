using UnityEngine;
using System.Collections;

public enum TYPE { SHIELD, SWORD };

// this class is the base class of tune object
public class InteractableBase : MonoBehaviour {

    public TYPE mType;
    private Vector3 mDestination;
    private float mVelocity = 1f;

    private void Start()
    {
        mDestination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        WandController controller = collider.GetComponent<WandController>();
        if (controller != null && controller.isActive())
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

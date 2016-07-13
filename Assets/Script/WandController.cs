using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

    public TYPE mType;
    protected bool mActive;
    protected Rigidbody rig;

    protected virtual void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        updateStatus();
    }

    private void OnTriggerEnter(Collider collider)
    {
        InteractableBase obj = collider.GetComponent<InteractableBase>();
        if (obj != null && isActive() && obj.mType == mType)
        {
        }
    }

    protected virtual void updateStatus() { }

    public bool isActive()
    {
        return mActive;
    }
}

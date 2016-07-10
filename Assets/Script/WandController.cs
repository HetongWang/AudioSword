using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

    public TYPE mType;
    private bool mActive;

    private void OnTriggerEnter(Collider collider)
    {
        InteractableBase obj = collider.GetComponent<InteractableBase>();
        if (obj != null && isActive() && obj.mType == mType)
        {

        }
    }

    public bool isActive()
    {
        return mActive;
    }
}

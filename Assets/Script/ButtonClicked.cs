using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {

    public string name;

    void Start() {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=> { onClick(); });
    }
    
    void Update() {
    }

    public void onClick() {
        Debug.Log("Button Clicked");
        TuneManager.musicName = name;
        SteamVR_LoadLevel.Begin("Scene/snow");
    }
}

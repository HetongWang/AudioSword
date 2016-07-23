using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {

    public string name;

    void Start() {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=> { onClick(); });
    }
    
    void Update() {
        GetComponent<UnityEngine.UI.Button>().Select();
    }

    public void onClick() {
        Debug.Log("Button Clicked");
        TuneManager.musicName = name;
        SteamVR_LoadLevel.Begin("snow");
    }
}

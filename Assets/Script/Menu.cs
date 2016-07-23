using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Menu : MonoBehaviour {

    public GameObject buttonPrefab;
    public GameObject songList;
    private List<string> fileNames = new List<string>();
    private static int WIDTH_GAP = -5;

	// Use this for initialization
	void Start () {
        DirectoryInfo dirInfo = new DirectoryInfo("Assets/Resources/Songs");
        FileInfo[] files = dirInfo.GetFiles();
        int index = -2;
        foreach (FileInfo fileInfo in files) {
            Debug.Log(fileInfo.Extension);
            if (fileInfo.Extension != ".meta") {
                string name = fileInfo.Name.Split('.')[0];
                GameObject button = Instantiate(buttonPrefab) as GameObject;
                button.transform.FindChild("Text").GetComponent<UnityEngine.UI.Text>().text = name;
                button.transform.parent = songList.transform;

                Vector3 pos = buttonPrefab.transform.localPosition;
                pos.y += index++ * WIDTH_GAP;
                button.transform.localPosition = pos;
                button.transform.localRotation = buttonPrefab.transform.localRotation;
                button.transform.localScale = buttonPrefab.transform.localScale;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

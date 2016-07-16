using UnityEngine;
using System.Collections;

public class note_controller : MonoBehaviour {

    private Rigidbody self;
    public int score;
	// Use this for initialization
	void Start () {
        self = GetComponent<Rigidbody>();
        self.velocity = new Vector3(0, -1, -1);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "hand")
        {
            // 判断动作
        }
    }
}

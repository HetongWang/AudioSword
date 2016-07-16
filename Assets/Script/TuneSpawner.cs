using UnityEngine;
using System.Collections.Generic;

public class TuneSpawner : MonoBehaviour {
    List<TuneCanSpwan> spawnList;
    float mStartTime;
    public GameObject tune00_prefab;
    public GameObject tune01_prefab;
    public GameObject tune02_prefab;
    public GameObject tune03_prefab;
    //private TextAsset mTextAsset;

    // Use this for initialization
    void Start () {
        var json = ((TextAsset)Resources.Load("m01")).text; // 没有后缀
        TuneList list = JsonUtility.FromJson<TuneList>(json);
        spawnList = new List<TuneCanSpwan>();
        foreach (var tune in list.l)
        {
            spawnList.Add(new TuneCanSpwan(tune.mDeparture_x, tune.mDeparture_y, tune.mDeparture_z, tune.mVelocity, tune.mType,tune.mHitTime));
        }
        //spawnList.Sort();
        foreach (var item in spawnList)
        {
            print(item.mDepartureTime);
        }
        StartTimer();

    }
	
    void StartTimer()
    {
        mStartTime = Time.time;
    }


	// Update is called once per frame
	void Update () {
        if (spawnList.Count == 0) return;
        float now_time = Time.time - mStartTime;
        if(spawnList[0].mDepartureTime <= (int)(now_time*1000))
        {
            print((int)(now_time * 1000));
            print(spawnList[0].mDepartureTime);
            //spawnList[0].Spawn(prefab);
            var note = Spawn(tune00_prefab, spawnList[0].mDeparture, spawnList[0].mVelocity);
            Destroy(note, spawnList[0].mHitTime - spawnList[0].mDepartureTime);
            print("Spwnaed!");
            spawnList.RemoveAt(0);
            //foreach (var item in spawnList)
            //{
            //    print(item.mDepartureTime);
            //}
        }
    }
    public GameObject Spawn(GameObject prefab, Vector3 mDeparture, float mVelocity)
    {
        var note = (GameObject)Instantiate(prefab, mDeparture, Quaternion.identity);
        var mDestination = GameObject.FindGameObjectWithTag("Player").transform.position;
        note.GetComponent<Rigidbody>().velocity = mVelocity * ( mDestination - mDeparture).normalized;
        return note;
    }
}


public class TuneList
{
    public List<TuneForJson> l;
}

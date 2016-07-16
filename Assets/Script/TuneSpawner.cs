using UnityEngine;
using System.Collections.Generic;



public class TuneSpawner : MonoBehaviour {

    public delegate void disappearHandler();
    public static event disappearHandler disappearEvent;

    List<TuneCanSpwan> spawnList;
    List<TuneCanSpwan> destroyList;
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
        destroyList = new List<TuneCanSpwan>();;
        foreach (var tune in list.l)
        {
            spawnList.Add(new TuneCanSpwan(tune.mDeparture_x, tune.mDeparture_y, tune.mDeparture_z, tune.mVelocity, tune.mType,tune.mHitTime));
        }
        spawnList.Sort();
        foreach (var item in spawnList)
        {
            print(item.mHitTime);
        }
        StartTimer();

    }
	
    void StartTimer()
    {
        mStartTime = Time.time;
    }


	// Update is called once per frame
	void Update () {
        float now_time = Time.time - mStartTime;
        if(spawnList.Count != 0 && spawnList[0].mDepartureTime <= (int)(now_time*1000))
        {
            var note = Spawn(tune00_prefab, spawnList[0].mDeparture, spawnList[0].mVelocity);
            spawnList[0].obj = note;
            //Destroy(note, 1.0f*spawnList[0].mHitTime/1000 - (1.0f*spawnList[0].mDepartureTime/1000));
            destroyList.Add(spawnList[0]);
            spawnList.RemoveAt(0);

        }
        for (int i = 0; i < destroyList.Count; i++)
        {
            var item = destroyList[i];
            if (item.obj == null) continue;
            if (1.0f*item.mHitTime / 1000 <= now_time)
            {
                Destroy(item.obj, 0);
                //disappearEvent();
                destroyList.Remove(item);
            }
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

using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class TuneManager : MonoBehaviour {

    public delegate void disappearHandler();
    public static event disappearHandler disappearEvent;

    static public string musicName = "加勒比海盗";
    static public bool finished = false;
    List<TuneCanSpwan> spawnList;
    List<TuneCanSpwan> destroyList;
    float mStartTime;
    public GameObject tune00_prefab;
    public GameObject tune01_prefab;
    public GameObject tune02_prefab;
    public GameObject tune03_prefab;
    public GameObject tune04_prefab;

    public GameObject effect0;
    public GameObject effect1;


    //private TextAsset mTextAsset;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
        finished = false;
        //var path = Application.dataPath + @"/Resources/" + musicName;

        //if (File.Exists(path))
        //{
        //string json = File.ReadAllText(path + ".txt");
        //WWW www = new WWW("file://" + path + ".mp3");
        //song.clip = www.audioClip;


        //audio_s.clip = new AudioClip("");
        //print(text);
        //}


        var json = ((TextAsset)Resources.Load( "Songs/" + musicName)).text; // 没有后缀


        var music = (AudioClip)Resources.Load("Music/" + musicName, typeof(AudioClip));
        audioSource.clip = music;
        audioSource.Play();

        //audioSource.playOnAwake = true;
        TuneList list = JsonUtility.FromJson<TuneList>(json);
        spawnList = new List<TuneCanSpwan>();
        destroyList = new List<TuneCanSpwan>();;
        foreach (var tune in list.l)
        {
            spawnList.Add(new TuneCanSpwan(tune.mDeparture_x, tune.mDeparture_y, tune.mDeparture_z*2+5, tune.mVelocity, tune.mType,tune.mHitTime));
        }
        spawnList.Sort();
        StartTimer();
    }
	
    void StartTimer() {
        mStartTime = Time.time;
    }


	// Update is called once per frame
	void Update () {
        //audioSource.Play();


        float now_time = Time.time - mStartTime;

        if(spawnList.Count == 0)// end 
        {
            finished = true;
            audioSource.Stop();
        }

        if(spawnList.Count != 0 && spawnList[0].mDepartureTime <= (int)(now_time*1000))
        {
            GameObject prefab = tune00_prefab;
            // 这里判断 mType 处理不同类型音符
            switch (spawnList[0].mType)
            {
                case TYPE.SWORD:
                    switch (Mathf.RoundToInt(4 * Random.value))
                    {
                        case 0:
                            prefab = tune01_prefab;
                            break;
                        case 1:
                            prefab = tune02_prefab;
                            break;
                        case 2:
                            prefab = tune03_prefab;
                            break;
                        case 3:
                            prefab = tune04_prefab;
                            break;
                    }
                    break;
                case TYPE.SHIELD:
                    prefab = tune00_prefab;
                    break;
            }


            var note = Spawn(prefab, spawnList[0]);

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
                disappearEvent(); // 这里调用过期事件
                destroyList.Remove(item);
                //var e = Instantiate(effect0, GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0,0,1f), Quaternion.EulerRotation(0,0,0));
                //Destroy(e, 1);
            }
        }
    }

    public GameObject Spawn(GameObject prefab, TuneCanSpwan tune)
    {
        var note = (GameObject)Instantiate(prefab, tune.mDeparture, Quaternion.identity);
        var destination = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0,0.8f,0);
        //note.GetComponent<Rigidbody>().velocity = mVelocity * ( mDestination - mDeparture).normalized;
        note.GetComponent<TuneBase>().mScore = tune.mType==TYPE.SWORD?2:1;
        note.GetComponent<TuneBase>().mType = tune.mType;
        note.GetComponent<TuneBase>().mVelocity = tune.mVelocity * (destination - tune.mDeparture).normalized;
        return note;
    }
}


public class TuneList
{
    public List<TuneForJson> l;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _Instance = null;
    private bool isPlaying = false;

    // 개체 이니셜라이저를 사용해서 개체 이니셜라이저 설정(생성자)
    public static SoundManager I
    {
        get
        {
            if(_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;           // SoundManager 객체 반환
        }
    }

    void Awake()
    {
        _Instance = this;
    }

    public int audioSourceCount = 3;

    [SerializeField]
    [Header("clips"), Tooltip("오디오 클립들")]
    public AudioClip[] BGMs = new AudioClip[3];

    private AudioSource BGMsource;

    public delegate void CallBack();
    CallBack BGMendCallBack;

    // 이 스크립트가 시작되면 호출되는 콜백메소드
    void OnEnable()
    {
        float volume = PlayerPrefs.GetFloat("volumeBGM", 1);

        //BGMsource = gameObject.AddComponent<AudioSource>(); 이건 컴포넌트를 새로 추가하는것
        BGMsource = gameObject.GetComponent<AudioSource>();     // 기존 컴포넌트를 조작하는것.
        BGMsource.volume = volume;
        BGMsource.playOnAwake = false;
        BGMsource.loop = true;

        ChangeBGM(GetRandomBGMName(), false);
    }

    /************BGM*************/

    private AudioClip changeClip;       // 바뀌는 클립
    private bool isChanging = false;
    private float startTime;

    [SerializeField]
    [Header("Changing speed"), Tooltip("브금 바꾸는 속도")]
    public float ChangingSpeed;

    public void ChangeBGM(string name, bool isSmooth = false, CallBack callback = null)// 브금 변경(브금이름, 부드럽게 바꾸기)
    {
        BGMendCallBack = callback;

        changeClip = null;
        for(int i = 0; i < BGMs.Length; i++)        // 브금 클립 탐색
        {
            if(BGMs[i].name == name)
            {
                changeClip = BGMs[i];
            }
        }

        if (changeClip == null)      // 없으면 재생안함
            return;

        if(!isSmooth)
        {
            BGMsource.clip = changeClip;        // 음악 클립 변경
            //BGMsource.Play();
        }else
        {
            startTime = Time.time;
            isChanging = true;
        }
        isPlaying = false;
    }
    // 음악 이름 랜덤으로 찾기
    public string GetRandomBGMName()
    {
        return BGMs[Random.Range(0, BGMs.Length)].name;
    }

    private void Update()
    {
        if (!isChanging) return;

        float progress = (Time.time - startTime) * ChangingSpeed;// 부드러운 오디오 전환
        BGMsource.volume = Mathf.Lerp(PlayerPrefs.GetFloat("volumeBGM", 1), 0, progress);

        if(progress > 1)
        {
            isChanging = false;
            BGMsource.volume = PlayerPrefs.GetFloat("volumeBGM", 1);
            BGMsource.clip = changeClip;
            BGMsource.Play();
        }
    }
    // 음악재생
    public void PlayBGM()
    {
        BGMsource.Play();
        isPlaying = true;
    }
    // 음악 정지
    public void StopBGM()
    {
        BGMsource.Stop();
        isPlaying = false;
    }
    
    // 음악 일시정지
    public void PauseBGM()
    {
        BGMsource.Pause();
    }

    // 핏치값 설정
    public void SetPitch(float pitch)
    {
        BGMsource.pitch = pitch;
    }

    // 재생되고 있는가?
    public bool isPlay()
    {
        return isPlaying;
    }
    // 볼륨

    public void changeBGMVolume(float volume)
    {
        PlayerPrefs.SetFloat("volumeBGM", volume);
        BGMsource.volume = volume;
    }


}

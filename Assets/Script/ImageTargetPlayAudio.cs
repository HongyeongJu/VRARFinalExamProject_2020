using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetPlayAudio : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehavior;
    //public AudioSource audio;

    private SoundManager mSoundManager;         // 직접만든 SoundManager
    // Start is called before the first frame update
    void Start()
    {
        mSoundManager = GetComponent<SoundManager>();
        mTrackableBehavior = GetComponent<TrackableBehaviour>();
        if (mTrackableBehavior)
        {
            mTrackableBehavior.RegisterTrackableEventHandler(this);
        }
    }
    
    // AR 트레킹되었을때 불려지는 콜백함수
    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // 타겟이 발견되었을 때 음악재생
            if (mSoundManager.isPlay())     // 음악이 현재 재생중이였다면 다시 실행
            {
                mSoundManager.PlayBGM();
            }else{                      // 음악이 실행중이지 않으면 랜덤곡 실행 
                mSoundManager.ChangeBGM(mSoundManager.GetRandomBGMName());
                mSoundManager.PlayBGM();
            }
        }
        else
        {
            // 타겟이 없어졌을 때 중지
            mSoundManager.PauseBGM();
        }
    }
    
}

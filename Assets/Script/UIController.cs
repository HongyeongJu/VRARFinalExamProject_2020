using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject mImageTarget;        // 이미지 타겟 객체(SoundManager를 참조하기 위해서사용)
    SoundManager mSoundManager;     // 사운드 매니저
    // Start is called before the first frame update
    void Start()
    {
        mSoundManager = mImageTarget.GetComponent<SoundManager>();      // SoundManager 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 시작 하기 버튼을 눌렀을때
    public void PlayButtonEvent()
    {
        SceneManager.LoadScene("PlayScene");
    }

    // 뒤로가기 버튼을 눌렀을때
    public void BackButtonEvent()
    {
        SceneManager.LoadScene("StartScene");
    }

    // 징글벨 버튼을 눌럿을때
    public void JingleBellButtonEvent()
    {
        mSoundManager.ChangeBGM("Xmas_Christmas_Song_Loop");
        mSoundManager.PlayBGM();
    }
    // 울면안돼 버튼을 눌렀을때
    public void DontCryButtonEvent()
    {
        mSoundManager.ChangeBGM("SANTA_CLAUS_IS_COMING_TO_TOWN");
        mSoundManager.PlayBGM();
    }
    // 거룩한밤 버튼을 눌렀을때
    public void SilentNightButtonEvent()
    {
        mSoundManager.ChangeBGM("Silent_Night_Holy_Night");
        mSoundManager.PlayBGM();
    }
}

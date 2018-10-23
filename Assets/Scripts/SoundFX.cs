using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SfxType {
    TAP,
    TAP_BACK,
    LABIRIN,
    STAR,
    LOGO_TULUS,
    LEFT_RIGHT,
    HIT_WALL,
    HIT_OBSTACLE
}

public enum PlayType {
    PLAY,
    RESTART,
    STOP,
    PAUSE,
    UNPAUSE,
    MAIN_BGM
}

[System.Serializable]
public class AudioClass {
	public SfxType Type;
	public AudioClip SFX;
}

public class SoundFX : MonoBehaviour {

	public List <AudioClass> AudioList;
	public List <AudioSource> Audio;

	private AudioSource _Audio;

    [SerializeField]
    AudioSource _BGM;

    [SerializeField]
    GameObject _MainBGM;
	// Use this for initialization

	void Awake (){
		_Audio = GetComponent<AudioSource>();
        EventManager.AddListener<SFXPlayEvent>(PlaySFX);
        EventManager.AddListener<BGMEvent>(BGMHandler);
	}

    private void BGMHandler(BGMEvent e)
    {
        switch (e.Type) {
            case PlayType.PLAY:
                _MainBGM.SetActive(false);
                _BGM.Play();
                break;
            case PlayType.RESTART:
                _BGM.Stop();
                _BGM.Play();
                break;
            case PlayType.STOP:
                _BGM.Stop();
                break;
            case PlayType.PAUSE:
                _BGM.Pause();
                break;
            case PlayType.UNPAUSE:
                _BGM.UnPause();
                break;
            case PlayType.MAIN_BGM:
                _BGM.Stop();
                _MainBGM.SetActive(true);
                break;
        }
    }

    public void PlaySFX (SFXPlayEvent e)
    {
		bool isFind = false;
		bool notPlay = false;

		if (e.IsEnd){
			_Audio.Stop();
			for (int i = 0 ; i < AudioList.Count && !isFind; i++){
				if (AudioList[i].Type == e.Sfx){
					isFind = true;
					_Audio.clip = AudioList[i].SFX;
					_Audio.Play();
				}
			}
		}
		else{
			for (int i = 0 ; i < AudioList.Count && !isFind; i++){
				if (AudioList[i].Type == e.Sfx)
                {
					isFind = true;
					for (int x = 0; x < Audio.Count && !notPlay;x++){
						if (!Audio[x].isPlaying){
							Audio[x].Stop();
							Audio[x].clip = AudioList[i].SFX;
							Audio[x].Play();
							notPlay = true;
						}
					}
				}
			}
		}
	}
}

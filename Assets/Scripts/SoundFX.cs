using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SfxType {
    CLICK,
    CANCEL,
    LABIRIN,
    DIAMOND
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
	// Use this for initialization

	void Awake (){
		_Audio = GetComponent<AudioSource>();
        EventManager.AddListener<SFXPlayEvent>(PlaySFX);
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

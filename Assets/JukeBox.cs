using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*
 * Controls JukeBox
 */
public class JukeBox : MonoBehaviour {
	AudioSource audio;
	AudioClip[] songs;
	string[] songNames;

	int song = 0;
	string songName;

	Button Btn_Next;
	Button Btn_Prev;
	Text Txt_Song;

	void Start () {

		//ui stuff
		Btn_Next = transform.Find("Btn_Next").GetComponent<Button>();
		Btn_Prev = transform.Find("Btn_Prev").GetComponent<Button>();
		Txt_Song = transform.Find("BG_Song/Txt_Song").GetComponent<Text>();


		//song stuff
		audio = GetComponent<AudioSource>();

		songs = System.Array.ConvertAll(Resources.LoadAll("Audio", typeof(AudioClip)),o=>(AudioClip)o);

		songNames = new string[songs.Length];
		for(int i = 0; i < songs.Length; i++){
			songNames[i] = songs[i].name;
		}

		song = (int)Random.Range(0f, (float)songs.Length);
		changeSong();


		//button listeners
		Btn_Next.onClick.AddListener(() => {
			if(song < (songs.Length - 1))
				song++;
			else
				song = 0;

			changeSong();

		});

		Btn_Prev.onClick.AddListener(() => {
			if(song > 0)
				song--;
			else
				song = songs.Length - 1;
			changeSong();

		});
	}

	//reset song name and audioclip
	public void changeSong(){
		songName = songNames[song];
		audio.clip = songs[song];
		Txt_Song.text = songName;
		audio.Play();
	}
}

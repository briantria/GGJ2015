using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGMusicMngr : MonoBehaviour 
{
	private static BGMusicMngr m_instance;
	public static BGMusicMngr Instance {get{return m_instance;}}

//	private Transform m_transform;

//	private AudioSource bgm_singleCricket;
//	private AudioSource bgm_guitar;
//	private AudioSource bgm_amb02;
	
	public List<AudioSource> m_listAudioSource = new List<AudioSource>();
	private AudioSource m_audioSource;
	private float m_fadeSpeed;
	private float m_targetVolume;
	
	private void Awake ()
	{
		m_instance = this;
		m_fadeSpeed = 0.5f;
//		m_transform = this.transform;
//		bgm_singleCricket = m_transform.Find("SingleCricket").GetComponent<AudioSource>();
//		bgm_guitar = m_transform.Find("GuitarOminous").GetComponent<AudioSource>();
//		bgm_amb02 = m_transform.Find("Ambience02").GetComponent<AudioSource>();
	}
	
	public void FadeIn (BGMType p_bgmType, float p_vol)
	{
		m_audioSource = m_listAudioSource[(int)p_bgmType];
		m_audioSource.Play();
		m_targetVolume = p_vol;
		StartCoroutine ("IEFadeIn");
	}
	
	private IEnumerator IEFadeIn ()
	{
		while(m_audioSource.volume < m_targetVolume)
		{
			m_audioSource.volume += Time.deltaTime * m_fadeSpeed;
			yield return 0;
		}
	}
}

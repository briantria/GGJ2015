using UnityEngine;
using System.Collections;

public class LevelTheButton : MonoBehaviour 
{
	public AudioClip m_btnClick;
	private AudioSource m_audioSource;

	private void Awake ()
	{
		m_audioSource = GetComponent<AudioSource>();
	}
	
	public void OnClick ()
	{
		m_audioSource.PlayOneShot(m_btnClick);
		StartCoroutine(LoadNextLevel());
	}
	
	private IEnumerator LoadNextLevel ()
	{
		yield return new WaitForSeconds(m_btnClick.length);
		LevelMngr.Instance.LoadNextLevel (Constants.LVL_CURSORTIMEOUT);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelRun : MonoBehaviour 
{
	public Text m_letterW;
	private bool m_bIsPlatformVisible;
	private MaterialFadeAnim m_platformMatFadeAnim;
	
	private float m_letterFadeInSpeed;
	Vector4 m_letterColor;
	
	private CharacterMotor m_charMotor;
	
	#region MONO FUNCTIONS
	private void Awake ()
	{
		m_letterFadeInSpeed = 0.0f;
		m_letterColor = m_letterW.color;
		m_bIsPlatformVisible = false;
		m_platformMatFadeAnim = this.transform.FindChild("Platform").GetComponent<MaterialFadeAnim>();
		m_charMotor = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMotor>();
	}
	
	private void Start ()
	{
		Screen.showCursor = false;
		FadeIn();
	}
	
	private void Update ()
	{
		// TODO: Centralized keyboard input manager
		if(   m_bIsPlatformVisible == false
		   && Input.GetKeyDown(KeyCode.W))
		{
			StopCoroutine("IEFadeIn");
			m_bIsPlatformVisible = true;
			m_charMotor.enabled = true;
			m_platformMatFadeAnim.FadeIn();
			this.FadeOut(200.0f);
		}
	}
	#endregion
	
	private void FadeIn (float p_speed = 120.0f)
	{
		m_letterFadeInSpeed = p_speed;
		StartCoroutine("IEFadeIn");
	}
	
	private void FadeOut (float p_speed = 120.0f)
	{
		m_letterFadeInSpeed = -p_speed;
		StartCoroutine("IEFadeOut");
	}
	
	private IEnumerator IEFadeIn ()
	{
		while(m_letterColor.w < 1.0f)
		{
			m_letterColor.w += (Time.deltaTime * m_letterFadeInSpeed * Constants.ALPHA_RATIO);
			m_letterW.color = (Color) m_letterColor;
			yield return 0;
		}
		
		StopCoroutine("IEFadeIn");
	}
	
	private IEnumerator IEFadeOut ()
	{
		while(m_letterColor.w > 0.0f)
		{
			m_letterColor.w += (Time.deltaTime * m_letterFadeInSpeed * Constants.ALPHA_RATIO);
			m_letterW.color = (Color) m_letterColor;
			yield return 0;
		}
		
		StopCoroutine("IEFadeOut");
	}
}

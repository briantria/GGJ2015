using UnityEngine;
using System.Collections;

public class MaterialFadeAnim : MonoBehaviour 
{
	private Material m_material;
	private Vector4 m_color;
	
	private float m_speed;
	
	#region MONO FUNCTIONS
	private void Awake ()
	{
		m_material = renderer.material;
		m_color = (Vector4) m_material.color;
		m_speed = 0.0f;
	}
	#endregion 
	
	public void FadeIn (float p_speed = 120.0f)
	{
		m_speed = p_speed;
		StartCoroutine("IEFadeIn");
	}
	
	private IEnumerator IEFadeIn ()
	{
		while(m_color.w < 1.0f)
		{
			m_color.w += (Time.deltaTime * m_speed * Constants.ALPHA_RATIO);
			m_material.color = (Color) m_color;
			yield return 0;
		}
		
		StopCoroutine("IEFadeIn");
	}
}

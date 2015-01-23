using UnityEngine;
using UnityEngine.UI;

public class LevelRun : MonoBehaviour 
{
	public Text m_letterW;
	private float alpha;
	
	#region MONO FUNCTIONS
	private void Awake ()
	{
		alpha = 0.0f;
	}
	
	private void Update ()
	{
		if(alpha < 255)
		{
			alpha += 1.2f;
			Vector4 c = m_letterW.color;
			c.w += Time.deltaTime * alpha * 0.0039f; // speed * alpha * (1 / 255)
			m_letterW.color = (Color) c;
		}
	}
	#endregion
}

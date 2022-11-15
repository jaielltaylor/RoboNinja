using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutScript : MonoBehaviour
{
	public int nextSceneNumber;
	public Color startClr;
	public Color endClr;
	public Texture fadeTexture;
	private Color curClr;
	private float t;
	public float fadeLength;

	void Start()
	{
		t = 1;
		startClr = new Color(0f, 0f, 0f, 1.0f);
		endClr = new Color(0f, 0f, 0f, 0f);
		curClr = startClr;
	}

	void OnGUI()
	{
		GUI.color = curClr;
		GUI.depth = -10;
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), fadeTexture);

	}

	void Update()
	{
		if (t >= 0)
		{
			t += Time.deltaTime / fadeLength;
			curClr = Color.Lerp(startClr, endClr, t);
		}
		else
		{
			SceneManager.LoadScene(nextSceneNumber);
		}
	}
}

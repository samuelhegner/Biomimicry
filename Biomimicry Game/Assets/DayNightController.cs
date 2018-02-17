// ping-pong animate background color
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
	public Color color1 = Color.red;
	public Color color2 = Color.blue;
	public float duration = 3.0F;


	public GameObject mainCam;
	Camera cam;

	void Start()
	{
		cam = GetComponent<Camera>();
		cam.clearFlags = CameraClearFlags.SolidColor;
	}

	void Update()
	{
		float t = Mathf.PingPong(Time.time, duration) / duration;
		cam.backgroundColor = Color.Lerp(color1, color2, t);
	}
}
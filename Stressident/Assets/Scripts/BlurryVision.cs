using UnityEngine;
using System.Collections;

public class BlurryVision : MonoBehaviour 
{
	public bool stressed = false;
	public static float timeBetweenBlurs = 5.0f;

	private static BlurryVision bv;

	private float blurSpeed = 50f;
	private Vector3 blurRange = new Vector3(1, 1, 1);
	private float blurTimer = 0f;
	private const float blurTime = 0.75f;
	private float blurCountdown = timeBetweenBlurs;

	private bool blur = false;

	private Vector3 originalCameraPosition;

	public static BlurryVision getBlurryVision
	{
		get { return bv; }
	}

	private void Awake()
	{
		if (bv == null) 
		{
			bv = this;
		}
	}

	private void Update()
	{
		if (stressed) 
		{
			blurCountdown -= Time.deltaTime;
			if (blurCountdown < 0) 
			{
				CameraBlur ();
				blurCountdown = timeBetweenBlurs;
			}
		}

		if (blur) 
		{
			if (blurTimer > blurTime * Time.timeScale) {
				blurTimer = 0;
				blur = false;
				Time.timeScale = 1;

				Camera.main.transform.position = new Vector3 (originalCameraPosition.x, Camera.main.transform.position.y, originalCameraPosition.z);
			} else 
			{
				blurTimer += Time.deltaTime;
				Camera.main.transform.position = originalCameraPosition + Vector3.Scale (SmoothRandom.GetVector2 (blurSpeed--), blurRange);
				blurSpeed *= -1;
				blurRange = new Vector3 (blurRange.x * -1, blurRange.y);
			}
		}
	}

	public void CameraBlur()
	{
		originalCameraPosition = Camera.main.transform.position;

		blurSpeed = 50;

		Time.timeScale = 0.2f;

		blur = true;
	}
}

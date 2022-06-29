using System;
using System.Collections;
using UnityEngine;

public static class CoroutineHelpers
{
	public static void FireAndForgetWithDelay(this MonoBehaviour monoBehaviour, float seconds, Action action)
	{
		monoBehaviour.StartCoroutine(InvokeActionAfterDelay(seconds, action));
	}

	// ReSharper disable Unity.PerformanceAnalysis
	private static IEnumerator InvokeActionAfterDelay(float seconds, Action action)
	{
		yield return new WaitForSeconds(seconds);
		action();
	}
}

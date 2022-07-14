using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public static class MonoBehaviourHelpers
{
	public static void FireAndForgetWithDelay(this MonoBehaviour monoBehaviour, float seconds, Action action, CancellationToken cancellationToken = default)
	{
		monoBehaviour.StartCoroutine(InvokeActionAfterDelay(seconds, action, cancellationToken));
	}

	// ReSharper disable Unity.PerformanceAnalysis
	private static IEnumerator InvokeActionAfterDelay(float seconds, Action action, CancellationToken cancellationToken)
	{
		yield return new WaitForSeconds(seconds);
		if (cancellationToken.IsCancellationRequested) yield break;
		action();
	}
}

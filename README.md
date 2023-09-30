# useful-unity
A collection of my helper methods and extensions for Unity3d development

Use this script to import it (WIP)

```cs
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class ImportUsefulUnityEditor : Editor
{
	private const string url = "https://github.com/MarcusOtter/useful-unity.git";
	private const int timeoutMs = 5000;
	
	[MenuItem("Assets/Update MarcusOtter⧸useful-unity")]
	public static async void ShowWindow()
	{
		var request = Client.Add(url);

		if (request.Status == StatusCode.InProgress)
		{
			Debug.Log("Adding or updating MarcusOtter/useful-unity...");

			var elapsed = 0;
			while (request.Status == StatusCode.InProgress || elapsed > timeoutMs)
			{
				await Task.Delay(100);
				elapsed += 100;
				EditorUtility.DisplayProgressBar("Importing MarcusOtter/useful-unity", "Please wait...", elapsed / (float)timeoutMs);
			}
			EditorUtility.ClearProgressBar();
		}

		
		if (request.Status == StatusCode.Success)
		{
			Debug.Log("Successfully added or updated MarcusOtter/useful-unity");
		}
		else if (request.Status == StatusCode.Failure)
		{
			var errorMessages = request.Result?.errors?.Select(x => x?.message ?? "") ?? Array.Empty<string>();
			Debug.LogError("Failed to add or update MarcusOtter/useful-unity\n" + string.Join("\n", errorMessages));
		}
	}
}

```

using UnityEngine.SceneManagement;

public static class SimpleSceneManager
{
	public static void ReloadScene()
	{
		SceneManager.LoadScene(CurrentSceneIndex);
	}

	public static bool HasNextScene()
	{
		return NextScene.IsValid();
	}

	public static bool HasPreviousScene()
	{
		return PreviousScene.IsValid();
	}
	
	public static void LoadNextScene()
	{
		if (HasNextScene())
		{
			SceneManager.LoadScene(NextScene.buildIndex);
		}
	}

	public static void LoadPreviousScene()
	{
		if (HasPreviousScene())
		{
			SceneManager.LoadScene(PreviousScene.buildIndex);
		}
	}

	private static int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;
	private static Scene NextScene => SceneManager.GetSceneByBuildIndex(CurrentSceneIndex + 1);
	private static Scene PreviousScene => SceneManager.GetSceneByBuildIndex(CurrentSceneIndex - 1);
}

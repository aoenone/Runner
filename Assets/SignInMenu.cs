using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class SignInMenu : MonoBehaviour {

	private const float FontSizeMult = 0.05f;
	private bool mWaitingForAuth = false;
	private string mStatusText = "Ready.";

	// Use this for initialization
	void Start () {
		GooglePlayGames.PlayGamesPlatform.Activate();
	}

	void OnGUI() {
		GUI.skin.button.fontSize = (int)(FontSizeMult * Screen.height);
		GUI.skin.label.fontSize = (int)(FontSizeMult * Screen.height);

		GUI.Label(new Rect(20, 20, Screen.width, Screen.height * 0.25f), mStatusText);

		if (mWaitingForAuth) {
			return;
		}

		string buttonLabel = Social.localUser.authenticated ? "Sign Out" : "Authenticate";
		Rect buttonRect = new Rect(0.25f * Screen.width, 0.25f * Screen.height,
		                  0.5f * Screen.width, 0.5f * Screen.height);

		if (GUI.Button(buttonRect, buttonLabel)) {
			if (!Social.localUser.authenticated) {
				// Authenticate
				mWaitingForAuth = true;
				mStatusText = "Authenticating...";
				Social.localUser.Authenticate((bool success) => {
					mWaitingForAuth = false;
					mStatusText = success ? "Successfully authenticated" : "Authentication failed.";
					Application.LoadLevel("MainScene");
				});
			} else {
				// Sign out!
				mStatusText = "Signing out.";
				((GooglePlayGames.PlayGamesPlatform) Social.Active).SignOut();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

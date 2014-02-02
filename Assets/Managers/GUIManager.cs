using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GUIManager : MonoBehaviour {

	public GUIText boostsText, distanceText, gameOverText, instructionsText;
	
	private static GUIManager instance;

	int UserScore;
	long UserScoreLong;
	
	void Start () {
		instance = this;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
	}
	
	void Update () {
		if(Input.anyKeyDown){
			GameEventManager.TriggerGameStart();
		}
	}
	
	private void GameStart () {
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		enabled = false;
	}
	
	private void GameOver () {

		gameOverText.enabled = true;
		instructionsText.enabled = true;
		enabled = true;
		Social.ReportScore(UserScore, "CgkIy7DGy_AfEAIQAQ",(bool success)=>{
			Social.ShowLeaderboardUI();
		});
	}
	
	public static void SetBoosts(int boosts){
		instance.boostsText.text = boosts.ToString();
	}
	
	public static void SetDistance(float distance){
		instance.distanceText.text = distance.ToString("f0");
		instance.UserScore = (int) distance;

	}
}

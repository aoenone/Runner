using UnityEngine;


public class Booster : MonoBehaviour {

	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;
	
	void Start () {
		GameEventManager.GameOver += GameOver;
		gameObject.active = false;
	}
	
	void Update () {
		if(transform.localPosition.x + recycleOffset < Runner.distanceTraveled){
			gameObject.active = false;
			return;
		}
		transform.Rotate(rotationVelocity * Time.deltaTime);
	}
	
	void OnTriggerEnter () {
		Runner.AddBoost();
		gameObject.active = false;
	}
	
	public void SpawnIfAvailable (Vector3 position) {
		if(gameObject.active || spawnChance <= Random.Range(0f, 100f)) {
			return;
		}
		transform.localPosition = position + offset;
		gameObject.active = true;
	}
	
	private void GameOver () {
		gameObject.active = false;
	}
}

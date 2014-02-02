#pragma strict

private var ray : Ray;
private var hit : RaycastHit;

function Start () {

}

function Update () {
	if(Input.GetMouseButtonDown(0)){
	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	if(Physics.Raycast(ray, hit)){
		if(hit.transform.name == "StartGame"){
			Application.LoadLevel("Scene");
		}else if(hit.transform.name == "PlayGames"){
			Application.LoadLevel("PlaySign");
	  }else{
	  
	  }
	}
	}
}
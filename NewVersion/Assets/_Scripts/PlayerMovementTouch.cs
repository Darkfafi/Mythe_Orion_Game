using UnityEngine;
using System.Collections;

public class PlayerMovementTouch : MonoBehaviour {

	private Vector3 topStartPos;
	private Vector3 botStartPos;

	Vector2 firstPressTop;
	Vector2 secondPressTop;
	Vector2 currentSwipeTop;
	Vector2 firstPressBot;
	Vector2 secondPressBot;
	Vector2 currentSwipeBot;

	private int topTouch = -1;
	private int botTouch = -1;
	private Movement movement;

	void Start(){
		movement = gameObject.GetComponent<Movement> ();
	}
	
	void Update()
	{
		Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		for (var i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began) {
				if (Physics.Raycast(rayCast,out hit)){
					if(hit.transform.tag == "Player1" || hit.transform.tag == "Player2"){
						if(hit.transform.GetComponent <Movement>().moving == false){
							print("touch " + hit.transform.tag);
							if(touch.position.x < Screen.width/2){
								if(topTouch > -1){
									topTouch = i;
									topStartPos = Input.GetTouch(i).position;
								}
							}
							else {
								if(botTouch > -1){
									botTouch = i;
									botStartPos = Input.GetTouch(i).position;
								}
							}
						}
						else{
							hit.transform.GetComponent<Movement>().Stop();
						}
					}
					else if(hit.transform.tag == "obstakel"){
						//TODO obstakel interactie
						if(touch.position.x < Screen.width/2){
							//TODO bovenkant obstakel
						}
						else {
							//TODO onderkant obstakel
						}
					}
				}
			}
			else if (touch.phase == TouchPhase.Ended){
				//print("touch ended");
				if(i == topTouch){
					secondPressTop = new Vector2(Input.GetTouch(i).position.x,Input.GetTouch(i).position.y);

					currentSwipeTop = new Vector3(secondPressTop.x - firstPressTop.x, secondPressTop.y - firstPressTop.y);

					currentSwipeTop.Normalize();
					
					//swipe up
					if(currentSwipeTop.y > 0 && currentSwipeTop.x > -0.5f && currentSwipeTop.x < 0.5f)
					{
						hit.transform.GetComponent<Movement>().Jump();
					}
					//swipe down
					if(currentSwipeTop.y < 0 && currentSwipeTop.x > -0.5f && currentSwipeTop.x < 0.5f)
					{
						//hit.transform.GetComponent<Movement>().
						Debug.Log("down swipe");
					}
					//swipe left
					if(currentSwipeTop.x < 0 && currentSwipeTop.y > -0.5f && currentSwipeTop.y < 0.5f)
					{
						hit.transform.GetComponent<Movement>().Move(-1);
						Debug.Log("left swipe");
					}
					//swipe right
					if(currentSwipeTop.x > 0 && currentSwipeTop.y > -0.5f && currentSwipeTop.y < 0.5f)
					{
						hit.transform.GetComponent<Movement>().Move(1);
						Debug.Log("right swipe");
					}
					topTouch = -1;
				}
				else if (i < topTouch){
					topTouch --;
				}
				if(i == botTouch){
					secondPressBot = new Vector2(Input.GetTouch(i).position.x,Input.GetTouch(i).position.y);
					
					currentSwipeBot = new Vector3(secondPressBot.x - firstPressBot.x, secondPressBot.y - firstPressBot.y);
					
					currentSwipeBot.Normalize();
					
					//swipe up
					if(currentSwipeBot.y > 0 && currentSwipeBot.x > -0.5f && currentSwipeBot.x < 0.5f)
					{
						hit.transform.GetComponent<Movement>().Jump();
					}
					//swipe down
					if(currentSwipeBot.y < 0 && currentSwipeBot.x > -0.5f && currentSwipeBot.x < 0.5f)
					{
						//TODO throw star
						Debug.Log("down swipe");
					}
					//swipe left
					if(currentSwipeBot.x < 0 && currentSwipeBot.y > -0.5f && currentSwipeBot.y < 0.5f)
					{
						hit.transform.GetComponent<Movement>().Move(-1);
						Debug.Log("left swipe");
					}
					//swipe right
					if(currentSwipeBot.x > 0 && currentSwipeBot.y > -0.5f && currentSwipeBot.y < 0.5f)
					{
						hit.transform.GetComponent<Movement>().Move(1);
						Debug.Log("right swipe");
					}
					botTouch = -1;
				}
				else if (i < botTouch){
					botTouch --;
				}
			}
		}
	}
}
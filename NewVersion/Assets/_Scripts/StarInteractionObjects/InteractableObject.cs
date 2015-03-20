using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {

	public float interactionDistance = 5f; 

	public bool interactableWithStarUser = true;

	public virtual void Interact(){

	}
}

	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler {

	private GameObject newPosition;
	public bool inPanelLateral = true;
	int posPanelLateral;

	public GameObject boomAnimation;

	public GameObject forEnd;

	void Update(){
		if (inPanelLateral) {
			GetComponent<TypeFunction>().onPanel ();
		} else {
			GetComponent<TypeFunction>().offPanel ();
		}
	}

	public void OnBeginDrag(PointerEventData eventData){
		newPosition = new GameObject ();
		newPosition.transform.SetParent (this.transform.parent);
		newPosition.AddComponent<LayoutElement> ();

		this.transform.SetParent (this.transform.parent.parent);
		this.GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}

	public void OnDrag(PointerEventData eventData){
		this.transform.position = eventData.position;

		if (inPanelLateral) {
			for (int i = 0; i < GameController.Instance.uiController.panelLateral.transform.childCount; i++){			
				if (this.transform.position.y < GameController.Instance.uiController.panelLateral.transform.GetChild (i).position.y){
					posPanelLateral = i;
					if (newPosition.transform.GetSiblingIndex () < posPanelLateral){
						posPanelLateral++;
						break;
					}
				}
			}
			newPosition.transform.SetSiblingIndex(posPanelLateral);
		}
		else{
			newPosition.transform.SetSiblingIndex(GameController.Instance.uiController.panelLateral.transform.childCount);
		}

		if (GetComponent<TypeFunction> ().type == TypeFunction.Type.funcFor) {
			Destroy (forEnd.gameObject);
		}
	}

	public void OnEndDrag(PointerEventData eventData){
		this.transform.SetParent (GameController.Instance.uiController.panelLateral.transform);
		this.transform.SetSiblingIndex (newPosition.transform.GetSiblingIndex ());
		Destroy (newPosition);
		this.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if (GetComponent<TypeFunction> ().type == TypeFunction.Type.funcFor) {
			if (inPanelLateral) {
				forEnd = Instantiate (GetComponent<TypeFunction> ().funcFor, GameController.Instance.uiController.panelLateral.transform);
				forEnd.GetComponent<TypeFunction> ().type = TypeFunction.Type.funcForEnd;
			}
		}

		if (!inPanelLateral){
			Instantiate (boomAnimation, this.transform.position, Quaternion.identity, this.transform.parent.parent);
			Destroy (this.gameObject);
		}
	}

	public void OnPointerUp(PointerEventData eventData){
		
	}
}

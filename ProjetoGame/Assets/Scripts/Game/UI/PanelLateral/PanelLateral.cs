using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelLateral : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData eventData){
		if (eventData.pointerDrag != null) {
			eventData.pointerDrag.gameObject.GetComponent<TileDrag> ().inPanelLateral = true;
		}
	}

	public void OnPointerExit(PointerEventData eventData){
		if (eventData.pointerDrag != null) {
			eventData.pointerDrag.gameObject.GetComponent<TileDrag> ().inPanelLateral = false;
		}
	}
}

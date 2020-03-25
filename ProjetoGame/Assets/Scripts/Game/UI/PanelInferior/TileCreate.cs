using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TileCreate : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject tileCreate;

	public void OnBeginDrag(PointerEventData eventData){
		GameObject aux;
		aux = Instantiate (tileCreate, GameController.Instance.uiController.panelLateral.transform);
		aux.GetComponent<TypeFunction> ().type = GetComponent<TypeFunction>().type;
		aux.GetComponent<TileDrag>().OnBeginDrag(eventData);
		eventData.pointerDrag = aux;
	}

	public void OnDrag(PointerEventData eventData){
		
	}

	public void OnEndDrag(PointerEventData eventData){

	}
}

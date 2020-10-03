using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform playerHolder;
    private Material initMat;
    private Material selectedMat;

    private void Start()
    {
        initMat = GetComponent<Renderer>().material;
        selectedMat = LevelController.Instance.selectedMat;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        GetComponent<Renderer>().material = LevelController.Instance.selectedMat;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Renderer>().material = initMat;
    }
}

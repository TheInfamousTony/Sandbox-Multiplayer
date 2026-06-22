using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TooltipSystem tooltipSystem;

    public string desc;
    public new string name;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipSystem.Show(desc, name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipSystem.Hide();
    }

}

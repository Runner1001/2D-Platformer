using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ToggleablePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private bool isActive;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        DeactivateCanavas();
    }

    private void Update()
    {
        if (isActive)
            ActivateCanvas();
        else
            DeactivateCanavas();

        if (Input.GetKeyDown(KeyCode.I))
        {
            isActive = !isActive;
        }
    }

    private void DeactivateCanavas()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void ActivateCanvas()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}

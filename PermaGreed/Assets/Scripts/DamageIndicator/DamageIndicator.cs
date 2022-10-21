using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{

    // Time for how long the indicator will stay on the screen
    private const float MaxTimer = 2.0f;
    private float timer = MaxTimer;

    // UI References
    private CanvasGroup canvasGroup = null;
    protected CanvasGroup CanvasGroup
    {
        get
        {
            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
                if (canvasGroup == null)
                {
                    canvasGroup = gameObject.AddComponent<CanvasGroup>();
                }
            }
            return canvasGroup;
        }
    }

    private RectTransform rect = null;
    protected RectTransform Rect
    {
        get
        {
            if (rect == null)
            {
                rect = GetComponent<RectTransform>();
                if (rect == null)
                {
                    rect = gameObject.AddComponent<RectTransform>();
                }
            }
            return rect;
        }
    }

    // Damage indicator to poin to the target
    public Transform Target { get; protected set; } = null;
    private Transform player = null;

    // Countdown timer, for indicator to disappear after the timer
    private IEnumerator IE_Countdown = null;

    // If damage indicator is already on the screen this will just reset the timer rather than place another one on top
    private Action unRegister = null;

    // Register to data into the damage indicator class
    public void Register(Transform target, Transform player, Action unRegister)
    {
        this.Target = Target;
        this.player = player;
        this.unRegister = unRegister;
        StartTimer();
    }

    // If we have the indicator present, it resets the timer of the current indicator
    public void Restart()
    {
        timer = MaxTimer;
        StartTimer();
    }

    //Starts the timer 
    private void StartTimer()
    {
        if (IE_Countdown != null) { StopCoroutine(IE_Countdown); }
        IE_Countdown = Countdown();
        StartCoroutine(IE_Countdown);
    }

    // Timer for when indicator will be destroyed
    private IEnumerator Countdown()
    {
        while (CanvasGroup.alpha < 1.0f)
        {
            CanvasGroup.alpha += 4 * Time.deltaTime;
            yield return null;
        }
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
        while (CanvasGroup.alpha > 0.0f)
        {
            CanvasGroup.alpha -= 2 * Time.deltaTime;
            yield return null;
        }
        unRegister();
        Destroy(gameObject);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    
    // Time for how long the indicator will stay on the screen
    private const float MaxTimer = 3.0f;
    private float timer = MaxTimer;

    // UI References
    private CanvasGroup canvasGroup = null;
    protected CanvasGroup CanvasGroup
    {
        get
        {
            if(canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
                if(canvasGroup == null)
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

    // Damage indicator to point to the target
    public Transform Target { get; protected set; } = null;
    private Transform player = null;

    // Countdown timer, for indicator to disappear after the timer
    private IEnumerator IE_Countdown = null;
    // If damage indicator is already on the screen this will just reset the timer rather than place another one on top
    private Action unRegister = null;

    // Determine the position of the target
    private Quaternion tRot = Quaternion.identity;
    private Vector3 tPos = Vector3.zero;

    // Register to data into the damage indicator class
   public void Register(Transform target, Transform player, Action unRegister)
    {
        this.Target = Target;
        this.player = player;
        this.unRegister = unRegister;

        StartCoroutine(RotateToTheTarget());
        StartTimer();
    }

    // If we have indicator on the screen, it just restarts the timer of current damage indicator
    public void Restart()
    {
        timer = MaxTimer;
        StartTimer();
    }
    
    // Starts the timer
    private void StartTimer()
    {
        if (IE_Countdown != null) { StopCoroutine(IE_Countdown);  }
        IE_Countdown = Countdown();
        StartCoroutine(IE_Countdown);
    }

    // Indicator rotates to target
    IEnumerator RotateToTheTarget()
    {
        while(enabled)
        {
            if (Target)
            {
                tPos = Target.position;
                tRot = Target.rotation;
            }          
            Vector3 direction = player.position - tPos;
            
            // Used so the UI only rotates in the Z axis
            tRot = Quaternion.LookRotation(direction);
            tRot.z = -tRot.y;
            tRot.x = 0;
            tRot.y = 0;

            Vector3 northDirection = new Vector3(0, 0, player.eulerAngles.y);
            Rect.localRotation = tRot * Quaternion.Euler(northDirection);

            yield return null;
        }
    }

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

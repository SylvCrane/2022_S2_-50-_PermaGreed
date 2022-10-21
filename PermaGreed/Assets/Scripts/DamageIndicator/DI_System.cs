using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DI_System : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private DamageIndicator indicatorPrefab = null;
    [SerializeField] private RectTransform holder = null;
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Transform player = null;

    // To keep track of all the created indicator 
    private Dictionary<Transform, DamageIndicator> Indicators = new Dictionary<Transform, DamageIndicator>();

    // Authorizes when to create the indicator
    #region Delegates 
    public static Action<Transform> CreateIndicator = delegate { };
    public static Func<Transform, bool> CheckIfObjectInSight = null;
    #endregion

    // This needs to be created for the delegates 
    private void OnEnable()
    {
        CreateIndicator += Create;
        CheckIfObjectInSight += InSight;
    }
    private void OnDisable()
    {
        CreateIndicator -= Create;
        CheckIfObjectInSight -= InSight;
    }

    // Checks if the damage indicator is currently existing in the dictionary
    void Create(Transform target)
    {
        if (Indicators.ContainsKey(target))
        {
            Indicators[target].Restart();
            return;
        }
        DamageIndicator newIndicator = Instantiate(indicatorPrefab, holder);
        newIndicator.Register(target, player, new Action( () => { Indicators.Remove(target); } ));

        Indicators.Add(target, newIndicator);
    }

    // Check if the object is within the cameras view
    bool InSight(Transform t)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(t.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;


    }
}


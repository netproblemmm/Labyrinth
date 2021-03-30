using System;
using UnityEngine;

public sealed class GameController: MonoBehaviour
{
    private InteractiveObject[] _interactiveObjects;
    public static int levelTargets = 6;

    private void Awake()
    {
        _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        foreach (var o in _interactiveObjects)
        {
            if (o is GoodBonus goodBonus)
            {
                goodBonus.CaughtInteraction += CameraShake;
            }
            if (o is BadBonus badBonus)
            {
                badBonus.CaughtInteraction += CameraShake;
            }
        }
    }

    private void CameraShake(object value)
    {
        Debug.Log("CameraShake");
    }

    private void Update()
    {
        for (var i = 0; i < _interactiveObjects.Length; i++)
        {
            var interactiveObject = _interactiveObjects[i];
            if (interactiveObject == null)
                continue;
            if (interactiveObject is IFly fly)
                fly.Fly();
            if (interactiveObject is IFlicker flicker)
                flicker.Flicker();
            if (interactiveObject is IRotation rotation)
                rotation.Rotation();
        }
    }
}
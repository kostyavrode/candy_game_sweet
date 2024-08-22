using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorInstaller : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] services;
    private void Awake()
    {
        foreach (var service in services)
        {
            ServiceLocator.AddService(service);
        }
    }
    private void OnDestroy()
    {
        ServiceLocator.ClearServices();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class tank : MonoBehaviour
{

    [SerializeField] private GameObject tankPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject tankInstance;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
        
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            tankInstance = Instantiate(tankPrefab, image.transform);
            tankInstance.transform.position += prefabOffset;
        }
    }
}

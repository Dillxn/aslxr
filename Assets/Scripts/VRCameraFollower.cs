using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MediaPipe.Unity.Holistic
{
  public class VRCameraFollower : MonoBehaviour
  {
    public GameObject model;
    public GameObject cameraReference;

    private Transform _mainCameraTransform;

    void Start()
    {
      _mainCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
      if (model == null || cameraReference == null) return;

      Vector3 targetPosition = model.transform.TransformPoint(cameraReference.transform.localPosition);
      _mainCameraTransform.position = targetPosition;

      Quaternion targetRotation = model.transform.rotation * cameraReference.transform.localRotation;
      _mainCameraTransform.rotation = targetRotation;
    }
  }
}
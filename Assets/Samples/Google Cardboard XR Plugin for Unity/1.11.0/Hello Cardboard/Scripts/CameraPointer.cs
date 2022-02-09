//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    [SerializeField] float _gazeFinishTime = 1f;
    [SerializeField] float _gazeTime;
    [SerializeField] Image _loadingRecticle;
    [SerializeField] string _buttonTag = "World Button";
    bool cameraPointerActive = true;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            _gazedAtObject = hit.transform.gameObject;
            if (_gazedAtObject.CompareTag(_buttonTag))
            {
                OnGazeEnter(_gazedAtObject.GetComponent<Button>());
            }
            else
            {
                OnGazeExit();
                _gazedAtObject = null;
            }
        }
        else
        {
            OnGazeExit();
        }

    }

    public void OnGazeEnter(Button gazedButton)
    {
        _gazeTime += Time.deltaTime;
        _loadingRecticle.fillAmount = _gazeTime / _gazeFinishTime;
        if (_gazeTime >= _gazeFinishTime && cameraPointerActive)
        {
            gazedButton.onClick.Invoke();
            cameraPointerActive = false;
        }
    }

    public void OnGazeExit()
    {
        _loadingRecticle.fillAmount = 0;
        _gazeTime = 0;
        cameraPointerActive = true;
    }
}

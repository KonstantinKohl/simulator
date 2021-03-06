/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Sensors.UI
{
    [RequireComponent(typeof(Toggle))]
    public class VisualizerToggle : MonoBehaviour
    {
        public Text VisualizerNameText;
        public GameObject OnGO;
        public GameObject OffGO;

        private Toggle toggle;
        public Visualizer Visualizer { get; set; }
        public SensorBase Sensor { get; set; }

        private void Awake()
        {
            toggle = GetComponent<Toggle>();
            toggle.isOn = false;
            OnGO.SetActive(toggle.isOn);
            OffGO.SetActive(!toggle.isOn);
        }

        private void OnEnable()
        {
            toggle.onValueChanged.AddListener(OnToggleClicked);
        }

        private void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(OnToggleClicked);
        }

        public void OnToggleClicked(bool value)
        {
            toggle.isOn = value;
            OnGO.SetActive(value);
            OffGO.SetActive(!value);
            if (Visualizer != null)
            {
                Visualizer.gameObject.SetActive(value);
                Visualizer.transform.SetAsLastSibling();
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.2
//     from Assets/Input/TouchControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine;

public partial class @TouchControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""control"",
            ""id"": ""407a4716-7bd1-483d-b34c-ef9c38ff15d1"",
            ""actions"": [
                {
                    ""name"": ""touch"",
                    ""type"": ""Value"",
                    ""id"": ""ac662c2f-21b2-4da9-890e-c5e002ddf658"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""00a5120f-e836-47f3-978c-a5a7b819fdc7"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // control
        m_control = asset.FindActionMap("control", throwIfNotFound: true);
        m_control_touch = m_control.FindAction("touch", throwIfNotFound: true);
    }

    ~@TouchControls()
    {
        Debug.Assert(!m_control.enabled, "This will cause a leak and performance issues, TouchControls.control.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // control
    private readonly InputActionMap m_control;
    private List<IControlActions> m_ControlActionsCallbackInterfaces = new List<IControlActions>();
    private readonly InputAction m_control_touch;
    public struct ControlActions
    {
        private @TouchControls m_Wrapper;
        public ControlActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @touch => m_Wrapper.m_control_touch;
        public InputActionMap Get() { return m_Wrapper.m_control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void AddCallbacks(IControlActions instance)
        {
            if (instance == null || m_Wrapper.m_ControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControlActionsCallbackInterfaces.Add(instance);
            @touch.started += instance.OnTouch;
            @touch.performed += instance.OnTouch;
            @touch.canceled += instance.OnTouch;
        }

        private void UnregisterCallbacks(IControlActions instance)
        {
            @touch.started -= instance.OnTouch;
            @touch.performed -= instance.OnTouch;
            @touch.canceled -= instance.OnTouch;
        }

        public void RemoveCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControlActions instance)
        {
            foreach (var item in m_Wrapper.m_ControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControlActions @control => new ControlActions(this);
    public interface IControlActions
    {
        void OnTouch(InputAction.CallbackContext context);
    }
}

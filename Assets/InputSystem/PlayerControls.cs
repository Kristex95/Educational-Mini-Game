//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""DragAndDrop"",
            ""id"": ""e97930ba-a026-44e6-ba70-93a1bf6e8775"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""afd2450a-4ff4-4ea7-abce-f1a615ba2456"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""066bc30d-94e3-4d44-bd50-647f6e085f04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bd57b2e6-a46b-4143-88ef-eefe319ca318"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e74b470-2fe6-48bf-a7d7-e006430e000e"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DragAndDrop
        m_DragAndDrop = asset.FindActionMap("DragAndDrop", throwIfNotFound: true);
        m_DragAndDrop_TouchPosition = m_DragAndDrop.FindAction("TouchPosition", throwIfNotFound: true);
        m_DragAndDrop_TouchPress = m_DragAndDrop.FindAction("TouchPress", throwIfNotFound: true);
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

    // DragAndDrop
    private readonly InputActionMap m_DragAndDrop;
    private IDragAndDropActions m_DragAndDropActionsCallbackInterface;
    private readonly InputAction m_DragAndDrop_TouchPosition;
    private readonly InputAction m_DragAndDrop_TouchPress;
    public struct DragAndDropActions
    {
        private @PlayerControls m_Wrapper;
        public DragAndDropActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_DragAndDrop_TouchPosition;
        public InputAction @TouchPress => m_Wrapper.m_DragAndDrop_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_DragAndDrop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DragAndDropActions set) { return set.Get(); }
        public void SetCallbacks(IDragAndDropActions instance)
        {
            if (m_Wrapper.m_DragAndDropActionsCallbackInterface != null)
            {
                @TouchPosition.started -= m_Wrapper.m_DragAndDropActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_DragAndDropActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_DragAndDropActionsCallbackInterface.OnTouchPosition;
                @TouchPress.started -= m_Wrapper.m_DragAndDropActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_DragAndDropActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_DragAndDropActionsCallbackInterface.OnTouchPress;
            }
            m_Wrapper.m_DragAndDropActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }
        }
    }
    public DragAndDropActions @DragAndDrop => new DragAndDropActions(this);
    public interface IDragAndDropActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
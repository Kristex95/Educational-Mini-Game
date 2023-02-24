using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void TriggerEvent()
    {
        listeners.ToList().ForEach((listener) =>
        {
            listener.OnEventTriggered();
        });
    }

    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    private void OnDisable()
    {
        listeners.Clear();
    }
}

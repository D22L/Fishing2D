using System.Collections.Generic;
using UnityEngine.Events;

namespace Fishing2D
{
    public class CustomEvent : UnityEvent<object> { }

    public static class EventManager
    {
        private static Dictionary<eEventType, CustomEvent> eventListeners = new Dictionary<eEventType, CustomEvent>();

        public static void Subscribe(eEventType eventType, UnityAction<object> callback)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent?.AddListener(callback);
            }
            else
            {
                customEvent = new CustomEvent();
                customEvent?.AddListener(callback);
                eventListeners.Add(eventType, customEvent);
            }
        }

        public static void Unsubscribe(eEventType eventType, UnityAction<object> callback)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent?.RemoveListener(callback);
            }
        }

        public static void OnEvent(eEventType eventType, object arg = null)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent.Invoke(arg);
            }
        }
    }
}

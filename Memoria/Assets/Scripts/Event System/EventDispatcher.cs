using System.Collections.Generic;
using UnityEngine;
public class EventDispatcher
{
    private static EventDispatcher _instance = null;

    private EventDispatcher()
    {
    }

    public static EventDispatcher Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventDispatcher();
            }
            return _instance;
        }
    }

    public delegate void EventDelegate<T>(T e) where T : Event;

    private Dictionary<System.Type, System.Delegate> m_eventDelegates =
        new Dictionary<System.Type, System.Delegate>();


    private void _AddListener<T>(EventDelegate<T> listener) where T : Event
    {
        System.Type eventType = typeof(T);
        System.Delegate del;

        if (m_eventDelegates.TryGetValue(eventType, out del))
        {
            del = System.Delegate.Combine(del, listener);
            m_eventDelegates[typeof(T)] = del;
        }
        else
        {
            m_eventDelegates.Add(typeof(T), listener);
        }
    }

    //Register to listen to an event
    public static void AddListener<T>(EventDelegate<T> listener) where T : Event
    {
        Instance._AddListener<T>(listener);
    }

    private void _RemoveListener<T>(EventDelegate<T> listener) where T : Event
    {
        System.Delegate del;
        if (m_eventDelegates.TryGetValue(typeof(T), out del))
        {
            System.Delegate newDel = System.Delegate.Remove(del, listener);

            if (newDel == null)
            {
                m_eventDelegates.Remove(typeof(T));
            }
            else
            {
                m_eventDelegates[typeof(T)] = newDel;
            }
        }
    }

    //Remove themselves from listening to an event
    public static void RemoveListener<T>(EventDelegate<T> listener) where T : Event
    {
        Instance._RemoveListener<T>(listener);
    }

    private void _Raise<T>(T evtData) where T : Event
    {
        System.Delegate del;
        if (m_eventDelegates.TryGetValue(typeof(T), out del))
        {
            EventDelegate<T> callback = del as EventDelegate<T>;
            if (callback != null)
            {
                callback(evtData);
            }
        }
    }

    //Trigger an Event
    public static void Raise<T>(T evtData) where T : Event
    {
        Instance._Raise(evtData);
    }
}
public class Event { }

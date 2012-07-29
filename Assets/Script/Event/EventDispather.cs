using System;
using System.Collections.Generic;


internal class DispatherInternal
{
    public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
    public readonly MessengerMode DEFAULT_MODE = MessengerMode.REQUIRE_LISTENER;

    public void OnListenerAdding(string eventType, Delegate listenerBeingAdded) 
	{
	    if (!eventTable.ContainsKey(eventType)) {
	        eventTable.Add(eventType, null);
	    }
	
	    Delegate d = eventTable[eventType];
	    if (d != null && d.GetType() != listenerBeingAdded.GetType()) {
	        throw new ListenerException(string.Format("Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}", eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
	    }
    }

    public void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved) 
	{
        if (eventTable.ContainsKey(eventType)) {
            Delegate d = eventTable[eventType];

            if (d == null) {
                throw new ListenerException(string.Format("Attempting to remove listener with for event type {0} but current listener is null.", eventType));
            } else if (d.GetType() != listenerBeingRemoved.GetType()) {
                throw new ListenerException(string.Format("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
            }
        } else {
            throw new ListenerException(string.Format("Attempting to remove listener for type {0} but Messenger doesn't know about this event type.", eventType));
        }
    }

    public void OnListenerRemoved(string eventType)
	{
        if (eventTable[eventType] == null) {
            eventTable.Remove(eventType);
        }
    }

    public void OnBroadcasting(string eventType, MessengerMode mode) 
	{
        if (mode == MessengerMode.REQUIRE_LISTENER && !eventTable.ContainsKey(eventType)) {
            throw new MessengerInternal.BroadcastException(string.Format("Broadcasting message {0} but no listener found.", eventType));
        }
    }

    public BroadcastException CreateBroadcastSignatureException(string eventType)
	{
        return new BroadcastException(string.Format("Broadcasting message {0} but listeners have a different signature than the broadcaster.", eventType));
    }

    public class BroadcastException : Exception {
        public BroadcastException(string msg)
            : base(msg) {
        }
    }

    public class ListenerException : Exception {
        public ListenerException(string msg)
            : base(msg) {
        }
    }
}

/*
public class EventDispather
{
	private DispatherInternal dispather = new DispatherInternal();
    //private Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();

    public void AddListener(string eventType, Callback handler) 
	{
		dispather.OnListenerAdding(eventType, handler);
        dispather.eventTable[eventType] = (Callback)dispather.eventTable[eventType] + handler;
    }

    public void RemoveListener(string eventType, Callback handler) 
	{
        dispather.OnListenerRemoving(eventType, handler);   
        dispather.eventTable[eventType] = (Callback)dispather.eventTable[eventType] - handler;
        dispather.OnListenerRemoved(eventType);
    }

    public void Broadcast(string eventType) 
	{
        Broadcast(eventType, dispather.DEFAULT_MODE);
    }

     public void Broadcast(string eventType, MessengerMode mode) 
	{
        dispather.OnBroadcasting(eventType, mode);
        Delegate d;
        if (dispather.eventTable.TryGetValue(eventType, out d)) {
            Callback callback = d as Callback;
            if (callback != null) {
                callback();
            } else {
                throw dispather.CreateBroadcastSignatureException(eventType);
            }
        }
    }
}
*/
public delegate void EventCallback( CommentEvent arg1 );
public class EventDispather
{
    private DispatherInternal dispather = new DispatherInternal();

    public void AddListener(string eventType, EventCallback handler) 
	{
        dispather.OnListenerAdding( eventType, handler );
        dispather.eventTable[eventType] = (EventCallback)dispather.eventTable[eventType] + handler;
    }

    public void RemoveListener(string eventType, EventCallback handler) 
	{
        dispather.OnListenerRemoving(eventType, handler);
        dispather.eventTable[eventType] = (EventCallback)dispather.eventTable[eventType] - handler;
        dispather.OnListenerRemoved(eventType);
    }

    public void Broadcast( CommentEvent e ) 
	{
        Broadcast(e, dispather.DEFAULT_MODE);
    }

    public void Broadcast(CommentEvent e, MessengerMode mode) 
	{
		string eventType = e.eventType;
        dispather.OnBroadcasting(eventType, mode);
        Delegate d;
        if (dispather.eventTable.TryGetValue(eventType, out d)) {
            EventCallback callback = d as EventCallback;
            if (callback != null) {
                callback(e);
            } else {
                throw dispather.CreateBroadcastSignatureException(eventType);
            }
        }
    }
}


/*
// Two parameters
public class EventDispather<T, U> {
    private DispatherInternal dispather = new DispatherInternal();

    public void AddListener(string eventType, Callback<T, U> handler) 
	{
        dispather.OnListenerAdding(eventType, handler);
        dispather.eventTable[eventType] = (Callback<T, U>)dispather.eventTable[eventType] + handler;
    }

    public void RemoveListener(string eventType, Callback<T, U> handler) 
	{
        dispather.OnListenerRemoving(eventType, handler);
        dispather.eventTable[eventType] = (Callback<T, U>)dispather.eventTable[eventType] - handler;
        dispather.OnListenerRemoved(eventType);
    }

    public void Broadcast(string eventType, T arg1, U arg2) {
        Broadcast(eventType, arg1, arg2, dispather.DEFAULT_MODE);
    }

    public void Broadcast(string eventType, T arg1, U arg2, MessengerMode mode) {
        dispather.OnBroadcasting(eventType, mode);
        Delegate d;
        if (dispather.eventTable.TryGetValue(eventType, out d)) {
            Callback<T, U> callback = d as Callback<T, U>;
            if (callback != null) {
                callback(arg1, arg2);
            } else {
                throw dispather.CreateBroadcastSignatureException(eventType);
            }
        }
    }
}


// Three parameters
public class EventDispather<T, U, V> {
	private DispatherInternal dispather = new DispatherInternal();
	
    public void AddListener(string eventType, Callback<T, U, V> handler) 
	{
        dispather.OnListenerAdding(eventType, handler);
        dispather.eventTable[eventType] = (Callback<T, U, V>)dispather.eventTable[eventType] + handler;
    }

    public void RemoveListener(string eventType, Callback<T, U, V> handler) 
	{
        dispather.OnListenerRemoving(eventType, handler);
        dispather.eventTable[eventType] = (Callback<T, U, V>)dispather.eventTable[eventType] - handler;
        dispather.OnListenerRemoved(eventType);
    }

    public void Broadcast(string eventType, T arg1, U arg2, V arg3) {
        Broadcast(eventType, arg1, arg2, arg3, dispather.DEFAULT_MODE);
    }

    public void Broadcast(string eventType, T arg1, U arg2, V arg3, MessengerMode mode) {
        dispather.OnBroadcasting(eventType, mode);
        Delegate d;
        if (dispather.eventTable.TryGetValue(eventType, out d)) {
            Callback<T, U, V> callback = d as Callback<T, U, V>;
            if (callback != null) {
                callback(arg1, arg2, arg3);
            } else {
                throw dispather.CreateBroadcastSignatureException(eventType);
            }
        }
    }
}
*/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Magas.Utilities {
    public static class EventDispatcher {
        public static T GetOrAddComponent<T>(this GameObject model) where T: Component {
           return model.GetComponent<T>() ?? model.AddComponent<T> () as T;
        }
        
        public static bool IsEqualVector(this Vector3 t, Vector3 e) {
            return Math.Abs(t.x - e.x) < 0.1 && Math.Abs(t.y - e.y) < 0.1 && Math.Abs(t.z - e.z) < 0.1;
        }
        
        private static readonly Dictionary<Type, SignalDelegate> Events = new Dictionary<Type, SignalDelegate>();

        public static void Subscribe<T>(SignalDelegate callback) where T : ISignal {
            var type = typeof(T);
            if (!Events.ContainsKey(type))
                Events.Add(type, null);

            Events[type] += callback;
        }

        public static void Unsubscribe<T>(SignalDelegate callback) where T : ISignal {
            var type = typeof(T);
            if (Events.ContainsKey(type)) Events[type] -= callback;
        }

        public static void Dispatch<T>(T signal) where T : ISignal {
            var type = typeof(T);
            if (!Events.ContainsKey(type)) return;

            Events[type](signal);
        }
    }
}

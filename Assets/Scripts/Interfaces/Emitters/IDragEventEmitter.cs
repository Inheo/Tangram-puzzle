using UnityEngine;

namespace Assets.Interfaces.Events.Emitters
{
    public interface IDragEventEmitter
    {
        event System.Action OnDrag;
    }
}
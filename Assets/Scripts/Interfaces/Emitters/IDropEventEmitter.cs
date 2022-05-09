using UnityEngine;

namespace Assets.Interfaces.Events.Emitters
{
    public interface IDropEventEmitter
    {
        event System.Action OnDrop;
    }
}
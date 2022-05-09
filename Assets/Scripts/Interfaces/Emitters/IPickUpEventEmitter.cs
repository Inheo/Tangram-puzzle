using UnityEngine;

namespace Assets.Interfaces.Events.Emitters
{
    public interface IPickUpEventEmitter
    {
        event System.Action OnPickUp;
    }
}
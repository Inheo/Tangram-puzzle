using UnityEngine;

namespace Assets.Interfaces.Events
{
    public interface IPickUpHandler
    {
        void OnPickUp(Vector3 position);
    }
}
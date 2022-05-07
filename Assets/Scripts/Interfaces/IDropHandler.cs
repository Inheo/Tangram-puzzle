using UnityEngine;

namespace Assets.Interfaces.Events
{
    public interface IDropHandler
    {
        void OnDrop(Vector3 position);
    }
}
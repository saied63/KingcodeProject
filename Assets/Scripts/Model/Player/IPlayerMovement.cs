using UnityEngine;
using UnityEngine.InputSystem;
namespace model
{
    public interface IPlayerModel
    {
        Vector3 Position { get; set; }
        void Move(Vector3 direction);
    }
}

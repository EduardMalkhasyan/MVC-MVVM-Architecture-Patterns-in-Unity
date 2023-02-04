using UnityEngine;

namespace MVC
{
    [CreateAssetMenu(fileName = "MessageData", menuName = "ScriptableObjects/MessageData")]
    public class MessageModelSO : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; }
        [field: SerializeField] public string Message { get; set; }
    }
}

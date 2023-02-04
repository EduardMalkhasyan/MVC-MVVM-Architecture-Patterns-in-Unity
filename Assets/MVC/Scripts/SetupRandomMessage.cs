using UnityEngine;

namespace MVC
{
    public class SetupRandomMessage : MonoBehaviour
    {
        [SerializeField] private MessageView messageView;
        [SerializeField] private MessageModelSO[] allMessages;

        private MessageController messageController;

        private void Start()
        {
            allMessages = Resources.LoadAll<MessageModelSO>("MVC/MessageDataSO/");
            messageController = new MessageController(allMessages, messageView);
            UpdateRandomMessage();
        }

        public void UpdateRandomMessage()
        {
            messageController.UpdateRandomMessage();
        }
    }
}

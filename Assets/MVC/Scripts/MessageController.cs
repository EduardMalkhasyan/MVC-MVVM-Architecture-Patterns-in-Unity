using UnityEngine;

namespace MVC
{
    public class MessageController
    {
        private MessageModelSO messageModel;
        private MessageModelSO[] messageModels;
        private MessageView messageView;

        public MessageController(MessageModelSO messageModel, MessageView messageView)
        {
            this.messageModel = messageModel;
            this.messageView = messageView;
        }

        public MessageController(MessageModelSO[] messageModels, MessageView messageView)
        {
            this.messageModels = messageModels;
            this.messageView = messageView;
        }

        public void UpdateDailyMessage()
        {
            messageView.DisplayMessage(messageModel.Message);
            messageView.DisplayColor(messageModel.Color);
        }

        public void UpdateRandomMessage()
        {
            var randomChose = UnityEngine.Random.Range(0, messageModels.Length);
            messageView.DisplayMessage(messageModels[randomChose].Message);
            messageView.DisplayColor(messageModels[randomChose].Color);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDailyMessage : MonoBehaviour
{
    [SerializeField] private MessageView messageView;
    [SerializeField] private MessageModelSO dailyMessage;

    private MessageController messageController;

    private void Start()
    {
        messageController = new MessageController(dailyMessage, messageView);
        messageController.UpdateDailyMessage();
    }
}

using UnityEngine;
using TMPro;

public class MessageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    public void DisplayMessage(string message)
    {
        textMesh.text = message;
    }

    public void DisplayColor(Color color)
    {
        textMesh.color = color;
    }
}

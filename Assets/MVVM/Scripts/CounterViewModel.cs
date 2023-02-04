using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterViewModel : MonoBehaviour
{
    private CounterModel counter = new CounterModel();

    [SerializeField] private TextMeshProUGUI counterUI;
    [SerializeField] private Button incrementButton;
    [SerializeField] private Button decrementButton;

    public void OnEnable()
    {
        if (counter != null)
        {
            counterUI.BindProperty(counter.count);
            incrementButton.onClick.AddListener(IncrementCount);
            decrementButton.onClick.AddListener(DecrementCount);
        }
    }

    private void OnDisable()
    {
        if (counter != null)
        {
            counterUI.UnbindProperty(counter.count);
            incrementButton.onClick.RemoveListener(IncrementCount);
            decrementButton.onClick.RemoveListener(DecrementCount);
        }
    }

    public void IncrementCount()
    {
        counter.count.Value += 1;
    }

    public void DecrementCount()
    {
        counter.count.Value -= 1;
    }
}

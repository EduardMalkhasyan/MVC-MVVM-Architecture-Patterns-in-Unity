using System;
using System.Collections.Generic;
using TMPro;

public static class RuntimeBindingEx
{
    private static readonly Dictionary<TextMeshProUGUI, List<(IProperty property, Action<object> binding)>> propertyBindings = new();

    public static void BindProperty(this TextMeshProUGUI element, IProperty property)
    {
        if (!propertyBindings.TryGetValue(element, out var bindingsList))
        {
            bindingsList = new List<(IProperty, Action<object>)>();
            propertyBindings.Add(element, bindingsList);
        }

        Action<object> onPropertyValueChanged = OnPropertyValueChanged;
        bindingsList.Add((property, onPropertyValueChanged));

        property.ValueChanged += onPropertyValueChanged;

        OnPropertyValueChanged(property.Value);

        void OnPropertyValueChanged(object newValue)
        {
            element.text = newValue?.ToString() ?? "";
        }
    }

    public static void UnbindProperty(this TextMeshProUGUI element, IProperty property)
    {
        if (!propertyBindings.TryGetValue(element, out var bindingsList))
        {
            return;
        }

        for (int i = bindingsList.Count - 1; i >= 0; i--)
        {
            var propertyBinding = bindingsList[i];
            if (propertyBinding.property == property)
            {
                propertyBinding.property.ValueChanged -= propertyBinding.binding;
                bindingsList.RemoveAt(i);
            }
        }
    }

    public static void UnbindAllProperties(this TextMeshProUGUI element)
    {
        if (!propertyBindings.TryGetValue(element, out var bindingsList))
        {
            return;
        }

        foreach (var propertyBinding in bindingsList)
        {
            propertyBinding.property.ValueChanged -= propertyBinding.binding;
        }

        bindingsList.Clear();
    }
}
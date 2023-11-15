using TMPro;
using UnityEngine;

public class GatheredText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        GetComponentInParent<Patron>().OnGatheredChanged += (count) => _text.SetText(count.ToString());
    }
}
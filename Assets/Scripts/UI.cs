using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMoney;
    [SerializeField] private Wallet _wallet;

    private int _currentMoney = 0;

    private void Start()
    {
        _textMoney.text = _currentMoney.ToString();
    }

    private void OnEnable()
    {
        _wallet.ChangeBalance += ChangeText;
    }

    private void OnDisable()
    {
        _wallet.ChangeBalance -= ChangeText;
    }

    private void ChangeText(int value)
    {
        _textMoney.text = value.ToString();
    }
}

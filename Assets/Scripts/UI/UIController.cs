using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Singletone
    private static UIController _instance;
    public static UIController GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        else
        {
            _instance = FindObjectOfType<UIController>();
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            return;
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    [SerializeField] private MobileController _mobileController;
    public static MobileController MobileController { get => GetInstance()._mobileController; private set => GetInstance()._mobileController = value; }
}

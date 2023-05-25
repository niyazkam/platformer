using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _authorsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _authorsBlock;

    private void OnEnable()
    {
        HandleBeginButton();
        HandleAuthorButton();
        HandleExitButton();
        HandleCloseButton();
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
        _authorsButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
        _closeButton.onClick.RemoveAllListeners();
    }

    private void HandleBeginButton()
    {
        _playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }

    private void HandleAuthorButton()
    {
        _authorsButton.onClick.AddListener(() =>
        {
            _authorsBlock.SetActive(true);
        });
    }

    private void HandleCloseButton()
    {
        _closeButton.onClick.AddListener(() =>
        {
            _authorsBlock.SetActive(false);
        });
    }

    private void HandleExitButton()
    {
        _exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}

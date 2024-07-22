using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Auth;
using UnityEngine.UI;
using System;

public class AuthManager
{
    private static AuthManager instance = null;

    public static AuthManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new AuthManager();
            }

            return instance;
        }
    }

    private FirebaseAuth auth; // �α��� / ȸ�����Կ� ���
    private FirebaseUser user; // ������ Ȯ�ε� ����

    public string UserId => user.UserId;

    public Action<bool> LoginState;

    public void Init()
    {
        auth = FirebaseAuth.DefaultInstance;

        if(auth.CurrentUser != null)
        {
            LogOut();
        }
        auth.StateChanged += OnChaged;
    }

    private void OnChaged(object sender, EventArgs e)
    {
        if(auth.CurrentUser != user)
        {
            bool signed = (auth.CurrentUser != user && auth.CurrentUser != null);
            if(!signed && user != null)
            {
                Debug.Log("�α׾ƿ�");
                LoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if(signed)
            {
                Debug.Log("�α���");
                LoginState?.Invoke(true);
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void Create(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        { 
            if(task.IsCanceled)
            {
                Debug.LogError("ȸ������ ���");
                return;
            }
            if(task.IsFaulted)
            {
                Debug.LogError("ȸ������ ����");
                return;
            }

            FirebaseUser newUser = task.Result.User;
            Debug.LogError("ȸ������ �Ϸ�");
        });
    }

    public void LogIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("�α��� ���");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("�α��� ����");
                return;
            }

            FirebaseUser newUser = task.Result.User;
            Debug.Log("�α��� �Ϸ�");
            SceneManager.LoadScene("GameScene");
        });
    }

    public void LogOut()
    {
        auth.SignOut();
        Debug.Log("�α׾ƿ�");
    }
}

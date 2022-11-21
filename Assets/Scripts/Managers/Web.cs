using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//логика работы с сервером
public class Web : MonoBehaviour
{
    [SerializeField] GameObject loginUI;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject signInUI;
    public InputField LoginUsernameInput;
    public InputField LoginPasswordInput;
    [SerializeField] Text LoginMessage;

    public InputField RegistrUsernameInput;
    public InputField RegistrPasswordInput;
    [SerializeField] Text RegistrMessage;
    [SerializeField] Button RegistrationButtonObject;
    public bool IgnorAuth;

    void Update()
    {
        //Если длина логина больше 4 символов, и длина пароля больше 5 символов - кнопка регистрации разблокируется
        if(RegistrUsernameInput.text.Length > 4 && RegistrPasswordInput.text.Length > 5)
        {
            RegistrationButtonObject.interactable = true;
        }
        else
        {
            RegistrationButtonObject.interactable = false;
        }
    }

    //запрос на сервер для авторизации
    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/students_bd/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                StartCoroutine(ShowMessage(LoginMessage, www.error, Color.red));
            }
            else
            {
                if(www.downloadHandler.text.Contains("Login Success"))
                {
                    UserInfo.Login = username;
                    BackButton(loginUI, mainUI);
                    LoginUsernameInput.text = "";
                    LoginPasswordInput.text = "";
                }
                else
                {
                    StartCoroutine(ShowMessage(LoginMessage, www.downloadHandler.text, Color.red));
                }
            }
        }   
    }

    //запрос на сервер для регистрации
    public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/students_bd/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                StartCoroutine(ShowMessage(RegistrMessage, www.error, Color.red));
            }
            else
            {
                if(www.downloadHandler.text.Contains("Пользователь успешно создан"))
                {
                    StartCoroutine(ShowMessage(RegistrMessage, www.downloadHandler.text, Color.green));
                    RegistrUsernameInput.text = "";
                    RegistrPasswordInput.text = "";
                }
            }
        }    
    }

    //запрос на сервер о выполнении всех задач
    public IEnumerator TasksResult(string lab)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", UserInfo.Login);
        form.AddField("lab", lab);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/students_bd/TasksResult.php", form))
        {
           yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            } 
        }
    }

    //показ ответа сервера на формах регистрации и авторизации
    IEnumerator ShowMessage(Text messageField, string message, Color color)
    {
        messageField.text = message;
        messageField.color = color;
        yield return new WaitForSeconds(1.5f);
        messageField.text = "";
    }

    public void SignInButton()
    {
        StartCoroutine(RegisterUser(RegistrUsernameInput.text, RegistrPasswordInput.text));
    }

    public void LogInButton()
    {
        if(IgnorAuth)
        {
            UserInfo.Login = "admin";
            BackButton(loginUI, mainUI);
        }
        else
        {
            StartCoroutine(Login(LoginUsernameInput.text, LoginPasswordInput.text));
        }
    }

    public void RegistrationButton()
    {
        BackButton(loginUI, signInUI);
        LoginUsernameInput.text = "";
        LoginPasswordInput.text = "";
    }

    void BackButton(GameObject curUI, GameObject nextUI)
    {
        curUI.SetActive(false);
        nextUI.SetActive(true);
    }

    public void BackButton()
    {
        signInUI.SetActive(false);
        loginUI.SetActive(true);
        RegistrUsernameInput.text = "";
        RegistrPasswordInput.text = "";
    }     
}
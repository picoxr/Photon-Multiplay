using LitJson;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class UserMessage : MonoBehaviour
{
    public delegate void DelegateGetUserInfoResult(string openid, string name);
    public DelegateGetUserInfoResult DELEGATE_GET_USER_INFO_RESULT;


    public void LoginCallback(string LoginInfo)
    {

        LoginSDK.GetUserAPI();
        Debug.Log("login callback:");
    }

    public void UserInfoCallback(string userInfo)
    {
        Debug.Log("userInfo callbackEkko:" + userInfo);

        JsonData jsrr = JsonMapper.ToObject(userInfo);
        JsonData user_data = JsonMapper.ToObject(jsrr["data"].ToJson());
        string openid = user_data["openid"].ToString();
        string name = user_data["username"].ToString();
        this.DELEGATE_GET_USER_INFO_RESULT(openid, name);
    }


    public GameObject GetCurrentGameObject()
    {
        return GameObject.Find("MassageInfo");
    }

    public void ActivityForResultCallback(string activity)
    {
        PicoPaymentSDK.jo.Call("authCallback", activity);
    }
}

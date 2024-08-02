using UnityEngine;

[System.Serializable]
public struct UserData
{
    public string UserName { get; private set; }
    public int Id { get; private set; }

    public UserData(string userName,int id)
    {
        UserName = userName;
        Id = id;
    }

}

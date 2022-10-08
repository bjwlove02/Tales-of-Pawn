using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Pause,
    Playing,
    GameOver
}
public class Message
{
    private GameState message;
    private static Message p_instance=null;
    public static Message Instance()
    {
        if (p_instance == null)
        {
            p_instance = new Message();
            
        }
        return p_instance;
    }
    public void SendMessage(GameState message)
    {
        this.message = message;
    }
    public GameState ReceiveMessage()
    {
        return message;
    }

}

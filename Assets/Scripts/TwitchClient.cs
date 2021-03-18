// If type or namespace TwitchLib could not be found. Make sure you add the latest TwitchLib.Unity.dll to your project folder
// Download it here: https://github.com/TwitchLib/TwitchLib.Unity/releases
// Or download the repository at https://github.com/TwitchLib/TwitchLib.Unity, build it, and copy the TwitchLib.Unity.dll from the output directory
using System;
using TwitchLib.Client.Models;
using TwitchLib.Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwitchClient : SingletonComponent<TwitchClient>
{
    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public
    private string _channelToConnectTo = Secrets.USERNAME_FROM_OAUTH_TOKEN;

    public RobotMovement robotMovement;

    [SerializeField]
    private bool isMainMenu = false;

    private Client _client;

    private void Start()
    {
        // To keep the Unity application active in the background, you can enable "Run In Background" in the player settings:
        // Unity Editor --> Edit --> Project Settings --> Player --> Resolution and Presentation --> Resolution --> Run In Background
        // This option seems to be enabled by default in more recent versions of Unity. An aditional, less recommended option is to set it in code:
        // Application.runInBackground = true;
        if(!isMainMenu)
            robotMovement = GameObject.Find("Robot").gameObject.GetComponent<RobotMovement>();

        //Create Credentials instance
        ConnectionCredentials credentials = new ConnectionCredentials(Secrets.USERNAME_FROM_OAUTH_TOKEN, Secrets.OAUTH_TOKEN);

        // Create new instance of Chat Client
        _client = new Client();

        // Initialize the client with the credentials instance, and setting a default channel to connect to.
        _client.Initialize(credentials, _channelToConnectTo);

        // Bind callbacks to events
        _client.OnConnected += OnConnected;
        _client.OnConnectionError += OnFailedToConnect;
        _client.OnError += _client_OnError;
        _client.OnJoinedChannel += OnJoinedChannel;
        _client.OnMessageReceived += OnMessageReceived;
        _client.OnChatCommandReceived += OnChatCommandReceived;
        _client.OnWhisperReceived += _client_OnWhisperReceived;

        // Connect
        _client.Connect();

    }

    public void ChangeTwitchName(Text twitchName)
    {
        _channelToConnectTo = twitchName.text;
    }
    private void Update()
    {
        if(robotMovement == null && !isMainMenu)
        {
            robotMovement = GameObject.Find("Robot").gameObject.GetComponent<RobotMovement>();
        }
    }

    private void _client_OnWhisperReceived(object sender, TwitchLib.Client.Events.OnWhisperReceivedArgs e)
    {
        Debug.Log("Message: " + e.WhisperMessage.Message);

        _client.SendWhisper(e.WhisperMessage.Username, "Its working!");
    }

    private void _client_OnError(object sender, TwitchLib.Communication.Events.OnErrorEventArgs e)
    {
        Debug.LogError($"The program didnt work correctly: {e.Exception.Message}");
    }

    private void OnConnected(object sender, TwitchLib.Client.Events.OnConnectedArgs e)
    {
        Debug.Log($"The bot {e.BotUsername} succesfully connected to Twitch.");

        if (!string.IsNullOrWhiteSpace(e.AutoJoinChannel))
            Debug.Log($"The bot will now attempt to automatically join the channel provided when the Initialize method was called: {e.AutoJoinChannel}");
    }
    private void OnFailedToConnect(object sender, TwitchLib.Client.Events.OnConnectionErrorArgs e)
    {
        Debug.Log($"The bot {e.BotUsername} failed to connect");
    }

    private void OnJoinedChannel(object sender, TwitchLib.Client.Events.OnJoinedChannelArgs e)
    {
        Debug.Log($"The bot {e.BotUsername} just joined the channel: {e.Channel}");
        _client.SendMessage(e.Channel, "I just joined the channel! PogChamp");
    }

    private void OnMessageReceived(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {
        if (e.ChatMessage.Message.Contains("!"))
        {
            if (e.ChatMessage.Message.Contains("answer"))
            {
                QuestionroundManager.instance.ValidateClosedQuestion(e.ChatMessage.Message.Substring(8), int.Parse(e.ChatMessage.UserId));
            }
            else if (e.ChatMessage.Message.Contains("join"))
            {
                try
                {
                    Debug.Log(e.ChatMessage.UserId);
                    // TODO: Add index out of range check, for example when someone says "!join 9000000"
                    TeamManager.instance.addParticipant(new Participant(int.Parse(e.ChatMessage.UserId), int.Parse(e.ChatMessage.Message.Substring(6)) -1));
                }
                catch (Exception ex)
                {
                    // TODO: Whisper about why it could not join team to person who send this message
                    Debug.LogError("Could not join team!   " + ex);
                }
            }
        }
    }


    private void OnChatCommandReceived(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e)
    {
        switch (e.Command.CommandText)
        {
            case "right":
                _client.SendMessage(e.Command.ChatMessage.Channel, "You moved the twitch bot to the right");
                robotMovement.MoveSideways(SidewaysDirections.right);
                break;
            case "left":
                _client.SendMessage(e.Command.ChatMessage.Channel, "You moved the twitch bot to the left");
                robotMovement.MoveSideways(SidewaysDirections.left);
                break;
            case "up":
                _client.SendMessage(e.Command.ChatMessage.Channel, "You moved the twitch bot up");
                robotMovement.MoveSideways(SidewaysDirections.up);
                break;
            case "down":
                _client.SendMessage(e.Command.ChatMessage.Channel, "You moved the twitch bot down");
                robotMovement.MoveSideways(SidewaysDirections.down);
                break;
            default:
                break;
        }
    }
}
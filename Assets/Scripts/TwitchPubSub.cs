using TwitchLib.Unity;
using UnityEngine;

public class TwitchPubSub : MonoBehaviour
{
	private PubSub _pubSub;

	private void Start()
	{
		// To keep the Unity application active in the background, you can enable "Run In Background" in the player settings:
		// Unity Editor --> Edit --> Project Settings --> Player --> Resolution and Presentation --> Resolution --> Run In Background
		// This option seems to be enabled by default in more recent versions of Unity. An aditional, less recommended option is to set it in code:
		// Application.runInBackground = true;

		// Create new instance of PubSub Client
		_pubSub = new PubSub();

		// Subscribe to Events
		_pubSub.OnWhisper += OnWhisper;
		_pubSub.OnPubSubServiceConnected += OnPubSubServiceConnected;
        _pubSub.OnPubSubServiceError += _pubSub_OnPubSubServiceError;
        _pubSub.OnFollow += _pubSub_OnFollow;
        _pubSub.OnListenResponse += _pubSub_OnListenResponse;


		// Connect
		_pubSub.Connect();

	}

    private void _pubSub_OnListenResponse(object sender, TwitchLib.PubSub.Events.OnListenResponseArgs e)
    {
		if (e.Successful)
			Debug.Log($"Successfully verified listening to topic: {e.Topic}");
		else
			Debug.LogError($"Failed to listen! Error: {e.Response.Error}");
	}

    private void _pubSub_OnFollow(object sender, TwitchLib.PubSub.Events.OnFollowArgs e)
    {
		Debug.Log("We got a new follower");
    }

    private void _pubSub_OnPubSubServiceError(object sender, TwitchLib.PubSub.Events.OnPubSubServiceErrorArgs e)
    {
		Debug.Log($"PubSub has thrown a unexpected error: {e}");
    }


    private void OnPubSubServiceConnected(object sender, System.EventArgs e)
	{
		Debug.Log("PubSubServiceConnected!");

		// On connect listen to Bits evadsent
		// Please note that listening to the whisper events requires the chat_login scope in the OAuth token.
		//_pubSub.ListenToWhispers(Secrets.CHANNEL_ID_FROM_OAUTH_TOKEN);

		// SendTopics accepts an oauth optionally, which is necessary for some topics, such as bit events.
		_pubSub.SendTopics(Secrets.OAUTH_TOKEN);
		Debug.Log("sendingTopics");
	}

private void OnWhisper(object sender, TwitchLib.PubSub.Events.OnWhisperArgs e)
	{
		Debug.Log("ITS GETTING A WHISPER");
		Debug.Log($"{e.Whisper.Data}");
		// Do your bits logic here.
	}
}

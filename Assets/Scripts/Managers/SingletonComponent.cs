using UnityEngine;

/// <summary>Use any class as a singleton by extending from this class.</summary>
/// <remarks>
///     Abstract because this cannot be used without extending it and using your own class T as reference.
///     The Where T : SingletonComponent<T> part requires T being referenced by SingletonComponent as well, like so:
///         public class PanelManager : SingletonComponent<PanelManager> { }
///     A usage example: After extending from this class and creating a public YourFunction() method, it can be used any other classes like so:
///         PanelManager.instance.YourFunction();
/// </remarks>
public abstract class SingletonComponent<T> : MonoBehaviour where T : SingletonComponent<T>
{
    private static T _instance = null;

    /// <summary>Get the instance of this class.</summary>
    public static T instance
    {
        get
        {
            return _instance;
        }
    }

    /// <remarks>
    ///     Protected because this shouldn't be used outside its class hierarchy.
    ///     Virtual so we can put the singleton instance logic here which will be used when this class is extended.
    /// </remarks>
    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Error: Singleton '" + name + "' is already initialized.", this);
        }

        _instance = (T)this;
    }
}

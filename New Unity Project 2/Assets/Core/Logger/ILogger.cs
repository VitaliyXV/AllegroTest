using UnityEngine;


namespace Assets.Scripts
{
  public  interface ILogger
    {
        bool IsSaveToFile{get;set;}
        bool IsCleanFiles { get; set; }

        void Assert(bool condition);
        void Assert(bool condition, Object context);
        void Assert(bool condition, object message);
        void Assert(bool condition, object message, Object context);
        void AssertFormat(bool condition, string format, params object[] args);
        void AssertFormat(bool condition, Object context, string format, params object[] args);
        void Break();
        void ClearDeveloperConsole();
        void Log(object message);
        void Log(object message, Object context);
        void LogAssertion(object message);
        void LogAssertion(object message, Object context);
        void LogAssertionFormat(string format, params object[] args);
        void LogError(object message);
        void LogError(object message, Object context); void LogAssertionFormat(Object context, string format, params object[] args);
        void LogErrorFormat(string format, params object[] args);
        void LogErrorFormat(Object context, string format, params object[] args);
        void LogException(System.Exception exception);
        void LogException(System.Exception exception, Object context);
        void LogFormat(string format, params object[] args);
        void LogFormat(Object context, string format, params object[] args);
        void LogWarning(object message);
        void LogWarning(object message, Object context);
        void LogWarningFormat(string format, params object[] args);
        void LogWarningFormat(Object context, string format, params object[] args);
    }
}

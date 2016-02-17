using UnityEngine;
using System.IO;
using Exeption = System.Exception;
using DateTime = System.DateTime;
using Exception = System.Exception;
using Action = System;

namespace Assets.Scripts
{
    // Логгер сдела по шаблону SingleTon
    public class GameLogger : ILogger
    {
        static GameLogger instance;

        // делегаты
        // нужны для реализации логики так как разные методы обращаются к разным функция класса Debug. Чтобы можно было создать сгрупированные методы локи реализации методов ис- делегаты                                             


        public Action.Action<object> DelegateForOnlyText;
        public Action.Action<object, Object> DelegateForTextAndObject;

        protected delegate void TwoArgumentFormated(string format, params object[] args);
        protected TwoArgumentFormated DelegateForFormatedText;

        protected delegate void ThreeArgumentFormated(Object context, string format, params object[] args);
        protected ThreeArgumentFormated DelegateForFormatedTextAndObj;

                                            // делегаты конец

        public bool IsSaveToFile { get; set; }
        public bool IsCleanFiles { get; set; }

                                         // переменные 
        protected Stream Stream;
        protected StreamWriter FileWriter;
        protected string nameOfFile;
        protected string typeOfLog;
        protected string date;
                                         // переменные  конец

        
        static public GameLogger GetInstance()
        {
            if (instance == null )
            {
                instance = new GameLogger();
            }
            return instance;
        }


        protected GameLogger()
        {
            nameOfFile = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
            IsSaveToFile = false;
            IsCleanFiles = false;
        }

        public void Assert(bool condition)
        {
            typeOfLog = "Warning!\t";
            LogicOfChooseTypeOfLog(condition);
        }

        public void Assert(bool condition, Object context)
        {
            typeOfLog = "Warning!\t";
            LogicOfChooseTypeOfLog(condition, context);

        }

        public void Assert(bool condition, object message)
        {
            typeOfLog = "Warning!\t";
            LogicOfChooseTypeOfLog(condition, message);
        }


        public void Assert(bool condition, object message, Object context)

        {
            typeOfLog = "Warning!\t";
            LogicOfChooseTypeOfLog(condition, message, context);
        }


        public void AssertFormat(bool condition, string format, params object[] args)
        {
            typeOfLog = "Warning!\t";
            LogicOfChooseTypeOfLog(condition, format, args);
        }


        public void AssertFormat(bool condition, Object context, string format, params object[] args)
        {
            typeOfLog = "Warning!\t";
            LogicOfChooseTypeOfLog(condition, context, format, args);
        }

        public void Break()
        {
            Debug.Break();
        }


        public void ClearDeveloperConsole()
        {
            Debug.ClearDeveloperConsole();
        }

        public void ClearLogFiles()
        {
            DirectoryInfo dir = new DirectoryInfo("Assets\\Log");
            FileInfo[] file = dir.GetFiles();
            foreach (FileInfo valuer in file)
            {
                try
                {
                    valuer.Delete();
                }
                catch (Exeption err)
                {
                    Debug.LogException(err);
                }
            }
        }


        public void Log(object message)
        {
            typeOfLog = "Debug\t\t";
            DelegateForOnlyText = Debug.Log;
            DelegateForOnlyText = Debug.Log;
            LogicOfChooseTypeOfLog(message);
        }


        public void Log(object message, Object context)
        {
            typeOfLog = "Debug\t\t";
            DelegateForTextAndObject = Debug.Log;
            LogicOfChooseTypeOfLog(message, context);
        }



        public void LogAssertion(object message)
        {
            typeOfLog = "Warning!\t";
            DelegateForOnlyText = delegate (object mes) { Debug.LogAssertion(message); };
            LogicOfChooseTypeOfLog(message);
        }


        public void LogAssertion(object message, Object context)
        {
            typeOfLog = "Warning!\t";
            DelegateForTextAndObject = delegate (object mes, Object cont) { Debug.LogAssertion(message,context); };
            LogicOfChooseTypeOfLog(message,context);
        }

        public void LogAssertionFormat(string format, params object[] args)
        {
            typeOfLog = "Warning!\t";
            DelegateForFormatedText = delegate (string form,  object[] arg) { Debug.LogAssertionFormat(format, args); };
            LogicOfChooseTypeOfLog(format, args);
        }

        public void LogAssertionFormat(Object context, string format, params object[] args)
        {
            typeOfLog = "Warning!\t";
            DelegateForFormatedTextAndObj = delegate (Object cont ,string form, object[] arg) { Debug.LogAssertionFormat(context,format, args); };
            LogicOfChooseTypeOfLog(context, format, args);
        }


        public void LogError(object message)
        {
            typeOfLog = "Error!!!\t";
            DelegateForOnlyText = Debug.LogError;
            LogicOfChooseTypeOfLog(message);
        }

        public void LogError(object message, Object context)
        {
            typeOfLog = "Error!!!\t";
            DelegateForTextAndObject = Debug.LogError;
            LogicOfChooseTypeOfLog(message, context);
        }


        public void LogErrorFormat(string format, params object[] args)
        {
            typeOfLog = "Error!!!\t";
            DelegateForFormatedText = Debug.LogErrorFormat;
            LogicOfChooseTypeOfLog(format, args);
        }


        public void LogErrorFormat(Object context, string format, params object[] args)
        {
            typeOfLog = "Error!!!\t";
            DelegateForFormatedTextAndObj = Debug.LogErrorFormat;
            LogicOfChooseTypeOfLog(context, format, args);
        }

        public void LogException(Exception exception)
        {
            typeOfLog = "Exception!!!\t";
            LogicOfChooseTypeOfLog(exception);
        }


        public void LogException(Exception exception, Object context)
        {
            typeOfLog = "Exception!!!\t";
            LogicOfChooseTypeOfLog(exception, context);
        }

        public void LogFormat(string format, params object[] args)
        {
            typeOfLog = "Debug\t\t";
            DelegateForFormatedText = Debug.LogFormat;
            LogicOfChooseTypeOfLog(format, args);
        }

        public void LogFormat(Object context, string format, params object[] args)
        {
            typeOfLog = "Debug\t\t";
            DelegateForFormatedTextAndObj = Debug.LogFormat;
            LogicOfChooseTypeOfLog(context, format, args);
        }


        public void LogWarning(object message)
        {
            typeOfLog = "Warning!\t";
            DelegateForOnlyText = Debug.LogWarning;
            LogicOfChooseTypeOfLog(message);
        }

        public void LogWarning(object message, Object context)
        {
            typeOfLog = "Warning!\t";
            DelegateForTextAndObject = Debug.LogWarning;
            LogicOfChooseTypeOfLog(message, context);
        }


        public void LogWarningFormat(string format, params object[] args)
        {
            typeOfLog = "Warning!\t";
            DelegateForFormatedText = Debug.LogWarningFormat;
            LogicOfChooseTypeOfLog(format, args);
        }


        public void LogWarningFormat(Object context, string format, params object[] args)
        {
            typeOfLog = "Warning!\t";
            DelegateForFormatedTextAndObj = Debug.LogWarningFormat;
            LogicOfChooseTypeOfLog(context, format, args);
        }






        ///////////////////////////////////////////////////////Служебные методы в основном перегрузки реализации записей в файл и логики вывода информации на экран или в файл/////////////////////////////////////////////////////////


        protected void LogicOfChooseTypeOfLog(bool condition)
        {
            if (IsSaveToFile == false)
            {
                Debug.Assert(condition);
            }
            else
            {
                Debug.Assert(condition);
                OperationWithFile(condition);
            }
        }


        protected void LogicOfChooseTypeOfLog(bool condition, Object context)
        {
            if (IsSaveToFile == false)
            {
                Debug.Assert(condition, context);
            }
            else
            {
                Debug.Assert(condition, context);
                OperationWithFile(condition, context);
            }
        }


        protected void LogicOfChooseTypeOfLog(bool condition, object message)
        {
            if (IsSaveToFile == false)
            {
                Debug.Assert(condition, message);
            }
            else
            {
                Debug.Assert(condition, message);
                OperationWithFile(condition, message);
            }
        }


        protected void LogicOfChooseTypeOfLog(bool condition, object message, Object context)
        {
            if (IsSaveToFile == false)
            {
                Debug.Assert(condition, message, context);
            }
            else
            {
                Debug.Assert(condition, message, context);
                OperationWithFile(condition, message, context);
            }
        }



        protected void LogicOfChooseTypeOfLog(bool condition, string format, params object[] args)
        {
            if (IsSaveToFile == false)
            {
                Debug.AssertFormat(condition, format, args);
            }
            else
            {
                Debug.AssertFormat(condition, format, args);
                OperationWithFile(condition, format, args);
            }
        }



        protected void LogicOfChooseTypeOfLog(bool condition, Object context, string format, params object[] args)
        {
            if (IsSaveToFile == false)
            {
                Debug.AssertFormat(condition, context, format, args);
            }
            else
            {
                Debug.AssertFormat(condition, context, format, args);
                OperationWithFile(condition, context, format, args);
            }
        }



        protected void LogicOfChooseTypeOfLog(object message)
        {
            if (IsSaveToFile == false)
            {
                DelegateForOnlyText(message);
            }
            else
            {
                DelegateForOnlyText(message);
                OperationWithFile(message);
            }
        }




        protected void LogicOfChooseTypeOfLog(string format, params object[] args)
        {
            if (IsSaveToFile == false)
            {
                DelegateForFormatedText(format, args);
            }
            else
            {
                DelegateForFormatedText(format, args);
                OperationWithFile(format, args);
            }
        }




        protected void LogicOfChooseTypeOfLog(Object context, string format, params object[] args)
        {
            if (IsSaveToFile == false)
            {
                DelegateForFormatedTextAndObj(context, format, args);
            }
            else
            {
                DelegateForFormatedTextAndObj(context, format, args);
                OperationWithFile(context, format, args);
            }
        }



        protected void LogicOfChooseTypeOfLog(Exception exception)
        {
            if (IsSaveToFile == false)
            {
                Debug.LogException(exception);
            }
            else
            {
                Debug.LogException(exception);
                OperationWithFile(exception);
            }
        }



        protected void LogicOfChooseTypeOfLog(object message, Object context)
        {
            if (IsSaveToFile == false)
            {
                DelegateForTextAndObject(message, context);
            }
            else
            {
                DelegateForTextAndObject(message, context);
                OperationWithFile(message, context);
            }
        }



        protected void LogicOfChooseTypeOfLog(Exception exception, Object context)
        {
            if (IsSaveToFile == false)
            {
                Debug.LogException(exception, context);
            }
            else
            {
                Debug.LogException(exception, context);
                OperationWithFile(exception, context);
            }
        }


        protected void OperationWithFile(object message)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + message);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }



        protected void OperationWithFile(bool condition)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + condition);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }


        protected void OperationWithFile(bool condition, Object context)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + condition + "\t" + context);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }



        protected void OperationWithFile(bool condition, object message)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t"  + typeOfLog + "\t" + condition + "\t" + message);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }



        protected void OperationWithFile(bool condition, object message, Object context)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + condition + "\t" + message + "\t" + context);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }




        protected void OperationWithFile(bool condition, string format, params object[] args)
        {
            try
            {
                OpenStream();
                string mes = string.Format(format, args);
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + condition + "\t" + mes);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }


        protected void OperationWithFile(bool condition, Object context, string format, params object[] args)
        {
            try
            {
                OpenStream();
                string mes = string.Format(format, args);
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + condition + "\t" + context  + "\t" + mes);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }



        protected void OperationWithFile(string format, params object[] args)
        {
            try
            {
                OpenStream();
                string mes = string.Format(format, args);
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + mes);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }



        protected void OperationWithFile(Object context, string format, params object[] args)
        {
            try
            {
                OpenStream();
                string mes = string.Format(format, args);
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + mes + "\t" + context);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }




        protected void OperationWithFile(Exception exception)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + exception);
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }




        protected void OperationWithFile(object message, Object context)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + message + "\t" + context );
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }




        protected void OperationWithFile(Exception exception, Object context)
        {
            try
            {
                OpenStream();
                FileWriter.WriteLine(date + "\t" + typeOfLog + "\t" + exception + "\t" + context );
                FileWriter.Flush();
                Stream.Close();
            }
            catch (Exeption err)
            {
                Debug.LogException(err);
            }
        }


        protected void OpenStream()
        {
            string path = "Assets\\Log";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            Stream = new FileStream(path + "\\" + nameOfFile + ".txt", FileMode.Append, FileAccess.Write);
            FileWriter = new StreamWriter(Stream);
            date = DateTime.Now.ToString();
        }

    }
}

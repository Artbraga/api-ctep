using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Ioc
{
    public class LoggingInterceptor : IInterceptionBehavior
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoggingInterceptor));
        public LoggingInterceptor() { }

        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var argumentsToLog = new List<Object>();
            foreach (var arg in input.Arguments)
            {
                if (arg != null && arg.GetType().Name.Contains("Func"))
                    argumentsToLog.Add("Argument is a Function");
                else if (arg != null && arg.GetType().Name.Contains("Stream"))
                    argumentsToLog.Add($"Argument is a Stream.");
                else
                    argumentsToLog.Add(arg);
            }
            log.Info(string.Format("Método {0} invocado com os parâmetros {1}", new object[] { GetMethodFullName(input), JsonConvert.SerializeObject(argumentsToLog, Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })
            }));

            var result = getNext()(input, getNext);

            if (result.Exception != null)
            {
                log.Error(string.Format("Método {0} levantou uma exceção: {1}", new object[] { GetMethodFullName(input), JsonConvert.SerializeObject(result.Exception) }));
            }
            else
            {
                log.Info(string.Format("Método {0} finalizado com sucesso.", new object[] { GetMethodFullName(input) }));
            }

            return result;
        }

        private string GetMethodFullName(IMethodInvocation input)
        {
            return input.MethodBase.DeclaringType + "." + input.MethodBase.Name;
        }
    }
}
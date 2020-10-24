using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Ioc
{
    public class LoggingInterceptor : IInterceptionBehavior
    {
        private readonly ILogger<LoggingInterceptor> _log;
        public LoggingInterceptor(ILogger<LoggingInterceptor> log)
        {
            _log = log;
        }
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
                else
                    argumentsToLog.Add(arg);
            }
            _log.LogInformation("Método {0} invocado com os parâmetros {1}", new object[] { GetMethodFullName(input), JsonConvert.SerializeObject(argumentsToLog, Formatting.None,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                })
            });

            var result = getNext()(input, getNext);

            if (result.Exception != null)
            {
                _log.LogError("Método {0} levantou uma exceção: {1}", new object[] { GetMethodFullName(input), JsonConvert.SerializeObject(result.Exception) });
            }
            else
            {
                _log.LogInformation("Método {0} finalizado com o resultado {1}", new object[] { GetMethodFullName(input), JsonConvert.SerializeObject(
                    result.ReturnValue, Formatting.None, 
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }) 
                });
            }

            return result;
        }

        private string GetMethodFullName(IMethodInvocation input)
        {
            return input.MethodBase.DeclaringType + "." + input.MethodBase.Name;
        }
    }
}
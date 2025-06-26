using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadSuasApi.Logging
{
    public class CustomerLogger : ILogger
    {

        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfiguration;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration configuration)
        {
            loggerName = name;
            loggerConfiguration = configuration;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == loggerConfiguration.LogLevel;

        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";
            EscreverTextoNoArquivo(message);

        }

        private void EscreverTextoNoArquivo(object message)
        {
            string caminhoArquivoLog = @"/home/joao/Área de Trabalho/Trabalhos/Prefeitura/CadSuasApi/CadSuasLogs.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
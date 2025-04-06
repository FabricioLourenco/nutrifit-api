using Nutrifit.Domain.Interfaces.Application.Services;
using Serilog;

namespace Nutrifit.Service.Services
{
    public class LoggerService : ILoggerService
    {
        public LoggerService() { }

        public void Information(string originClass, string method, string mensage)
        {
            var exlog = Log.ForContext(originClass, method);

            exlog.Information(mensage);
        }

        public void Warning(string originClass, string method, string mensage)
        {
            var exlog = Log.ForContext(originClass, method);

            exlog.Warning(mensage);
        }

        public void Error(Exception exception)
        {
            Log.Error(exception, "Erro na aplicação!");
        }

        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}

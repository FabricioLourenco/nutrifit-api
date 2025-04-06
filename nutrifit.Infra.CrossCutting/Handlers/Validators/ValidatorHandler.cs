using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Nutrifit.Infra.CrossCutting.Exceptions;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;

namespace Nutrifit.Infra.CrossCutting.Handlers.Validators
{
    public class ValidatorHandler : IValidatorHandler
    {
        private readonly INotificationHandler _notificationHandler;

        private readonly IServiceProvider _serviceProvider;

        private bool _commit;

        public ValidatorHandler(INotificationHandler notificationHandler, IServiceProvider serviceProvider)
        {
            _notificationHandler = notificationHandler;
            _serviceProvider = serviceProvider;
        }

        public void CommitChanges()
        {
            _commit = true;
        }

        public bool Commit()
        {
            return _commit;
        }

        public void AddMsgErrorAndStopExecution(string msg)
        {
            _notificationHandler.AddNotification(msg, NotificationType.Error);
            throw new ValidatorException();
        }

        public void AddMsgError(string msg)
        {
            _notificationHandler.AddNotification(msg, NotificationType.Error);
        }

        public void AddMsgAlert(string msg)
        {
            _notificationHandler.AddNotification(msg, NotificationType.Alert);
        }

        public void ValidateAndAddMsgError<TEntity>(TEntity entity)
        {
            using IServiceScope serviceScope = _serviceProvider.CreateScope();
            ValidationResult validationResult = serviceScope.ServiceProvider.GetService<IValidator<TEntity>>()!.Validate(entity);
            if (!validationResult.IsValid)
            {
                _notificationHandler.AddNotifications(validationResult, NotificationType.Error);
            }
        }

        public void ValidateAndStopExecution<TEntity>(TEntity entity)
        {
            using IServiceScope serviceScope = _serviceProvider.CreateScope();
            ValidationResult validationResult = serviceScope.ServiceProvider.GetService<IValidator<TEntity>>()!.Validate(entity);
            if (!validationResult.IsValid)
            {
                _notificationHandler.AddNotifications(validationResult, NotificationType.Error);
                throw new ValidatorException();
            }
        }

        public bool Validate<TEntity>(TEntity entity)
        {
            using IServiceScope serviceScope = _serviceProvider.CreateScope();
            return serviceScope.ServiceProvider.GetService<IValidator<TEntity>>()!.Validate(entity).IsValid;
        }
    }
}

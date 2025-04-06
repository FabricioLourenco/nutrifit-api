using FluentValidation.Results;

namespace Nutrifit.Infra.CrossCutting.Handlers.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> GetNotifications() => _notifications;

        public bool HasNotifications() => _notifications.Any();

        public bool HasNotificationsErrors() => _notifications.Any(x => x.Type == NotificationType.Error);

        public void DisposeNotifications() => _notifications = new List<Notification>();

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                var msgError = error.ErrorMessage;

                AddNotification(msgError);
            }
        }

        public void AddNotification(string message, NotificationType type)
        {
            _notifications.Add(new Notification(message, type));
        }

        public void AddNotifications(ValidationResult validationResult, NotificationType type)
        {
            if (validationResult.Errors == null)
            {
                return;
            }

            foreach (string item in from error in validationResult.Errors
                                    let msgError = error.ErrorMessage
                                    select msgError)
            {
                AddNotification(item, type);
            }
        }
    }
}

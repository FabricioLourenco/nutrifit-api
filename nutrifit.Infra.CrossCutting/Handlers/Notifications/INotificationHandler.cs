using FluentValidation.Results;

namespace Nutrifit.Infra.CrossCutting.Handlers.Notifications
{
    public interface INotificationHandler
    {
        void AddNotification(string message);
        void AddNotification(string message, NotificationType type);
        void AddNotifications(ValidationResult validationResult);
        void AddNotifications(ValidationResult validationResult, NotificationType type);
        IReadOnlyCollection<Notification> GetNotifications();
        bool HasNotifications();
        bool HasNotificationsErrors();
        void DisposeNotifications();
    }
}

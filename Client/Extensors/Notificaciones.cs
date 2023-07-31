using Radzen;

namespace _2Parcial_BonillaAp1.Client.Extensors
{
    public static class Notificaciones
    {
        public static void ShowNotification(this NotificationService notifier,
            string titulo,
            string mensaje,
            NotificationSeverity severity)
        {
            var message = new NotificationMessage
            {
                Severity = severity,
                Summary = titulo,
                Detail = mensaje,
                Duration = 3000
            };

            notifier.Notify(message);
        }

    }
}
using Radzen;

namespace EjemploDetalle2022_02.Extensors
{
    public static class Extensions
    {
        public static void Success(this NotificationService notifService, string message)
        {
            notifService.Notify (new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Summary =message
            });
        }
    }

     
}

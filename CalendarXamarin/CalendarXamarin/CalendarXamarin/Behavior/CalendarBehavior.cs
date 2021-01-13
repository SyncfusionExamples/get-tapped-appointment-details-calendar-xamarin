using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace CalendarXamarin.Behavior
{
    class CalendarBehavior : Behavior<ContentPage>
    {
        SfCalendar calendar;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            calendar = bindable.FindByName<SfCalendar>("calendar");
            calendar.OnCalendarTapped += Calendar_OnCalendarTapped;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            calendar.OnCalendarTapped -= Calendar_OnCalendarTapped;
        }

        private void Calendar_OnCalendarTapped(object sender, CalendarTappedEventArgs e)
        {
            var appointmentCollection = e.SelectedAppointment as CalendarEventCollection;
            if (appointmentCollection.Count > 0)
            {
                var appointment = appointmentCollection[0]; ;
                App.Current.MainPage.DisplayAlert(appointment.Subject, appointment.StartTime.ToString("dd/MM/yyyy hh:mm tt"), "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("", "No Events", "OK");
            }
        }
    }
}

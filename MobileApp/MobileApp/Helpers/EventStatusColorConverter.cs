using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.Helpers
{
    class EventStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var status = (EventStatus)value;
            switch (status.Id)
            {
                case 2:
                    return Color.FromHex("#6eeb3d");
                case 1:
                    return Color.FromHex("#EBCE3D");
                case 3:
                    return Color.FromHex("#FF0A0A");
            }

            return Color.FromHex("#828294");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            // so from color to yes no or maybe
            throw new NotImplementedException();
        }
    }
}

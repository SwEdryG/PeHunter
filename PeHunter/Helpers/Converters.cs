using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using PeHunter.Models;

namespace PeHunter.Helpers
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            bool isNull = value == null;
            bool inverse = p is string s && s.Equals("Inverse", StringComparison.OrdinalIgnoreCase);
            if (inverse) isNull = !isNull;
            return isNull ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class EntropyToColorConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is double e)
            {
                if (e > 7.0) return new SolidColorBrush(Color.FromRgb(255, 68, 68));
                if (e > 3.0) return new SolidColorBrush(Color.FromRgb(255, 204, 0));
                return new SolidColorBrush(Color.FromRgb(0, 255, 65));
            }
            return Brushes.White;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class TabIndexToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is int sel && p is string ps && int.TryParse(ps, out int idx))
                return sel == idx ? new SolidColorBrush(Color.FromRgb(0, 255, 65)) : Brushes.Transparent;
            return Brushes.Transparent;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class TabIndexToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is int sel && p is string ps && int.TryParse(ps, out int idx))
                return sel == idx ? new SolidColorBrush(Color.FromRgb(18, 18, 18)) : new SolidColorBrush(Color.FromRgb(170, 170, 170));
            return Brushes.White;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class BoolToAnalysisStatusConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is bool b && b) ? "ANALYZING..." : "ANALYSIS COMPLETE";
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class BoolToAnalysisStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is bool b && b)
                ? new SolidColorBrush(Color.FromRgb(255, 204, 0))
                : new SolidColorBrush(Color.FromRgb(0, 255, 65));
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class BytesToSizeConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is long b)
            {
                if (b >= 1073741824) return $"{b / 1073741824.0:F2} GiB";
                if (b >= 1048576) return $"{b / 1048576.0:F2} MiB";
                if (b >= 1024) return $"{b / 1024.0:F2} KiB";
                return $"{b} B";
            }
            return "0 B";
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class BoolToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is bool b && b) ? "YES" : "NO";
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class EntropyToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is double e)
            {
                if (e > 7.0) return new SolidColorBrush(Color.FromRgb(255, 68, 68));
                if (e > 3.0) return new SolidColorBrush(Color.FromRgb(255, 204, 0));
                return new SolidColorBrush(Color.FromRgb(0, 255, 65));
            }
            return Brushes.Gray;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class EntropyToSeverityConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is double e)
            {
                if (e > 7.0) return "HIGH";
                if (e > 3.0) return "MEDIUM";
                return "LOW";
            }
            return "LOW";
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class HasHighAnomalyConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is List<AnomalyInfo> a)
                return a.Any(x => x.Severity == "HIGH") ? Visibility.Visible : Visibility.Collapsed;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class HighCountConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is List<AnomalyInfo> a) ? a.Count(x => x.Severity == "HIGH") : 0;
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class WarnCountConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is List<AnomalyInfo> a) ? a.Count(x => x.Severity == "WARN") : 0;
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class ZeroCountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is int i && i == 0) ? Visibility.Visible : Visibility.Collapsed;
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class EntropyToBarWidthConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is double e)
            {
                double w = e / 8.0 * 80;
                if (w < 4) w = 4;
                if (w > 80) w = 80;
                return w;
            }
            return 0.0;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }

    public class BoolToFolderIconConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => (value is bool b && b) ? "📁" : "📄";
        public object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotImplementedException();
    }
}
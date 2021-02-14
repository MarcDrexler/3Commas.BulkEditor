using System;
using XCommas.Net.Objects;

namespace _3Commas.BulkEditor.Misc
{
    public static class Extensions
    {
        public static string ToHumanReadableString(this BotStrategy strategy)
        {
            switch (strategy)
            {
                case RsiBotStrategy rsiBotStrategy:
                    return $"RSI {rsiBotStrategy.Options.Time.ToHumanReadableString()} {rsiBotStrategy.Options.Points}";
                case ManualStrategy manualStrategy:
                    return "Manual";
                case QflBotStrategy qflBotStrategy:
                    return $"QFL {qflBotStrategy.Options.Type} {qflBotStrategy.Options.Percent}%";
                case NonStopBotStrategy nonStopBotStrategy:
                    return "NonStop";
                case UltBotStrategy ultBotStrategy:
                    return $"ULT {ultBotStrategy.Options.Time.ToHumanReadableString()} {ultBotStrategy.Options.Points}";
                case TradingViewBotStrategy tradingViewBotStrategy:
                    return $"TradingView {tradingViewBotStrategy.Options.Type} {tradingViewBotStrategy.Options.Time.ToHumanReadableString()}";
                case TaPresetsBotStrategy taPresetsBotStrategy:
                    return $"{taPresetsBotStrategy.Name} {taPresetsBotStrategy.Options.Type} {taPresetsBotStrategy.Options.Time.ToHumanReadableString()}";
                case CqsPremiumBotStrategy cqsPremiumBotStrategy:
                case CqsTelegramBotStrategy cqsTelegramBotStrategy:
                case UnknownStrategy unknownStrategy:
                    return strategy.Name;
                default:
                    throw new ArgumentOutOfRangeException(nameof(strategy));
            }
        }

        private static string ToHumanReadableString(this IndicatorTime time)
        {
            switch (time)
            {
                case IndicatorTime.ThreeMinutes:
                    return "3m";
                case IndicatorTime.FiveMinutes:
                    return "5m";
                case IndicatorTime.FifteenMinutes:
                    return "15m";
                case IndicatorTime.ThirtyMinutes:
                    return "30m";
                case IndicatorTime.OneHour:
                    return "1h";
                case IndicatorTime.TwoHours:
                    return "2h";
                case IndicatorTime.FourHours:
                    return "4h";
                default:
                    throw new ArgumentOutOfRangeException(nameof(time), time, null);
            }
        }

        private static string ToHumanReadableString(this TradingViewTime time)
        {
            switch (time)
            {
                case TradingViewTime.OneMinute:
                    return "1min";
                case TradingViewTime.FiveMinutes:
                    return "5min";
                case TradingViewTime.FifteenMinutes:
                    return "15min";
                case TradingViewTime.OneHour:
                    return "1h";
                case TradingViewTime.FourHours:
                    return "4h";
                case TradingViewTime.OneDay:
                    return "1d";
                case TradingViewTime.OneWeek:
                    return "1w";
                case TradingViewTime.OneMonth:
                    return "1month";
                case TradingViewTime.Cumulative:
                    return "Cumulative";
                default:
                    throw new ArgumentOutOfRangeException(nameof(time), time, null);
            }
        }
    }
}
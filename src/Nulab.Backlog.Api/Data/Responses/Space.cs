namespace Nulab.Backlog.Api.Data.Responses
{
    using System;

    public sealed class Space
    {
        public string spaceKey { get; set; }

        public string name { get; set; }

        public int ownerId { get; set; }

        public string lang { get; set; }

        public string timezone { get; set; }

        public string reportSendTime { get; set; }

        public string textFormattingRule { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(spaceKey)}: {spaceKey}, {nameof(name)}: {name}, {nameof(ownerId)}: {ownerId}, {nameof(lang)}: {lang}, {nameof(timezone)}: {timezone}, {nameof(reportSendTime)}: {reportSendTime}, {nameof(textFormattingRule)}: {textFormattingRule}, {nameof(created)}: {created}, {nameof(updated)}: {updated}";
        }
    }
}
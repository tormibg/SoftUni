// new ver

namespace EventHandler
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        private readonly string title;
        private readonly string location;
        private DateTime date;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            if (other != null)
            {
                int comparedToByDate = this.date.CompareTo(other.date);
                int comparedToByTitle = string.Compare(this.title, other.title, StringComparison.Ordinal);

                int comparedToByLocation = string.Compare(this.location, other.location, StringComparison.Ordinal);
                if (comparedToByDate == 0)
                {
                    if (comparedToByTitle == 0)
                    {
                        return comparedToByLocation;
                    }
                    else
                    {
                        return comparedToByTitle;
                    }
                }
                else
                {
                    return comparedToByDate;
                }
            }

            throw new ArgumentNullException("obj");
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}
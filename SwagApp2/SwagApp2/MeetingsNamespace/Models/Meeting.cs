using System;
using System.Collections.Generic;
using System.Text;

namespace SwagApp2.MeetingsNamespace.Models
{
    public class AgendaItem
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime CreatedStamp { get; set; }
        public bool Cleared { get; set; }
        public DateTime ClearedStamp { get; set; }

        public AgendaItem(string name, string author)
        {
            Name = name;
            Author = author;
            Cleared = false;
            CreatedStamp = DateTime.Now;
            ClearedStamp = new DateTime();
        }

        public void Clear()
        {
            Cleared = true;
            ClearedStamp = DateTime.Now;
        }

        public void UnClear()
        {
            Cleared = false;
            ClearedStamp = new DateTime();
        }

    }

    public class Facility
    {
        public string Name { get; set; }
        public string Address { get; set; }
        
    }

    public enum Types
    {
        AdHoc,
        AwayDay,
        Board,
        Breakfast,
        Comittee,
        Investigative,
        Kickoff,
        Management,
        OffSite,
        OneOnOne,
        Staff,
        Standup,
        Team,
        Work,
        Pleasure
    }

    public enum Frequency
    {
        OneTime,
        Recurring,
        Series
    }

    public class Meeting
    {
        public string Name { get; set; }
        public string ActionItem { get; set; }
        public Facility Location { get; set; }
        public Types Type { get; set; }
        public Frequency Frequency { get; set; }
        public List<AgendaItem> Agenda { get; set; }
        public DateTime TimeOfEvent { get; set; }
        public DateTime CreatedStamp { get; set; }


    }
}

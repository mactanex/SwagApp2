using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SwagApp2.MeetingsNamespace.Models;

namespace SwagApp2.MeetingsNamespace.Datastores
{
    class FakeMeetingStorage : IMeetingStorage
    {
        private static List<Meeting> _meetings;

        public FakeMeetingStorage()
        {
            _meetings = new List<Meeting>();

            var agenda2 = new List<AgendaItem>();
            agenda2.Add(new AgendaItem("Do this", "Malthe"));
            agenda2.Add(new AgendaItem("Dont Do this", "Malthe"));
            agenda2.Add(new AgendaItem("Really Do this", "Malthe"));

            var meeting1 = new Meeting()
            {
                Name = "dopeMeeting",
                CreatedStamp = DateTime.Today,
                Frequency = Frequency.OneTime,
                Type = Types.Management,
                ActionItem = "How To Proceed",
                Agenda = agenda2,
                Location = new Facility() { Name = "Burger Shack", Address = "Frederiksgade" },
                TimeOfEvent = DateTime.UtcNow
            };


            

            var meeting2 = new Meeting()
            {
                Name = "not a dope meeting",
                CreatedStamp = DateTime.Today,
                Frequency = Frequency.OneTime,
                Type = Types.Investigative,
                ActionItem = "How To Proceed",
                Agenda = agenda2,
                Location = new Facility() { Name = "Burger Shack", Address = "Frederiksgade" },
                TimeOfEvent = DateTime.UtcNow


            };

            var meeting3 = new Meeting()
            {
                Name = "i dunno anymore",
                CreatedStamp = DateTime.Today,
                Frequency = Frequency.OneTime,
                Type = Types.Kickoff,
                ActionItem = "How To Proceed",
                Agenda = agenda2,
                Location = new Facility(){Name = "Burger Shack", Address = "Frederiksgade"},
                TimeOfEvent = DateTime.UtcNow
            };
            _meetings.Add(meeting1);
            _meetings.Add(meeting2);
            CreateMeetingAsync(meeting3);
;        }

        public Task<List<Meeting>> GetAllListsAsync()
        {
            var result = _meetings;
            return Task.FromResult(result);
        }

        public Task<Meeting> GetMeetingAsync(string name)
        {
            var result = _meetings.Find(x => x.Name == name); ;
            return Task.FromResult(result);
        }

        public Task<Meeting> CreateMeetingAsync(Meeting meeting)
        {
            _meetings.Add(meeting);
            var result = meeting;
            return Task.FromResult(result);
        }

        public Task<Meeting> UpdateMeetingAsync(string name, Meeting meeting)
        {
            if (_meetings.Find(x => x.Name == name)!=null)
            {
                _meetings.Insert(_meetings.IndexOf(meeting), meeting);
                return Task.FromResult(meeting);
            }
            return null;
        }

        public Task<Meeting> DeleteMeetingAsync(string name)
        {
           var meeting = _meetings.Find(x => x.Name == name);
           _meetings.Remove(meeting);
            return Task.FromResult(meeting);
        }
    }
}

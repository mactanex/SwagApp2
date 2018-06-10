using System.Collections.Generic;
using System.Threading.Tasks;
using SwagApp2.MeetingsNamespace.Models;

namespace SwagApp2.MeetingsNamespace.Datastores
{
    public interface IMeetingStorage
    {
        Task<List<Meeting>> GetAllListsAsync();
        Task<Meeting> GetMeetingAsync(string id);
        Task<Meeting> CreateMeetingAsync(Meeting meeting);
        Task<Meeting> UpdateMeetingAsync(string id, Meeting meeting);
        Task<Meeting> DeleteMeetingAsync(string id);
    }
}
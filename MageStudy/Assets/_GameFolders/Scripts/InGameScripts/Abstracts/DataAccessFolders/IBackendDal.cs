using System.Threading.Tasks;
using MageStudy.DataEntities;

namespace MageStudy.Abstracts.DataAccessFolders
{
    public interface IBackendDal
    {
        public int PageLength { get; }
        Task<LeaderboardEntityData> GetLeaderboardPageAsync(int pageCount);
        Task<QuestionsEntityData> GetQuestions();
    }
}
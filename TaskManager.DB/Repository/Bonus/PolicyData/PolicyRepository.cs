using System.Collections.Generic;
using Dapper;
using TaskManager.DB.Context;
using TaskManager.Model.POCO;

namespace TaskManager.DB.Repository.Bonus.PolicyData
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly BonusConnection _bonusConnection;

        public PolicyRepository(BonusConnection bonusConnection)
        {
            _bonusConnection = bonusConnection;
        }

        public IEnumerable<Policy> GetOldPoliciesToUpdate()
        {
            int stageId = 5;
            int daysPassToUpdate = 30;

            return _bonusConnection.DB.Query<Policy>(
                "SELECT * from dbo.v_policies where stageid = @stageId and DATEDIFF(DAY, StageDate, CONVERT(DATETIME2(0),GETDATE())) >= @days",
                new { stageId = stageId, days = daysPassToUpdate });
        }

        public void UpdatePolicyStage(string podoc, int oldStageId, int newStageId, string stageComment, string userId)
        {
            _bonusConnection.DB.Query(
                "update dbo.input_policy_channel set stageid = @newStageId, StageComment = @stageComment, UserID = @userId" +
                "where stageId = @oldStageId and PODOC = @podoc",
                new
                {
                    oldStageId = oldStageId,
                    newStageId = newStageId,
                    stageComment = stageComment,
                    userId = userId,
                    podoc = podoc
                });
        }
    }
}

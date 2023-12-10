using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.fuben;

namespace AscNet.GameServer.Commands
{
    [CommandName("stage")]
    internal class StageCommand : Command
    {
        public StageCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        [Argument(0, @"^[0-9]+$|^all$", "The target stage, value is stage id or 'all'")]
        string TargetStage { get; set; } = string.Empty;

        public override string Help => "Modify the stage completion status of the account.";

        public override void Execute()
        {
            if (TargetStage == "all")
            {
                session.stage.Stages.Clear();
                foreach (var stageData in TableReaderV2.Parse<StageTable>())
                {
                    session.stage.Stages.Add(stageData.StageId, new()
                    {
                        StageId = stageData.StageId,
                        StarsMark = 7,
                        Passed = true,
                        PassTimesToday = 0,
                        PassTimesTotal = 1,
                        BuyCount = 0,
                        Score = 0,
                        LastPassTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        BestRecordTime = 0,
                        LastRecordTime = 0,
                        BestCardIds = new List<long> { 1021001 },
                        LastCardIds = new List<long> { 1021001 }
                    });
                }

                session.SendPush(new NotifyStageData() { StageList = session.stage.Stages.Select(x => x.Value).ToList() });
            }
            else
            {
                StageTable? stageData = TableReaderV2.Parse<StageTable>().Find(x => x.StageId == int.Parse(TargetStage));
                if (stageData is not null && !session.stage.Stages.ContainsKey(stageData.StageId))
                {
                    StageDatum stage = new()
                    {
                        StageId = stageData.StageId,
                        StarsMark = 7,
                        Passed = true,
                        PassTimesToday = 0,
                        PassTimesTotal = 1,
                        BuyCount = 0,
                        Score = 0,
                        LastPassTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                        BestRecordTime = 0,
                        LastRecordTime = 0,
                        BestCardIds = new List<long> { 1021001 },
                        LastCardIds = new List<long> { 1021001 }
                    };
                    session.stage.Stages.Add(stageData.StageId, stage);

                    session.SendPush(new NotifyStageData() { StageList = new() { stage } });
                }
            }
        }
    }
}

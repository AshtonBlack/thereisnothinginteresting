namespace Caitlyn_v1._0
{
    internal class SolveEnemyIsReady : Action
    {
        public override bool SolveTheIssue()
        {
            if (VisualCheck.Check(PointsAndRectangles.chooseanEnemy, "ChooseanEnemy", 90))
            {
                NotePad.DoLog("противник загрузился, готов фотать трассы");
                TrackInfo[] tracksInfo = new TrackInfo[5];
                for (int i = 0; i < tracksInfo.Length; i++)
                {
                    tracksInfo[i] = new TrackInfo(i + 1);
                }
                Condition.setTracks(tracksInfo);
                Rat.Clk(PointsAndRectangles.ChooseAnEnemy);
                NotePad.DoLog("противник выбран");
                return true;
            }
            return false;
        }
    }
}

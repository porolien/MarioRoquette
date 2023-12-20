namespace Dan.Main
{
    public static class Leaderboards
    {
        public static LeaderboardReference DemoSceneLeaderboard = /*new LeaderboardReference("980324f10e2f03fc0fd6a38a70f88123919a6aed35a4aea86211ad58b68db9c4")*/ new LeaderboardReference("ca06c234e4013f92c018675b676afb30f4cf492bc3cce1d5cbbbbb48799b769b");

        public static void ChangeKey(string _sceneName)
        {
            switch (_sceneName)
            {
                case "":
                    DemoSceneLeaderboard = new LeaderboardReference("ce88d94f85261789f0586157a0b5d653c8a216fcb625aee1dbf98ef96fcdb61e");
                    //Level Tuto
                    break;
            }
            
        }
    }
}

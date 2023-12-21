namespace Dan.Main
{
    public static class Leaderboards
    {
        public static LeaderboardReference DemoSceneLeaderboard = /*new LeaderboardReference("980324f10e2f03fc0fd6a38a70f88123919a6aed35a4aea86211ad58b68db9c4")*/ new LeaderboardReference("ca06c234e4013f92c018675b676afb30f4cf492bc3cce1d5cbbbbb48799b769b");

        public static void ChangeKey(string _sceneName)
        {
            
            switch (_sceneName)
            {
                case "Tests_Nathan":
                    DemoSceneLeaderboard = new LeaderboardReference("ce88d94f85261789f0586157a0b5d653c8a216fcb625aee1dbf98ef96fcdb61e");
                    //Level Tuto
                    break;

                case "Tests_Aure3":
                    DemoSceneLeaderboard = new LeaderboardReference("d3216b7d2a89c81b31d3884d2a3d0a86c12322cf2c97081d56dd5d71cdb8150f");
                    //Level Aure
                    break;
                case "Tests_Nathan 2":
                    DemoSceneLeaderboard = new LeaderboardReference("13e9feb1017df7f933f85171a849aeb3d982048cf9f1a49d6ea5323873135d0a");
                    //Level Nathan 2 
                    break;
                case "Tests_Nathan 3":
                    DemoSceneLeaderboard = new LeaderboardReference("132235113b0ed0948e4591822852e90d8ca48f465668d245b03dc91dce9ef7dd");
                    //Level Nathan 3
                    break;
                case "Tests_ToddLevel":
                    DemoSceneLeaderboard = new LeaderboardReference("b99150b58baf4152368996cb9e6cd3bfedbf4cbfffd0875bb814a13bb054d613");
                    //Level Todd
                    break;
                case "Nest 2":
                    DemoSceneLeaderboard = new LeaderboardReference("aee393e3f2410fffd6713fe92e8eb2b63a32f55a3f1ddf635c0a5b657d347b81");
                    //Level Nestor
                    break;
                case "LevelNoah":
                    DemoSceneLeaderboard = new LeaderboardReference("a3b01553352f6198423af64d063d29afce568a9a7ba8f6bcdce1047b9761505c");
                    //Level Noah
                    break;
                case "LevelLouis":
                    DemoSceneLeaderboard = new LeaderboardReference("ecb687b722955fb01d633f231af343953b2e9f9bf4798e4fa41f8c27fee8436b");
                    //Level Louis
                    break;
            }
            
        }
    }
}

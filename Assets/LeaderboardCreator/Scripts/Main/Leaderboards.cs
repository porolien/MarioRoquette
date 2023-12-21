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

                case "Tests_Aure3":
                    DemoSceneLeaderboard = new LeaderboardReference("d3216b7d2a89c81b31d3884d2a3d0a86c12322cf2c97081d56dd5d71cdb8150f");
                    //Level Aure
                    break;
                case "Tests_Todd":
                    DemoSceneLeaderboard = new LeaderboardReference("b99150b58baf4152368996cb9e6cd3bfedbf4cbfffd0875bb814a13bb054d613");
                    //Level Aure
                    break;
                    
            }
            
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GOT_Umm_Actually.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        private static List<Character> DeadCharacters = new List<Character>()
        {
            //Season 1
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "1 - Winter is Coming", Name = "Waymar Royce", DeathDescription = "Killed by White Walker", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/97/WaymarRoyceHD1x01.jpg/revision/latest?cb=20160710183336"},
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "1 - Winter is Coming", Name = "Gared", DeathDescription = "Killed by White Walker", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/81/Gared_1x01.png/revision/latest?cb=20170227202343" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "1 - Winter is Coming", Name = "Will", DeathDescription = "Executed by Ned Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1a/Will1.jpg/revision/latest?cb=20160704215302" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "1 - Winter is Coming", Name = "Jon Arryn", House = HouseEnum.Arryn,DeathDescription = "Poisoned by Lysa", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/7a/Jon_Arryn_funeral_bier.jpg/revision/latest?cb=20120520000749" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "2 - The Kingsroad", Name = "Assassin", DeathDescription = "Killed by Bran\"s Wolf", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/14/Catspaw.jpg/revision/latest?cb=20160807061648" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "2 - The Kingsroad", Name = "Mycah", DeathDescription = "Killed by the Hound", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/9f/Mycah_infobox.jpg/revision/latest?cb=20120509174103" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "4 - Cripples, Bastards and Broken Things", Name = "Ser Hugh", DeathDescription = "Killed by the Mountain", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/df/Hugh_profile.jpg/revision/latest?cb=20130111183816" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "5 - The Wolf and the Lion", Name = "Kurleket", DeathDescription = "Killed by hill tribesmen", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/b/b2/Kurleket.jpg/revision/latest?cb=20120302011408" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "5 - The Wolf and the Lion", Name = "Willis Wode", DeathDescription = "Killed by hill tribesmen", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1b/Willis_Wode_infobox.jpg/revision/latest?cb=20160802033932" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "5 - The Wolf and the Lion", Name = "Wyl", DeathDescription = "Killed by Lannister guardsmen", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/85/Heward-and-Wyl.jpg/revision/latest?cb=20131219165605" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "5 - The Wolf and the Lion", Name = "Heward", DeathDescription = "Killed by Lannister guardsmen", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/85/Heward-and-Wyl.jpg/revision/latest?cb=20131219165605" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 1, Episode = "5 - The Wolf and the Lion", Name = "Jory Cassel", DeathDescription = "Killed by Jamie Lannister", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/87/Jory_profile.jpg/revision/latest?cb=20130122153149" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "6 - A Golden Crown", Name = "Wallen", DeathDescription = "Killed by Rob Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/f/fa/Wallen1.jpg/revision/latest?cb=20130216195147" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "6 - A Golden Crown", Name = "Stiv", DeathDescription = "Killed by Theon Greyjoy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1b/Stiv.jpg/revision/latest?cb=20110615180310" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "6 - A Golden Crown", Name = "Vardis Egen", DeathDescription = "Killed by Bronn", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/32/Vardis_profile.jpg/revision/latest?cb=20130126143838" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 1, Episode = "6 - A Golden Crown", Name = "Viserys Targaryen", House = HouseEnum.Targaryen, DeathDescription = "Killed by Khal Drogo", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/46/Viseryspromoheadshot.jpg/revision/latest?cb=20160730184148" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "7 - You Win or You Die", Name = "Wine seller", DeathDescription = "Dragged behind a Horse", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/77/Wineseller.jpg/revision/latest?cb=20150314034745" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 1, Episode = "7 - You Win or You Die", Name = "Robert Baratheon", House = HouseEnum.Baratheon , DeathDescription = "Killed by a boar", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/d4/RobertBaratheon.jpg/revision/latest?cb=20141119000127" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "8 - The Pointy End", Name = "Vayon Poole", DeathDescription = "Killed by House Lannister men", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/69/Vayon_Poole.jpg/revision/latest?cb=20120313172256" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "8 - The Pointy End", Name = "Mordane", DeathDescription = "Killed by House Lannister men", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/20/MordaneCropped.jpg/revision/latest?cb=20190215194539" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 1, Episode = "8 - The Pointy End", Name = "Syrio Forel", DeathDescription = "Killed by House Lannister men", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/b/bc/Syrio_Forel-0.png/revision/latest?cb=20180702204345" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "8 - The Pointy End", Name = "Stableboy", DeathDescription = "Killed by Arya", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/3f/Stableboy.jpg/revision/latest?cb=20150505161920" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "8 - The Pointy End", Name = "Mago", DeathDescription = "Killed by Khal Drogo", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/86/Mago_profile.jpg/revision/latest?cb=20130122155822" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "8 - The Pointy End", Name = "Othor", DeathDescription = "Burned by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/3b/Othor.jpg/revision/latest?cb=20110606235048" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 1, Episode = "9 - Baelor", Name = "Qotho", DeathDescription = "Killed by Jorah Mormont", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a5/Qotho_1x08.png/revision/latest?cb=20160829192752" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 1, Episode = "9 - Baelor", Name = "Eddard Stark", House = HouseEnum.Stark, DeathDescription = "Executed by Ilyn Payne", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/37/Eddard_Stark_infobox_new.jpg/revision/latest?cb=20160730050722" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 1, Episode = "10 - Fire and Blood", Name = "Khal Drogo", DeathDescription = "Smothered by Daenerys", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1f/Drogo_1x01b.jpg/revision/latest?cb=20110626031733" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 1, Episode = "10 - Fire and Blood", Name = "Mirri Maz Duur", DeathDescription = "Burned alive by Daenerys", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/69/Mirri_Speaks.png/revision/latest?cb=20170904121606" },
            //Season 2
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "1 - The North Remembers", Name = "Maester Cressen", DeathDescription = "Suicide by poison", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/32/Cressen.png/revision/latest?cb=20130511145128" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "1 - The North Remembers", Name = "Barra", DeathDescription = "Killed by Janos Slynt", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/0c/Barra.jpg/revision/latest?cb=20160717053734" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "2 - The Night Lands", Name = "Rakharo", DeathDescription = "Killed by Dothrakis", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/ce/RakharoTheNorthRemembers.jpg/revision/latest?cb=20190215192725" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "2 - Dark Wings, Dark Words", Name = "Hoster Tully", House = HouseEnum.Tully, DeathDescription = "Old age", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a3/Hoster_Tully.png/revision/latest?cb=20140615193244" },
        };

        [HttpGet("[action]/{difficulty}")]
        public List<Character> GetDeadCharactersShuffled([FromRoute] DifficultyEnum difficulty)
        {
            return GetCharacterList(difficulty).OrderBy(c => c.Season).ThenBy(_ => Guid.NewGuid()).ToList();
        }

        [HttpPost("[action]/{difficulty}")]
        public GameResult CheckAnswers([FromRoute] DifficultyEnum difficulty, [FromBody] List<Character> submittedCharacterList)
        {
            var GameResult = new GameResult();
            List<Character> answerSheet = GetCharacterList(difficulty);
            GameResult.CorrectCharacterOrder = answerSheet;

            var score = 0;
            for (int correctIndex = 0; correctIndex < answerSheet.Count; correctIndex++)
            {
                //This line if for setting the correct Order
                answerSheet[correctIndex].Order = correctIndex + 1;

                var guessIndex = submittedCharacterList.FindIndex(c => c.Name == answerSheet[correctIndex].Name);
                score += 2 - Math.Abs(guessIndex - correctIndex);
            }

            GameResult.Score = score;
            return GameResult;
        }

        private List<Character> GetCharacterList(DifficultyEnum difficulty)
        {
            switch (difficulty)
            {
                case DifficultyEnum.Easy:
                    return DeadCharacters.Where(c => c.Importance == Character.ImportanceEnum.Major).ToList();
                case DifficultyEnum.Medium:
                    return DeadCharacters.Where(c =>
                        c.Importance == Character.ImportanceEnum.Major ||
                        c.Importance == Character.ImportanceEnum.Recurring).ToList();
                case DifficultyEnum.Hard:
                    return DeadCharacters;
                default:
                    throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, "Invalid Difficulty");
            }
        }

        public class GameResult
        {
            public int Score { get; set; }
            public List<Character> CorrectCharacterOrder { get; set; }
        }

        public class Character
        {
            public string Name { get; set; }
            public int Season { get; set; }
            public int Order { get; set; }
            public string Episode { get; set; }
            public string Time { get; set; }
            public string DeathDescription { get; set; }
            public string ImageUrl { get; set; }
            public ImportanceEnum Importance { get; set; }
            public HouseEnum? House { get; set; }

            public enum ImportanceEnum
            {
                Minor = 1,
                Recurring = 2,
                Major = 3
            }
        }

        public enum DifficultyEnum
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }

        public enum HouseEnum
        {
            None = 0,
            Targaryen = 1,
            Baratheon = 2,
            Stark = 3,
            Arryn = 4,
            Tully = 5
        }
    }
}
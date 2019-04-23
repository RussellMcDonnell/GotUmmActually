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
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "3 - What is Dead May Never Die", Name = "Yoren", DeathDescription = "Killed by Amory Lorch", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/14/Yoren_profile.jpg/revision/latest?cb=20130111172454" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "3 - What is Dead May Never Die", Name = "Lommy", DeathDescription = "Killed by Polliver", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/65/LommyS2.jpg/revision/latest?cb=20131004001551" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "4 - Garden of Bones", Name = "Rennick", DeathDescription = "Killed by Robb Stark's wolf", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/54/Rennick.jpg/revision/latest?cb=20160716065010" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "4 - Garden of Bones", Name = "Lannister guardsmen", DeathDescription = "Killed by Robb Stark's wolf", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/45/Lannister_Guard.png/revision/latest?cb=20160720034023" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "4 - Garden of Bones", Name = "Tortured Prisoner", DeathDescription = "Tortured to death", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/41/Male_Lannister_prisoner.png/revision/latest?cb=20120423160401" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 2, Episode = "5 - The Ghost of Harrenhal", Name = "Renly Baratheon", House = HouseEnum.Baratheon, DeathDescription = "Killed by shadow creature", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/f/ff/Profile-Renly_Baratheon.png/revision/latest?cb=20171006064500" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "5 - The Ghost of Harrenhal", Name = "Emmon Cuy", DeathDescription = "Killed by Brenne of Tarth", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1e/Renly%27s_Kingsguard_1.png/revision/latest?cb=20160720034843" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "5 - The Ghost of Harrenhal", Name = "Robar Royce", DeathDescription = "Killed by Brenne of Tarth", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/66/Renly%27s_Kingsguard_2.png/revision/latest?cb=20160720034858" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "5 - The Ghost of Harrenhal", Name = "The Tickler", DeathDescription = "Killed by Jaqen H'ghar", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/02/Tickler.png/revision/latest?cb=20120423144129" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "6 - The Old Gods and the New", Name = "Rodrik Cassel", DeathDescription = "Killed by Teon Greyjoy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/6b/Rodrik_profile.jpg/revision/latest?cb=20130122155003" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "6 - The Old Gods and the New", Name = "The High Septon", DeathDescription = "Killed by Rioters", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/01/The_Fat_One.jpg/revision/latest?cb=20160306093500" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "6 - The Old Gods and the New", Name = "Armory Lorch", DeathDescription = "Killed by Jagen H'ghar", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/02/Amory_Lorch.png/revision/latest?cb=20180702194703" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "6 - The Old Gods and the New", Name = "Drennan", DeathDescription = "Killed by Osha", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/dd/Drennan.jpg/revision/latest?cb=20160716045852" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "6 - The Old Gods and the New", Name = "Irri", DeathDescription = "Killed by Xaro Xhoan Daxos", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/4d/ProfilIrri1.png/revision/latest?cb=20170905201241" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "7 - A Man Without Honor", Name = "Alton Lannister", House = HouseEnum.Lannister, DeathDescription = "Killed by Jamie Lanister", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/02/Alton_profile.jpg/revision/latest?cb=20160719232326" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "7 - A Man Without Honor", Name = "Torrhen Karstark", DeathDescription = "Killed by Jamie Lanister", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/59/Torrhen_Karstark.png/revision/latest?cb=20160720041557" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "7 - A Man Without Honor", Name = "Eleven of the Thirteen", DeathDescription = "Killed by Pyat Pree", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1c/The_Thirteen_2x07.jpg/revision/latest?cb=20120515005330" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "7 - A Man Without Honor", Name = "Billy (FarmBoy1)", DeathDescription = "Killed by Theon Greyjoy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/0e/Jack%26BillyS02EP07.jpg/revision/latest?cb=20121213142537" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "7 - A Man Without Honor", Name = "Jack (FarmBoy2)", DeathDescription = "Killed by Theon Greyjoy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/0e/Jack%26BillyS02EP07.jpg/revision/latest?cb=20121213142537" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "8 - The Prince of Winterfell", Name = "Stonesnake", DeathDescription = "Killed by wildlings", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/52/Stonesnake2x06.jpg/revision/latest?cb=20140731233957" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "8 - The Prince of Winterfell", Name = "Harker", DeathDescription = "Killed by wildlings", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/41/Harker2x06.jpg/revision/latest?cb=20140731235913" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "8 - The Prince of Winterfell", Name = "Borba", DeathDescription = "Killed by wildlings", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/95/Borba.png/revision/latest?cb=20120501011740" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "9 - Blackwater", Name = "Matthos Seaworth", DeathDescription = "Killed by Wildfire explosion", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/b/b3/MatthosSeaworthHD2x09.png/revision/latest?cb=20160724071826" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "9 - Blackwater", Name = "Mandon Moore", DeathDescription = "Killed by Podrik", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/17/Mandon_2x09.jpg/revision/latest?cb=20160718185052" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 2, Episode = "10 - Valar Morghulis", Name = "Tom", DeathDescription = "Killed by Brienne of Tarth", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/b/b1/Tom_2x10.png/revision/latest?cb=20120604131006" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "10 - Valar Morghulis", Name = "Maester Luwin", DeathDescription = "Killed by Dagmer", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/53/Luwin.jpg/revision/latest?cb=20180702203634" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "10 - Valar Morghulis", Name = "Pyat Pree", DeathDescription = "Killed by Daenerys' dragons", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/30/Pyat_profile.jpg/revision/latest?cb=20170829212058" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "10 - Valar Morghulis", Name = "Qhorin", DeathDescription = "Killed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/15/Qhorin.png/revision/latest?cb=20160720012556" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "10 - Valar Morghulis", Name = "Doreah", DeathDescription = "Locked in Xaro Xhoan Daxos' Vault", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/07/Doreah_infobox_main.jpg/revision/latest?cb=20160623000252" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 2, Episode = "10 - Valar Morghulis", Name = "Xaro Xhoan Daxos", DeathDescription = "Locked in Xaro Xhoan Daxos' Vault", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1f/XaroXhoanDaxosPromo.jpg/revision/latest?cb=20131003195514" },
            //Season 3
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "2 - Dark Wings, Dark Words", Name = "Hoster Tully", House = HouseEnum.Tully, DeathDescription = "Old age", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a3/Hoster_Tully.png/revision/latest?cb=20140615193244" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "3 - Walk of Punishment", Name = "Master Torturer", DeathDescription = "Killed by Ramsay Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/b/b7/Skinner-3x02.jpg/revision/latest?cb=20160805021917" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "4 - And Now His Watch is Ended", Name = "Bannen", DeathDescription = "Died of a broken foot and being starved", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/87/Bannen%27s_Funeral_S3E4.jpg/revision/latest?cb=20130422043048" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 3, Episode = "4 - And Now His Watch is Ended", Name = "Caster", DeathDescription = "Killed by Karl Tanner", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/78/CrasterHD3x03.png/revision/latest?cb=20160829161002" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 3, Episode = "4 - And Now His Watch is Ended", Name = "Jeor Mormont", DeathDescription = "Killed by Rast", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1b/Jeor_Mormont_Season_2.jpg/revision/latest?cb=20120705014740" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "4 - And Now His Watch is Ended", Name = "Kraznys mo Nakloz", DeathDescription = "Killed by dragon", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/cf/Kraznys-3x03.jpg/revision/latest?cb=20130408113949" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "5 - Kissed by Fire", Name = "Willen Lannister", House = HouseEnum.Lannister, DeathDescription = "Killed by Richard Karstark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/05/Willem-3x05.jpg/revision/latest?cb=20130502090242" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "5 - Kissed by Fire", Name = "Martyn Lannister", House = HouseEnum.Lannister, DeathDescription = "Killed by Richard Karstark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/cc/Martyn-Lannister-3x05.jpg/revision/latest?cb=20160829160830" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "5 - Kissed by Fire", Name = "Martyn Lannister", House = HouseEnum.Lannister, DeathDescription = "Killed by Richard Karstark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/cc/Martyn-Lannister-3x05.jpg/revision/latest?cb=20160829160830" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 3, Episode = "5 - Kissed by Fire", Name = "Richard Karstark", DeathDescription = "Executed by Robb Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/9d/Karstark.jpg/revision/latest?cb=20170701013013" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 3, Episode = "6 - The Climb", Name = "Ros", DeathDescription = "Killed by Joffrey", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/23/Ros-3x04a.jpg/revision/latest?cb=20160719051204" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "8 - Second Sons", Name = "Mero", DeathDescription = "Killed by Daario Naharis", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/63/Mero_3x08.jpg/revision/latest?cb=20130524070035" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "8 - Second Sons", Name = "Prendahl na Ghezn", DeathDescription = "Killed by Daario Naharis", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1c/Prendhahl_Second_Sons.png/revision/latest?cb=20130526212955" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "8 - Second Sons", Name = "White Walker", DeathDescription = "Killed by Samwell Tarly", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/56/WhiteWalker%28ValarMorghulis%29.PNG/revision/latest?cb=20180615224129" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "9 - The Rains of Castamere", Name = "Old Man", DeathDescription = "Killed by Ygritte", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/5e/Rain_of_castamere_Old_Man_Cropped.jpg/revision/latest?cb=20160807053327" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 3, Episode = "9 - The Rains of Castamere", Name = "Orell", DeathDescription = "Killed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/9a/Orell_S3_Crop.jpeg/revision/latest?cb=20140604150416" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 3, Episode = "9 - The Rains of Castamere", Name = "Talisa Stark", House = HouseEnum.Stark, DeathDescription = "Killed by Lorthar Frey", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/ca/Talisa3x9.jpg/revision/latest?cb=20150515053353" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 3, Episode = "9 - The Rains of Castamere", Name = "Robb Stark", House = HouseEnum.Stark, DeathDescription = "Killed by Roose Bolton", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/50/S3E9_Robb_Stark_main.jpg/revision/latest?cb=20160718071203" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "9 - The Rains of Castamere", Name = "Joyeuse Frey", DeathDescription = "Killed by Catelyn Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/61/Joyeuse_Erenford_3x09.jpg/revision/latest?cb=20160717060047" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 3, Episode = "9 - The Rains of Castamere", Name = "Catelyn Stark", House = HouseEnum.Stark, DeathDescription = "Killed by Walder Rivers", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/d8/CatelynS3Promo.jpg/revision/latest?cb=20131004004734" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 3, Episode = "10 - Mhysa", Name = "Frey Soldier", DeathDescription = "Killed by Arya Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/27/Freysoldier1.jpg/revision/latest?cb=20170613015122" },
            //Season 4
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "1 - Two Swords", Name = "Iowell", DeathDescription = "Killed by the Hound", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/e/eb/Lowell.jpg/revision/latest?cb=20140410205106" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "1 - Two Swords", Name = "Polliver", DeathDescription = "Killed by Arya Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/6c/Polliver-Profile-HD.jpg/revision/latest?cb=20160718191846" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "2 - The Lion and the Rose", Name = "Tansy", DeathDescription = "Killed by Ramsey's Dogs", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/23/Tansy4x02.jpg/revision/latest?cb=20160716073003" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "2 - The Lion and the Rose", Name = "Axell Florent", DeathDescription = "Burned alive by Melisandre", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a8/Axell-Florent-On-The-Stake.png/revision/latest?cb=20160826074127" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 4, Episode = "2 - The Lion and the Rose", Name = "Joffrey Baratheon", House = HouseEnum.Baratheon, DeathDescription = "Poisoned by Olenna Tyrell", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/25/Joffrey_Season_4_Episode_2_TLATR.jpg/revision/latest?cb=20171105180252" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "3 - Breaker of Chains", Name = "Dontos Hollar", DeathDescription = "Killed by Petyr Baelish's men", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/d8/DontosGoodQ.jpg/revision/latest?cb=20170830011801" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "3 - Breaker of Chains", Name = "Guymon", DeathDescription = "Killed by Ygritte", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/21/Guymon%27s_father.png/revision/latest?cb=20140421121146" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "3 - Breaker of Chains", Name = "Olly's Mother", DeathDescription = "Killed by Styr", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/8c/Guymon%27s_mother.jpg/revision/latest?cb=20160807065628" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "3 - Breaker of Chains", Name = "Oznak zo Pahl", DeathDescription = "Killed by Daario Naharis", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/39/Oznak_zo_pahl.png/revision/latest?cb=20140421104359" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "4 - Oathkeeper", Name = "Locke", DeathDescription = "Killed by Bran Stark While warging into Hodor", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/cf/Locke_Staffel_4.jpg/revision/latest?cb=20170905200142" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "5 - First of His Name", Name = "Locke", DeathDescription = "Killed by Bran Stark While warging into Hodor", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/cf/Locke_Staffel_4.jpg/revision/latest?cb=20170905200142" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "5- First of His Name", Name = "Karl Tanner", DeathDescription = "Killed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/58/Karl_tanner_released_by_HBO_S4.PNG/revision/latest?cb=20170506112727" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "5 - First of His Name", Name = "Rast", DeathDescription = "Killed by Jon Snow's wolf", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/61/Rast-S4-EP-04.jpg/revision/latest?cb=20140501100824" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "7 - Mockingbird", Name = "Dying Man", DeathDescription = "Mercy Killed by the Hound", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/f/fd/Dying_man.png/revision/latest?cb=20140519204758" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "7 - Mockingbird", Name = "Biter", DeathDescription = "Killed by the Hound", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/aa/Biterharrenhal.png/revision/latest?cb=20190214194345" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "7 - Mockingbird", Name = "Rorge", DeathDescription = "Killed by Arya Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/af/Rorge_S04.jpg/revision/latest?cb=20170307154737" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "7 - Mockingbird", Name = "Lysa Arryn", House = HouseEnum.Arryn, DeathDescription = "Pushed through the moon door by Littlefinger", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/46/LysaArryn.png/revision/latest?cb=20140523133128" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "8 - The Mountain and the Viper", Name = "Mole's Town whore", DeathDescription = "Killed by Ygritte", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1d/Whore.png/revision/latest?cb=20160809103629" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "8 - The Mountain and the Viper", Name = "Ralf Kenning", DeathDescription = "Killed by Adrack Humble", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/b/ba/Ralf-Kenning.png/revision/latest?cb=20150607061223" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "8 - The Mountain and the Viper", Name = "Adrack Humble", DeathDescription = "Killed by Ramsay Snow's men", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/9b/AdrackHumble_S4.jpg/revision/latest?cb=20160710232017" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 4, Episode = "8 - The Mountain and the Viper", Name = "Oberyn Martell", House = HouseEnum.Martell, DeathDescription = "Killed by the Mountain", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/96/Oberyn-Martell-house-martell-37118334-2832-4256.jpg/revision/latest?cb=20150815065729" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Pypar", DeathDescription = "Killed by Ygritte", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/e/e6/Pypar-mockingbird.jpg/revision/latest?cb=20161215025708" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Thenn warg", DeathDescription = "Killed by Samwell Tarly", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/88/Thennwarg.PNG/revision/latest?cb=20160730065017" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Dongo", DeathDescription = "Killed by Black Brothers", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a3/Giant_S3.PNG/revision/latest?cb=20140604145849" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Smitty", DeathDescription = "Fell off the wall", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/75/Smitty.PNG/revision/latest?cb=20160826070050" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Styr", DeathDescription = "Killed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/96/Styr-HD.png/revision/latest?cb=20140512161058" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Ygritte", DeathDescription = "Killed by Olly", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/28/Ygritte-promotionals4pic.jpg/revision/latest?cb=20170107042949" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Mag Mar Tun Doh Weg", DeathDescription = "Killed by Grenn and 5 other black brothers", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/f/f2/Mag_Mar_Tun_Doh_Weg.png/revision/latest?cb=20160719014250" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Grenn", DeathDescription = "Killed by Mag Mar Tun Doh Weg", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1b/Grenn.jpg/revision/latest?cb=20180702193920" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Cooper", DeathDescription = "Killed by Mag Mar Tun Doh Weg", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/61/Donnel_Hill.PNG/revision/latest?cb=20160816152329" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "9 - The Watchers on the Wall", Name = "Done Hill", DeathDescription = "Killed by Mag Mar Tun Doh Weg", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/64/Cooper_.PNG/revision/latest?cb=20160816152350" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 4, Episode = "10 - The Children", Name = "Zalla", DeathDescription = "Killed by Dragon", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/37/Zalla.png/revision/latest?cb=20140617070913" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 4, Episode = "10 - The Children", Name = "Jojen Reed", DeathDescription = "Killed by Wight", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/2/23/Jojen-Reed-Profile.jpg/revision/latest?cb=20170904015452" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 4, Episode = "10 - The Children", Name = "Shae", DeathDescription = "Killed by Tyrion Lannister", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/01/Shae_in_Two_Swords.png/revision/latest?cb=20140505142823" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 4, Episode = "10 - The Children", Name = "Tywin Lannister", House = HouseEnum.Lannister, DeathDescription = "Killed by Tyrion Lannister", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/71/Tywin_Lannister_4x08.jpg/revision/latest?cb=20170830015346" },
            //Season 5
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "1 - The Wars to Come", Name = "White Rat", DeathDescription = "Killed by a member of the Sons of the Harpy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/78/White_rat.png/revision/latest?cb=20160829160732" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "1 - The Wars to Come", Name = "Mance Rayder", DeathDescription = "Mercy killed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/17/GOT_Season_5_10.jpg/revision/latest?cb=20160826005613" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "2 - The House of Black and White", Name = "Son of Harpy", DeathDescription = "Killed by Mossador", ImageUrl = "https://deathtimeline.com/119.jpg" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "2 - The House of Black and White", Name = "Mossador", DeathDescription = "Executed by Daario Naharis", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/af/Mossador-s5e1-v2.jpg.jpg/revision/latest?cb=20150427224509" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "3 - High Sparrow", Name = "Janos Slynt", DeathDescription = "Executed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/c/ce/S4_Slynt_HD.png/revision/latest?cb=20151006235041" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "4 - Sons of the Harpy", Name = "Lead Dornish guard", DeathDescription = "Killed by Bronn", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/08/Lead_dornish_guard-v2-s5e4.jpg/revision/latest?cb=20150508232251" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "4 - Sons of the Harpy", Name = "Merchant captain", DeathDescription = "Killed by Obara Sand", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/8/8e/Merchant_Captain.png/revision/latest?cb=20150505161455" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "4 - Sons of the Harpy", Name = "Ser Barristan Selmy", DeathDescription = "Killed by Sons of Harpy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1f/Barristan_Selmy_Sons_of_the_Harpy.jpg/revision/latest?cb=20150504180820" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "5 - Kill the Boy", Name = "Great Master", DeathDescription = "Killed by Dragon", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/98/Eatonepisode5.png/revision/latest?cb=20150511165617" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "6 - Unbowed, Unbent, Unbroken", Name = "Ghita", DeathDescription = "Posioned with water from House of Black and White by Arya", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a9/5x06_Ghita.png/revision/latest?cb=20170826013558" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "7 - The Gift", Name = "Master Aemon", House = HouseEnum.Targaryen, DeathDescription = "Died of natural causes", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/3/32/Aemonepisode5.png/revision/latest?cb=20150511170352" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "7 - The Gift", Name = "Old Woman", DeathDescription = "Killed by Ramsay Bolton", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/79/Old_Lady_at_Mount_Cailin.jpg/revision/latest?cb=20160716065719" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "8 - Hardhome", Name = "Lord of Bones", DeathDescription = "Killed by Tormund", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1e/5x08_Lord_of_Bones.jpg/revision/latest?cb=20160807064855" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "8 - Hardhome", Name = "Loboda", DeathDescription = "Killed by White Walker", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/1/1f/Loboda_Hardhome.PNG/revision/latest?cb=20180702220807" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "8 - Hardhome", Name = "White Walker", DeathDescription = "Killed by Jon Snow", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/7d/WhiteWalker_s5e8.jpg/revision/latest?cb=20150602122300" },
            new Character { Importance = Character.ImportanceEnum.Minor, Season = 5, Episode = "8 - Hardhome", Name = "Karsi", DeathDescription = "Killed by pack of child-wights", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/a/a0/Karsi-hardhome.jpg/revision/latest?cb=20161215025503" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "9 - The Dance of Dragons", Name = "Shrine Baratheon", House = HouseEnum.Baratheon, DeathDescription = "Burned alive as a sacrifice by Melisandre", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/e/eb/Shireen_Baratheon_Season_4_profile.jpg/revision/latest?cb=20161215030938" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "9 - The Dance of Dragons", Name = "Hizdahr zo Loraq", DeathDescription = "Killed by son of Harpy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/5/5f/Hizdahr_season_5_wars_to_come.jpg/revision/latest?cb=20150415042040" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "10 - Mother's Mercy", Name = "Selyse Baratheon", House = HouseEnum.Baratheon, DeathDescription = "Suicide by hanging", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/6/65/SelyseS05E05.png/revision/latest?cb=20150515051443" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 5, Episode = "10 - Mother's Mercy", Name = "Stannis Baratheon", House = HouseEnum.Baratheon, DeathDescription = "Killed by Brienne of Tarth", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/7/7a/Stannis_S05E09.png/revision/latest?cb=20190412205744" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "10 - Mother's Mercy", Name = "Myranda", DeathDescription = "Killed by Theon Greyjoy", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/9/92/Myranda.jpg/revision/latest?cb=20161215025334" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "10 - Mother's Mercy", Name = "Meryn Trant", DeathDescription = "Killed by Arya Stark", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/4/46/Ser_Meryn.png/revision/latest?cb=20140928135510" },
            new Character { Importance = Character.ImportanceEnum.Recurring, Season = 5, Episode = "10 - Mother's Mercy", Name = "Myrcella Baratheon", House = HouseEnum.Baratheon, DeathDescription = "Poisoned by Ellaria Sand", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/0/02/MyrcellaS5Cropped.jpg/revision/latest?cb=20160802025401" },
            new Character { Importance = Character.ImportanceEnum.Major, Season = 5, Episode = "10 - Mother's Mercy", Name = "Jon Snow", House = HouseEnum.Targaryen, DeathDescription = "Killed by Black brothers", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/d3/JonSnowSeason8HB.jpg/revision/latest?cb=20190401173347" },
            //Season 6
            new Character { Importance = Character.ImportanceEnum.Major, Season = 6, Episode = "1 - Mother's Mercy", Name = "Jon Snow", House = HouseEnum.Targaryen, DeathDescription = "Killed by Black brothers", ImageUrl = "https://vignette.wikia.nocookie.net/gameofthrones/images/d/d3/JonSnowSeason8HB.jpg/revision/latest?cb=20190401173347" },
        };

        [HttpGet("[action]/{difficulty}")]
        public List<Character> GetDeadCharactersShuffled([FromRoute] DifficultyEnum difficulty)
        {
            if(difficulty == DifficultyEnum.Easy)
                return GetCharacterList(difficulty).OrderBy(_ => Guid.NewGuid()).ToList();
            else
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
            Tully = 5,
            Lannister = 6,
            Martell = 7
        }
    }
}
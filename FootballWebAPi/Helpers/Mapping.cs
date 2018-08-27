using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Helpers
{
    public class Mapping
    {

        private static Dictionary<string, string> TeamMapping = new Dictionary<string, string> {
            { "MULHOUSE BOURTZ C.S", "Mulhouse Bourtz C.S." },
            { "BANTZENHEIM F.C.", "Bantzenheim F.C."},
            { "HUNINGUE A.S", "Huningue A.S."},
            { "UFFHEIM F.C.", "Uffheim F.C."},
            { "RIEDISHEIM F.C", "Riedisheim F.C."},
            { "ALTKIRCH A.S.", "Altkirch A.S."},
            { "HIRSINGUE U.S", "Hirsingue U.S."},
            { "BALLERSDORF EPA", "Ballersdorf EPA"},
            { "MULHOUSE REAL C.F.", "Mulhouse Real C.F."},
            { "KINGERSHEIM F.C", "Kingersheim F.C."},
            { "PFASTATT F.C.", "Pfastatt F.C."},
            { "BARTENHEIM F.C", "Bartenheim F.C."},
            { "WITTENHEIM U.S. 2", "Wittenheim U.S. 2"},
            { "MULHOUSE A.S.R.S", "Mulhouse A.S.R.S." },
            { "HABSHEIM F.C.", "Habsheim F.C." },
            { "HIRTZBACH F.C", "Hirtzbach F.C." },
            { "BERRWILLER A.S. 2", "Berrwiller A.S. 2" },
            { "ZILLISHEIM S.S.", "Zillisheim S.S." },
            { "MONTREUX SPORTS", "Montreux Sports" },
            { "MULHOUSE R.C.", "Mulhouse R.C." }
        };

        public static string GetTeam(string lafaTeamName)
        {
            string retVal;
            if (TeamMapping.TryGetValue(lafaTeamName.Trim(), out retVal))
            {
                return retVal;
            }

            throw new Exception(lafaTeamName + "mapping not found");
        }

    }
}
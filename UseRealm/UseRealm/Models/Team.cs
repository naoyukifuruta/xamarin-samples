﻿using Realms;
using System;
using System.Collections.Generic;

namespace UseRealm.Models
{
    public class Team : RealmObject
    {
        [PrimaryKey]
        public string TeamId { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public string Manager { get; set; }
        public string City { get; set; }

        public string StadiumName { get; set; }

        public IList<Player> Players { get; }
    }
}

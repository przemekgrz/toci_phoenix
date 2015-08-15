﻿using Phoenix.Bll.Interfaces.BusinessModels.UsersList;
using Toci.Utilities.Interfaces.User;

namespace Phoenix.Bll.BusinessModels.UsersList
{
    public class Users : IUsers
    {
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
﻿using System;

namespace ShareIt.ShareLinkCtx.Domain
{
    public class Name
    {
        private readonly string _name;

        public Name(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException(String.Format("{0} cannot be null or white spaces", name));
            _name = name;
        }

        public static implicit operator string(Name name)
        {
            return name._name;
        }
    }
}
﻿using System;

namespace ShareIt.DiscussionCtx.Domain
{
    public class LinkId : Identity
    {
        private string _value;

        public LinkId(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
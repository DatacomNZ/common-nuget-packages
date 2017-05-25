﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Exceptions
{
    public class UnauthorizedException : UnauthorizedAccessException
    {
        public UnauthorizedException(string message, int errorCode = 0, int attempts = 0, int remainingAttempts = 0)
            : base(message)
        {
            ErrorCode = errorCode;
            LoginAttempts = attempts;
            RemainingAttempts = remainingAttempts;
        }

        public int ErrorCode { get; set; }

        public int LoginAttempts { get; set; }

        public int RemainingAttempts { get; set; }
    }
}
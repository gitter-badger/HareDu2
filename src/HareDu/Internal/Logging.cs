﻿// Copyright 2013-2017 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace HareDu.Internal
{
    using System;
    using Common.Logging;

    internal abstract class Logging
    {
        readonly ILog _logger;
        readonly bool _isEnabled;

        protected Logging(string loggerName, ILog logger, bool enable)
        {
            _logger = logger ?? (!string.IsNullOrWhiteSpace(loggerName) ? LogManager.GetLogger(loggerName) : null);
            _isEnabled = enable && _logger != null;
        }

        protected virtual void LogError(Exception e)
        {
            if (_isEnabled)
                _logger.Error(format => format($"[Msg]: {e.Message}, [Stack Trace] {e.StackTrace}"));
        }

        protected virtual void LogRetryError(Exception e, int retry)
        {
            if (_isEnabled)
                _logger.Error(format => format($"Retry {retry}\n[Msg]: {e.Message}, [Stack Trace] {e.StackTrace}"));
        }

        protected virtual void LogError(string message)
        {
            if (_isEnabled)
                _logger.Error(message);
        }

        protected virtual void LogInfo(string message)
        {
            if (_isEnabled)
                _logger.Info(message);
        }
    }
}
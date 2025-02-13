﻿#region Copyright & License

// Copyright © 2012 - 2021 François Chabot
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

#endregion

using System;
using Be.Stateless.BizTalk.Stream.Extensions;
using Moq;

namespace Be.Stateless.BizTalk.Unit.Stream
{
	internal class ProbeBatchContentStreamMockInjectionScope : IDisposable
	{
		public ProbeBatchContentStreamMockInjectionScope()
		{
			_proberFactory = BatchContentStreamExtensions.BatchContentStreamProberFactory;
			Mock = new Mock<IProbeBatchContentStream>();
			BatchContentStreamExtensions.BatchContentStreamProberFactory = _ => Mock.Object;
		}

		#region IDisposable Members

		public void Dispose()
		{
			BatchContentStreamExtensions.BatchContentStreamProberFactory = _proberFactory;
		}

		#endregion

		public Mock<IProbeBatchContentStream> Mock { get; }

		private readonly Func<System.IO.Stream, IProbeBatchContentStream> _proberFactory;
	}
}

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

using System.Diagnostics.CodeAnalysis;
using Be.Stateless.BizTalk.Dsl.Binding.Convention;
using Be.Stateless.BizTalk.Dsl.Binding.Convention.Simple;

namespace Be.Stateless.BizTalk
{
	public class ApplicationBinding : ApplicationBinding<NamingConvention>
	{
		public ApplicationBinding()
		{
			Name = ApplicationName.Is("BizTalk.Factory.Batching");
			Description = "BizTalk.Factory's BizTalk Server Batching Application.";
			ReceivePorts.Add(new ContentReceivePort());
			SendPorts.Add(
				new PartSendPort(),
				new ReleaseSendPort());
		}

		#region Base Class Member Overrides

		[SuppressMessage("ReSharper", "InvertIf")]
		protected override void ApplyEnvironmentOverrides(string environment)
		{
			if (environment.IsDevelopmentOrBuild())
			{
				ReceivePorts.Add(new PartReceivePortStub());
				SendPorts.Add(new ContentSendPortStub());
			}
		}

		#endregion
	}
}

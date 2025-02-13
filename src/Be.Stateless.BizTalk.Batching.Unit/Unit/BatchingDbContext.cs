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

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Be.Stateless.BizTalk.Unit
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Public API.")]
	[SuppressMessage("ReSharper", "UnusedType.Global", Justification = "Public API.")]
	public class BatchingDbContext
	{
		private static SqlConnection Connection => new(ConfigurationManager.ConnectionStrings["TransientStateDb"].ConnectionString);

		public static void ClearParts()
		{
			using (var connection = Connection)
			using (var command = new SqlCommand("DELETE FROM batch_Parts", connection))
			{
				connection.Open();
				command.ExecuteNonQuery();
			}
		}
	}
}

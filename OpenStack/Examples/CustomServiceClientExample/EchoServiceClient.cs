﻿// /* ============================================================================
// Copyright 2014 Hewlett Packard
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ============================================================================ */

using System.Threading;
using System.Threading.Tasks;
using OpenStack.Common.ServiceLocation;
using OpenStack.Identity;

namespace CustomServiceClientExample
{
    internal class EchoServiceClient : IEchoServiceClient
    {
        internal IServiceLocator ServiceLocator;

        public EchoServiceClient(ICredential credential, CancellationToken token, IServiceLocator serviceLocator)
        {
            this.ServiceLocator = serviceLocator;
        }

        public async Task<EchoResponse> Echo(string message)
        {
            var pocoClient = this.ServiceLocator.Locate<IEchoPocoClientFactory>().Create(this.ServiceLocator);
            return await pocoClient.Echo(message);
        }
    }
}
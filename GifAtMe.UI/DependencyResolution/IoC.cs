// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GifAtMe.UI.DependencyResolution
{
    using GifAtMe.Common.Domain;
    using GifAtMe.Common.UnitOfWork;
    using GifAtMe.Domain.Entities.GifEntry;
    using GifAtMe.Repository.Contexts;
    using GifAtMe.Repository.Repositories;
    using GifAtMe.Service.Interfaces;
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssemblyContainingType<IGifEntryRepository>();
                    scan.AssemblyContainingType<GifEntryRepository>();
                    scan.AssemblyContainingType<IGifEntryService>();
                    scan.AssemblyContainingType<IAggregateRoot>();
                    scan.WithDefaultConventions();
                });
                x.For<IUnitOfWork>().Use<GifAtMe.Repository.EfUnitOfWork>();
            });
            //return new Container(c => c.AddRegistry<DefaultRegistry>());
            return ObjectFactory.Container;
        }
    }
}
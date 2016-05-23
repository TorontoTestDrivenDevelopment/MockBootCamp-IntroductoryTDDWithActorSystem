using System;
using Autofac;

namespace EmailSender.Tests
{
    public class TestHelper
    {
        public IContainer Register<TF,TT>(IContainer continer = null)
        {
            continer = continer ?? new ContainerBuilder().Build();
            var builder = new ContainerBuilder();
            builder.RegisterType<TF>().As<TT>();
            builder.Update(continer);
            return continer;
        }
        public IContainer Register<TT>(Func<IComponentContext,TT> resolution, IContainer continer = null)
        {
            continer = continer ?? new ContainerBuilder().Build();
            var builder = new ContainerBuilder();
            builder.Register(resolution).As<TT>();
            builder.Update(continer);
            return continer;
        }
    }
}
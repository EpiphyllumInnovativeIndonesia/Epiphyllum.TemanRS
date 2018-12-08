using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Xunit;

namespace Epiphyllum.TemanRS.Core.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void Singleton_IsNullByDefault()
        {
            var instance = Singleton<SingletonTests>.Instance;

            Assert.Null(instance);
        }

        [Fact]
        public void Singletons_ShareSame_SingletonsDictionary()
        {
            Singleton<int>.Instance = 1;
            Singleton<double>.Instance = 2.0;

            Assert.Equal(Singleton<int>.AllSingletons, Singleton<double>.AllSingletons);
            Assert.Equal(1, BaseSingleton.AllSingletons[typeof(int)]);
            Assert.Equal(2.0, BaseSingleton.AllSingletons[typeof(double)]);
        }

        [Fact]
        public void SingletonDictionary_IsCreatedByDefault()
        {
            var instance = SingletonDictionary<SingletonTests, object>.Instance;

            Assert.NotNull(instance);
        }

        [Fact]
        public void SingletonDictionary_CanStoreStuff()
        {
            var instance = SingletonDictionary<Type, SingletonTests>.Instance;
            instance[typeof(SingletonTests)] = this;

            Assert.Same(this, instance[typeof(SingletonTests)]);
        }

        [Fact]
        public void SingletonList_IsCreatedByDefault()
        {
            var instance = SingletonList<SingletonTests>.Instance;

            Assert.NotNull(instance);
        }

        [Fact]
        public void SingletonList_CanStoreItems()
        {
            var instance = SingletonList<SingletonTests>.Instance;
            instance.Insert(0, this);

            Assert.Same(this, instance[0]);
        }
    }
}

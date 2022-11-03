using System;
using System.Linq;
using System.Reflection;
using Zenject;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Gamespace.Core.Actions.PlayModeTests.Infrastructure
{
    [TestFixture]
    public class ActionInfrastructureTests : ZenjectUnitTestFixture
    {
        [Test]
        [TestCase(typeof(IntAdditionBehaviour), typeof(IntActionBehaviour))]
        [TestCase(typeof(SetActiveBehaviour), typeof(VoidActionBehaviour))]
        public void ActionTypeTest(Type typeToSpawn, Type expectedType)
        {
            var linkObject = Object.Instantiate(new GameObject());
            var linkBehaviour = linkObject.AddComponent(typeToSpawn) as IActionBehaviour;
            Assert.IsTrue(linkBehaviour.GetType().IsSubclassOf(expectedType));
        }
    }
}

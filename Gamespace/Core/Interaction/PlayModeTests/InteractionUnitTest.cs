using System;
using NUnit.Framework;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Interaction.PlayModeTests
{
    [TestFixture]
    public class InteractionUnitTest : ZenjectUnitTestFixture
    {
        [Test]
        public void InteractableTest()
        {
            var leverGameObject = UnityEngine.Object.Instantiate(new GameObject());
            leverGameObject.AddComponent<ZPullableObject>();

            var interactable = leverGameObject.GetComponent<IInteractable>();
            Assert.That(interactable != null);
        }
        [Test]
        public void InteractTest()
        {
            var leverGameObject = UnityEngine.Object.Instantiate(new GameObject());
            leverGameObject.AddComponent<ZPullableObject>();

            var interactable = leverGameObject.GetComponent<IInteractable>();
            try
            {
                interactable.Interact();
            }
            catch (Exception exception)
            {
                Assert.That(exception is null);
            }
        }
        [Test]
        public void PullTest()
        {
            var leverGameObject = UnityEngine.Object.Instantiate(new GameObject());
            leverGameObject.AddComponent<ZPullableObject>();

            var interactable = leverGameObject.GetComponent<IInteractable>();
            var pullable = leverGameObject.GetComponent<IPullable>();

            interactable.Interact();
            pullable.Pull(0.5f);
            Assert.That(pullable.value == 0.5f);
        }
        [Test]
        [TestCase(10f, 10, 0f, 1f)]
        [TestCase(-10f, 10, 1f, 0f)]
        public void MousePullTest(float mouseVelocity, float frameDuration, float initialValue, float expectedValue)
        {
            var leverGameObject = UnityEngine.Object.Instantiate(new GameObject());
            leverGameObject.AddComponent<ZPullableObject>();

            var interactable = leverGameObject.GetComponent<IInteractable>();
            var pullable = leverGameObject.GetComponent<IPullable>();

            interactable.Interact();
            pullable.Pull(initialValue);

            var mouseYDelta = 0f;
            var frameCount = 0;

            while (frameCount < frameDuration)
            {
                mouseYDelta += 0.01f * mouseVelocity;
                pullable.Pull(mouseYDelta);
                frameCount++;
            }

            Assert.That(pullable.value >= expectedValue);
        }
    }
}

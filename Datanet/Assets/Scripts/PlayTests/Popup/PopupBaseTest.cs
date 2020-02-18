using Zenject;
using System.Collections;
using UnityEngine.TestTools;

public class PopupBaseTest : ZenjectIntegrationTestFixture
{
    [UnityTest]
    public IEnumerator RunTest1()
    {
        // Setup initial state by creating game objects from scratch, loading prefabs/scenes, etc

        PreInstall();

        // Call Container.Bind methods

        PostInstall();

        // Add test assertions for expected state
        // Using Container.Resolve or [Inject] fields
        yield break;
    }
}
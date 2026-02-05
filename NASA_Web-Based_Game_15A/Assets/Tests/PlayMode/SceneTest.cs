using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SceneTest
    {
        [UnityTest]
        public IEnumerator PlayScene()
        {
            var gameObject = new GameObject();
            var sceneLoader = gameObject.AddComponent<MainMenu>();

            var soundMangerObject = new GameObject();
            var soundManager = soundMangerObject.AddComponent<SoundManager>();
            soundManager.soundlist = null;

            sceneLoader.PlayGame();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(SceneManager.GetActiveScene().name, "GameLevel");
        }

        [UnityTest]
        public IEnumerator ScoreboardScene()
        {
            var gameObject = new GameObject();
            var sceneLoader = gameObject.AddComponent<MainMenu>();

            sceneLoader.ScoreBoard();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(SceneManager.GetActiveScene().name, "Scoreboard");
        }

        [UnityTest]
        public IEnumerator OptionsScene()
        {
            var gameObject = new GameObject();
            var sceneLoader = gameObject.AddComponent<MainMenu>();

            var soundMangerObject = new GameObject("SoundManager");
            var soundManager = soundMangerObject.AddComponent<SoundManager>();
            soundManager.soundlist = null;

            sceneLoader.Options();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(SceneManager.GetActiveScene().name, "Options");
        }

        [UnityTest]
        public IEnumerator HowToPlayScene()
        {
            var gameObject = new GameObject();
            var sceneLoader = gameObject.AddComponent<MainMenu>();

            sceneLoader.Tutorial();

            yield return new WaitForSeconds(1);

            Assert.AreEqual(SceneManager.GetActiveScene().name, "HowToPlay");
        }
    }
}

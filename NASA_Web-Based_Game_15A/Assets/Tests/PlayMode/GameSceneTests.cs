using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class GameSceneTests
    {
        [UnityTest]
        public IEnumerator Move()
        {
            var gameObject = new GameObject();
            var sceneLoader = gameObject.AddComponent<MainMenu>();

            var soundMangerObject = new GameObject();
            var soundManager = soundMangerObject.AddComponent<SoundManager>();
            soundManager.soundlist = null;

            sceneLoader.PlayGame();

            var pycheObject = new GameObject();
            var pyche = pycheObject.AddComponent<PsycheMovement>();
            pyche.gameObject.AddComponent<Rigidbody2D>();
            pyche.rb = pyche.GetComponent<Rigidbody2D>();

            Debug.Log(pyche.gameObject.GetComponent<Rigidbody2D>().position);

            yield return new WaitForSeconds(3);

            Debug.Log("test over");

            Assert.AreNotEqual(Vector2.zero, pyche.gameObject.GetComponent<Rigidbody2D>().position);
        }
    }
}

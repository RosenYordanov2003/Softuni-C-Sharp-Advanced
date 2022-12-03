// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 


using System.Linq;
///using FestivalManager.Entities;

namespace FestivalManager.Tests
{

    using NUnit.Framework;
    using System;


    [TestFixture]
    public class StageTests
    {
        private Song song;
        private Performer performer;
        private Stage stage;


        [SetUp]
        public void SetUp()
        {
            song = new Song("Despasito", new TimeSpan(0, 3, 55));
            performer = new Performer("Gosho", "Tsvetanov", 18);
            stage = new Stage();
        }

        [Test]
        public void Test_Stage_Constructor()
        {
            Assert.IsNotNull(stage.Performers);
        }

        [Test]
        public void Test_Stage_Add_Performer_Method_WithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(null);
            });
        }

        [Test]
        public void Test_Stage_Add_Performer_Method_With_Smaller_Age()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(new Performer("Pesho", "Peshov", 14));
            });
        }
        [Test]
        public void Test_Stage_Add_Performer_Method_ShouldWork()
        {
            stage.AddPerformer(performer);
            Assert.AreEqual(1, stage.Performers.Count);
            Assert.AreSame(performer,stage.Performers.First());
        }
        [Test]
        public void Test_Stage_Add_Performer_Method_ShouldWork2()
        {
            stage.AddPerformer(performer);
            stage.AddPerformer(new Performer("Pesho", "Peshov", 24));
            stage.AddPerformer(new Performer("Jadon", "Sancho", 24));
            Assert.AreEqual(3, stage.Performers.Count);
        }

        [Test]
        public void Test_Stage_AddSong_Method_With_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(null);
            });
        }
        [Test]
        public void Test_Stage_AddSong_Method_With_SmallerTime()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(new Song("Bazuka", new TimeSpan(0, 0, 50)));
            });
        }

        [Test]
        public void Test_Stage_AddSongToPerformer_Method_WithNull_AsSongName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer(null, "Gosho");
            });
        }
        [Test]
        public void Test_Stage_AddSongToPerformer_Method_WithNull_AsPerformer()
        {
            stage.AddSong(song);
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer("Despasito", null);
            });
        }

        [Test]
        public void Test_Stage_AddSongToPerformer_Method_ShouldWork()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            string name = string.Format("Gosho" + " " + "Tsvetanov");
            stage.AddSongToPerformer("Despasito", name);
            Assert.AreEqual(1, performer.SongList.Count);
        }
        [Test]
        public void Test_Stage_AddSongToPerformer_Method_With_No_ExistingSong()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            string name = string.Format("Gosho" + " " + "Tsvetanov");
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("Lovely", name);
            });
        }
        [Test]
        public void Test_Stage_AddSongToPerformer_Method_With_No_ExistingPerformer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer("Despasito", "Petur");
            });
        }
        [Test]
        public void Test_Stage_PlayMethod()
        {
            int expectedCountPerformers = 1;
            int expectedCountSongs = 2;

            stage.AddPerformer(performer);
            stage.AddSong(song);
            stage.AddSong(new Song("Lovely", new TimeSpan(0, 3, 10)));
            string name = string.Format("Gosho" + " " + "Tsvetanov");
            stage.AddSongToPerformer("Despasito", name);
            stage.AddSongToPerformer("Lovely", name);
            string expectedResult = string.Format($"{expectedCountPerformers} performers played {expectedCountSongs} songs");
            Assert.AreEqual(expectedResult, stage.Play());
        }
    }
}
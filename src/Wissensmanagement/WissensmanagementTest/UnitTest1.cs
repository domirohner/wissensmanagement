using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wissensmanagement.Tests
{
    [TestClass]
    public class WissensmanagementTests
    {
        private WissensmanagementApp app;

        [TestInitialize]
        public void Setup()
        {
            app = new WissensmanagementApp();
        }

        [TestMethod]
        public void Test_ProjekteWerdenGespeichert()
        {
            for (int i = 1; i <= 5; i++)
            {
                app.NeuesProjektErstellen($"Projekt {i}");
            }

            var projects = app.GetProjects();
            Assert.AreEqual(5, projects.Count);
        }

        [TestMethod]
        public void Test_TexteWerdenProjektenZugeordnet()
        {
            for (int i = 1; i <= 5; i++)
            {
                app.NeuesProjektErstellen($"Projekt {i}");
                app.NeueInformationHinzufuegen($"Projekt {i}", $"Titel {i}", $"Text {i}", DateTime.Now.ToString("yyyy-MM-dd"), new List<Tag>());
            }

            var projects = app.GetProjects();
            foreach (var project in projects)
            {
                Assert.AreEqual(1, project.getProjectInfo().Count);
            }
        }

        [TestMethod]
        public void Test_BilderURLsWerdenProjektenZugeordnet()
        {
            for (int i = 1; i <= 5; i++)
            {
                app.NeuesProjektErstellen($"Projekt {i}");
                string text = $"Text {i}\nBild: https://image{i}.com\nDokument: ";
                app.NeueInformationHinzufuegen($"Projekt {i}", $"Titel {i}", text, DateTime.Now.ToString("yyyy-MM-dd"), new List<Tag>());
            }

            var projects = app.GetProjects();
            foreach (var project in projects)
            {
                Assert.IsTrue(project.getProjectInfo().Any(info => info.getText().Contains("Bild:")));
            }
        }

        [TestMethod]
        public void Test_DokumentURLsWerdenProjektenZugeordnet()
        {
            for (int i = 1; i <= 5; i++)
            {
                app.NeuesProjektErstellen($"Projekt {i}");
                string text = $"Text {i}\nBild: \nDokument: https://document{i}.com";
                app.NeueInformationHinzufuegen($"Projekt {i}", $"Titel {i}", text, DateTime.Now.ToString("yyyy-MM-dd"), new List<Tag>());
            }

            var projects = app.GetProjects();
            foreach (var project in projects)
            {
                Assert.IsTrue(project.getProjectInfo().Any(info => info.getText().Contains("Dokument:")));
            }
        }

        [TestMethod]
        public void Test_TagsWerdenProjektenZugeordnet()
        {
            for (int i = 1; i <= 5; i++)
            {
                app.NeuesProjektErstellen($"Projekt {i}");
                var tags = new List<Tag> { new Tag($"Tag {i}") };
                app.NeueInformationHinzufuegen($"Projekt {i}", $"Titel {i}", $"Text {i}", DateTime.Now.ToString("yyyy-MM-dd"), tags);
            }

            var projects = app.GetProjects();
            foreach (var project in projects)
            {
                Assert.IsTrue(project.getProjectInfo().Any(info => info.tags.Count > 0));
            }
        }

        [TestMethod]
        public void Test_MehrereTagsEinProjekt()
        {
            app.NeuesProjektErstellen("Projekt 1");
            var tags = new List<Tag> { new Tag("Tag A"), new Tag("Tag B"), new Tag("Tag C"), new Tag("Tag D") };
            app.NeueInformationHinzufuegen("Projekt 1", "Titel 1", "Text 1", DateTime.Now.ToString("yyyy-MM-dd"), tags);

            var project = app.GetProjects().FirstOrDefault(p => p.getProjectName() == "Projekt 1");
            Assert.IsNotNull(project);
            Assert.AreEqual(4, project.getProjectInfo().First().tags.Count);
        }

        [TestMethod]
        public void Test_InformationenWerdenGespeichert()
        {
            for (int i = 1; i <= 5; i++)
            {
                app.NeuesProjektErstellen($"Projekt {i}");
                app.NeueInformationHinzufuegen($"Projekt {i}", $"Titel {i}", $"Text {i}", DateTime.Now.ToString("yyyy-MM-dd"), new List<Tag>());
            }

            var projects = app.GetProjects();
            foreach (var project in projects)
            {
                Assert.AreEqual(1, project.getProjectInfo().Count);
            }
        }

        [TestMethod]
        public void Test_SucheNachTags()
        {
            app.NeuesProjektErstellen("Projekt 1");
            var tags = new List<Tag> { new Tag("Tag A"), new Tag("Tag B"), new Tag("Tag C"), new Tag("Tag D"), new Tag("Tag E") };
            app.NeueInformationHinzufuegen("Projekt 1", "Titel 1", "Text 1", DateTime.Now.ToString("yyyy-MM-dd"), tags);

            var project = app.GetProjects().FirstOrDefault(p => p.getProjectName() == "Projekt 1");
            Assert.IsNotNull(project);

            foreach (var tag in tags)
            {
                Assert.IsTrue(project.getProjectInfo().Any(info => info.tags.Any(t => t.tag_Name == tag.tag_Name)));
            }
        }
    }
}

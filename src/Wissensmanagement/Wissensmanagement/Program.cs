using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wissensmanagement
{
    [Serializable]
    public class Tag
    {
        // Attributes
        public string tag_Name;

        // Constructor
        public Tag(string tag_Name)
        {
            this.tag_Name = tag_Name;
        }
    }

    [Serializable]
    public class Info
    {
        // Attributes
        public string title;
        public string text;
        public string date;
        public List<Tag> tags;

        // Constructor
        public Info(string title, string text, string date, List<Tag> tags)
        {
            this.title = title;
            this.text = text;
            this.date = date;
            this.tags = tags;
        }

        // Method
        public void addTag(Tag tag)
        {
            tags.Add(tag);
        }

        public void removeTag(Tag tag)
        {
            tags.Remove(tag);
        }

        public string getText()
        {
            return text;
        }

        public string getTitle()
        {
            return title;
        }
    }

    [Serializable]
    public class Project
    {
        // Attributes
        public string project_Name;
        public List<Info> project_Info = new List<Info>();
        public List<Tag> project_Tags = new List<Tag>();

        // Constructor
        public Project(string project_Name)
        {
            this.project_Name = project_Name;
        }

        // Method
        public string getProjectName()
        {
            return project_Name;
        }

        public List<Info> getProjectInfo()
        {
            return project_Info;
        }

        public List<Tag> getProjectTags()
        {
            return project_Tags;
        }

        public void addInfo(Info info)
        {
            project_Info.Add(info);
        }

        public void removeInfo(Info info)
        {
            project_Info.Remove(info);
        }

        public void addTag(Tag tag)
        {
            project_Tags.Add(tag);
        }

        public void removeTag(Tag tag)
        {
            project_Tags.Remove(tag);
        }
    }

    public class WissensmanagementApp
    {
        private List<Project> projects = new List<Project>();
        private const string SpeicherDatei = "C:\\Temp\\projects.dat";

        public void NeuesProjektErstellen(string projektName)
        {
            var projekt = new Project(projektName);
            projects.Add(projekt);
            Speichern();
            MessageBox.Show("Projekt erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Project> GetProjects()
        {
            return projects;
        }

        public void NeueInformationHinzufuegen(string projektName, string title, string text, string date, List<Tag> tags)
        {
            var projekt = projects.FirstOrDefault(p => p.project_Name == projektName);
            if (projekt == null)
            {
                MessageBox.Show("Projekt nicht gefunden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var info = new Info(title, text, date, tags);
            projekt.addInfo(info);
            Speichern();
            MessageBox.Show("Information erfolgreich hinzugefügt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void InformationenSuchen()
        {
            Console.Write("Tag eingeben: ");
            string tag = Console.ReadLine();

            var ergebnisse = projects
                .SelectMany(p => p.getProjectInfo(), (projekt, info) => new { projektName = projekt.getProjectName(), Info = info })
                .Where(p => p.Info.tags.Any(t => t.tag_Name.Equals(tag, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (ergebnisse.Any())
            {
                foreach (var ergebnis in ergebnisse)
                {
                    Console.WriteLine($"Projekt: {ergebnis.projektName}, Titel: {ergebnis.Info.getTitle()}, Inhalt: {ergebnis.Info.getText()}");
                }
            }
            else
            {
                Console.WriteLine("Keine Informationen gefunden.");
            }
        }

        public void Speichern()
        {
            using (var stream = new FileStream(SpeicherDatei, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, projects);
            }
        }

        public void Laden()
        {
            if (File.Exists(SpeicherDatei))
            {
                using (var stream = new FileStream(SpeicherDatei, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    projects = (List<Project>)formatter.Deserialize(stream);
                }
            }
        }

        public static void Main(string[] args)
        {
            var app = new WissensmanagementApp();
            app.Laden();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1(app));
        }
    }

    public partial class Form1 : Form
    {
        private WissensmanagementApp app;

        public Form1(WissensmanagementApp app)
        {
            InitializeComponent();
            this.app = app;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateComboBox();
        }

        private void create_project_Click(object sender, EventArgs e)
        {
            string projektname = projektname_tb.Text;

            if (string.IsNullOrWhiteSpace(projektname))
            {
                MessageBox.Show("Projektname darf nicht leer sein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            app.NeuesProjektErstellen(projektname);
            UpdateComboBox();
        }

        private void information_hinzufuegen_btn_Click(object sender, EventArgs e)
        {
            if (project_cb.SelectedItem == null)
            {
                MessageBox.Show("Bitte ein Projekt auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string projektname = project_cb.SelectedItem.ToString();
            string title = information_text_tb.Text;
            string text = $"Text: {information_text_tb.Text}\nBild: {information_bilder_tb.Text}\nDokument: {information_dokumente_tb.Text}";
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            List<Tag> tags = informationen_tags_tb.Text.Split(',').Select(t => new Tag(t.Trim())).ToList();
            app.NeueInformationHinzufuegen(projektname, title, text, date, tags);
        }

        private void suchen_btn_Click(object sender, EventArgs e)
        {
            // Lade die gespeicherten Projekte aus der Datei
            app.Laden();

            // Überprüfe, ob ein Projekt ausgewählt wurde
            if (suche_project_cb.SelectedItem == null)
            {
                MessageBox.Show("Bitte ein Projekt auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hole den ausgewählten Projektnamen
            string projektname = suche_project_cb.SelectedItem.ToString();

            // Suche das Projekt anhand des Namens
            var projekt = app.GetProjects().FirstOrDefault(p => p.getProjectName() == projektname);

            // Wenn das Projekt nicht gefunden wurde
            if (projekt == null)
            {
                MessageBox.Show("Projekt nicht gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lese das Tag aus der Textbox (wenn vorhanden)
            string gesuchtesTag = suche_tags_tb.Text.Trim();

            // Initialisiere einen StringBuilder, um die Informationen zu sammeln
            StringBuilder projektInformationen = new StringBuilder();

            // Füge Informationen des Projekts hinzu
            projektInformationen.AppendLine($"Projekt: {projekt.getProjectName()}");
            projektInformationen.AppendLine("Informationen:");

            // Filtere die Informationen basierend auf dem eingegebenen Tag
            var gefilterteInfos = string.IsNullOrWhiteSpace(gesuchtesTag)
                ? projekt.getProjectInfo() // Falls kein Tag angegeben ist, zeige alle Informationen an
                : projekt.getProjectInfo().Where(info => info.tags.Any(t => t.tag_Name.Equals(gesuchtesTag, StringComparison.OrdinalIgnoreCase))).ToList(); // Nur Infos mit dem passenden Tag anzeigen

            if (!gefilterteInfos.Any())
            {
                projektInformationen.AppendLine("Keine passenden Informationen gefunden.");
            }
            else
            {
                foreach (var info in gefilterteInfos)
                {
                    projektInformationen.AppendLine($"Titel: {info.getTitle()}");
                    projektInformationen.AppendLine($"Datum: {info.date}");

                    // Reguläre Ausdrücke zum Extrahieren von Text, Bild und Dokument
                    string text = info.getText();

                    // Regex zum Extrahieren der Teile: Bild und Dokument
                    string bild = Regex.Match(text, @"Bild: ([^\n]*)").Groups[1].Value;
                    string dokument = Regex.Match(text, @"Dokument: ([^\n]*)").Groups[1].Value;

                    // Nun den Text ohne "Bild:" und "Dokument:" extrahieren
                    string reinerText = text.Split(new string[] { "Bild: ", "Dokument: " }, StringSplitOptions.None)[0];

                    // Jetzt alles in den StringBuilder einfügen
                    projektInformationen.AppendLine($"{reinerText}");
                    projektInformationen.AppendLine($"Bild: {bild}");
                    projektInformationen.AppendLine($"Dokument: {dokument}");

                    projektInformationen.AppendLine("Tags:");
                    foreach (var tag in info.tags)
                    {
                        projektInformationen.AppendLine($"- {tag.tag_Name}");
                    }
                    projektInformationen.AppendLine();  // Zeilenumbruch für jede Info
                }
            }

            // Zeige die gesammelten Informationen in der TextBox an
            suche_projektinformation_tb.Text = projektInformationen.ToString();
        }


        private void UpdateComboBox()
        {
            project_cb.Items.Clear();
            var projects = app.GetProjects();
            foreach (var project in projects)
            {
                project_cb.Items.Add(project.getProjectName());
                suche_project_cb.Items.Add(project.getProjectName());
            }
        }
    }
}

